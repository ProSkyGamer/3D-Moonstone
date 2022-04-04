using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    public GameObject PuzzleInt;
    public GameObject swiping;
    public GameObject interface_menu;
    public void OnPointerClick(PointerEventData eventData)
    {
        PuzzleInt.SetActive(true);
        swiping.SetActive(false);
        interface_menu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
