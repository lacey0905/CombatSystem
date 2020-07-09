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
        NextMostion(currentMostionType);
    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        isMostionContinue = false;
        currentMostionType = 1;
        currentMostionTime = 0f;
        Manager.Anim.SetBool("Attack", false);
        Manager.Anim.SetInteger("AttackMotion", 0);
    }

    float endMotionTimer = 1.0f;
    float currentMostionTime = 0f;
    bool isMostionContinue;
    int maxMotionType = 3;
    int currentMostionType;

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (currentMostionTime < endMotionTimer)
        {
            currentMostionTime += Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && currentMostionType < maxMotionType)
            {
                isMostionContinue = true;
            }
        }
        else if(!isMostionContinue && currentMostionTime > endMotionTimer)
        {
            Manager.SetState(State.Idle);
        }

        if(isMostionContinue && currentMostionTime > 0.5f)
        {
            currentMostionType++;
            NextMostion(currentMostionType);
            isMostionContinue = false;
        }

    }

    // 다음 모션이 실행 되면 모션 예약을 받을 수 있도록 레디 상태로 변경
    public void SetMostionReady()
    {
        currentMostionTime = 0f;
    }

    public void NextMostion(int motion)
    {
        Manager.Anim.SetInteger("AttackMotion", motion);
    }

}
