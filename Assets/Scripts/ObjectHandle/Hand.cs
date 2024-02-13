using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand Instance;
    [SerializeField] private Transform _holder;
    private TackableObject _tackedObject;
    private GameObject _objectInHand;
    private void Awake()
    {
        Instance = this;
    }

    public void TakeItem(TackableObject itemToTake)
    {
        _tackedObject = itemToTake;
        _objectInHand = Instantiate(itemToTake.Item, _holder);

    }

    public bool TryTakeItem()
    {
        return _tackedObject != null;
    }

    public void ReturnItem()
    {
        _tackedObject.gameObject.SetActive(true);
        DestroyItem();
    }

    public void DestroyItem() 
    {
        Destroy(_objectInHand);
        _tackedObject = null;
    }

    public TackableObject TackedObject() 
    {
        return _tackedObject;
    }

}
