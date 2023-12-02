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
        if (PlayerHPPoint == null)
        {
            TryGetComponent(out PlayerHPPoint);
        }
    }
    private void Update()
    {

        float fillvalue = PlayerHPPoint.PlayerCurrentHP / Hploader.hp;
        Slider.value = fillvalue;
    }
}
