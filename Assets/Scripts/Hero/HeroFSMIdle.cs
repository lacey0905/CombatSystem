using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFSMIdle : HeroFSM
{
    public override void OnEnter(HeroManager _manager)
    {
        base.OnEnter(_manager);
        Manager.Anim.SetBool("Idle", true);
    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        Manager.Anim.SetBool("Idle", false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetMouseButtonDown(0))
        {
            Manager.SetState(State.Attack);
        }
        else if(movement.x != 0f || movement.y != 0f)
        {
            Manager.SetState(State.Move);
        }
    }
}
