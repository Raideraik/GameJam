using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DTWUI : MonoBehaviour
{
    public static DTWUI Instance { get; private set; }
    public event EventHandler OnEndReached;

    [SerializeField] private GameObject[] _screenLevel;
    [SerializeField] private int _wallsProhibitedTouchCount = 3;
    [SerializeField] private int _goalNeedToTouchCount = 3;
    [SerializeField] private Texture2D _newCursour;

    private int _wallsTouchedCount = 0;
    private int _goalTouchedCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DTWGoal.OnDTWGoalTouched += DTWGoal_OnDTWGoalTouched;
        DTWWall.OnAnyWallTouched += OnAnyWallTouched;
        Hide();
    }

    private void OnDisable()
    {

        DTWGoal.OnDTWGoalTouched -= DTWGoal_OnDTWGoalTouched;
        DTWWall.OnAnyWallTouched -= OnAnyWallTouched;
    }

    private void DTWGoal_OnDTWGoalTouched(object sender, System.EventArgs e)
    {
        if (_wallsTouchedCount > 0)
            _wallsTouchedCount--;

        _goalTouchedCount++;
        SelectNewLevel();
        if (_goalTouchedCount >= _goalNeedToTouchCount)
        {
            OnEndReached?.Invoke(this, EventArgs.Empty);
            DeactivateGame();
           gameObject.SetActive(false);
        }
    }

    private void OnAnyWallTouched(object sender, System.EventArgs e)
    {
        _wallsTouchedCount++;
        SelectNewLevel();
        if (_wallsTouchedCount >= _wallsProhibitedTouchCount)
        {
            DeactivateGame();
        }
    }

    private void SelectNewLevel()
    {
        Hide();
        Show();
    }


    private void DeactivateGame()
    {
        PauseMenu.Instance.SwitchCanPause();
        Hide();
        PauseMenu.Instance.ToggleGame();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        /*
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();*/
    }

    public void ActivateGame()
    {
        PauseMenu.Instance.SwitchCanPause();
        _wallsTouchedCount = 0;
        _goalTouchedCount = 0;
        Show();
        PauseMenu.Instance.ToggleGame();
        Cursor.SetCursor(_newCursour, Vector2.zero, CursorMode.Auto);
        /* Cursor.visible = true;
         Cursor.lockState = CursorLockMode.Confined;
         PlayerCam.Instance.ToggleCam();
         PlayerMovement.Instance.ToggleMovement();*/
    }
    private void Show()
    {
        _screenLevel[Random.Range(0, _screenLevel.Length)].SetActive(true);

    }
    private void Hide()
    {
        for (int i = 0; i < _screenLevel.Length; i++)
        {
            _screenLevel[i].SetActive(false);
        }

    }
}
