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
    [SerializeField] private Item2 ItemCollect;


    private void Awake()
    {
        Control = new PlayerInputControl();
        AttackAction = Controller.actions[Control.Player.Attack.name];
        if( ItemCollect == null )
        {
            TryGetComponent(out ItemCollect);
        }
    }

    private void OnEnable()
    {
        AttackAction.performed += attackCode;
        if (ItemCollect != null)
        {
            ItemCollect.AddAttackIndex += AttackUpdate;
        }
        
    }

    private void OnDisable()
    {
        if (ItemCollect != null)
        {
            ItemCollect.AddAttackIndex -= AttackUpdate;
        }
    }

    void AttackUpdate(bool input)
    {
        CanAttack = input;
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
}

