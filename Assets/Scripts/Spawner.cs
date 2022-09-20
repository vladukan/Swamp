using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPoint;
    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;
    private Wave _currentWave;
    private int _currentNumWave = 0;
    private float _timeLastWave;
    private int _spawned;
    private void Start()
    {
        _spawnPoint = transform;
        SetWave(_currentNumWave);
    }
    private void Update()
    {
        if (_currentWave == null) return;
        _timeLastWave += Time.deltaTime;
        if (_timeLastWave >= _currentWave.Delay)
        {
            InitEnemy();
            _spawned++;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            _timeLastWave = 0;
        }
        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentNumWave + 1) AllEnemySpawned?.Invoke();
            _currentWave = null;
        }
    }
    private void InitEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.DieEnemy += OnEnemyDied;
    }
    private void OnEnemyDied(Enemy enemy)
    {
        enemy.DieEnemy -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
    }
    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }
    public void NextWave()
    {
        SetWave(++_currentNumWave);
        _spawned = 0;
    }
}
[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
