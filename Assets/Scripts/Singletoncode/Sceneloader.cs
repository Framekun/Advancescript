using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : Singleton<Sceneloader>
{
    [SerializeField] private string _gameplayScenename = "Gameplay";
    private bool _isLoading = false;
    private Scene currentActiveScene;
    public string GetCurrentActiveSceneName()
    {
         return currentActiveScene.name;
    }
    public void Loadlocation(string location)
    {
        if(_isLoading) return;

        StartCoroutine(LoadSceneCoroutine(location,false));
    }

    public void LoadMenu(string menu)
    {
        if (_isLoading) return;

        StartCoroutine(LoadSceneCoroutine(menu, true));
    }

    IEnumerator LoadSceneCoroutine(string targetscene, bool isMenu)
    {
        _isLoading = true;

        Savesystem.Instance.RecordSaveGameData(targetscene);

        if(currentActiveScene.isLoaded)
        {
            AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(currentActiveScene);

            while(!unloadOp.isDone)
            {
                yield return null;
            }
        }

        Scene gameplayScene = SceneManager.GetSceneByName(_gameplayScenename);

        if(isMenu && gameplayScene.isLoaded)
        {
            AsyncOperation unloadGameplayOp = SceneManager.UnloadSceneAsync(gameplayScene);
            while(!unloadGameplayOp.isDone)
            {
                yield return null;
            }
        }

        if (!isMenu && !gameplayScene.isLoaded)
        {
            AsyncOperation loadGameplayOp = SceneManager.LoadSceneAsync(_gameplayScenename,LoadSceneMode.Additive);
            while (!loadGameplayOp.isDone)
            {
                yield return null;
            }
        }

        AsyncOperation loadOp = SceneManager.LoadSceneAsync(targetscene, LoadSceneMode.Additive);
        while(!loadOp.isDone)
        {
            yield return null;
        }

        currentActiveScene = SceneManager.GetSceneByName(targetscene);

        SceneManager.SetActiveScene(currentActiveScene);


        if(!isMenu)
        {
            Savesystem.Instance.ApplySaveGameData();
            SpawnSystem.Instance.SpawnPlayer();
        }

        _isLoading = false;
    }
}
