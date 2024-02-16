using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<Card> _cards;
    [SerializeField] private List<Material> _materialsBack;
    [SerializeField] private Material _materialsFront;

    private int _tempMaterialIndex;
    private Card _tempCard;
    private void Start()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].OnCardFlipped += OnCardFlipped;
        }
        SetCardsMaterials();
    }

    private void SetCardsMaterials()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _tempMaterialIndex = Random.Range(0, _materialsBack.Count);
            Debug.Log("card id =" + _cards[i].Id);
            Debug.Log(_tempMaterialIndex);
            foreach (var item in _cards)
            {
                if (_cards[i].Id == item.Id)
                {
                    Debug.Log("Item id =" + item.Id + " " + item.name);
                    //_cards[i].SetMaterial(_materialsFront, _materialsBack[_tempMaterialIndex]);
                    item.SetMaterial(_materialsFront, _materialsBack[_tempMaterialIndex]);
                }
            }
        }
    }

    private void OnCardFlipped(object sender, Card card)
    {
        CheckCards(card);
    }

    private void CheckCards(Card card)
    {
        if (_tempCard != null)
        {
            if (card.Id == _tempCard.Id)
            {
                SetCorrect(card);
            }
            else
            {
                card.FlipCardFalse();
                _tempCard.FlipCardFalse();
                _tempCard = null;
            }
        }
        else
        {
            _tempCard = card;
        }
    }

    private void SetCorrect(Card card)
    {
        _tempCard.SetFlippedCorrect();
        card.SetFlippedCorrect();
        _tempCard = null;

    }
}
