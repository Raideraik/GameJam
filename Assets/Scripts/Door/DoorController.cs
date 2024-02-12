using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _animator;
    private bool _doorOpen = false;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation() 
    {
        if (!_doorOpen)
        {
            _animator.SetTrigger("Open");
            _doorOpen = true;
        }
        else
        {

            _animator.SetTrigger("Close");
            _doorOpen = false;
        }
    }

}
