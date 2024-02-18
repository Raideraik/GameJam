using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public static event EventHandler OnEffectPlaced;

    public void Placed()
    {
        OnEffectPlaced?.Invoke(this, EventArgs.Empty);
    }
}
