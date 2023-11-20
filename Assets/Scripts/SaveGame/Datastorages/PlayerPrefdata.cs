using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefdata : iDatastorage
{
    public string GetData(string filename)
    {
        return PlayerPrefs.GetString(filename);
    }

    public bool Hasdata(string filename)
    {
        return (PlayerPrefs.HasKey(filename));
    }

    public IEnumerator StorageData(string filename, string data)
    {
        PlayerPrefs.SetString(filename, data);
        PlayerPrefs.Save();

        yield break;
    }
}
