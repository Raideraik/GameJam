using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : InteractableObject, IItems
{
    [SerializeField] private GameObject[] _portals;

    [SerializeField] private IItems.Items _items;
    private Animator _animator;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger("Open");
        for (int i = 0; i < _portals.Length; i++)
        {
            _portals[i].SetActive(true);
        }

    }
    public override void UseItem()
    {
        if (Hand.Instance.TackedObject().ItemType == _items)
        {
            Hand.Instance.DestroyItem();
            PlayAnimation();
        }
    }
}
