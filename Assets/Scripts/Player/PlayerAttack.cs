using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private PlayerInput Controller;
    private PlayerInputControl Control;

    private InputAction AttackAction;
    [SerializeField] private bool CanAttack = false;
    [SerializeField] private bool Attacking = false;

    public bool isAttack => Attacking;

    public delegate void attackEvent();
    public event attackEvent OnAttack = delegate { };

    private void Awake()
    {
        Control = new PlayerInputControl();
        AttackAction = Controller.actions[Control.Player.Attack.name];
    }

    private void OnEnable()
    {
        AttackAction.performed += attackCode;
        
    }

    private void OnDisable()
    {
        AttackAction.performed -= attackCode;
    }

    private void Attack()
    {
        Attacking = true;
        OnAttack?.Invoke();
    }

    public void attackCode(InputAction.CallbackContext context)
    {
        if(CanAttack == true)
        {
            Attack();
            Debug.Log("Attack");
        }
    }

    public void EnableAttack()
    {
        CanAttack = true;
    }
}

