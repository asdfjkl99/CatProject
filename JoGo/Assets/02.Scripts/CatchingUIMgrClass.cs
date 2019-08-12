//////////////////////////////////////////////////////
//                                                  //
//               CATCHINGUI MANAGER                 //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatchingUIMgrClass : MonoBehaviour
{
    // UI Object
    //
    private GameObject mainUI;
    private GameObject itemListUI;
    private GameObject itemDescUI;

    // Singleton
    //
    public static CatchingUIMgrClass _instance = null;

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
        EventMgrClass._instance.SetEventsActive(false);

        // Init UI
        //
        this.Initialize();
    }

//////////////////////////////////////////////////////
//                   Initialize                     //
//////////////////////////////////////////////////////

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

//////////////////////////////////////////////////////
//                  BUTTON FUNCTION                 //
//////////////////////////////////////////////////////

    public void OnTouchFoodtBtn()
    {
        Debug.Log("Touch Food Btn");

        mainUI.SetActive(false);

        itemListUI.SetActive(true);
    }

    public void OnTouchToyBtn()
    {
        Debug.Log("Touch Toy Btn");

        mainUI.SetActive(false);

        itemListUI.SetActive(true);
    }

    public void OnTouchSwitchModBtn()
    {
        Debug.Log("Touch Mod Btn");
    }

    public void OnTouchReturnBtn()
    {
        Debug.Log("Touch Return Btn");

        // Return not destroyed events
        if (EventMgrClass._instance != null)
            EventMgrClass._instance.SetEventsActive(true);
        else
            Debug.Log("Can't find EventManager");

        SceneManager.LoadScene("scMap");
    }

    public void OnTouchItemBtn()
    {
        itemListUI.SetActive(false);
        itemDescUI.SetActive(true);
    }

    public void OnTouchUseBtn()
    {
        itemDescUI.SetActive(false);
        mainUI.SetActive(true);
    }
}
