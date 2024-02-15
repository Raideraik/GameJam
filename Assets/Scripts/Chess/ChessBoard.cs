using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public static ChessBoard Instance { get; private set; }

    private bool _isGameEnded = false;
    [SerializeField] private ChessPlaces[] _placesToDeactivate;
    [SerializeField] private GameObject[] _piecesToDeactivate;

    private void Start()
    {
        Instance = this;
    }

    public void CheckMate()
    {
        _isGameEnded = true;
        /*
        for (int i = 0; i < _placesToDeactivate.Length; i++)
        {
            _placesToDeactivate[i].enabled = false;
            _placesToDeactivate[i].GetComponent<Collider>().enabled = false;
        }*/
        for (int i = 0; i < _piecesToDeactivate.Length; i++)
        {
            _piecesToDeactivate[i].SetActive(!_piecesToDeactivate[i].activeSelf);
        }
    }

    public bool IsGameEnded()
    {
        return _isGameEnded;
    }
}
