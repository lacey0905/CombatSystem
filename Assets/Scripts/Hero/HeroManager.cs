using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle = 0,
    Move,
    Attack
}

public class HeroManager : MonoBehaviour
{
    [SerializeField]
    State currentState;

    public List<HeroFSM> stateList = new List<HeroFSM>();
    Dictionary<int, HeroFSM> stateDic = new Dictionary<int, HeroFSM>();

    Animator anim;
    public Animator Anim { get { return anim; } }

    bool isStart = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        for (int i = 0; i < stateList.Count; i++)
        {
            stateDic.Add(i, stateList[i]);
        }
        SetState(State.Idle);
    }

    private void Update()
    {
        stateDic[(int)currentState].OnUpdate();
    }

    public void SetState(State newState)
    {
        if(isStart)
        {
            stateDic[(int)currentState].OnExit(this);
        }
        else
        {
            isStart = true;
        }
        stateDic[(int)newState].OnEnter(this);
        currentState = newState;
    }
}
