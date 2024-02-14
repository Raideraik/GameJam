using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonActivator : MonoBehaviour, IItems
{
    [SerializeField] private IItems.Items _items;
    [SerializeField] private PortalController _portalController;
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
            _portalController.ActivatePortal();
            Hand.Instance.DestroyItem();
            PlayAnimation();
        }
    }
}
