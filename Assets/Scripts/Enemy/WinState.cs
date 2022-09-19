using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WinState : State
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _animator.Play("Win");
    }
    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
