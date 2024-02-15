using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : InteractableObject
{
    public event EventHandler<Indicator> OnAnyIndicatorClick;

    private MeshRenderer _meshRenderer;
    [SerializeField] private bool _isMaterialGreen;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public override void UseItem()
    {
        SendIndication();
    }

    private void SendIndication()
    {
        OnAnyIndicatorClick?.Invoke(this, this);
    }

    public void ChangeColor(Material changedMaterial)
    {
        _meshRenderer.material = changedMaterial;
        _isMaterialGreen = !_isMaterialGreen;
    }

    public bool GetIsMaterialGreen() 
    {
        return _isMaterialGreen;
    }
}
