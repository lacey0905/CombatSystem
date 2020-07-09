using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFSMMove : HeroFSM
{
    public override void OnEnter(HeroManager _manager)
    {
        base.OnEnter(_manager);
        Manager.Anim.SetBool("Move", true);
    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        Manager.Anim.SetBool("Move", false);
    }

    public float speed;
    public float rotSpeed;

    public override void OnUpdate()
    {
        base.OnUpdate();

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Manager.Anim.SetFloat("movementX", movement.x);
        Manager.Anim.SetFloat("movementY", movement.y);

        if (movement.y != 0f)
        {
            transform.position += Manager.Camera.forward * movement.y * speed * Time.deltaTime;
            Quaternion newRot = Quaternion.LookRotation(Manager.Camera.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * rotSpeed);
        }

        if (movement.x != 0f)
        {
            transform.position += Manager.Camera.right * movement.x * speed * Time.deltaTime;
            Quaternion newRot = Quaternion.LookRotation(Manager.Camera.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * rotSpeed);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Manager.SetState(State.Attack);
        }

        if (movement.x == 0f && movement.y == 0f)
        {
            Manager.SetState(State.Idle);
        }

    }
}
