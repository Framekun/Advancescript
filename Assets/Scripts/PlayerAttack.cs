using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour 
{

    [SerializeField] private PlayerInput Controller;
    private PlayerInputControl Control;

    private InputAction AttackAction;

    private GameObject Object;

    [SerializeField] private bool Attacking = false;

    
    private void Start()
    {
        Object = transform.GetChild(0).gameObject;
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
        //AttackHit.SetActive(Attacking);
        Object.SetActive(Attacking);

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
