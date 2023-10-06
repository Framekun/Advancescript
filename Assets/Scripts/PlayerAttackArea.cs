using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    private Collider2D PlayerHitBox;

    [SerializeField] private GameObject ObjectToHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHitBox = ObjectToHit.GetComponent<Collider2D>();

        if (PlayerHitBox.enabled)
        {
            Debug.Log("Hit");
        }
    }
}
