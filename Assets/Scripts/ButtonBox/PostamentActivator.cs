using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostamentActivator : HandheldActivator, IItems
{
    public static event EventHandler OnEffectPlaced;

    [SerializeField] private IItems.Items _items;
    [SerializeField] private MeshFilter _mesh;
    [SerializeField] private AudioClip _audioClip;
    private Animator _animator;

    private Mesh mesh;
    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Placed()
    {
        OnEffectPlaced?.Invoke(this, EventArgs.Empty);
    }
    private void PlayAnimation()
    {
        SoundsController.Instance.PlaySound(_audioClip);
        _animator.SetTrigger("Set");
        Placed();
    }

    public override void UseItem()
    {
        if (Hand.Instance.TackedObject().ItemType == _items)
        {
            _mesh.mesh = Hand.Instance.TackedObject().GetComponent<MeshFilter>().mesh;
            PlayAnimation();
            //_effect.Placed();
            Hand.Instance.DestroyItem();
        }
    }
}
