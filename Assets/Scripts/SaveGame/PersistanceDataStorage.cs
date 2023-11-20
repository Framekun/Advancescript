using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistanceDataStorage : iDatastorage
{

    private const string SAVE_FOLDER_PATH = "Savefile";

    private string BuildFolder()
    {
        return Path.Combine(Application.persistentDataPath, SAVE_FOLDER_PATH);
    }

    private string BuildFile(string filename)
    {
        return Path.Combine(BuildFolder(),$"{filename}.Inu");
    }


    public string GetData(string filename)
    {
        string result = string.Empty;
        using(StreamReader reader = new StreamReader(BuildFile(filename)))
        {
            result = reader.ReadToEnd();
        }
        return result;
    }

    public bool Hasdata(string filename)
    {
        return File.Exists(BuildFile(filename));
    }

    public IEnumerator StorageData(string filename, string data)
    {
        string folderpath = BuildFolder();
        string filepath = BuildFile(filename);

        if(!Directory.Exists(folderpath))
        {
            Directory.CreateDirectory(folderpath);
        }

        using(StreamWriter writer = new StreamWriter(filepath)) 
        { 
            writer.Write(data); 
        }

        yield break;
    }
}
