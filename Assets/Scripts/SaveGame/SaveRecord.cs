using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveRecord
{
    [SerializeField] private string _key;
    public string Key => _key;

    [SerializeField] private string _data;

    public string Data => _data;

    private bool _isPersistance;

    public bool IsPersistance => _isPersistance;

    public SaveRecord(string key, string data, bool isPersistance)
    {
        _key = key;
        _data = data;
        _isPersistance = isPersistance;
    }

    public void SetPersistance(bool isPersistance)
    {
        _isPersistance = isPersistance;
    }

    public void SetData(string data)
    {
        _data = data;
    }
}
