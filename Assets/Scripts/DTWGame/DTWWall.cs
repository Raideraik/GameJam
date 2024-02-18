using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DTWWall : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public static event EventHandler OnAnyWallTouched;

    private Image _image;
    [SerializeField] private float _alpha = 0.1f;
    private bool _inPath;
    private void Start()
    {
        _image = GetComponent<Image>();
        _image.alphaHitTestMinimumThreshold = _alpha;
    }

    private void Update()
    {
        if (!_inPath)
        {
            OnExit();
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _inPath = false;
        Invoke("UnlockCursor", 0.05f);

    }

    private void OnExit() 
    {
        OnAnyWallTouched?.Invoke(this, EventArgs.Empty);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void UnlockCursor()
    {

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _inPath = true;
    }
}
