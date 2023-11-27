using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavable<TSavedata> where TSavedata : class
{
    void ApplySavedata(TSavedata savedata);
    TSavedata getdata();
}
