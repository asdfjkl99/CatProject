using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatUI : MonoBehaviour
{

    private GameObject catUI;

    // Start is called before the first frame update
    void Start()
    {
        catUI = GameObject.Find("CatUI");
    }

    public void OnTouchFeedingtBtn()
    {
        Debug.Log("Touch Feeding Btn");

        catUI.SetActive(false);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
