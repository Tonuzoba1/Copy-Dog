using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupDestroy : MonoBehaviour
{
    public float floatUpSpeed = 3f;
    public float floatSideSpeed;
    public float damage;

    //ez maga a szöveg - nem a TMP UGUI az nem működik
    public TextMeshPro popUpText;

    void Start()
    {
        popUpText = GetComponent<TextMeshPro>();
        StartCoroutine(countdown());
        RandomSideSpeed();

    }

    void Update()
    {
        transform.position += new Vector3(floatSideSpeed, floatUpSpeed) * Time.deltaTime;

        if (floatSideSpeed >= 0)
        {
            floatSideSpeed += 0.03f;
        }
        else
        {
            floatSideSpeed -= 0.03f;
        }
        popUpText.alpha -= 0.02f;
    }

    IEnumerator countdown()
    {
        WaitForSeconds wfs = new WaitForSeconds(1f);

        yield return wfs;

        Destroy(gameObject);

    }

    public void setPopupText(float damage)
    {
        popUpText.text = damage.ToString();
    }

    private void RandomSideSpeed()
    {
        floatSideSpeed = Random.Range(-0.3f, 0.3f);

    }
}
