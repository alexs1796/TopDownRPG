using UnityEngine;
using TMPro;

public class WaveCounterUI : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private TextMeshProUGUI waveNumberText;

    void Start()
    {
        UpdateWaveUI(enemySpawner.CurrentWave);
    }
   
    private void OnEnable()
    {
        enemySpawner.WaveChanged += UpdateWaveUI;
    }

    private void OnDisable()
    {
        enemySpawner.WaveChanged -= UpdateWaveUI;
    }

    private void UpdateWaveUI(int currentWave)
    {
        //Debug.Log($"Current Wave: {currentWave}");

        waveNumberText.text = $"Wave: {currentWave}";
    }
}
