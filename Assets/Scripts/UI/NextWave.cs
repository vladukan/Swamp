using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextBtn;
    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextBtn.onClick.AddListener(OnNextBtnWaveClick);
    }
    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextBtn.onClick.RemoveListener(OnNextBtnWaveClick);
    }
    private void OnAllEnemySpawned()
    {
        _nextBtn.gameObject.SetActive(true);
    }
    public void OnNextBtnWaveClick()
    {
        _spawner.NextWave();
        _nextBtn.gameObject.SetActive(false);
    }

}
