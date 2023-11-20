using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStageSaver : MonoBehaviour,ISavable<objectStateSaveData>
{
    [SerializeField] private Transform _transform;

    public void ApplySavedata(objectStateSaveData savedata)
    {
        if(savedata.Isdestroyed)
        {
            Destroy(_transform.gameObject);
        }
        _transform.position = savedata.Posiition;
        _transform.rotation = savedata.Rotation;
    }

    public objectStateSaveData getdata()
    {
        objectStateSaveData saveData = new objectStateSaveData();
        if(_transform == null)
        {
            saveData.Isdestroyed = true;
        }
        saveData.Posiition = _transform.position;
        saveData.Rotation = _transform.rotation;

        return saveData;
    }
}

[System.Serializable]
public class objectStateSaveData
{
    public Vector3 Posiition;
    public Quaternion Rotation;
    public bool Isdestroyed;
}
