using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : UIActivator
{
    public event EventHandler<int> OnPuzzleActivation;

    [SerializeField] private int _id;

    public void ActivatePuzzle()
    {
        OnPuzzleActivation?.Invoke(this, _id);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
    }
    public void DeActivatePuzzle()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCam.Instance.ToggleCam();
        PlayerMovement.Instance.ToggleMovement();
    }

    public override void ActivateUI()
    {
        ActivatePuzzle();
    }
}
