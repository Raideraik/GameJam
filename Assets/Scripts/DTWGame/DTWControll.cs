using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTWControll : UIActivator
{
    private Animator _animator;
    private bool _gameEnded;
    private void Start()
    {
        _animator = GetComponent<Animator>();

        DTWUI.Instance.OnEndReached += OnEndReached;
    }

    private void OnEndReached(object sender, System.EventArgs e)
    {
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        _gameEnded = true;
        _animator.SetTrigger("Open");
    }

    public override void ActivateUI()
    {
        if (!_gameEnded)
            DTWUI.Instance.ActivateGame();
    }
}
