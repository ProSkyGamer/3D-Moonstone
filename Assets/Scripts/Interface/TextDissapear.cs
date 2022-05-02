using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDissapear : MonoBehaviour
{
    [SerializeField] private float dis_per_upd = 0.05f;
    private Color standart_color;
    private void Start()
    {
        standart_color = gameObject.GetComponent<Text>().color;
    }
    void Update()
    {
        if (gameObject.activeSelf)
        {
            standart_color.a = gameObject.GetComponent<Text>().color.a - dis_per_upd;
            gameObject.GetComponent<Text>().color = standart_color;
            if (gameObject.GetComponent<Text>().color.a <= 0)
            {
                standart_color.a = 1;
                gameObject.GetComponent<Text>().color = standart_color;
                gameObject.SetActive(false);
            }

        }
    }
    public void OnceMore()
    {
        standart_color.a = 1;
        gameObject.GetComponent<Text>().color = standart_color;
    }
}
