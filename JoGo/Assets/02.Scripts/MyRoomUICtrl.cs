using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoomUICtrl : MonoBehaviour
{
    public GameObject RemoveButton;
    public GameObject FList;
    private GameObject selectcircle;
    public GameObject getTarget;
    //GameObject models;

    Vector3 add = new Vector3(45.0f, 45.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        RemoveButton.SetActive(false);
        FList.SetActive(false);
        selectcircle = GameObject.Find("SelectCircle");
       // models = GameObject.Find("Models");
    }

    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(selectcircle.transform.position);

        float x = screenPos.x;

        RemoveButton.transform.position = new Vector3(x, screenPos.y, RemoveButton.transform.position.z) + add;

        if (selectcircle.activeSelf == true)
            RemoveButton.SetActive(true);
        else
            RemoveButton.SetActive(false);
    }

    public void OnTouchXButton()
    {

    }

    public void OnTouchAddFButton()
    {
        if (!FList.activeSelf)
            FList.SetActive(true);
        else
            FList.SetActive(false);
    }

    public void OnTouchSaveButton()
    {

    }

    public void OnTouchRemoveButton()
    {
        Destroy(getTarget);
        selectcircle.SetActive(false);
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