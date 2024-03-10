using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScreen : MonoBehaviour
{
    [SerializeField] private AudioClip _startClip;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SoundsController.Instance.PlaySound(_startClip);
            gameObject.SetActive(false);
        }
    }
}
