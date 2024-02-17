using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : InteractableObject
{
    public event EventHandler<Card> OnCardFlipped;

    [SerializeField] private bool _isFlipped = false;
    [SerializeField] private int _id;
    private MeshRenderer _meshRenderer;
    private float _tempTransform;
    private bool _flippedCorrect = false;
    public bool FlippedCorrect => _flippedCorrect;
    public int Id => _id;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        _tempTransform = transform.eulerAngles.y;
    }

    public void FlipCardTrue()
    {
        if (_flippedCorrect)
            return;

        _isFlipped = true;
        transform.DORotate(new Vector3(transform.rotation.x, _tempTransform - 180f, transform.rotation.z), 1f);

        // if (!_isFlipped)
        OnCardFlipped?.Invoke(this, this);
    }
    public void FlipCardFalse()
    {
        _isFlipped = false;
        transform.DORotate(new Vector3(transform.rotation.x, _tempTransform, transform.rotation.z), 1f);
    }

    public void SetFlippedCorrect()
    {
        _flippedCorrect = true;
    }

    public void SetMaterial(Material front)
    {
        //Debug.Log("Sett");
        _meshRenderer.material = front;
    }
    
    public void SetId(int id)
    {
        //Debug.Log("Sett");
        _id = id;
    }

    public override void UseItem()
    {
        if (!_isFlipped)
        {
            FlipCardTrue();
        }
    }
}
