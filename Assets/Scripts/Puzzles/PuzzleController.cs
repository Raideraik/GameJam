using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public event EventHandler OnPuzzleActivation;
    public event EventHandler OnPuzzleDeActivation;

    public static PuzzleController Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void ActivatePuzzle() 
    {
        OnPuzzleActivation?.Invoke(this, EventArgs.Empty);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void DeActivatePuzzle() 
    {
        OnPuzzleDeActivation?.Invoke(this, EventArgs.Empty);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
