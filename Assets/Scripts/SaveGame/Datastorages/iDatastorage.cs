using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDatastorage
{
    IEnumerator StorageData(string filename,string data);
    string GetData(string filename); //Load info
    bool Hasdata(string filename); //Check has File or not
}
