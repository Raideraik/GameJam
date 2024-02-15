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
    [SerializeField] private TMP_Text _text;

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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerCam.Instance.ToggleCam();
            PlayerMovement.Instance.ToggleMovement();
        });
        Hide();
    }

    public void OpenLetter(string text)
    {
        _text.text = text;
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
