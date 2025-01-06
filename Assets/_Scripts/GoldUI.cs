using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityGold _playerGold;


    public void UpdateGold(int newGoldValue)
    {
        _text.text = $"Gold : {newGoldValue}";
    }

    private void Start()
    {
        UpdateGold(_playerGold.CurrentGold);
    }
}
