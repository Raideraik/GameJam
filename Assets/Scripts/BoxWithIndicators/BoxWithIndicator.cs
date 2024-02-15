using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxWithIndicator : MonoBehaviour
{
    [SerializeField] private List<Indicator> _indicators;
    [SerializeField] private Material _red;
    [SerializeField] private Material _green;

    private int _tempIndex;
    private int _greenIndicators = 0;

    private void Start()
    {
        for (int i = 0; i < _indicators.Count; i++)
        {
            _indicators[i].OnAnyIndicatorClick += BoxWithIndicator_OnAnyIndicatorClick;
        }
    }

    private void BoxWithIndicator_OnAnyIndicatorClick(object sender, Indicator e)
    {
        for (int i = 0; i < _indicators.Count; i++)
        {
            Debug.Log(_indicators[i] == e && i < _indicators.Count && _indicators[i].GetIsMaterialGreen());

            if (_indicators[i] == e && i < _indicators.Count)
            {
                _tempIndex = i + 1;
                //Debug.Log(_tempIndex);

                if (_indicators[i].GetIsMaterialGreen())
                {
                    _indicators[i].ChangeColor(_red);
                }
                else
                {
                    _indicators[i].ChangeColor(_green);

                }

                if (_tempIndex < _indicators.Count)
                {

                    if (_indicators[_tempIndex].GetIsMaterialGreen())
                    {
                        _indicators[_tempIndex].ChangeColor(_red);
                    }
                    else
                    {
                        _indicators[_tempIndex].ChangeColor(_green);
                    }
                }
            }
        }
        CheckAllInidactorsGreen();
    }

    private void CheckAllInidactorsGreen()
    {
        foreach (var item in _indicators)
        {
            if (item.GetIsMaterialGreen())
            {
                _greenIndicators++;

                if (_greenIndicators == _indicators.Count)
                {
                    Debug.Log("Win!");
                }
                else
                {
                    _greenIndicators = 0;
                }
            }
        }
    }
}
