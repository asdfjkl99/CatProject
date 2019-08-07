using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMgr : MonoBehaviour
{
    public GameObject BuyUI;
    public Button buybutton;
    public Button cancelbutton;

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
