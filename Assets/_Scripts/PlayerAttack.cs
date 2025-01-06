using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;


    public event Action OnStartAttack;
    public event Action OnStopAttack;

    bool _onTriggerWithEntityHealth = false;
    GameObject _objectWithEntityHealth = null;

    [SerializeField, Range(0, 100)]
    int _valueDamage;


    private void Start()
    {
        _attack.action.started += StartAttack;
        _attack.action.canceled += StopAttack;
    }
    private void OnDestroy()
    {
        _attack.action.started -= StartAttack;
        _attack.action.canceled -= StopAttack;
    }

    private void StartAttack(InputAction.CallbackContext obj)
    {
        OnStartAttack?.Invoke();
        if (_onTriggerWithEntityHealth && _objectWithEntityHealth != null)
        {
            _objectWithEntityHealth.GetComponent<EntityHealth>().TakeDamage(_valueDamage);
        }
    }

    private void StopAttack(InputAction.CallbackContext obj)
    {
        OnStopAttack?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EntityHealth>())
        {
            _onTriggerWithEntityHealth = true;
            _objectWithEntityHealth = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _onTriggerWithEntityHealth = false;
        _objectWithEntityHealth = null;
    }
}
