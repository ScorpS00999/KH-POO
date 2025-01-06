using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] int _degats = 10;

    EntityHealth _health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<EntityHealth>() != null)
        {
            print(_degats);
            _health = other.gameObject.GetComponentInParent<EntityHealth>();
            StartCoroutine(Damage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(Damage());
        _health = null;
    }

    IEnumerator Damage()
    {
        while (true)
        {
            _health?.TakeDamage(_degats);
            yield return new WaitForSeconds(1.5f);
        }
    }


}
