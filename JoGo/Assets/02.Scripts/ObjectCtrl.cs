using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    public Material[] materials;

    private Vector3 initMousePos;
    GameObject tile;

    int tileColor = 0;
    Vector3 originalPos;
    bool getInitPos = false;
    public int floor = 1;
    bool isCat = false;
    // bool catgoup = false;
    // bool isUp = false;

    private GameObject selectCircle;
    public GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    void Start()
    {
        tile = transform.Find("Tile").gameObject;

        if (transform.tag == "Cat")
            isCat = true;

        selectCircle = GameObject.Find("SelectCircle");
    }

    void Update()
    {
        if(isCat)
           UpDownCat();

        SetTileColor();
    }

    void SetTileColor()
    {
        tile.GetComponentInChildren<MeshRenderer>().material = materials[tileColor];
    }

    void CheckPosition()
    {
        if (tileColor == 1)
        {
            transform.position = originalPos;
        }
    }

    // 가구 위에 올렸다 내렸다
    void UpDownCat()
    {
        //Vector3 changePos = transform.position;

        //if (isUp)
        //{
        //    changePos.y += 5.0f;
        //}
        //else
        //    changePos.y -= 5.0f;

        ////if(!catgoup)
        //transform.position = changePos;
    }

    void OnCollisionStay(Collision coll)
    {
        tileColor = 1;

        // 가구 위에 올렸다 내렸다
        if (isCat && coll.collider.tag == "Furniture")
        {
            //     catgoup = true;
            //     tileColor = 0;
        }
        //else
        //    catgoup = false;
    }

    void OnCollisionExit(Collision coll)
    {
        tileColor = 0;
    }

     void GetInitPos(Vector3 initpos)
    {
        originalPos = initpos;
    }

    //처음마우스 클릭시
    void OnMouseDown()
    {
        RaycastHit hitInfo;
        getTarget = ReturnClickedObject(out hitInfo);
        if (getTarget != null)
        {
            isMouseDragging = true;
            //Converting world position to screen position.
            positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
            offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));

            GameObject.Find("MyRoomUI").GetComponent<MyRoomUICtrl>().getTarget = getTarget;
        }

        GetInitPos(transform.position);

        Vector3 add = new Vector3(1.4f, 0.0f, -2.0f);

        if (transform.tag == "Furniture")
            selectCircle.transform.position = transform.position + add;
    }

    private void OnMouseUp()
    {
        CheckPosition();
        getInitPos = false;
        isMouseDragging = false;
    }

    //마우스 드래그시
    void OnMouseDrag()
    {
        if (transform.tag == "Furniture" && originalPos == transform.position)
        {
            selectCircle.SetActive(true);
        }
        else
            selectCircle.SetActive(false);

        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

        //converting screen position to world position with offset changes.
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

        if(getTarget != null)
          getTarget.transform.position = currentPosition;
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Cat") || hit.collider.gameObject.CompareTag("Furniture"))
                target = hit.collider.gameObject;
        }

        return target;
    }
}
