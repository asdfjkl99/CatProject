using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoomCtrl : MonoBehaviour
{
    public GameObject FList;

    // Start is called before the first frame update
    void Start()
    {
        FList.SetActive(false);
    }

    public void OnTouchXButton()
    {

    }

    public void OnTouchAddFButton()
    {
        if(!FList.activeSelf)
         FList.SetActive(true);
        else
         FList.SetActive(false);
    }

    public void OnTouchF1()
    {

    }

    public void OnTouchF2()
    {

    }

    public void OnTouchF3()
    {

    }

    public void OnTouchF4()
    {

    }

}
