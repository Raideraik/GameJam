using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<Card> _cards;
    [SerializeField] private List<Material> _materialsBack;
    [SerializeField] private float _waitTime;
    [SerializeField] private GameObject _gameObjectToActivate;
    [SerializeField] private AudioClip _clip;

    private List<int> usedIDs = new List<int>();
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
    {
        // Перемешиваем массив объектов
        ShuffleArray(_cards);

        // Присваиваем ID парам случайных объектов
        for (int i = 0; i < _cards.Count; i += 2)
        {
            int id = GetRandomID();
            _cards[i].SetId(id);
            _cards[i + 1].SetId(id);
        }

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
    private int GetRandomID()
    {
        int id;
        do
        {
            id = Random.Range(0, _materialsBack.Count);
        } while (usedIDs.Contains(id));

        usedIDs.Add(id);
        return id;
    }

    private void ShuffleArray(List<Card> array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            int randomIndex = Random.Range(i, array.Count);
            Card temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
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
            SoundsController.Instance.PlaySound(_clip);
            _gameObjectToActivate.SetActive(true);
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
