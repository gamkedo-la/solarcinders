using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputManagerTest : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (CustomInputManager.GetButtonDown("Fire1"))
            Debug.Log("Fire1");
    }
}
