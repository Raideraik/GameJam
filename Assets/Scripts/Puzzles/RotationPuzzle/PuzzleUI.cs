using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _screen;
    private void Start()
    {
        PuzzleController.Instance.OnPuzzleActivation += OpenWindow;
        PuzzleController.Instance.OnPuzzleDeActivation += CloseWindow;
        _exitButton.onClick.AddListener(() =>
        {
            PuzzleController.Instance.DeActivatePuzzle();
        });
        Hide();
    }

    private void OpenWindow(object sender, EventArgs e)
    {
        Show();
    }
    private void Show()
    {
        _screen.SetActive(true);

    } 
    private void Hide()
    {
        _screen.SetActive(false);

    }

    private void CloseWindow(object sender, EventArgs e)
    {
        Hide();
    }
}
