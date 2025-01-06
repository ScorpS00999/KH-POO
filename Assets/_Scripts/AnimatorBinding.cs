using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField, Required] Animator _animator;

    //[SerializeField, Required] GameObject _player;

    [SerializeField, Required] PlayerMove _move;
    [SerializeField, Required] PlayerAttack _attack;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] string _isWalkingBoolParam;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] string _isDyingBoolParam;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Trigger)]
    [SerializeField] string _attackTriggerParam;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Trigger)]
    [SerializeField] string _hurtTriggerParam;

    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponentInParent<PlayerMove>();
        _attack = GetComponentInParent<PlayerAttack>();

        _isWalkingBoolParam = "Walking";
        _isDyingBoolParam = "Dying";

        _attackTriggerParam = "Attack";
        _hurtTriggerParam = "GetHit";
    }


    private void Start()
    {
        _move.OnStartMove += _move_OnStartMove;
        _move.OnStopMove += _move_OnStopMove;

        _attack.OnStartAttack += _attack_OnStartAttack;

        //_entityHealth.OnDie += _entityHealth_OnDying;
    }

    private void _move_OnStartMove()
    {
        _animator.SetBool(_isWalkingBoolParam, true);
    }

    private void _move_OnStopMove()
    {
        _animator.SetBool(_isWalkingBoolParam, false);
    }

    public void EntityHealth_OnDying()
    {
        _animator.SetBool(_isDyingBoolParam, true);
    }

    private void _attack_OnStartAttack()
    {
        _animator.SetTrigger(_attackTriggerParam);
    }

    public void EntityHealth_OnHurt()
    {
        _animator.SetTrigger(_hurtTriggerParam);
    }

}
