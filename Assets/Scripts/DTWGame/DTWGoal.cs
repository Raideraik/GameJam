using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DTWGoal : MonoBehaviour, IPointerEnterHandler
{
    public static event EventHandler OnDTWGoalTouched;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnDTWGoalTouched?.Invoke(this, EventArgs.Empty);
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("UnlockCursor", 0.05f);
    }

    private void UnlockCursor() => Cursor.lockState = CursorLockMode.Confined;

}
