using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeBehav : MonoBehaviour
{
    public GameObject upgradePanel;

    public Image swordsman;
    public Image spearman;
    public Image cavarly;
    public Image knight;
    public Image mage;


    public TextMeshProUGUI allyName;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI speed;

    public bool[] selectedCharacter = new bool[5];
    public int selectedIndex;

    public Image updateImg;
    public TextMeshProUGUI cost;

    void Awake()
    {
        if (!PlayerStats.isInited)
        {
            PlayerStats.swordsmanPowerup = 1;
            PlayerStats.spearmanPowerup = 1;
            PlayerStats.cavarlyPowerup = 1;
            PlayerStats.armoredKnightPowerup = 1;
            PlayerStats.magePowerup = 1;

            PlayerStats.allyStats[0] = PlayerStats.swordsman;
            PlayerStats.allyStats[1] = PlayerStats.spearman;
            PlayerStats.allyStats[2] = PlayerStats.cavarly;
            PlayerStats.allyStats[3] = PlayerStats.knight;
            PlayerStats.allyStats[4] = PlayerStats.mage;

            //PlayerStats.playerCoins = 100;

            PlayerStats.isInited = true;
        }
    }

    public void swordmanSelected()
    {
        EnableUpgradePanel();

        //kiveszi az előző kiválasztottat
        for (int i = 0; i < selectedCharacter.Length; i++)
        {
            selectedCharacter[i] = false;
        }

        selectedIndex = 0;

        updateImg.sprite = swordsman.sprite;
        updateImg.SetNativeSize();
        cost.text = PlayerStats.allyStats[0].cost.ToString() + " Coin";

        Debug.Log(PlayerStats.allyStats[0].cost);
        StatUpdater(PlayerStats.allyStats[0]);

        selectedCharacter[0] = true;
    }

    public void spearmanSelected()
    {
        EnableUpgradePanel();

        for (int i = 0; i < selectedCharacter.Length; i++)
        {
            selectedCharacter[i] = false;
        }

        selectedIndex = 1;

        updateImg.sprite = spearman.sprite;
        updateImg.SetNativeSize();
        cost.text = PlayerStats.allyStats[1].cost.ToString() + " Coin";

        Debug.Log(PlayerStats.allyStats[1].cost);
        StatUpdater(PlayerStats.allyStats[1]);


        selectedCharacter[1] = true;
    }

    public void cavarlySelected()
    {
        EnableUpgradePanel();

        for (int i = 0; i < selectedCharacter.Length; i++)
        {
            selectedCharacter[i] = false;
        }

        selectedIndex = 2;

        updateImg.sprite = cavarly.sprite;
        updateImg.SetNativeSize();
        cost.text = PlayerStats.allyStats[2].cost.ToString() + " Coin";

        StatUpdater(PlayerStats.allyStats[2]);

        selectedCharacter[2] = true;
    }

    public void knightSelected()
    {
        EnableUpgradePanel();

        for (int i = 0; i < selectedCharacter.Length; i++)
        {
            selectedCharacter[i] = false;
        }

        selectedIndex = 3;

        updateImg.sprite = knight.sprite;
        updateImg.SetNativeSize();
        cost.text = PlayerStats.allyStats[3].cost.ToString() + " Coin";

        StatUpdater(PlayerStats.allyStats[3]);

        selectedCharacter[3] = true;
    }

    public void mageSelected()
    {
        EnableUpgradePanel();

        for (int i = 0; i < selectedCharacter.Length; i++)
        {
            selectedCharacter[i] = false;
        }

        selectedIndex = 4;

        updateImg.sprite = mage.sprite;
        updateImg.SetNativeSize();
        cost.text = PlayerStats.allyStats[4].cost.ToString() + " Coin";

        StatUpdater(PlayerStats.allyStats[4]);

        selectedCharacter[4] = true;
    }

    public void StatUpdater(PlayerStats.Ally ally)
    {
        allyName.text = ally.name;
        hp.text = ally.hp.ToString();
        attack.text = ally.attack.ToString();
        speed.text = ally.hitSpeed.ToString("F2");
        cost.text = ally.cost.ToString();

       }

    public void UpgradeBtn()
    {
        if((PlayerStats.playerCoins - PlayerStats.allyStats[selectedIndex].cost) >= 0)
        {
            PlayerStats.allyStats[selectedIndex].hp += 1;
            PlayerStats.allyStats[selectedIndex].attack += 0.5f;
            PlayerStats.allyStats[selectedIndex].hitSpeed -= 0.001f;


            PlayerStats.playerCoins -= PlayerStats.allyStats[selectedIndex].cost;
            PlayerStats.allyStats[selectedIndex].cost += 5;
        }

        StatUpdater(PlayerStats.allyStats[selectedIndex]);
        Debug.Log(PlayerStats.playerCoins);
    }
        
    public void EnableUpgradePanel()
    {
        if(upgradePanel.activeSelf == false)
        {
            upgradePanel.SetActive(true);
        }
    }

    

}



