using UnityEngine;
using TMPro;

public class LevelCounterText : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Level " + PlayerStats.reachedLevel.ToString();

        Destroy(gameObject, 0.9f);
    }
}
