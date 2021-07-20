using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    public void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        CountCoins();
    }

    public void CountCoins()
    {
        coinText.text = PlayerStats.playerCoins.ToString();
    }
}
