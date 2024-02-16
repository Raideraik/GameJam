using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DTWWall : MonoBehaviour, IPointerEnterHandler
{
    public static event EventHandler OnAnyWallTouched;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnAnyWallTouched?.Invoke(this, EventArgs.Empty);
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("UnlockCursor", 0.05f);
    }

    private void UnlockCursor() => Cursor.lockState = CursorLockMode.None;

}
