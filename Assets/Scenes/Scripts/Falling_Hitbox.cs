using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Hitbox : MonoBehaviour
{
    [SerializeField] private string TagName;
    [SerializeField] private PlayerDiedSystem Dead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == TagName)
        {
            Dead.Deadload();
        }
    }
}
