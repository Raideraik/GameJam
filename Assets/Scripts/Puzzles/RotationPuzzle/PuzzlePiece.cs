using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


public class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{
    private float _tempTransform;

    private void Start()
    {
        _tempTransform = transform.rotation.z;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _tempTransform += 90f;


        Debug.Log(_tempTransform);
        transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, _tempTransform), 1f);
        //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 90f);
    }

}
