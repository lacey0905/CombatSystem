using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFSM : MonoBehaviour
{
    HeroManager manager;
    public HeroManager Manager
    {
        get { return manager; }
    }

    public virtual void OnEnter(HeroManager _manager)
    {
        this.manager = _manager;
    }
    public virtual void OnExit(HeroManager _manager)
    {
        this.manager = _manager;
    }
    public virtual void OnUpdate() { }
}
