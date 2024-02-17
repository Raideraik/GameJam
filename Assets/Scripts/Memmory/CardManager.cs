using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<Card> _cards;
    [SerializeField] private List<Material> _materialsBack;
    [SerializeField] private float _waitTime;

    private int _tempMaterialIndex;
    private Card _tempCard;
    private IEnumerator _coroutine;
    private void Start()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].OnCardFlipped += OnCardFlipped;
        }
        SetCardsMaterials();
    }

    private void SetCardsMaterials()
    {/*
        for (int i = 0; i < _cards.Count; i++)
        {
            _tempMaterialIndex = Random.Range(, _materialsBack.Count);
            for (int j = 0; j < _cards.Count; j++)
            {
                if (_cards[i].Id == _cards[j].Id)
                {
                    _cards[j].SetMaterial(_materialsBack[_tempMaterialIndex]);
                }
            }
        }*/
        for (int i = 0; i < _cards.Count; i++)
        {
            for (int j = 0; j < _cards.Count; j++)
            {
                if (_cards[i].Id == _cards[j].Id)
                {
                    _cards[j].SetMaterial(_materialsBack[_cards[i].Id]);
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
                _coroutine = FlipCardToFalse(card);
                StartCoroutine(_coroutine);
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
        TryWin();
    }

    private void TryWin()
    {
        int correctCount = 0;
        for (int i = 0; i < _cards.Count; i++)
        {
            if (_cards[i].FlippedCorrect)
            {
                correctCount++;
            }
        }

        if (correctCount >= _cards.Count)
        {
            Debug.Log("WIN!!");
        }
    }
    private IEnumerator FlipCardToFalse(Card card)
    {
        yield return new WaitForSeconds(_waitTime);
        card.FlipCardFalse();
        _tempCard.FlipCardFalse();
        _tempCard = null;

    }
}
