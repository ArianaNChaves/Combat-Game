using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public event Action RolEvent;
    
    private Controls _controls;
    private void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        
        _controls.Player.Enable();
    }

    private void OnDestroy()
    {
        _controls.Player.Disable();
    }


    public void OnRol(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RolEvent?.Invoke(); 
        }
        
    }
}
