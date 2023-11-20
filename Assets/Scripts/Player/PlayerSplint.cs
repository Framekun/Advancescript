using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSplint : MonoBehaviour
{
    [SerializeField] private PlayerInput Controller;
    private PlayerInputControl Control;
    private InputAction SplintAction;
    [SerializeField] private bool CanSplint = false;
    [SerializeField] private float ReadSpeedValue;
    [SerializeField] private float SplintSpeed;
    [SerializeField] private PlayerMovement PlayerMove;
    public delegate void splintSpeedValue(float _value);
    public splintSpeedValue SplintSpeedValue;
    [SerializeField] private Item3 ItemCollect;

    void Awake()
    {
        if (ItemCollect == null)
        {
            TryGetComponent(out ItemCollect);
        }
        Control = new PlayerInputControl();
        TryGetComponent(out Controller);
        SplintAction = Controller.actions[Control.Player.Splint.name];
    }
    private void OnEnable()
    {
        if (ItemCollect != null)
        {
            ItemCollect.AddSpintIndex += UpdateSplint;
        }
    }

    void UpdateSplint(bool input)
    {
        CanSplint = input;
    }
    private void Update()
    {
        ReadSpeedValue = SplintAction.ReadValue<float>();
        if(ReadSpeedValue != 0 && CanSplint == true)
        {
            SplintSpeedValue.Invoke(SplintSpeed);
        }
        else
        {
            SplintSpeedValue.Invoke(PlayerMove.speed);
        }
    }
}
