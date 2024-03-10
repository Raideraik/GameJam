using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsControll : MonoBehaviour
{
    [SerializeField] private PostamentActivator[] _postaments;

    private int _effectCount;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        PostamentActivator.OnEffectPlaced += OnEffectPlaced;
    }

    private void OnEffectPlaced(object sender, System.EventArgs e)
    {
        _effectCount++;
        if (_effectCount >= _postaments.Length)
        {
            PlayeAnimation();
        }
    }

    private void PlayeAnimation()
    {
        _animator.SetTrigger("Open");
    }
}
