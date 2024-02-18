using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsControll : MonoBehaviour
{
    [SerializeField] private Effect[] _effects;

    private int _effectCount;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        Effect.OnEffectPlaced += OnEffectPlaced;
    }

    private void OnEffectPlaced(object sender, System.EventArgs e)
    {
        if (_effectCount >= _effects.Length)
        {
            PlayeAnimation();
        }
    }

    private void PlayeAnimation()
    {
        _animator.SetTrigger("Open");
    }
}
