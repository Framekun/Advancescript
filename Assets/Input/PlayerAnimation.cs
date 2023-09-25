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
        if(PlayerMove.movePos.x != 0)
        {
            Animation.SetBool("isRun", true);
        }
        else
        {
            Animation.SetBool("isRun", false);
        }

        if(PlayerMove.isJump == true)
        {
            Animation.SetBool("jump", true);
        }
        else
        {
            Animation.SetBool("jump", false);
        }

        if(PlayerMove.onGround == true)
        {
            Animation.SetBool("onGround", true);
        }
        else
        {
            Animation.SetBool("onGround", false);
        }
    }
}
