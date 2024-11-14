using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, SLEEP
    };

    public enum EVENT
    {
        ENTER, UPDATE,EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;
    
    float vishDist = 10.0f;
    float vishAngle = 30.0f;
    float shootDist = 7.0f;

    public  State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        anim = _anim;
        player = _player;
        agent = _agent;
        stage = EVENT.ENTER;
    }
    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}
