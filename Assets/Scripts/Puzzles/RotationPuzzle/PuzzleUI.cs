using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour
{
    [SerializeField] private Button[] _exitButton;
    [SerializeField] private GameObject[] _screen;

    [SerializeField] private PuzzleController[] _controller;
    private void Start()
    {
        for (int i = 0; i < _controller.Length; i++)
        {
            _controller[i].OnPuzzleActivation += OnPuzzleActivation;
        }

        for (int i = 0; i < _exitButton.Length; i++)
        {
            _exitButton[i].onClick.AddListener(() =>
        {
            Hide();
        });        }

        Hide();
    }

    private void OnPuzzleActivation(object sender, int id)
    {
        Show(id);
    }

    private void Show(int id)
    {
        _screen[id].SetActive(true);

    }
    private void Hide()
    {
        for (int i = 0; i < _screen.Length; i++)
        {
            _screen[i].SetActive(false);
        }
    }

}
