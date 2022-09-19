using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _range;
    [SerializeField] private float _spread;
    private void Start()
    {
        _range += Random.Range(-_spread, _spread);
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _range)
            NeedTransit = true;
    }
}
