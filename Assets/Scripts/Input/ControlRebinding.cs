using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlRebinding : MonoBehaviour
{
    public InputActionReference actionReference;
    public InputActionAsset playerInputActions;
    public TextMeshProUGUI bindingText;
    public int bindingsIndex = 0;

    private InputActionMap playerActionMap;

    public GameObject DuplicateBindingWarningPanel;

    public delegate void UnbindAction();
    public static event UnbindAction OnUnbind;

    private void OnEnable()
    {
        ResetBindings.OnReset += SetBindingText;
        ControlRebinding.OnUnbind += SetBindingText;
    }

    private void OnDisable()
    {
        ResetBindings.OnReset -= SetBindingText;
        ControlRebinding.OnUnbind -= SetBindingText;
    }

    private void Start()
    {
        playerActionMap = playerInputActions.FindActionMap("Player");
        SetBindingText();
    }

    public void PerformRebinding()
    {
        playerActionMap.Disable();
        RemapButtonClicked(actionReference);
    }

    private void RemapButtonClicked(InputAction actionToRebind)
    {
        var rebindOperation = actionToRebind.PerformInteractiveRebinding(bindingsIndex)
                    // To avoid accidental input from mouse motion
                    //.WithControlsExcluding("Mouse")            
                    .OnMatchWaitForAnother(0.1f)
                    .Start();

        // Dispose the operation on completion.
        rebindOperation.OnComplete(
           operation =>
           {
               Debug.Log($"Rebound '{actionToRebind}' to '{operation.selectedControl}'");
               operation.Dispose();
               UnbindDuplicates();
               SetBindingText();
               playerActionMap.Enable();
           });
    }

    private void UnbindDuplicates()
    {
        foreach (InputActionMap inputActionMap in playerInputActions.actionMaps)
        {
            foreach (var action in inputActionMap.actions)
            {
                //Debug.Log(action.name + actionReference.action.name);
                if (action.name != actionReference.action.name)
                {
                    for (int i = 0; i < action.bindings.Count; i++)
                    {
                            if (action.bindings[i].effectivePath == actionReference.action.bindings[bindingsIndex].effectivePath)
                            {
                                Debug.Log("Duplicate Detected In Other Input Map " + action.bindings[i].effectivePath);
                                DuplicateBindingWarningPanel.SetActive(true);
                            }
                    }
                }
            }
        }

        Debug.Log(actionReference.action.bindings[bindingsIndex].effectivePath);
        for (int i = 0; i < actionReference.action.bindings.Count; i++)
        {
            if (i != bindingsIndex)
            {
                if (actionReference.action.bindings[i].effectivePath == actionReference.action.bindings[bindingsIndex].effectivePath)
                {
                    Debug.Log("Duplicate Detected " + actionReference.action.bindings[i].effectivePath);
                    actionReference.action.RemoveBindingOverride(i);
                    actionReference.action.RemoveBindingOverride(bindingsIndex);
                    if (OnUnbind != null)
                    {
                        OnUnbind();
                    }
                }
            }
        }
    }

    private void SetBindingText()
    {
        bindingText.text = InputControlPath.ToHumanReadableString(actionReference.action.bindings[bindingsIndex].effectivePath);
    }

    private void ResetToDefaultBinding()
    {
        actionReference.action.RemoveBindingOverride(bindingsIndex);
        SetBindingText();
    }
}
