using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupDestroy : MonoBehaviour
{
    public float floatUpSpeed = 3f;
    public float damage;

    //ez maga a szöveg - nem a TMP UGUI az nem működik
    public TextMeshPro popUpText;

    void Start()
    {
        popUpText = GetComponent<TextMeshPro>();
        StartCoroutine(countdown());

    }

    void Update()
    {
        transform.position += new Vector3(0, floatUpSpeed) * Time.deltaTime;    
    }

    IEnumerator countdown()
    {
        WaitForSeconds wfs = new WaitForSeconds(1f);

        yield return wfs;

        Destroy(gameObject);

    }

    public void setPopupText(int damage)
    {
        popUpText.text = damage.ToString();
    }

}
