using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRay : MonoBehaviour
{
    public Camera camera;
    private GameObject catUI;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        catUI = GameObject.Find("CatUI");
        catUI.SetActive(false);
    }

    public void OnTouchFeedingtBtn()
    {
        catUI.SetActive(false);
    }
    public void OnTouchPlayingtBtn()
    {
        catUI.SetActive(false);
    }
    public void OnTouchWalkingBtn()
    {
        catUI.SetActive(false);
    }
    public void OnTouchInfomationBtn()
    {
        catUI.SetActive(false);
    }
         
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want
                if (hit.collider.tag == "CAT")
                {
                    Debug.Log("maw?");

                    Vector3 screenPos = camera.WorldToScreenPoint(hit.rigidbody.position);

                    float x = screenPos.x;
                    
                    catUI.transform.position = new Vector3(x, screenPos.y, catUI.transform.position.z);

                    catUI.SetActive(true);
                }

             

            }
            
        }
    }

}
