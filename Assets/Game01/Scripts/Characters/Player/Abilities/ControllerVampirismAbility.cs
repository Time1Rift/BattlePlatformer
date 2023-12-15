using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControllerVampirismAbility : MonoBehaviour
{
    [SerializeField] private Button _button;

    private VampirismAbility _vampirismAbility;
    private float _abilityDuration = 6f;
    private float _abilityCooldown = 10f;
    private Coroutine _launchCooldown;

    private void Awake()
    {
        _vampirismAbility = GetComponentInChildren<VampirismAbility>();
        _vampirismAbility.gameObject.SetActive(false);
    }

    public void OnClickAbility()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            _launchCooldown = StartCoroutine(LaunchCooldown());
    }

    private IEnumerator LaunchCooldown()
    {
        WaitForSecondsRealtime abilityDuration = new WaitForSecondsRealtime(_abilityDuration);
        WaitForSecondsRealtime abilityCooldown = new WaitForSecondsRealtime(_abilityCooldown);

        _button.interactable = false;
        _vampirismAbility.gameObject.SetActive(true);

        yield return abilityDuration;
        _vampirismAbility.gameObject.SetActive(false);

        yield return abilityCooldown;
        _button.interactable = true;
    }
}