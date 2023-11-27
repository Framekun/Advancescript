using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public float PlayerCurrentHP;
    [SerializeField] private HPScript Hploader;
    [SerializeField] private string EnemyName;
    [SerializeField] private PlayerDiedSystem Dead;

    private float GetDamage;
    void Start()
    {
        PlayerCurrentHP = Hploader.hp;
    }

    void Update()
    {
        if (PlayerCurrentHP <= 0)
        {
            Dead.Deadload();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(EnemyName))
        {
            DecreasedHP decreasedHP = collision.gameObject.GetComponent<DecreasedHP>();
            GetDamage = decreasedHP.Damage;
            PlayerCurrentHP -= GetDamage;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(EnemyName))
        {
            DecreasedHP decreasedHP = collision.gameObject.GetComponent<DecreasedHP>();
            GetDamage = decreasedHP.Damage;
            PlayerCurrentHP -= GetDamage;
        }
    }
}
