using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SaveGameData
{
    private Dictionary<string,SaveRecord> _dict = new Dictionary<string,SaveRecord>();

    [SerializeField] private List<SaveRecord> _records = new List<SaveRecord>();

    public string SceneName;

    public void HanndlebeforSerialize()
    {
        UpdatelistfromDic();
    }
    public void HanndleafterSerialize()
    {
        UpdateDicfromList();
        foreach (var record in _records)
        {
            record.SetPersistance(true);
        }
    }
    private void UpdatelistfromDic()
    {
        _records.Clear();
        foreach (var kvp in _dict)
        {
            _records.Add(kvp.Value);
        }
    }

    private void UpdateDicfromList()
    {
        _dict = new Dictionary<string, SaveRecord>();
        foreach(SaveRecord record in _records)
        {
            if (record == null) continue;
            _dict[record.Key] = record;
        }
    }

    public string GetData(string key)
    {
        return _dict.ContainsKey(key) ? _dict[key].Data : null;
    }

    public void SetData(SaveRecord saveRecord)
    {
        if(saveRecord == null) return;
        if (string.IsNullOrWhiteSpace(saveRecord.Data)) return;

        _dict[saveRecord.Key] = saveRecord;
    }

    public SaveGameData GetPersistanceData()
    {
        SaveGameData persistance = new SaveGameData();
        persistance.SceneName = SceneName;
        persistance._dict = _dict.Where(element => element.Value.IsPersistance)
            .ToDictionary(element => element.Key, element => element.Value);
        return persistance;
    }
}
