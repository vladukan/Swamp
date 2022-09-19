using UnityEngine;
using System.Collections.Generic;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _trans;
    protected Player Target { get; set; }
    public void Enter(Player target)
    {
        if (!enabled)
        {
            Target = target;
            enabled = true;
            foreach (var el in _trans)
            {
                el.enabled = true;
                el.Init(target);
            }
        }
    }
    public State GetNextState()
    {
        foreach (var el in _trans)
        {
            if (el.NeedTransit) return el.TargetState;
        }
        return null;
    }
    public void Exit()
    {
        if (enabled)
        {
            foreach (var el in _trans) el.enabled = false;
            enabled = false;
        }
    }
}
