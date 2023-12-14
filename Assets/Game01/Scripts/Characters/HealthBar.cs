using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected TextMeshProUGUI _text;

    protected char _symbol = '/';

    protected void Start()
    {
        _text.text = _health.CurrentHealth.ToString() + _symbol + _health.MaxHealth.ToString();
    }

    protected void OnEnable()
    {
        _health.HealthChanged += ChangeValue;
    }

    protected virtual void OnDisable()
    {
        _health.HealthChanged -= ChangeValue;
    }

    protected virtual void ChangeValue()
    {
        _text.text = _health.CurrentHealth.ToString() + _symbol + _health.MaxHealth.ToString();
        _slider.value = (float)_health.CurrentHealth / _health.MaxHealth;
    }
}