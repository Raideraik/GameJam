using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterUI : MonoBehaviour
{
    public static LetterUI Instance { get; private set; }

    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Image _image;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //LetterController.Instance.OnLetterActivation += OpenLetter;
        _exitButton.onClick.AddListener(() =>
        {
            Hide();
            PauseMenu.Instance.ToggleGame();/*
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerCam.Instance.ToggleCam();
            PlayerMovement.Instance.ToggleMovement();*/
        });
        Hide();
    }

    public void OpenLetter(Sprite letter)
    {
        _image.sprite = letter;
        Show();
        PauseMenu.Instance.ToggleGame();/*
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();*/
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
