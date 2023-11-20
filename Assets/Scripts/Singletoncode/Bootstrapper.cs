using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    private const string App_Scene_name = "App";
    private const string First_level_Name = "MainMenu";
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
   static void Init()
    {
        string levelToLoad = First_level_Name;
        bool isMenu = true;
#if UNITY_EDITOR
        Scene currentlyLoadscene = SceneManager.GetActiveScene();
        if(currentlyLoadscene.path.Contains("level"))
        {
            levelToLoad = currentlyLoadscene.name;
            isMenu = false;
        }
        else if(currentlyLoadscene.path.Contains("Menus"))
        {
            levelToLoad= currentlyLoadscene.name;
            isMenu = true;
        }
#endif
        if(!SceneManager.GetSceneByName(App_Scene_name).isLoaded)
        {
            AsyncOperation appLoadOp = SceneManager.LoadSceneAsync(App_Scene_name);
            appLoadOp.completed += (op) => { Loadlevel(levelToLoad, isMenu); };
        }
        else
        {
            Loadlevel(levelToLoad,isMenu);
        }
    }

    static void Loadlevel(string levelName, bool isMenu)
    {
        if(isMenu)
        {
            Sceneloader.Instance.LoadMenu(levelName);
        }
        else
        {
            Sceneloader.Instance.Loadlocation(levelName);
        } 
    }
}
