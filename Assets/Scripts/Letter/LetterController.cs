using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : UIActivator
{
    [SerializeField] private Sprite _letter;

    public override void ActivateUI()
    {
        LetterUI.Instance.OpenLetter(_letter);
    }
}
