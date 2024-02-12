using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastSystem : MonoBehaviour
{
    [SerializeField] private int _rayLength = 5;

    //INPUTSYSTEM !!!!!
    [SerializeField] private KeyCode _interactKey = KeyCode.Mouse0;

    [SerializeField] private Image _crosshair = null;
    private bool _isCrosshairActive;
    private bool _doOnce;


    private void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, _rayLength))
        {
            if (hit.transform.TryGetComponent(out DoorController door))
            {
                TryChangeCrosshair();

                if (Input.GetKeyDown(_interactKey))
                {
                    door.PlayAnimation();
                }
            }
            else if (hit.transform.TryGetComponent(out PuzzleController puzzle))
            {
                TryChangeCrosshair();

                if (Input.GetKeyDown(_interactKey))
                {
                    PuzzleController.Instance.ActivatePuzzle();
                }
            }

        }
        else
        {
            if (_isCrosshairActive)
            {
                CrosshairChange(false);
                _doOnce = false;
            }
        }
    }

    private void TryChangeCrosshair()
    {
        if (!_doOnce)
        {
            CrosshairChange(true);
        }

        _isCrosshairActive = true;
        _doOnce = true;
    }

    private void CrosshairChange(bool on)
    {
        if (on && !_doOnce)
        {
            _crosshair.color = Color.red;
        }
        else
        {
            _crosshair.color = Color.white;
            _isCrosshairActive = false;
        }
    }
}
