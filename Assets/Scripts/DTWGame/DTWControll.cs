using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTWControll : UIActivator
{
    private Animator _animator;
    private bool _gameEnded;
    [SerializeField] private AudioClip _clipComputer;
    [SerializeField] private AudioClip _safeOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        DTWUI.Instance.OnEndReached += OnEndReached;
    }

    private void OnEndReached(object sender, System.EventArgs e)
    {
        PlayAnimation();
        //Invoke("PlayAnimation", 1);
    }

    private void PlayAnimation()
    {
        _gameEnded = true;
        SoundsController.Instance.PlaySound(_safeOpen);
        _animator.SetTrigger("Open");
    }

    public override void ActivateUI()
    {
        SoundsController.Instance.PlaySound(_clipComputer);
        if (!_gameEnded)
            DTWUI.Instance.ActivateGame();
    }
}
