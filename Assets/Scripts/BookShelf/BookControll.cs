using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControll : MonoBehaviour
{
    [SerializeField] private BookPlace[] _bookPlaces;

    private int _correctBooks = 0;
    private void Start()
    {
        BookPlace.OnAnyBookSetCorrrect += OnAnyBookSetCorrrect;
    }

    private void OnAnyBookSetCorrrect(object sender, System.EventArgs e)
    {
        _correctBooks++;

        if (_correctBooks == _bookPlaces.Length)
        {
            Debug.Log("Win!!");
        }
    }
}
