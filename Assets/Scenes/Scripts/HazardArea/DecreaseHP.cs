using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class DecreasedHP : MonoBehaviour
{
    private Collider2D _hitBox;
    [SerializeField]private float _damage = 20;
    public float Damage => _damage;
    void Update()
    {
        
    }

   
}
