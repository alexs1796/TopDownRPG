using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private RectTransform fill;

    private void OnEnable()
    {
        playerHealth.HealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= UpdateHealthUI;
    }

    private void Start()
    {
        UpdateHealthUI(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }

    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        healthText.text = $"HP: {currentHealth} / {maxHealth}";
    }
}