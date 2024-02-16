using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DTWUI : MonoBehaviour
{
    public static DTWUI Instance { get; private set; }

    [SerializeField] private GameObject _screen;
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
        if (_goalTouchedCount >= _goalNeedToTouchCount)
        {
            DeactivateGame();
            Debug.Log("Win!!");
        }
    }

    private void OnAnyWallTouched(object sender, System.EventArgs e)
    {
        _wallsTouchedCount++;
        if (_wallsTouchedCount >= _wallsProhibitedTouchCount)
        {
            DeactivateGame();
        }
    }

    private void DeactivateGame()
    {
        Hide();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
    }

    public void ActivateGame()
    {
        _wallsTouchedCount = 0;
        Show();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
    }
    private void Show()
    {
        _screen.SetActive(true);

    }
    private void Hide()
    {
        _screen.SetActive(false);

    }
}
