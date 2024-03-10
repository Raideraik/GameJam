using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : UIActivator
{
    [SerializeField] private Sprite _letter;
    [SerializeField] private AudioClip _audioClip;
    public override void ActivateUI()
    {
        SoundsController.Instance.PlaySound(_audioClip);
        LetterUI.Instance.OpenLetter(_letter);
    }
}
