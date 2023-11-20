using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralManager : Singleton<CentralManager>
{
   public Sceneloader sceneloader {  get; private set; }
   public SpawnSystem spawnsystem { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        sceneloader = GetComponent<Sceneloader>();
        spawnsystem = GetComponent<SpawnSystem>();
    }
}
