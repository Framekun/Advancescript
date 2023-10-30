using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float PlayerCurrentHP;
    [SerializeField] private HPScript Hploader;
    void Start()
    {
        PlayerCurrentHP = Hploader.hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerCurrentHP--;
            Debug.Log("Player HP: " + PlayerCurrentHP);
        }
        
    }

    void Update()
    {
        if (PlayerCurrentHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
