using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationButton : InteractableObject
{
    [SerializeField] private GameObject[] _activationObjects;
    private Animator _animator;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _animator.SetTrigger("Use");


        ActivatePortal();

    }

    private void ActivatePortal()
    {
        for (int i = 0; i < _activationObjects.Length; i++)
        {
            _activationObjects[i].SetActive(!_activationObjects[i].activeSelf);
        }
    }
    /*
    private void DeactivatePortal()
    {
        for (int i = 0; i < _activationObjects.Length; i++)
        {

            _activationObjects[i].SetActive(false);
        }
    }*/

    public override void UseItem()
    {
        PlayAnimation();
    }
}
