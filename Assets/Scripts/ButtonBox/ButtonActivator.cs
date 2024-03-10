using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonActivator : HandheldActivator, IItems
{
    [SerializeField] private IItems.Items _items;
    [SerializeField] private PortalController _portalController;
    private Animator _animator;

    [SerializeField] private AudioClip _audioClipButtonActivator;
    [SerializeField] private AudioClip _audioClipDoorOpen;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger("SetBox");
        SoundsController.Instance.PlaySound(_audioClipButtonActivator);
        SoundsController.Instance.PlaySound(_audioClipDoorOpen);

    }

    public override void UseItem()
    {
        if (Hand.Instance.TackedObject().ItemType == _items)
        {
            _portalController.ActivatePortal();
            Hand.Instance.DestroyItem();
            PlayAnimation();
        }
    }
}
