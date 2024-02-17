using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton, _exitButton;
    [SerializeField] private string _levelName;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        _startButton.onClick.AddListener(() =>
        {
            //LevelManager.Instance.LoadLevel(_levelName);
            SceneFader.Instance.FadeIn(_levelName);
            PlayerPrefs.SetInt("Video", 0);
        });
        _exitButton.onClick.AddListener(() =>
        {
            ExitGame();
        });
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
