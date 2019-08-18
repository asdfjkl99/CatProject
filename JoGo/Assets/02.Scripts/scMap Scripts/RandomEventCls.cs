/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                                 Random Event                                    //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/////////////////////////////////////////////////////////////////////////////////////
// 0) Cat Event                                                                    //
// 1) Food Event                                                                   //
// 2) Toy Event                                                                    //
// 3) Money Event                                                                  //
//  ) Stamp Event (From Server)                                                    //
//  ) Festival Event (From Server)                                                 //
/////////////////////////////////////////////////////////////////////////////////////
/**
 * Random Event Class
 * 
 * This class manage each event.
 * Can initialize randomly and use different function each event type.
 * Inheritance from EventCls
 * 
 * Changes
 * 
 * 190812 Namhun Kim
 * Write InitEventInfo(), CatEvent(), UseItemEvent(), MoneyEvent()
 **/
public class RandomEventCls : EventCls
{
    private Transform _playerTr;

    // Start is called before the first frame update
    private void Start()
    {
        InitEventInfo();
        _playerTr = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.GetComponent<Transform>().Rotate(Vector3.up * Time.deltaTime * 300.0f * Input.GetAxis("Mouse Y"));
        }
    }

    /**
     * 190812 Namhun Kim
     * 
     * private void OnMouseUp()
     * 
     * If user touchs event object, parse event type and find right event function.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void OnMouseUp()
    {
        Debug.Log("Event Touch" + _evtType);
        
        // This is cat event
        if (_evtType == 0)
        {
            this.CatEvent();
        }
        // This is getting money event
        else if (_evtType == 1 || _evtType == 2)
        {
            this.UseItemEvent();
        }
        // This is getting toy event
        else if (_evtType == 3)
        {
            this.MoneyEvent();
        }
        // ERROR CODE #
        else
        {
            Debug.Log("Wrong event type.");
        }
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                   Initialize                                    //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190812 Namhun Kim
     * 
     * private void InitEventInfo()
     * 
     * Initialize event information randomize.
     * If receieve message from EventManager, this function starts.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void InitEventInfo()
    {
        // Manage Object active
        int __num = Random.Range(0, 2);
        bool __isAppear;

        if (__num == 0)
            __isAppear = false;
        else
            __isAppear = true;

        this.gameObject.SetActive(__isAppear);

        // Random event type
        _evtType = Random.Range(0, 4);
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                 Event Function                                  //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190812 Namhun Kim
     * 
     * private void CatEvent()
     * 
     * If this event is cat event, load scene to "scCatching".
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void CatEvent()
    {
        EventMgrCls._instance.StopCoroutine("DistCheckTimer");

        SceneManager.LoadScene("scCatching");
    }

    /**
     * 190812 Namhun Kim
     * 
     * private void UseItemEvent()
     * 
     * If this event is getting use item event, create random use item and give information to UI manager.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void UseItemEvent()
    {
        // __no = 0 ~ foodDB or toyDB Max NO + 1 
        int __no = Random.Range(0, CommClientDBCls._instance.GetMaxNo(_evtType));
        
        MapUIMgrCls._instance.UseItemEventUI(_evtType, __no);

        // Upload User Data On Server
        //

        this.gameObject.SetActive(false);
    }

    /**
     * 190812 Namhun Kim
     * 
     * private void MoneyEvent()
     * 
     * If this event is getting money event, create random money and give information to UI manager.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void MoneyEvent()
    {
        int multiply = Random.Range(10, 30);
        int money = 100 * multiply;

        // Call Money Event UI
        MapUIMgrCls._instance.MoneyEventUI(money);

        // Upload User Data On Server
        //

        this.gameObject.SetActive(false);
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                    Function                                     //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190812 Namhun Kim
     * 
     * private void CalculateDist()
     * 
     * Calculate distance that event between user.
     * According to distance, displaying random event icon is different.
     * In 10m, user know event what it is.
     * 
     * @param    void
     * 
     * @return   void
     **/
     private void CalculateDist()
    {
        GameObject player = GameObject.Find("Player");

        _dist = Vector3.Distance(player.GetComponent<Transform>().position, this.gameObject.GetComponent<Transform>().position);
    }
}