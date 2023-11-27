using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationExit : MonoBehaviour
{
    [SerializeField] private string _nextLocation;
    [SerializeField] private string _markerName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement pc))
        {
            SpawnSystem.Instance.SpawnMarker = _markerName;
            Sceneloader.Instance.Loadlocation(_nextLocation);
        }
    }
}
