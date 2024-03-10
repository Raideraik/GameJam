using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        transform.LookAt(_player);
    }
}
