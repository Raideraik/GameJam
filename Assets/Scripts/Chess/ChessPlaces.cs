using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlaces : HandheldActivator, IItems
{
    [SerializeField] private bool _isHorse;
    [SerializeField] private bool _isCorrectPlace;
    [SerializeField] private IItems.Items _items;
    [SerializeField] private GameObject _chessPieceVisual;
    [SerializeField] private List<TackableObject> _chessPieces;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        HidePiece();
    }

    private void PlacePiece()
    {
        ShowPiece();
        
        if (!_isCorrectPlace)
        {
            //Animator
            HidePiece();
            for (int i = 0; i < _chessPieces.Count; i++)
            {
                _chessPieces[i].gameObject.SetActive(true);
            }
        }
        else if (_isCorrectPlace && Hand.Instance.TackedObject().Item.GetComponent<ChessPiece>().IsHorse)
        {
            Debug.Log("WIN!");

            ChessBoard.Instance.CheckMate();
        }
        Hand.Instance.DestroyItem();
    }

    private void ShowPiece() 
    {
        _chessPieceVisual.SetActive(true);
    }

    private void HidePiece() 
    {
        _chessPieceVisual.SetActive(false);

    }

    public override void UseItem()
    {
        if (Hand.Instance.TackedObject().ItemType == _items && !ChessBoard.Instance.IsGameEnded())
        {
            PlacePiece();
        }
    }
}
