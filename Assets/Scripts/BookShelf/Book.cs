using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private Material _material;

    public Material GetBookMaterial() 
    {
        return _material;
    }
}
