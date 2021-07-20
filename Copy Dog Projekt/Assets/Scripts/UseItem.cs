using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    public Button item1;
    public CharacterCombat charComb;


    public GameObject healingEffect;

    private void Awake()
    {
        item1 = GetComponent<Button>();
    }

   /* public void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            
            UseItem1();
        }

        if (Input.GetKeyDown("k"))
        {
            
            UseItem2();
        }

        if (Input.GetKeyDown("l"))
        {
            UseItem3();
        }
    }
   */

    public void UseItem1()
    {
        ItemSelector(1);
    }

    public void UseItem2()
    {
        ItemSelector(2);
    }

    public void UseItem3()
    {
        ItemSelector(3);
    }

    public void ItemSelector(int id)
    {
        switch (id)
        {
            case 1:
                {
                    
                    Debug.Log("1-es cucc");
                    break;
                }

            case 2:
                {
                    if (charComb.heroHealth + 20 >= 100 && charComb.heroMana - 10 >= 0)
                    {
                        charComb.heroMana -= 10;
                        charComb.heroHealth = 100;
                        Instantiate(healingEffect, charComb.transform.position, Quaternion.identity);

                    } else if (charComb.heroHealth + 20 < 100 && charComb.heroMana - 10 >= 0)
                    {
                        charComb.heroMana -= 10;
                        charComb.heroHealth += 20;
                        Instantiate(healingEffect, charComb.transform.position, Quaternion.identity);
                    }

                    Debug.Log("2-es cucc");
                    
                    break;
                }

            case 3:
                {
                    Debug.Log("3-as cucc");
                    break;
                }

            default:
                {
                    Debug.Log("Hibás item");
                    break;
                }

        }
    }
}
