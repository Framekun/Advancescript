using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;

public class SpawnSystem : Singleton<SpawnSystem>, ISavable<PlayerSpawnSystemSaveData>
{
    [SerializeField] private Playerloadsystem playerPrefab;
    [SerializeField] private bool _spawnOnStart;

    public string SpawnMarker {  get; set; }
    void Start()
    {
        if(_spawnOnStart)
        {
            SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        Vector3 Spawndefault = playerPrefab.transform.position;

        LocationSpawn[] entrance = FindObjectsOfType<LocationSpawn>();
        LocationSpawn entrancetouse = null;
        if(!string.IsNullOrEmpty(SpawnMarker))
        {
            entrancetouse = entrance.SingleOrDefault(x => SpawnMarker.Equals(x.MarkerName));
        }
        else
        {
            entrancetouse = entrance.SingleOrDefault(X => X.IsDefault);
        }

        if( entrancetouse != null )
        {
            Spawndefault = entrancetouse.transform.position;
        }

        Instantiate(playerPrefab,Spawndefault,playerPrefab.transform.rotation);
    }

    public void ApplySavedata(PlayerSpawnSystemSaveData savedata)
    {
        SpawnMarker = savedata.SpawnMarker;
    }

    public PlayerSpawnSystemSaveData getdata()
    {
        PlayerSpawnSystemSaveData data = new PlayerSpawnSystemSaveData();
        data.SpawnMarker = SpawnMarker;
        return data;
    }
}

[System.Serializable]
public class PlayerSpawnSystemSaveData
{
    public string SpawnMarker;
}
