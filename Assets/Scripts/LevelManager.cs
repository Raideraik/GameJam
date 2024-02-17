using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
        
    }
}
