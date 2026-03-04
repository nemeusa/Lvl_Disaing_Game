using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _coins;
    [SerializeField] TMP_Text _coinsText;


    public void AddCoin()
    {
        _coins++;
        _coinsText.text = "Alfajores: " + _coins;
    }

}
