using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    private Player _target;
    public event UnityAction<Enemy> DieEnemy;
    public Player Target => _target;
    public int Reward => _reward;
    public void Init(Player target)
    {
        _target = target;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            DieEnemy?.Invoke(this);
            Destroy(gameObject);
        }
    }

}
