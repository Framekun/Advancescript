using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour 
{

    [SerializeField] private PlayerInput Controller;

    private PlayerInputControl Control;

    private InputAction AttackAction;

    private GameObject AttackHit;
    private bool Attacking = false;

    [SerializeField] Animator AttackAnim;

    private void Start()
    {
        AttackHit = transform.GetChild(0).gameObject;
    }

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
        AttackHit.SetActive(Attacking);

    }

    public void attackCode(InputAction.CallbackContext context)
        {
        Debug.Log("Attack");

        if(AttackAction != null)
            {
            Attack();
            }
        }

    /*
    private void Update(Animator SetTrigger)
    {
        Animation.SetTrigger("attack", PlayerAttack.attackCode);
    }
    */
}
