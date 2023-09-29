using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator Animation;
    [SerializeField] PlayerMovement PlayerMove;
    void Start()
    {
        
    }

    void Update()
    {
        Animation.SetBool("isRun", PlayerMove.movePos.x != 0);
        Animation.SetBool("jump", PlayerMove.isJump);
        Animation.SetBool("onGround", PlayerMove.onGround);   
    }
}
