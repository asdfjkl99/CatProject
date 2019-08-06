//////////////////////////////////////////////////////
//                                                  //
//                   MAPUI MANAGER                  //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIMgrClass : MonoBehaviour
{
    // UI Object
    //
    private GameObject mapUI;
    public Image icon;
    public Text desc;

    // Singleton
    //
    public static MapUIMgrClass _instance = null;

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

//////////////////////////////////////////////////////
//                   INITIALIZE                     //
//////////////////////////////////////////////////////

    private void Initialize()
    {
        mapUI = GameObject.Find("MapUIMgr");

        if (mapUI == null)
            Debug.Log("Can't find MapUIMgr Object");
        else
            mapUI.SetActive(false);
    }


//////////////////////////////////////////////////////
//                  EVENT FUNCTION                  //
//////////////////////////////////////////////////////

    public void MoneyEventUI(float money)
    {
        // Item icon Load On Client DB
        //

        // Update Text
        desc.text = "축하합니다! 현금 " + money + "원을 획득하셨습니다!";

        mapUI.SetActive(true);
    }

    public void ToyEventUI(int toyNo)
    {
        string toyName = "NULL";

        // Item icon Load On Client DB
        //

        // Update Text
        desc.text = "축하합니다! " + toyName + "을 획득하셨습니다!";

        mapUI.SetActive(true);
    }

//////////////////////////////////////////////////////
//                  BUTTON FUNCTION                 //
//////////////////////////////////////////////////////
    public void OnTouchReturnBtn()
    {
        mapUI.SetActive(false);
    }
}
