using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;

    private bool stateChanged = false;

    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
        stateChanged = false;
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }


    public override void Exit()
    {
        if (!stateChanged)
        {
            stateChanged = true;
            Machine.ChangeState(StateType.Idle);
            Debug.Log("기본상태로변경");
        }
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            if (col.GetComponent<IDamagable>() == null) return;
            damagable = col.GetComponent<IDamagable>();
            damagable.TakeHit(Controller.AttackValue);
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        Attack();
        yield return _wait;

        Exit();
    }

}
