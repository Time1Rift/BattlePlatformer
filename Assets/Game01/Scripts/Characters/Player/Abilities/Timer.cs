using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Timer : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }

    public void OnSwitch(float cooldown)
    {
        float startValue = 1;
        float endValue = 0;

        _image.fillAmount = startValue;
        StartCoroutine(LaunchCooldown(startValue, endValue, cooldown, Destroy));
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
    }

    private IEnumerator LaunchCooldown(float startValue, float endValue, float cooldown, Action<float> endChanges)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed <= cooldown)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / cooldown);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }

        endChanges?.Invoke(endValue);
    }
}