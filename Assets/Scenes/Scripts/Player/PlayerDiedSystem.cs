using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDiedSystem : MonoBehaviour
{
    [SerializeField] private string SceneName;
    public void Deadload()
    {
        SceneManager.LoadScene(SceneName);
    }
}
