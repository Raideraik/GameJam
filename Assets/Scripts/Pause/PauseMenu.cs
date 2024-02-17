using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static string _levelName = "MainMenu";
    public static PauseMenu Instance { get; private set; }

    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    private KeyCode _pauseKey = KeyCode.Escape;
    private bool _isGamePaused = false;
    public bool IsGamePaused => _isGamePaused;

    private void Start()
    {
        Instance = this;
        _exitButton.onClick.AddListener(() =>
        {
            SceneFader.Instance.FadeIn(_levelName);
        });

        _continueButton.onClick.AddListener(() =>
        {
            ShowScreen();
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
        {
            ShowScreen();
        }
    }
    public void ToggleGame()
    {
        _isGamePaused = !_isGamePaused;
        if (_isGamePaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
    }

    private void ShowScreen()
    {
        _pauseScreen.SetActive(!_pauseScreen.activeSelf);
        ToggleGame();
    }
}
