using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Slider _sliderSlowly;
    [SerializeField] private TextMeshProUGUI _textSlowly;

    private char _symbol = '/';
    private Coroutine _changeValueSlowly;

    private void Start()
    {
        _text.text = _health.CurrentHealth.ToString() + _symbol + _health.MaxHealth.ToString();
        _textSlowly.text = _health.CurrentHealth.ToString() + _symbol + _health.MaxHealth.ToString();
    }

    private void OnEnable()
    {
        _health.HealthChanged += ChangeValue;
        _health.HealthChanged += ChangeValueSlowly;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeValue;
        _health.HealthChanged -= ChangeValueSlowly;
        
        StopChangeValueSlowly();
    }

    public void ChangeValue()
    {
        _text.text = _health.CurrentHealth.ToString() + _symbol + _health.MaxHealth.ToString();
        _slider.value = (float)_health.CurrentHealth / _health.MaxHealth;
    }

    public void ChangeValueSlowly()
    {
        StopChangeValueSlowly();
        float targetValue = (float)_health.CurrentHealth / _health.MaxHealth;
        _changeValueSlowly = StartCoroutine(SlowlyShiftValues(targetValue));
    }

    private void StopChangeValueSlowly()
    {
        if (_changeValueSlowly != null)
            StopCoroutine(_changeValueSlowly);
    }

    private IEnumerator SlowlyShiftValues(float targetValue)
    {
        float step = 0.1f;

        while (_sliderSlowly.value != targetValue)
        {
            _sliderSlowly.value = Mathf.MoveTowards(_sliderSlowly.value, targetValue, step * Time.deltaTime);
            _textSlowly.text = Mathf.Round(_sliderSlowly.value * _health.MaxHealth).ToString() + _symbol + _health.MaxHealth.ToString();
            yield return null;
        }
    }
}