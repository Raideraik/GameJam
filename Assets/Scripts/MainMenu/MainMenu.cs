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
        _startButton.onClick.AddListener(() =>
        {
            LevelManager.Instance.LoadLevel(_levelName);
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
