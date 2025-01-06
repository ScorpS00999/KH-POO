using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGold : MonoBehaviour
{
    [SerializeField] GoldUI _goldUI;

    public int CurrentGold { get; private set; } = 0;

    public void AddGold(int gold)
    {
        CurrentGold += gold;
        _goldUI.UpdateGold(CurrentGold);
    }
}
