using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float playerHP;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHP--;
            Debug.Log("Player HP: " + playerHP);
        }
        if(playerHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }

    void Update()
    {
        
    }
}
