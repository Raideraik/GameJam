using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitLock : MonoBehaviour
{
    [SerializeField] private Digit[] _digits;
    [SerializeField] private int[] _correctLock;
    [SerializeField] private AudioClip _audioClip;
    private Animator _animator;

    private int[] _correctNumbers = { 0, 0, 0 };

    private void Start()
    {
        _animator = GetComponent<Animator>();

        for (int i = 0; i < _digits.Length; i++)
        {
            _digits[i].OnDigitChanged += OnDigitChanged;
        }
    }

    private void OnDigitChanged(int arg1, int arg2)
    {
        CheckLock(arg1, arg2);
    }

    private void CheckLock(int id, int number)
    {

        switch (id)
        {
            case 0:
                _correctNumbers[0] = number;
                break;
            case 1:
                _correctNumbers[1] = number;
                break;
            case 2:
                _correctNumbers[2] = number;
                break;

        }
        TryUnlockLock();
    }

    private void TryUnlockLock()
    {
        if (_correctNumbers[0] == _correctLock[0] &&
            _correctNumbers[1] == _correctLock[1] &&
            _correctNumbers[2] == _correctLock[2])
        {
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        SoundsController.Instance.PlaySound(_audioClip);
        _animator.SetTrigger("Open");
    }
}
