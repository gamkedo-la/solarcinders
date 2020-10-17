using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputManager : MonoBehaviour
{
    static Dictionary<string, string> buttonKeys;

    private void Start()
    {
        buttonKeys = new Dictionary<string, string>();

        // Default controls - Keyboard
        // MovementH: Horizontal - Left, Right, A, D
        // MovementV: Vertical - Down, Up, S, W
        // Shoot: Fire1 - Left Click, Z. mouse 0
        // Powerup: Fire2 - Right Click, X, mouse 1
        // Barrel Roll: Fire3 - C, mouse 2
        // Pause: Escape

        // Default Controls - Controller
        // MovementH: Horizontal - Joystick Axis - X axis
        // MovementV: Vertical - Joystick Axis - Y axis
        // Shoot: Fire1 - joystick button 0
        // Powerup: Fire2 - joystick button 1
        // Barrel Roll: Fire3 - joystick button 2

        buttonKeys["Fire1"] = "Fire1";
    }

    public static bool GetButtonDown(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            //Debug.LogError("CustomInputManager::GetButtonDown " + buttonName + " does not exist in buttonKeys dictionary");
            return false;
        }

        return Input.GetButtonDown(buttonKeys[buttonName]);
    }
}
