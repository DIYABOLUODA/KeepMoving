using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    public bool shoot => playerInputActions.GamePlay.Shoot.IsPressed();
    public bool attack=>playerInputActions.GamePlay.Attack.IsPressed();
    public bool attckTwo=>playerInputActions.GamePlay.AttackTwo.IsPressed();
    Vector2 axes => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();
    public float AxisY => axes.y;
   // public bool Move => AxisY != 0f;



    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

   public void EnableGameplayInputs()
    {
        playerInputActions.GamePlay.Enable();
    }
}
