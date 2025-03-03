using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }
    private PlayerInput playerInput;

    public event EventHandler OnMoveUp;
    public event EventHandler OnMoveDown;
    public event EventHandler OnMoveLeft;
    public event EventHandler OnMoveRight;
    

    

    private void Awake()
    {
        Instance = this;

        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.MoveUp.performed += MoveUpOnPerformed;  
        playerInput.Player.MoveDown.performed += MoveDownOnPerformed;
        playerInput.Player.MoveLeft.performed += MoveLeftOnPerformed;
        playerInput.Player.MoveRigth.performed += MoveRigthOnPerformed;   
    }

    private void MoveRigthOnPerformed(InputAction.CallbackContext obj)
    {
        OnMoveRight?.Invoke(this, EventArgs.Empty);
    }

    private void MoveLeftOnPerformed(InputAction.CallbackContext obj)
    {
        OnMoveLeft?.Invoke(this, EventArgs.Empty);
    }

    private void MoveDownOnPerformed(InputAction.CallbackContext obj)
    {
        OnMoveDown?.Invoke(this, EventArgs.Empty);
    }

    private void MoveUpOnPerformed(InputAction.CallbackContext obj)
    {
        OnMoveUp?.Invoke(this, EventArgs.Empty);
    }
}
