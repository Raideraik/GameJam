using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digit : InteractableObject
{
    public event Action<int, int> OnDigitChanged;
    [SerializeField] private int _numberShown = 0;
    [SerializeField] private int _id;

    private bool _coroutineAllowed = true;

    public void RotateWheel()
    {
        if (_coroutineAllowed)
        {
            StartCoroutine("Rotate");
        }


    }

    private IEnumerator Rotate()
    {
        _coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(-3f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        _coroutineAllowed = true;

        _numberShown++;
        if (_numberShown > 9)
        {
            _numberShown = 0;
        }
        OnDigitChanged?.Invoke(_id, _numberShown);
    }

    public override void UseItem()
    {
        RotateWheel();
    }
}
