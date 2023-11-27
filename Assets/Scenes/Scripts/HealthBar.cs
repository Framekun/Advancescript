using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HPScript Hploader;
    public PlayerHP PlayerHP;
    public Image FillImage;
    private Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    private void Update()
    {
        float fillvalue = PlayerHP.PlayerCurrentHP / Hploader.hp;
        Slider.value = fillvalue;
    }
}
