using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DTWUI : MonoBehaviour
{
    public static DTWUI Instance { get; private set; }

    [SerializeField] private GameObject[] _screenLevel;
    [SerializeField] private int _wallsProhibitedTouchCount = 3;
    [SerializeField] private int _goalNeedToTouchCount = 3;
    //[SerializeField] private Texture2D _cursor;

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
            DeactivateGame();
            Debug.Log("Win!!");
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
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
    }

    public void ActivateGame()
    {
        _wallsTouchedCount = 0;
        Show();
        Cursor.visible = true;
        //Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.ForceSoftware);
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
