using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    //[SerializeField] int _valueHeal = 10;

    public HealthPotion(int value) : base(value)
    {
    }

    public HealthPotion() : base()
    {
    }

    public override void Use(PickUpItem pui, GameObject player)
    {
        player.GetComponent<EntityHealth>().Heal(valueItem);
        base.Use(pui, player);
    }
}
