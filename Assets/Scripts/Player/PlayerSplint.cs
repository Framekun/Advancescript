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
   
    [SerializeField] private float ReadValue;
    [SerializeField] private float SplintSpeed;

    void Awake()
    {
        Control = new PlayerInputControl();
        TryGetComponent(out Controller);
        SplintAction = Controller.actions[Control.Player.Splint.name];
    }
    private void Update()
    {
        ReadValue = SplintAction.ReadValue<float>();
        if(ReadValue != 0)
        {
            
        }
    }
}
