using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private PlayerInput Controller;
    private PlayerInputControl Control;

    private InputAction AttackAction;

    [SerializeField] private bool Attacking = false;

    private Collider2D PlayerHitBox;

    private GameObject ObjectToHit;
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
        Attack();
    }
    
    private void Update()
    {
        PlayerHitBox = ObjectToHit.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit");
    }
}

