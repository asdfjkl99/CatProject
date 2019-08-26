using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIMgr : ItemInfoCls
{
    public GameObject itemInfo;
    public GameObject buyPopUp;
    public Text itemCount;
    public Button increase;
    public Button decrease;
    int num = 1;


    // Start is called before the first frame update
    void Start()
    {
        itemInfo.SetActive(false);
        buyPopUp.SetActive(false);
    }

    void Update()
    {
        itemCount.text = num.ToString();
    }

    public void IncreaseOnClick()
    {
        num++;
    }

    public void DecreaseOnClick()
    {
        if (num > 1)
            num--;
    }
}
