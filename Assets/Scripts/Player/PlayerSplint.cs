using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSplint : MonoBehaviour
{
    [SerializeField] private PlayerInput Controller;
    private PlayerInputControl Control;
    private InputAction SplintAction;
   
    [SerializeField] private float ReadSpeedValue;
    [SerializeField] private float SplintSpeed;
    [SerializeField] private PlayerMovement PlayerMove;
    public delegate void splintSpeedValue(float _value);
    public splintSpeedValue SplintSpeedValue;

    void Awake()
    {
        Control = new PlayerInputControl();
        TryGetComponent(out Controller);
        SplintAction = Controller.actions[Control.Player.Splint.name];
    }
    private void Update()
    {
        ReadSpeedValue = SplintAction.ReadValue<float>();
        if(ReadSpeedValue != 0)
        {
            SplintSpeedValue.Invoke(SplintSpeed);
        }
        else
        {
            SplintSpeedValue.Invoke(PlayerMove.speed);
        }
    }
}
