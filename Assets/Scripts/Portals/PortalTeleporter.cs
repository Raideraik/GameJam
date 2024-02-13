using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _receiver;

    private bool _playerIsOverlapping = false;

    private void Update()
    {
        if (_playerIsOverlapping)
        {
            Vector3 portalToPlayer = _player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //if true player moved across portal
            if (dotProduct < 0f)
            {
                //Teleport him
                float rotationDiff = -Quaternion.Angle(transform.rotation, _receiver.rotation);
                rotationDiff += 180f;
                _player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                _player.position = _receiver.position + positionOffset;

                _playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCam player))
        {
            _playerIsOverlapping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCam player))
        {
            _playerIsOverlapping = false;
        }
    }
}
