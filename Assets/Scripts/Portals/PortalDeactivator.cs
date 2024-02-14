using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _portals;
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            DeactivatePortals();
        }
    }

    private void DeactivatePortals()
    {
        for (int i = 0; i < _portals.Length; i++)
        {
            _portals[i].SetActive(!_portals[i].activeSelf);
        }
    }
}
