using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    public Material[] materials;

    private Vector3 initMousePos;
    private GameObject tile;

    int tileColor;
    Vector3 originalPos;
    bool getInitPos = false;
    public int floor = 1;
    bool isCat = false;
    bool catgoup = false;
    bool isCatUp = false;
    public Vector3 objectPos;

    private GameObject selectCircle;
    public GameObject getTarget;
    bool isMouseDragging;
    Vector3 colliderPos;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    public GameObject currentTarget = null;
    MyRoomUICtrl myroomUICtrl;

    public float MaxX, MaxZ, MinX, MinZ;
    public float X, Y, Z;
    Vector3 changePos = new Vector3(0.0f, -5.0f, 0.0f);

    // 충돌시 부모가 고양이인지 확인하는 용도
    public Animator collParent = null;

    void Start()
    {
        myroomUICtrl = GameObject.Find("MyRoomUI").GetComponent<MyRoomUICtrl>();
        tileColor = 0;
        isMouseDragging = false;
        objectPos = transform.position;

        tile = transform.Find("Tile").gameObject;

        if (transform.tag == "Cat")
            isCat = true;

        selectCircle = GameObject.Find("SelectCircle");

        MinX = -10.0f;
        MaxX = 11.5f;
        MinZ = -168.0f;
        MaxZ = -146.5f;
    }

    void Update()
    {
        if(myroomUICtrl.getTarget != null)
          currentTarget = myroomUICtrl.getTarget;

        CheckPosition();
        SetTileColor();

        X = transform.position.x;
        Y = transform.position.y;
        Z = transform.position.z;
    }

    // 메인 상태일때 타일 없애기 
    private void OnDisable()
    {
        tileColor = 2;
        SetTileColor();
    }

    void SetTileColor()
    {
        tile.GetComponentInChildren<MeshRenderer>().material = materials[tileColor];
    }

    void CheckCat()
    {
        if (isCat == true && tileColor == 1 && currentTarget.tag == "Cat")
        {
            Vector3 temppos = transform.position + changePos;
            transform.position = temppos;

            Debug.Log(currentTarget.tag);
        }
    }

    void isUp()
    {
        if(transform.position.y < objectPos.y)
        {
            Vector3 tempPos = transform.position;
            tempPos.y = objectPos.y;
            transform.position = tempPos;

            isCatUp = false;
        }
    }

    // 가구 위에 올렸다 내렸다
    void UpDownCat()
    {
        if (!isCatUp)
        {
            colliderPos += changePos;

            if (catgoup)
            {
                transform.position = colliderPos;
                tileColor = 0;
                catgoup = false;
                isCatUp = true;
                Debug.Log("a");
            }
        }
    }

    void CheckPosition()
    {
        if (transform.position.x < MinX || transform.position.x > MaxX || transform.position.z < MinZ || transform.position.z > MaxZ)
        {
            tileColor = 1;
        }
    }

    void ReturnPosition()
    {
        if (tileColor == 1)
        {
            transform.position = originalPos;
            tileColor = 0;
        }
    }

    void GetInitPos(Vector3 initpos)
    {
        originalPos = initpos;
    }


    private void OnTriggerEnter(Collider coll)
    {
       collParent = coll.gameObject.GetComponentInParent<Animator>();
    }

    void OnTriggerStay(Collider coll)
    {
        tileColor = 1;
        colliderPos = coll.transform.position;

        if (currentTarget != null)
        {
            if (currentTarget.tag == "Cat" && (coll.tag == "Furniture" || collParent == null))
            {
                catgoup = true;
            }
            else
                catgoup = false;
        }

        if(currentTarget.tag != "Cat")
            CheckCat();
    }

    void OnTriggerExit(Collider coll)
    {
        tileColor = 0;
        catgoup = false;
    }

    //처음마우스 클릭시
    void OnMouseDown()
    {
        if (isCat)
            isUp();

        tileColor = 0;

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

        if(tileColor == 0)
          GetInitPos(transform.position);

        Vector3 add = new Vector3(1.4f, 0.0f, -2.0f);

        if (transform.tag == "Furniture")
            selectCircle.transform.position = transform.position + add;
    }

    //마우스 드래그시
    void OnMouseDrag()
    {
        if (isCat)
            isUp();

        if (transform.tag == "Furniture" && originalPos == transform.position)
        {
            selectCircle.SetActive(true);
        }
        else
            selectCircle.SetActive(false);

        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

        //converting screen position to world position with offset changes.
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

        currentPosition.y = transform.position.y;

        if (getTarget != null)
            getTarget.transform.position = currentPosition;
    }

    private void OnMouseUp()
    {
        if (isCat)
            UpDownCat();

        ReturnPosition();
        CheckCat();
        getInitPos = false;
        isMouseDragging = false;
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
