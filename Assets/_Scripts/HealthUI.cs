using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    int CachedMaxHealth;

    public void UpdateSlider(int newHealthValue)
    {
        _slider.value = newHealthValue;
        if (_text != null)
        {
            _text.text = $"{newHealthValue} / {CachedMaxHealth}";
        }
        
    }

    public void UpdateMaxHealth(int newHealthMax)
    {
        CachedMaxHealth = newHealthMax;
        _slider.maxValue = CachedMaxHealth;
        UpdateSlider(_playerHealth.CurrentHealth);
    }

    private void Start()
    {
        CachedMaxHealth = _playerHealth.MaxHealth;
        UpdateSlider(_playerHealth.CurrentHealth);
    }

}
