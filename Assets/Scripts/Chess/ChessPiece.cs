using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    [SerializeField] private bool _isHorse;
    public bool IsHorse => _isHorse;
}
