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
        int coins = Mathf.RoundToInt(PlayerStats.playerCoins);
        coinText.text = PlayerStats.playerCoins.ToString("F0");
    }
}
