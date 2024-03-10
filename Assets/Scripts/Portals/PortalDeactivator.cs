using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _portals;
    [SerializeField] private AudioClip _clip;
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            DeactivatePortals();
        }
    }

    private void DeactivatePortals()
    {
        SoundsController.Instance.PlaySound(_clip);
        for (int i = 0; i < _portals.Length; i++)
        {
            _portals[i].SetActive(!_portals[i].activeSelf);
        }
    }
}
