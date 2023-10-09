using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator Animation;
    [SerializeField] PlayerMovement PlayerMove;
    [SerializeField] PlayerAttack PlayerAttack;

    private void OnEnable()
    {
        PlayerAttack.OnAttack += HandleAttack;
    }

    private void OnDisable()
    {
        PlayerAttack.OnAttack -= HandleAttack;
    }

    void Start()
    {

    }

    void Update()
    {
        Animation.SetBool("isRun", PlayerMove.movePos.x != 0);
        Animation.SetBool("jump", PlayerMove.isJump);
        Animation.SetBool("onGround", PlayerMove.onGround);
    }

    void HandleAttack()
    {
        Animation.SetTrigger("attack");
    }
}
