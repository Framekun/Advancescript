using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput Controller;

    private PlayerInputControl Control;
    private InputAction MoveAction;
    private InputAction JumpAction;
   
    private Vector2 MovePos;
    public  Vector2 movePos => MovePos;
    private Rigidbody2D Rb;
    [SerializeField] private float Speed = 10;
    [SerializeField] private float CurrentSpeed;
    [SerializeField] private float JumpPower = 20;
    [SerializeField] private int JumpCount = 0;
    [SerializeField] private int JumpIndex = 1;
    [SerializeField] private bool IsJump = false;
    public bool isJump => IsJump;
    [SerializeField] private bool OnGround = true;
    public bool onGround => OnGround;
    public float speed => Speed;
    [SerializeField] private PlayerSplint Splint;
    [SerializeField] private Item ItemCollect;
    void Awake()
    {
        if (ItemCollect == null)
        {
            TryGetComponent(out ItemCollect);
        }
        Control = new PlayerInputControl();
        TryGetComponent(out Controller);
        TryGetComponent(out Rb);
        JumpAction = Controller.actions[Control.Player.Jump.name];
        MoveAction = Controller.actions[Control.Player.Move.name];
    }

    private void OnEnable()
    {
        JumpAction.performed += JumpCode;
        Splint.SplintSpeedValue += SplintMovement;
        if (ItemCollect != null)
        {
            ItemCollect.AddJumpIndex += JumpIndexUpdate;
        }
    }

    private void OnDisable()
    {
        ItemCollect = GetComponent<Item>();
        JumpAction.performed -= JumpCode;
        Splint.SplintSpeedValue -= SplintMovement;
        if (ItemCollect != null)
        {
            ItemCollect.AddJumpIndex -= JumpIndexUpdate;
        }
    }

    void Update()
    {
        Movement();
        if (Rb.velocity.y <= 0)
        {
            IsJump = false;
        }
    }

    void Movement()
    {
        MovePos = MoveAction.ReadValue<Vector2>();
        float horizontalInput = MoveAction.ReadValue<Vector2>().x;
        if (horizontalInput != 0f)
        {
            transform.rotation = Quaternion.LookRotation(horizontalInput * Vector3.forward, Vector3.up);
        }
        Rb.velocity = new Vector2(MovePos.x * CurrentSpeed, Rb.velocity.y);
        
    }

    void SplintMovement(float splintSpeed)
    {
        CurrentSpeed = splintSpeed;
    }

    void JumpCode(InputAction.CallbackContext context)
    {
        if (JumpCount < JumpIndex)
        {
            IsJump = true;
            Rb.velocity = new Vector2(Rb.velocity.x, JumpPower);
            JumpCount++;
        }
    }

    void JumpIndexUpdate(int index)
    {
        JumpIndex += index;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            OnGround = true;
            JumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnGround = false;
        }
    }
}
