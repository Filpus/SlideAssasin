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

    public event EventHandler OnReset;
    public event EventHandler OnPause;
    public event EventHandler OnSkipDialog;


    private void Awake()
    {
        Instance = this;

        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.MoveUp.performed += MoveUpOnPerformed;  
        playerInput.Player.MoveDown.performed += MoveDownOnPerformed;
        playerInput.Player.MoveLeft.performed += MoveLeftOnPerformed;
        playerInput.Player.MoveRigth.performed += MoveRigthOnPerformed;
        playerInput.Player.ResetLevel.performed += ResetLevelOnperformed;
        playerInput.Player.ExitMenu.performed += ExitMenuOnperformed;
        playerInput.Player.SkipDialog.performed += SkipDialogOnperformed;
    }

    private void ExitMenuOnperformed(InputAction.CallbackContext obj)
    {
        OnPause?.Invoke(this,EventArgs.Empty);
    }

    private void ResetLevelOnperformed(InputAction.CallbackContext obj)
    {
        OnReset?.Invoke(this, EventArgs.Empty);
    }

    private void MoveRigthOnPerformed(InputAction.CallbackContext obj)
    {
        if (Player.Instance != null)
        {
            OnMoveRight?.Invoke(this, EventArgs.Empty);
        }
    }

    private void MoveLeftOnPerformed(InputAction.CallbackContext obj)
    {
        if (Player.Instance != null)
        {
            OnMoveLeft?.Invoke(this, EventArgs.Empty);
        }
    }

    private void MoveDownOnPerformed(InputAction.CallbackContext obj)
    {
        if (Player.Instance != null)
        {
            OnMoveDown?.Invoke(this, EventArgs.Empty);
        }
    }

    private void MoveUpOnPerformed(InputAction.CallbackContext obj)
    {
        if (Player.Instance != null)
        {
            OnMoveUp?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SkipDialogOnperformed(InputAction.CallbackContext obj)
    {
        OnSkipDialog?.Invoke(this, EventArgs.Empty);
    }
}
