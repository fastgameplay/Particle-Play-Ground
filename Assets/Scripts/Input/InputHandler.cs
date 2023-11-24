using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private SO_EventVector2 _onMovement; 
    [SerializeField] private InputActionReference _currentActionMap;

    private void MovementPerformed(InputAction.CallbackContext context){
        _onMovement.Event?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void MovementCanceled(InputAction.CallbackContext context){
        _onMovement.Event?.Invoke(Vector2.zero);
    }
    
    private void OnEnable(){
        _currentActionMap.action.Enable();
        _currentActionMap.action.performed += MovementPerformed;
        _currentActionMap.action.canceled += MovementCanceled;
    }

    private void OnDisable(){
        _currentActionMap.action.performed += MovementPerformed;
        _currentActionMap.action.canceled += MovementCanceled;
        _currentActionMap.action.Disable();
    }
}
