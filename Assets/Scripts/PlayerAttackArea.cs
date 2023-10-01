using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    private int damage = 3;
    private PlayerAttack Attack;
    [SerializeField] private Animator AttackAnim;
    
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        AttackAnim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Attack != null)
        {
            //AttackAnim.ResetTrigger("attack")

            //Send the message to the Animator to activate the trigger parameter named "Jump"
            AttackAnim.ResetTrigger("attack");
        }
        else AttackAnim.SetTrigger("attack");

        return;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyBehavior>() != null)
            EnemyBehavior Enemy = collider.GetComponent<EnemyBehavior>();
    }
    */
}
