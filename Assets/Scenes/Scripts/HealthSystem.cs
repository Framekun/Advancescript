using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] private float MaxHealth;
    private float CurrentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        CurrentHealth = MaxHealth;

        healthBar.SetSliderMax(MaxHealth);

    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        healthBar.SetSliderMax(CurrentHealth);  
    }

    private void Update()
    {
        
    }
}
