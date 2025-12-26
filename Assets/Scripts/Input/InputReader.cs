using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputPlayer;

[CreateAssetMenu(menuName = "Input/InputReader")]
public class InputReader : ScriptableObject, IMovementInputActions
{
    public Vector2 MoveDirection { get; private set; }
    public Vector2 MousePosition => Mouse.current.position.ReadValue();
    private InputPlayer _gameInput;
    public bool IsShooting { get; private set; }


    private void OnEnable()
    {
        _gameInput = new InputPlayer();
        _gameInput.MovementInput.SetCallbacks(this);
        _gameInput.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started) IsShooting = true;
        if (context.canceled) IsShooting = false;
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }
}
