using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenucode : MonoBehaviour
{
    [SerializeField] private string _menuScene = "Mainmenu";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            Savesystem.Instance.SaveGameToCurrentSlot(Sceneloader.Instance.GetCurrentActiveSceneName(), () =>
            {
                Sceneloader.Instance.LoadMenu(_menuScene);
            });
        }
    }
}
