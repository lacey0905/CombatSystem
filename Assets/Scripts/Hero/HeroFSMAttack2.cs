using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFSMAttack2 : HeroFSM
{
    public override void OnEnter(HeroManager _manager)
    {
        base.OnEnter(_manager);
        Manager.Anim.SetBool("Attack", true);
        Manager.Anim.SetInteger("AttackMotion", 2);
        curTime = 0f;
        isContinue = false;
    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        Manager.Anim.SetBool("Attack", false);
        Manager.Anim.SetInteger("AttackMotion", 0);
    }

    bool isContinue;
    float curTime;

    public override void OnUpdate()
    {
        base.OnUpdate();

        curTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            isContinue = true;
        }

        if (curTime > 0.5f && isContinue)
        {
            Manager.SetState(State.Attack3);
        }
        else if (curTime > 1.0f)
        {
            Manager.SetState(State.Idle);
        }

    }

}
