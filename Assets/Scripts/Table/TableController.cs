using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    private Animator _animator;
    private bool _tableOpened = false;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!_tableOpened)
        {
            _animator.SetTrigger("Open");
            _tableOpened = true;
        }
        else
        {

            _animator.SetTrigger("Close");
            _tableOpened = false;
        }
    }

}
