using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    //[SerializeField] int _valueTreasure = 10;

    public Gold(int value) : base(value)
    {
    }

    public Gold() : base()
    {
    }

    public override void Use(PickUpItem pui, GameObject player)
    {
        player.GetComponent<EntityGold>().AddGold(valueItem);
        base.Use(pui, player);
    }
}
