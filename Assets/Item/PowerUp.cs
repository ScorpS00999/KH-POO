using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    //[SerializeField] int _valueHealthUpdate = 10;

    public PowerUp(int value) : base(value)
    {
    }

    public PowerUp() : base()
    {
    }

    public override void Use(PickUpItem pui, GameObject player)
    {
        player.GetComponent<EntityHealth>().UpdateMaxHealth(valueItem);
        base.Use(pui, player);
    }
}
