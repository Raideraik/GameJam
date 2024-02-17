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

    private int _wallsTouchedCount = 0;
    private int _goalTouchedCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DTWWall.OnAnyWallTouched += OnAnyWallTouched;
        DTWGoal.OnDTWGoalTouched += DTWGoal_OnDTWGoalTouched;
        Hide();
    }

    private void DTWGoal_OnDTWGoalTouched(object sender, System.EventArgs e)
    {
        _goalTouchedCount++;
        SelectNewLevel();
        if (_goalTouchedCount >= _goalNeedToTouchCount)
        {
            OnEndReached?.Invoke(this, EventArgs.Empty);
            DeactivateGame();
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
        Hide();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
    }

    public void ActivateGame()
    {
        _wallsTouchedCount = 0;
        Show();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
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
