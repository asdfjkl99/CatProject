//////////////////////////////////////////////////////
//                                                  //
//                       EVENT                      //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////////
// 0 == Cat Event                                   //
// 1 == Money Event                                 //
// 2 == Toy Event                                   //
// 3 == Stamp Event (From Server)                   //
// 4 == Festival Event (From Server)                //
//////////////////////////////////////////////////////
public class EventClass : MonoBehaviour
{
    //
    // ON CLIENT
    //
    private int evtType;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        InitEventInfo();
    }

    // Touch Event
    private void OnMouseUp()
    {
        Debug.Log("Event Touch" + evtType);

        // CAT
        if (evtType == 0)
        {
            this.CatEvent();
        }
        // MONEY
        else if (evtType == 1)
        {
            this.MoneyEvent();
        }
        // TOY
        else if (evtType == 2)
        {
            this.ToyEvent();
        }
        // STAMP
        else if (evtType == 3)
        {
            Debug.Log("This is stamp event");
        }
        // FESTIVAL
        else if (evtType == 4)
        {
            Debug.Log("This is festival event");
        }
        // ERROR CODE #
        else
        {
        }
    }

//////////////////////////////////////////////////////
//                    Initialize                    //
//////////////////////////////////////////////////////
    // Init Event Info
    private void InitEventInfo()
    {       
        // Manage Object active
        int num = Random.Range(0, 2);
        bool isAppear;

        if (num == 0)
            isAppear = false;
        else
            isAppear = true;
        
        this.gameObject.SetActive(isAppear);

        evtType = Random.Range(0, 3);
    }

//////////////////////////////////////////////////////
//                  Event Function                  //
//////////////////////////////////////////////////////

    // If this is cat event
    private void CatEvent()
    {
        SceneManager.LoadScene("scCatching");
    }

    // If this is money event
    private void MoneyEvent()
    {
        int multiply = Random.Range(10, 30);
        int money = 100 * multiply;

        // Call Money Event UI
        MapUIMgrClass._instance.MoneyEventUI(money);

        // Upload User Data On Server
        //

        this.gameObject.SetActive(false);
    }

    // If this is toy event
    private void ToyEvent()
    {
        // toyNo = 0 ~ toyDB Max NO + 1 
        int toyNo = Random.Range(0, GetToyNoOnDB() + 1);

        MapUIMgrClass._instance.ToyEventUI(toyNo);

        // Upload User Data On Server
        //

        this.gameObject.SetActive(false);
    }

    // Dummy Func
    private int GetToyNoOnDB()
    {
        return 10;
    }
}