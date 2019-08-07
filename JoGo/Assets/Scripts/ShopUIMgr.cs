using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIMgr : MonoBehaviour
{
    short num;
    public Text ScriptTxt;
    public Button increase;
    public Button decrease;
    bool incFlag;
    bool decFlag;

    // Start is called before the first frame update
    void Start()
    {
        num = 1;
        ScriptTxt.text = num.ToString();
        incFlag = false;
        decFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (incFlag)
        {
            ++num;
            incFlag = false;
        }

        if (decFlag)
        {
            if(num > 1)
                --num;

            decFlag = false;
        }

        ScriptTxt.text = num.ToString();
    }

    public void IncreaseOnClick()
    {
        incFlag = true;
    }

    public void DecreaseOnClick()
    {
        decFlag = true;
    }
}
