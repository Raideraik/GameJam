using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostamentActivator : HandheldActivator, IItems
{
    [SerializeField] private IItems.Items _items;
    [SerializeField] private Effect _effect;
    [SerializeField] private MeshFilter _mesh;
    private Animator _animator;

    private Mesh mesh;
    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger("Set");
    }

    public override void UseItem()
    {
        if (Hand.Instance.TackedObject().ItemType == _items)
        {
            _mesh.mesh = Hand.Instance.TackedObject().GetComponent<MeshFilter>().mesh;
            PlayAnimation();
            _effect.gameObject.SetActive(true);
            //_effect.Placed();
            Hand.Instance.DestroyItem();
        }
    }
}
