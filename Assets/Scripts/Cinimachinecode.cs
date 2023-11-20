using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinimachinecode : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Cam;
    [SerializeField] private Transform Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            var PlayerObject = GameObject.FindGameObjectWithTag("Player");
            if (PlayerObject != null)
            {
                Player = PlayerObject.transform;
            }
            else
            {
                return;
            }
        }

        Cam.Follow = Player.transform;
    }
}
