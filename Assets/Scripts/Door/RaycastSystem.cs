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
        if (PauseMenu.Instance.IsGamePaused)
            return;



        if (Physics.Raycast(transform.position, forward, out hit, _rayLength))
        {
            if (hit.transform.TryGetComponent(out HandheldActivator activator))
            {
                TryChangeCrosshair();
                if (Hand.Instance.TackedObject() != null)
                {
                    if (Input.GetKeyDown(_interactKey))
                    {
                        activator.UseItem();
                    }
                }
            }
            else if (hit.transform.TryGetComponent(out InteractableObject interactableObject))
            {
                TryChangeCrosshair();

                if (Input.GetKeyDown(_interactKey))
                {
                    interactableObject.UseItem();
                }

            }
            else if (hit.transform.TryGetComponent(out UIActivator uiActivator))
            {
                TryChangeCrosshair();

                if (Input.GetKeyDown(_interactKey) && PlayerCam.Instance.IsCamActive)
                {
                    uiActivator.ActivateUI();
                }
            }
            else if (hit.transform.TryGetComponent(out TackableObject tackableObject))
            {
                TryChangeCrosshair();

                if (Input.GetKeyDown(_interactKey))
                {
                    if (Hand.Instance.TryTakeItem())
                    {
                        Hand.Instance.ReturnItem();
                    }
                    else
                    {
                        Hand.Instance.TakeItem(tackableObject);
                        tackableObject.gameObject.SetActive(false);
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
