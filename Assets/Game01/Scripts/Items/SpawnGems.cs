using UnityEngine;

public class SpawnGems : MonoBehaviour
{
    [SerializeField] private Gem _gem;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            Instantiate(_gem, transform.GetChild(i).position, Quaternion.identity);
    }
}