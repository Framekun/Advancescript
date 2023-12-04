using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HPScript Hploader;
    [SerializeField] private PlayerHP PlayerHPPoint;
    [SerializeField] private Image FillImage;
    [SerializeField] private Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
       
    }
    private void Update()
    {
        if (PlayerHPPoint == null)
        {
            var PlayerObject = GameObject.FindGameObjectWithTag("Player");
            if (PlayerObject != null)
            {
                PlayerHPPoint = PlayerObject.GetComponent<PlayerHP>();
            }
            else
            {
                return;
            }
        }
        if (Slider.value <= Slider.minValue)
        {
            FillImage.enabled = false;
        }
        if (Slider.value > Slider.minValue && !FillImage.enabled)
        {
            FillImage.enabled = true;
        }

        float fillvalue = PlayerHPPoint.PlayerCurrentHP / Hploader.hp;
        Slider.value = fillvalue;
    }
}
