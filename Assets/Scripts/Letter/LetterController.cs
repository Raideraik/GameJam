using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : UIActivator
{
    [TextArea(3, 10)]
    [SerializeField] private string _myText;

    public override void ActivateUI()
    {
        LetterUI.Instance.OpenLetter(_myText);
    }
}
