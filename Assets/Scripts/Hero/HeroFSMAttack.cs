using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroFSMAttack : HeroFSM
{
    public override void OnEnter(HeroManager _manager)
    {
        base.OnEnter(_manager);
        Manager.Anim.SetBool("Attack", true);

        isContinue = false;
        next = false;
        motion = 1;

        Manager.Anim.SetInteger("AttackMotion", 1);

    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        Manager.Anim.SetBool("Attack", false);
    }

    bool isContinue;
    bool next;
    int motion;

    public override void OnUpdate()
    {
        base.OnUpdate();

        if(Input.GetKeyDown(KeyCode.Z))
        {
            isContinue = true;
        }

        if(next && isContinue)
        {
            if(motion == 1)
            {
                Manager.Anim.SetInteger("AttackMotion", 2);
                motion = 2;
                next = false;
                isContinue = false;
            }
            else if (motion == 2)
            {
                Manager.Anim.SetInteger("AttackMotion", 3);
                motion = 3;
                next = false;
                isContinue = false;
            }
        }

    }

    public void NextMostion()
    {
        next = true;
    }

    public void EndMotion()
    {
        if (!isContinue || motion >= 3)
        {
            Manager.SetState(State.Idle);
            Manager.Anim.SetInteger("AttackMotion", 0);
        }
    }

}
