using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int _rayLength = 5;
    [SerializeField] private LayerMask _layerMaskInteract;
    [SerializeField] private string _excludeLayerName = null;

    //INPUTSYSTEM !!!!!
    [SerializeField] private KeyCode _openDoorKey = KeyCode.Mouse0;

    [SerializeField] private Image _crosshair = null;
    private bool _isCrosshairActive;
    private bool _doOnce;


    private void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(_excludeLayerName) | _layerMaskInteract.value;

        if (Physics.Raycast(transform.position, forward, out hit, _rayLength, mask))
        {
            if (hit.transform.TryGetComponent(out DoorController door))
            {
                if (!_doOnce)
                {
                    CrosshairChange(true); 
                }

                _isCrosshairActive = true;
                _doOnce = true;
                if (Input.GetKeyDown(_openDoorKey))
                {
                    door.PlayAnimation();
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
