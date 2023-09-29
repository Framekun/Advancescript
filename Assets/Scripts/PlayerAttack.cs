using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour 
{
    private PlayerInput PlayerInput;
    private PlayerInputControl PlayerInputControl;
    private InputAction AttackAction;

    private void Awake()
    {
        TryGetComponent(out PlayerInput);
        AttackAction = PlayerInput.actions[PlayerInputControl.Player.Attack.name];
    }

    private void OnEnable()
    {
        AttackAction.performed += AttackSlash;
    }

    private void OnDisable()
    {
        AttackAction.performed -= AttackSlash;
    }

    void AttackSlash(InputAction.CallbackContext context)
    {
        print("Attack");
    }

    void Update()
    {

    }
}
