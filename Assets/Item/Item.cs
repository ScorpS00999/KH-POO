using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] UnityEvent _destroyFeedback;

    //public virtual int valueItem => 10;

    [SerializeField] private int _valueItem;

    public int valueItem => _valueItem;

    public Item(int value)
    {
        this._valueItem = value;
    }

    public Item()
    {
        this._valueItem = 10;
    }

    public virtual void Use(PickUpItem pui, GameObject player)
    {
        _destroyFeedback?.Invoke();
        Destroy(this);
        Destroy(gameObject, 3f);
    }

}
