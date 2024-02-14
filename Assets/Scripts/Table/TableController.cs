using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : InteractableObject
{
    private bool _canUse = true;
    private bool _tableOpened = false;
    [SerializeField] private float _openLength = 0.3f;
    private int _waitTime = 1;

    public void ToggleDesk()
    {
        if (_canUse)
        {
            if (!_tableOpened)
            {
                _canUse = false;
                transform.DOLocalMoveX(transform.localPosition.x - _openLength, 1, false);
                StartCoroutine(ExecuteAfterTime(_waitTime));

                _tableOpened = true;
            }
            else
            {
                _canUse = false;
                StartCoroutine(ExecuteAfterTime(_waitTime));
                transform.DOLocalMoveX(transform.localPosition.x + _openLength, 1, false);
                _tableOpened = false;
            }
        }
    }

    public override void UseItem()
    {
        ToggleDesk();
    }

    IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        //сделать нужное
        _canUse = true;

    }
}
