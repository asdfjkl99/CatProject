/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                              Map UI Manager Class                               //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * MapUIMgr Class
 * 
 * This class manage Map scene UI.
 * Can display buttons, images and text.
 * 
 * Changes
 * 
 * 190812 Namhun Kim
 * Write _mapUI, _icon, _desc, Initialize(), UseItemEventUI(), MoneyEventUI(), OnTouchReturnBtn()
 **/
public class MapUIMgrCls : MonoBehaviour
{
    // UI Object
    //
    private GameObject _mapUI; // UI manager
    public Image _icon; // Icon UI
    public Text _desc; // Text UI

    // Singleton
    //
    public static MapUIMgrCls _instance = null;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
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
        _mapUI = GameObject.Find("MapUIMgr");

        if (_mapUI == null)
            Debug.Log("Can't find MapUIMgr Object");
        else
            _mapUI.SetActive(false);
    }


/////////////////////////////////////////////////////////////////////////////////////
//                                 Event Function                                  //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190812 Namhun Kim
     * 
     * public void UseItemEventUI()
     * 
     * If events is getting use item event, Event class give information.
     * This function receieves informations and display information on screen.
     * 
     * @param    int __category   Item category that food item or toy item.
     *           int __no         Got item's no
     *           
     * @return   void
     **/
    public void UseItemEventUI(int __category, int __no)
    {
        string __name = CommClientDBCls._instance.GetName(__category, __no);

        // Item icon Load On Client DB
        //

        // Update Text
        _desc.text = "축하합니다! " + __name + "을 획득하셨습니다!";

        _mapUI.SetActive(true);
    }

    /**
     * 190812 Namhun Kim
     * 
     * public void MoneyEventUI()
     * 
     * If events is getting money event, Event class give information.
     * This function receieves informations and display information on screen.
     * 
     * @param    float __money   Got money amount.
     *           
     * @return   void
     **/
    public void MoneyEventUI(float __money)
    {
        // Item icon Load On Client DB
        //

        // Update Text
        _desc.text = "축하합니다! 현금 " + __money + "원을 획득하셨습니다!";

        _mapUI.SetActive(true);
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                Button Function                                  //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190812 Namhun Kim
     * 
     * public void OnTouchReturnBtn()
     * 
     * If Return Button touched by user, this function calls.
     * Go back to map screen
     * 
     * @param    void
     *
     * @return   void
     **/
    public void OnTouchReturnBtn()
    {
        _mapUI.SetActive(false);
    }
}

