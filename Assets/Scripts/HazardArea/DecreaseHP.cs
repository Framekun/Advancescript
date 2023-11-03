using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasedHP : MonoBehaviour
{
    private Collider2D _hitBox;
    private float _damage = 20;
    void Update()
    {
        Debug.Log("Hp -20");
    }
}
