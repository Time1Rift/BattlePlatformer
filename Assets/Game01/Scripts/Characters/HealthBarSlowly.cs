using System.Collections;
using UnityEngine;

public class HealthBarSlowly : HealthBar
{
    private Coroutine _changeValueSlowly;

    protected override void OnDisable()
    {
        base.OnDisable();
        StopChangeValueSlowly();
    }

    protected override void ChangeValue()
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

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, step * Time.deltaTime);
            _text.text = Mathf.Round(_slider.value * _health.MaxHealth).ToString() + _symbol + _health.MaxHealth.ToString();
            yield return null;
        }
    }
}