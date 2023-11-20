using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinimachinecode : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Cam;
    [SerializeField] private GameObject Target;
    void Start()
    {
        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cam.Follow = Target.transform;
    }
}
