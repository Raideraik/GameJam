using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : HandheldActivator, IItems
{
    [SerializeField] private GameObject[] _portals;

    [SerializeField] private IItems.Items _items;
    private Animator _animator;

    [SerializeField] private AudioClip _clip;
    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void PlayAnimation()
    {
        SoundsController.Instance.PlaySound(_clip);
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
