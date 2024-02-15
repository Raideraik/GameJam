using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] private string _myText;

    public void OpenLetter()
    {

        LetterUI.Instance.OpenLetter(_myText);
    }
}
