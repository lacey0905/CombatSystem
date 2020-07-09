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
        Manager.Anim.SetInteger("AttackMotion", 1);
        atkMode = 0;
    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        Manager.Anim.SetBool("Attack", false);
        Manager.Anim.SetInteger("AttackMotion", 0);
    }

    int atkMode;
    bool reserve = false;
    bool isLoop = true;
    float timer = 0f;

    public override void OnUpdate()
    {
        base.OnUpdate();

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (atkMode == 0)
        {
            if(isLoop)
            {
                timer += Time.deltaTime;
                look = timer < 0.2f;
                if (Input.GetMouseButtonDown(0))
                {
                    reserve = true;
                }
                else if (reserve && timer > 0.5f)
                {
                    isLoop = false;
                    reserve = false;
                    Manager.Anim.SetInteger("AttackMotion", 2);
                }
                else if (timer > 1.0f)
                {
                    isLoop = false;
                    if(movement.x != 0f || movement.y != 0f)
                    {
                        Manager.SetState(State.Move);
                    }
                    else
                    {
                        Manager.SetState(State.Idle);
                    }
                }
            }
        }
        else if (atkMode == 1)
        {
            
            if (isLoop)
            {
                timer += Time.deltaTime;
                look = timer < 0.2f;
                move = timer < 0.4f;
                if (Input.GetMouseButtonDown(0))
                {
                    reserve = true;
                }
                else if (reserve && timer > 0.5f)
                {
                    isLoop = false;
                    reserve = false;
                    Manager.Anim.SetInteger("AttackMotion", 3);
                }
                else if (timer > 1.0f)
                {
                    isLoop = false;
                    if (movement.x != 0f || movement.y != 0f)
                    {
                        Manager.SetState(State.Move);
                    }
                    else
                    {
                        Manager.SetState(State.Idle);
                    }
                }
            }
        }
        else if (atkMode == 2)
        {
            if (isLoop)
            {
                timer += Time.deltaTime;
                look = timer < 0.2f;
                move = timer < 0.7f;
                if (timer > 1.0f)
                {
                    isLoop = false;
                    if (movement.x != 0f || movement.y != 0f)
                    {
                        Manager.SetState(State.Move);
                    }
                    else
                    {
                        Manager.SetState(State.Idle);
                    }
                }
            }
        }

        if(look)
        {
            Quaternion newRot = Quaternion.LookRotation(Manager.Camera.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * 20f);
        }
        if(move)
        {
            transform.position += Manager.Camera.forward * 2f * Time.deltaTime;
        }
    }

    bool move = false;
    bool look = false;

    public void Atk1()
    {
        atkMode = 0;
        reserve = false;
        isLoop = true;
        timer = 0f;
        look = true;
        move = false;
    }

    public void Atk2()
    {
        atkMode = 1;
        reserve = false;
        isLoop = true;
        timer = 0f;
        look = true;
        move = true;
    }

    public void Atk3()
    {
        atkMode = 2;
        reserve = false;
        isLoop = true;
        timer = 0f;
        look = true;
        move = true;
    }

}
