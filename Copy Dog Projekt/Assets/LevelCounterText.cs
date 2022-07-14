using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounterText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Level " + PlayerStats.reachedLevel.ToString();

        Destroy(gameObject, 0.9f);
    }

}
