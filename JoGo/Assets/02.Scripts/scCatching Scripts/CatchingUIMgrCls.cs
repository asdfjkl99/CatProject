/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                           Catching UI Manager Class                             //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * CatchingUIMgr Class
 * 
 * This class manage Catching scene UI.
 * Can display buttons, images and text.
 * 
 * Changes
 * 
 * 190812 Namhun Kim
 * Write _mainUI, _itemListUI, _itemDescUI, Initialize(), OnTouchFoodBtn(), OnTouchToyBtn(), OnTouchSwitchModbtn(), OnTouchReturnBtn(), OnTouchItemBtn(), OnTouchUseBtn()
 **/
public class CatchingUIMgrCls : MonoBehaviour
{
    // UI Object
    //
    private GameObject mainUI;
    private GameObject itemListUI;
    private GameObject itemDescUI;

    // Singleton
    //
    public static CatchingUIMgrCls _instance = null;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Deactive events
        EventMgrCls._instance.SetEventsActive(false);

        // Init UI
        //
        this.Initialize();
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                   Initialize                                    //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190812 Namhun Kim
     * 
     * private void Initialize()
     * 
     * Initialize member variables.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void Initialize()
    {
        mainUI = GameObject.Find("MainUI");

        if (mainUI == null)
            Debug.Log("Can't find MainUI Object");


        itemListUI = GameObject.Find("ItemUI");

        if (itemListUI == null)
            Debug.Log("Can't find ItemUI Object");
        else
            itemListUI.SetActive(false);


        itemDescUI = GameObject.Find("ItemDescUI");

        if (itemDescUI == null)
            Debug.Log("Can't find ItemDescUI Object");
        else
            itemDescUI.SetActive(false);
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                 Button Function                                 //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190812 Namhun Kim
     * 
     * public void OnTouchFoodBtn()
     * 
     * If user touch food item use button.
     * 
     * @param    void
     * 
     * @return   void
     **/
    public void OnTouchFoodtBtn()
    {
        Debug.Log("Touch Food Btn");

        mainUI.SetActive(false);

        itemListUI.SetActive(true);
    }

    /**
     * 190812 Namhun Kim
     * 
     * public void OnTouchToyBtn()
     * 
     * If user touch toy item use button.
     * 
     * @param    void
     * 
     * @return   void
     **/
    public void OnTouchToyBtn()
    {
        Debug.Log("Touch Toy Btn");

        mainUI.SetActive(false);

        itemListUI.SetActive(true);
    }

    /**
     * 190812 Namhun Kim
     * 
     * public void OnTouchSwitchModBtn()
     * 
     * If user touch switch mod button.
     * Switch mode AR or 3D background.
     * 
     * @param    void
     * 
     * @return   void
     **/
    public void OnTouchSwitchModBtn()
    {
        Debug.Log("Touch Mod Btn");
    }

    /**
     * 190812 Namhun Kim
     * 
     * public void OnTouchReturnBtn()
     * 
     * If user touch return button.
     * 
     * @param    void
     * 
     * @return   void
     **/
    public void OnTouchReturnBtn()
    {
        Debug.Log("Touch Return Btn");

        SceneManager.LoadScene("scMap");

        // Return not destroyed events
        if (EventMgrCls._instance != null)
            EventMgrCls._instance.SetEventsActive(true);
        else
            Debug.Log("Can't find EventManager");

        EventMgrCls._instance.StartCoroutine("DistCheckTimer");
    }

    /**
     * 190812 Namhun Kim
     * 
     * public void OnTouchItemBtn()
     * 
     * If user touch item icon button.
     * 
     * @param    void
     * 
     * @return   void
     **/
    public void OnTouchItemBtn()
    {
        itemListUI.SetActive(false);
        itemDescUI.SetActive(true);
    }

    /**
     * 190812 Namhun Kim
     * 
     * public void OnTouchUseBtn()
     * 
     * If user touch item use button.
     * 
     * @param    void
     * 
     * @return   void
     **/
    public void OnTouchUseBtn()
    {
        itemDescUI.SetActive(false);
        mainUI.SetActive(true);
    }
}
