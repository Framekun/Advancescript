using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savesystem : Singleton<Savesystem>
{
    private const string SAVE_KEY_BASE = "Saver";
    private List<Saver> _savers = new List<Saver>();
    private SaveGameData _savegameData = new SaveGameData();
    private int _currentSlot;
    private iDatastorage _datastorage;

    protected override void Awake()
    {
        base.Awake();
        _datastorage = new PersistanceDataStorage();
    }

    public void RegsisterSaver(Saver saver) //Component ที่เราอยากเซฟไว้
    {
        if (_savers.Contains(saver)) return;
        if(string.IsNullOrWhiteSpace(saver.key))return; 
        
        _savers.Add(saver);
    }
    public void UnregsisterSaver(Saver saver)
    {
        _savers.Remove(saver);
    }

    //สร้าง Save File
    private string GetSaveKey(int slotNumber)
    {
        return SAVE_KEY_BASE + slotNumber;
    }

    //Check Save file
    public bool HasSaveGameInSlot(int slotNumber)
    {
        return _datastorage.Hasdata(GetSaveKey(slotNumber));
    }
    public void LoadGameFromSlot(int slot,bool Loadscene)
    {
        if(!HasSaveGameInSlot(slot))
        {
            Debug.Log("No save in slot");
            return;
        }
        StartCoroutine(LoadFromlist(slot, Loadscene));
    }

    private IEnumerator LoadFromlist(int slotNumber,bool loadScene)
    {
        _currentSlot = slotNumber;
        string saveGameJson = _datastorage.GetData(GetSaveKey(slotNumber));
        _savegameData = JsonUtility.FromJson<SaveGameData>(saveGameJson);
        _savegameData.HanndleafterSerialize();
        if(loadScene)
        {
            Sceneloader.Instance.Loadlocation(_savegameData.SceneName);
        }
        else
        {
            ApplySaveGameData();
        }

        yield break;
    }

    public void ApplySaveGameData() //เอาข้อมูลในSaveลงเกม
    {
        for (int i = _savers.Count - 1; i >= 0; i--) //-- คือ For loop ย้อนหลัง
        {
            Saver aSaver = _savers[i];
            if(aSaver != null)
            {
                string saverdataString = _savegameData.GetData(aSaver.key);
                aSaver.TryapplyData(saverdataString);
            }
        }
    }

    public void ClearSaveGamedata()
    {
        _savegameData = new SaveGameData();
    }

    public void RecordSaveGameData(string sceneName)
    {
        if(!string.IsNullOrEmpty(sceneName))
        {
            _savegameData.SceneName = sceneName;
        }
        foreach(Saver aSaver in _savers)
        {
            _savegameData.SetData(aSaver.BuildSaveRecord());
        }
    }

    public void SaveGameToCurrentSlot(string sceneName, System.Action saveCallback)
    {
        SaveGameToSlot(_currentSlot,sceneName,saveCallback);
    }

    public void SaveGameToSlot(int slotNumber,string sceneName,System.Action saveCallback) //saveCallback เพื่อรอโหลด
    {
        StartCoroutine(SaveToSlotCoroutine(slotNumber, sceneName, saveCallback));
    }

    private IEnumerator SaveToSlotCoroutine(int slotNumber, string sceneName, System.Action saveCallback)
    {
        RecordSaveGameData(sceneName);

        SaveGameData persistance = _savegameData.GetPersistanceData();
        persistance.HanndlebeforSerialize();

        string saveGameJson = JsonUtility.ToJson(persistance);

        yield return _datastorage.StorageData(GetSaveKey(slotNumber),saveGameJson);

        saveCallback?.Invoke();
    }
}
