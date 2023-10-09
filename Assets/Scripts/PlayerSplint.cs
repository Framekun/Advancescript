using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSplint : MonoBehaviour
{
    [SerializeField] private PlayerInput Controller;
    private PlayerInputControl Control;

    private InputAction SplintAction;

    [SerializeField] private bool SplintCheck = false;

    void Awake()
    {
        Control = new PlayerInputControl();
        TryGetComponent(out Controller);

        SplintAction = Controller.actions[Control.Player.Splint.name];
    }
    private void OnEnable()
    {
        SplintAction.performed += Splinting;
    }

    private void OnDisable()
    {
        SplintAction.performed -= Splinting;
    }
   void Splinting(InputAction.CallbackContext context)
    {
        Debug.Log("Split");
    }
}
