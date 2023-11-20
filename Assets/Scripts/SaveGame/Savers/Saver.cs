using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Saver : MonoBehaviour
{
    [SerializeField] private bool _ispersistance = true;
    public bool ispersistance => _ispersistance;
    [SerializeField] private string _key;
    public string key => _key;

    private bool _applied;

    private void OnEnable()
    {
        if(Savesystem.Instance != null)
        {
            Savesystem.Instance.RegsisterSaver(this);
        }
    }

    private void OnDisable()
    {
        if (Savesystem.Instance != null)
        {
            Savesystem.Instance.UnregsisterSaver(this);
        }
    }

    public SaveRecord BuildSaveRecord()
    {
        return new SaveRecord(_key, BuildRecordDataasJson(), _ispersistance);
    }

    protected abstract string BuildRecordDataasJson();
    public virtual void TryapplyData(string data)
    {
        if (!_applied && !string.IsNullOrWhiteSpace(data))
        {
            ApplyDataFromJson(data);
        }
    }
    protected abstract void ApplyDataFromJson(string data);
}

public abstract class Saver<TSaveData,TSavable> : Saver where TSaveData: class where TSavable : ISavable<TSaveData>
{
    [SerializeField] private TSavable _savable;
    protected override void ApplyDataFromJson(string s)
    {
        Applydata(JsonUtility.FromJson<TSaveData>(s));
    }
    protected virtual void Applydata(TSaveData loaddata)
    {
        _savable.ApplySavedata(loaddata);
    }

    protected override string BuildRecordDataasJson()
    {
        TSaveData saveData = BuilRecordData();
        if(saveData == null) return null; 
        return JsonUtility.ToJson(saveData);
    }

    protected virtual TSaveData BuilRecordData()
    {
        return _savable.getdata();
    }
}
