using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPlace : MonoBehaviour,IItems
{
    public static event EventHandler OnAnyBookSetCorrrect;

    [SerializeField] private IItems.Items _items;
    [SerializeField] private Book _book;
    [SerializeField] private TackableObject _bookGameObject;

    private Book _tackedBook;
    private MeshRenderer _meshRenderer;
    private bool _isCorrectBook = false;

    private void Start()
    {

        _meshRenderer = _bookGameObject.GetComponent<MeshRenderer>();
    }
    private void SetBook()
    {
        if (!_isCorrectBook)
        {
            _tackedBook = Hand.Instance.TackedObject().Item.GetComponent<Book>();
            _meshRenderer.material = _tackedBook.GetBookMaterial();
            _bookGameObject.gameObject.SetActive(true);
            _bookGameObject.Item = Hand.Instance.TackedObject().Item;
            Hand.Instance.DestroyItem();

            CheckBook();
        }
    }

    private void CheckBook()
    {
        if (_book == _tackedBook)
        {
            _isCorrectBook = true;
            _bookGameObject.GetComponent<Collider>().enabled = false;
            OnAnyBookSetCorrrect?.Invoke(this, EventArgs.Empty);
        }
    }

    public void UseItem()
    {
        if (Hand.Instance.TackedObject().ItemType == _items)
        {
            SetBook();
        }
    }
}
