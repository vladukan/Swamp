using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    private void Update()
    {
        print("speed");
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}
