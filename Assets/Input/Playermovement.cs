using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
    private PlayerInput controller;

    private Playerinputcontrol control;
    private InputAction Moveaction;
    private InputAction Jumpaction;
    private InputAction Attackaction;
    Vector2 movepos;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10;
    [SerializeField] private float Jumppower = 20;
    [SerializeField] private int Jumpindex = 2;


    void Awake()
    {
        control = new Playerinputcontrol();
        TryGetComponent(out controller);
        TryGetComponent(out rb);
        Attackaction = controller.actions[control.Player.Attack.name];
        Jumpaction = controller.actions[control.Player.Jump.name];
        Moveaction = controller.actions[control.Player.Move.name];
        
    }

    private void OnEnable()
    {
        Jumpaction.performed += Jumpcode;
        Attackaction.performed += Attackcode;
    }

    private void OnDisable()
    {
        Jumpaction.performed -= Jumpcode;
        Attackaction.performed -= Attackcode;
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        movepos = Moveaction.ReadValue<Vector2>();
        rb.velocity = new Vector2(movepos.x * speed, rb.velocity.y);
    }
    void Jumpcode(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(rb.velocity.x, Jumppower);
    }

    void Attackcode(InputAction.CallbackContext context)
    {
        print("Attack");
    }
}
