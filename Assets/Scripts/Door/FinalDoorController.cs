using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : InteractableObject
{
    [SerializeField] private int _choosedFinal;

    public override void UseItem()
    {
        PlayerPrefs.SetInt("Video", _choosedFinal);
        SceneFader.Instance.FadeIn("VideoLevel");
    }
}
