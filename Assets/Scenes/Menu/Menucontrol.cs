using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menucontrol : MonoBehaviour
{
    [SerializeField] private string _firstlocationname = "Deleigate";
    [SerializeField] private GameObject _continuebutton;

    private void Start()
    {
        _continuebutton.SetActive(Savesystem.Instance.HasSaveGameInSlot(0));
    }
    public void Newgame()
    {
        Savesystem.Instance.ClearSaveGamedata(); //·§Ë„πRam
        Sceneloader.Instance.Loadlocation(_firstlocationname);
    }
    public void Continuegame()
    {
        Savesystem.Instance.LoadGameFromSlot(0, true);
    }
}
