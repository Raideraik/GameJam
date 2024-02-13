using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivator : MonoBehaviour, IItems
{
    [SerializeField] private IItems.Items _items;
    private Animator _animator;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void PlayAnimation()
    {       
            _animator.SetTrigger("SetBox");
    }

    public void UseItem()
    {
        if (Hand.Instance.TackedObject().ItemType == _items)
        {
            Hand.Instance.DestroyItem();
            PlayAnimation();
        }
    }
}
