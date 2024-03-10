using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public static ChessBoard Instance { get; private set; }

    private bool _isGameEnded = false;
    [SerializeField] private ChessPlaces[] _placesToDeactivate;
    [SerializeField] private GameObject[] _piecesToDeactivate;
    [SerializeField] private GameObject _gameObjectToActivate;

    [SerializeField] private AudioClip _audioClip;

    private void Start()
    {
        Instance = this;
    }

    public void CheckMate()
    {
        SoundsController.Instance.PlaySound(_audioClip);
        _isGameEnded = true;

        for (int i = 0; i < _piecesToDeactivate.Length; i++)
        {
            _piecesToDeactivate[i].SetActive(!_piecesToDeactivate[i].activeSelf);
        }

        _gameObjectToActivate.SetActive(true);

    }

    public bool IsGameEnded()
    {
        return _isGameEnded;
    }
}
