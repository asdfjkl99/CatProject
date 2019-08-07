using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public GameObject BuyUI;
    public Button buybutton;
    public Button cancelbutton;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        BuyUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
