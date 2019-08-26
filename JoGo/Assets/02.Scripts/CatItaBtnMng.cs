﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatItaBtnMng : MonoBehaviour
{
    private int btnCount = 0;
    private GameObject catItaBtn;
    private GameObject mainBtnUI;
    private CatClickCls catCountMng;

    public GameObject itemListUI;
    public GameObject itemDescUI;
    public GameObject catInfoUI;
    public GameObject feedingBtn;
    public GameObject playingBtn;
    public GameObject walkingBtn;
    public GameObject informationBtn;
    public GameObject catInfoBackBtn;

    public void OnTouchFeedingtBtn()
    {
        Debug.Log("Touch Feeding Btn");
        btnCount++;
        if(btnCount%2 == 1)
        {
            //feedingBtn.SetActive(false);
            playingBtn.SetActive(false);
            walkingBtn.SetActive(false);
            informationBtn.SetActive(false);
            itemListUI.SetActive(true);
            mainBtnUI.SetActive(false);
        }
        else
        {
            if(itemDescUI.active || itemListUI.active)
            {
                itemListUI.SetActive(false);
                itemDescUI.SetActive(false);
            }
            //feedingBtn.SetActive(true);
            playingBtn.SetActive(true);
            walkingBtn.SetActive(true);
            informationBtn.SetActive(true);
        }
        
    }
    public void OnTouchPlayingtBtn()
    {
        Debug.Log("Touch Playing Btn");
        btnCount++;
        if (btnCount % 2 == 1)
        {
            feedingBtn.SetActive(false);
            //playingBtn.SetActive(false);
            walkingBtn.SetActive(false);
            informationBtn.SetActive(false);
            itemListUI.SetActive(true);
            mainBtnUI.SetActive(false);
        }
        else
        {
            if (itemDescUI.active || itemListUI.active)
            {
                itemListUI.SetActive(false);
                itemDescUI.SetActive(false);
            }
            feedingBtn.SetActive(true);
            //playingBtn.SetActive(true);
            walkingBtn.SetActive(true);
            informationBtn.SetActive(true);
        }

    }
    public void OnTouchWalkingtBtn()
    {
        Debug.Log("Touch Walking Btn");
        btnCount++;
        if (btnCount % 2 == 1)
        {
            feedingBtn.SetActive(false);
            playingBtn.SetActive(false);
            //walkingBtn.SetActive(false);
            informationBtn.SetActive(false);
        }
        else
        {
            feedingBtn.SetActive(true);
            playingBtn.SetActive(true);
            //walkingBtn.SetActive(true);
            informationBtn.SetActive(true);
        }

    }
    public void OnTouchInformationingtBtn()
    {
        Debug.Log("Touch Infomationing Btn");
        btnCount++;
        if (btnCount % 2 == 1)
        {
            feedingBtn.SetActive(false);
            playingBtn.SetActive(false);
            walkingBtn.SetActive(false);
            // informationBtn.SetActive(false);
            catInfoUI.SetActive(true);
            mainBtnUI.SetActive(false);
        }
        else
        {
            feedingBtn.SetActive(true);
            playingBtn.SetActive(true);
            walkingBtn.SetActive(true);
            //informationBtn.SetActive(true);
        }

    }
    public void OnTouchItemSelectBtn()
    {
        itemListUI.SetActive(false);
        itemDescUI.SetActive(true);
       
    }
    public void OnTouchItemUseBtn()
    {
        itemDescUI.SetActive(false);
        
        catItaBtn.SetActive(false);
        mainBtnUI.SetActive(true);
        catCountMng.catUICount++;

    }
    public void OnTouchCatInfoBackBtn()
    {
        catInfoUI.SetActive(false);
        catItaBtn.SetActive(false);
        mainBtnUI.SetActive(true);
        catCountMng.catUICount++;
    }
    /*public void OnTouchCatByeBtn()
    {
        
    }*/

    private void OnEnable()
    {
        feedingBtn.SetActive(true);
        playingBtn.SetActive(true);
        walkingBtn.SetActive(true);
        informationBtn.SetActive(true);
        btnCount = 0;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        catItaBtn = GameObject.Find("CatIta");
        mainBtnUI = GameObject.Find("MainUIMgr");
        catCountMng = GameObject.Find("CatUICanvas").GetComponent<CatClickCls>();
    }


    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
