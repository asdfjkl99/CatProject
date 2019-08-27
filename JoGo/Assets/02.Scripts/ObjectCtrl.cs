using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    private GameObject currentTarget = null;
    private MyRoomUICtrl myroomUICtrl;

    private GameObject tile;
    private GameObject selectCircle;
    private GameObject getTarget;
    private Vector3 initMousePos;
    private bool isMouseDragging = false;
    private Vector3 colliderPos;
    private Vector3 offsetValue;
    private Vector3 positionOfScreen;

    // 타일 색을 바꾸기 위한 변수
    private int tileColor = 0;
    // 마우스 클릭시 위치
    private Vector3 originalPos;
    // 오브젝트가 고양이인지 여부
    private bool isCat = false;
    // 고양이를 가구 위에 올라갈지 여부
    private bool catgoup = false;
    // 현재 고양이가 가구위에 위치 여부
    private bool isCatUp = false;
    // 오브젝트의 처음 위치
    private Vector3 objectPos;
    // 가구 위에 고양이 위치 여부를 위한 변수
    private bool catIsOn = false;
    // 가구 위에 고양이 위치 
    private Vector3 CatOnMePos;
    // 가구 위의 고양이 오브젝트
    private GameObject CatOnMe = null;
    // 가구 위의 고양이의 움직임 이후 값
    private Vector3 afterPosition;
    // 충돌 오브젝트
    public GameObject myColl = null;
    // 충돌 오브젝트가 가구인지 여부
    private bool collIsFurniture = false;
    // 고양이가 가구 위로 올라갈 시 위치 설정을 위한 변수
    public Vector3 changePos;

    // 마이룸 상태인지 확인하는 변수
    public bool isMyRoom = false;
    // 기본 타일 상태를 확인하는 변수
    private bool normalTile = true;

    // 오브젝트 위치 
    public float X, Y, Z;
    // 가구 선택 ui 위치 설정을 위한 변수
    public Vector3 add;

    private void Start()
    {
        tile = transform.Find("Tile").gameObject;
        tile.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
        myroomUICtrl = GameObject.Find("MyRoomUI").GetComponent<MyRoomUICtrl>();
        FindSelectCircle();

        // y값을 비교하여 고양이가 가구 위에 있는 여부를 알아내기 위한 초기값 설정
        objectPos = transform.position;

        // 자신이 고양이인지 알아냄
        if (transform.tag == "Cat")
            isCat = true;

        changePos = new Vector3(0.0f, 7.0f, 0.0f);
        add = new Vector3(1.8f, 4.39f, -2.2f);
    }

    private void Update()
    {
        // 마이룸 상태가 아니면 작동 안함
        if (!CheckIsMyRoom())
            return;

        // 타겟이 널이 아니면 변수로 받아옴
        if (myroomUICtrl.getTarget != null)
            currentTarget = myroomUICtrl.getTarget;

        SetTileColor();
        CheckCatOnMe();

        ShowCurrentPosition();
    }

    // 가구 선택 UI 연결
    private void FindSelectCircle()
    {
        selectCircle = GameObject.Find("MyRoomUI").transform.Find("SelectCircle").gameObject;
    }

    // 현재 위치 보기
    private void ShowCurrentPosition()
    {
        X = transform.position.x;
        Y = transform.position.y;
        Z = transform.position.z;
    }

    // 메인 상태와 마이룸 상태시 타일 색 변화
    private bool CheckIsMyRoom()
    {
        if (!isMyRoom)
        {
            if (normalTile)
            {
                tileColor = 2;
                SetTileColor();
                normalTile = false;
            }
        }
        else
        {
            if (!normalTile)
            {
                tileColor = 0;
                SetTileColor();
                normalTile = true;
            }
        }

        return isMyRoom;
    }

    // 타일 색 업데이트
    private void SetTileColor()
    {
        if (transform.position.y > objectPos.y)
            tileColor = 2;

        if (tileColor == 0)
            tile.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        else if (tileColor == 1)
            tile.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        else if (tileColor == 2)
            tile.GetComponentInChildren<MeshRenderer>().material.color = Color.clear;
    }

    // 고양이가 가구 위에 올라와있는 경우 다시 위치를 내림
    private void IsUp()
    {
        if (transform.position.y > objectPos.y)
        {
            Vector3 tempPos = transform.position;
            tempPos.y = objectPos.y;
            transform.position = tempPos;

            isCatUp = false;
        }
    }

    // 가구 위에 고양이가 있는지 확인
    public void CheckCatOnMe()
    {
        if (CatOnMe != null && CatOnMe.GetComponent<ObjectCtrl>())
            if (CatOnMePos != CatOnMe.GetComponent<ObjectCtrl>().afterPosition)
                catIsOn = false;
    }

    // 고양이를 가구위에 위치하도록 함
    private void UpDownCat()
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

                if (myColl != null && myColl.GetComponent<ObjectCtrl>())
                {
                    myColl.GetComponent<ObjectCtrl>().CatOnMePos = transform.position;
                    myColl.GetComponent<ObjectCtrl>().catIsOn = true;
                }
            }
        }
    }

    // 타일이 빨간색일 경우 원래 자리로 돌아옴
    private void ReturnPosition()
    {
        if (tileColor == 1)
        {
            transform.position = originalPos;
            tileColor = 0;
        }
    }

    //  충돌 시작
    private void OnTriggerEnter(Collider coll)
    {
        if (!CheckIsMyRoom())
            return;

        // 충돌한 것이 고양이인지 가구인지 알아냄
        if (coll.tag == "Cat")
            collIsFurniture = false;
        else if (coll.tag == "Furniture")
            collIsFurniture = true;
        else if (coll.tag == "Tile")
        {
            if (coll.GetComponentInParent<ObjectCtrl>().isCat)
                collIsFurniture = false;
            else
                collIsFurniture = true;
        }

        if (currentTarget != null)
            if (currentTarget.tag == "Cat")
            {
                if (coll.tag == "Furniture")
                    myColl = coll.gameObject;
                else if (coll.tag == "Tile" && collIsFurniture)
                    myColl = coll.gameObject.transform.parent.gameObject;
            }
    }

    // 충돌중
    private void OnTriggerStay(Collider coll)
    {
        if (!CheckIsMyRoom())
            return;

        tileColor = 1;
        colliderPos = coll.transform.position;

        // 현재 레이캐스트가 고양이고 가구와 부딪힌 경우
        if (currentTarget != null)
            if (currentTarget.tag == "Cat" && collIsFurniture)
            {
                if (myColl != null && myColl.GetComponent<ObjectCtrl>())
                {
                    if (!(myColl.GetComponent<ObjectCtrl>().catIsOn))
                    {
                        catgoup = true;
                        myColl.GetComponent<ObjectCtrl>().CatOnMe = gameObject;
                    }
                    else
                        catgoup = false;
                }
            }
    }

    // 충돌 끝
    private void OnTriggerExit(Collider coll)
    {
        if (!CheckIsMyRoom())
            return;

        tileColor = 0;
        catgoup = false;
    }

    //마우스 클릭
    private void OnMouseDown()
    {
        if (!CheckIsMyRoom() || catIsOn)
            return;

        // 이동 실패시 원래 위치로 돌아오게 하기 위한 변수 값 삽입
        originalPos = transform.position;

        if (isCat)
            IsUp();

        // 가구만 가구삭제 버튼을 나오게 하기위한 조건문
        if (transform.tag == "Furniture")
            selectCircle.transform.position = transform.position + add;

        // 레이캐스트로 타겟 받아옴
        RaycastHit hitInfo;
        getTarget = ReturnClickedObject(out hitInfo);

        if (getTarget != null)
        {
            isMouseDragging = true;
            // 월드 좌표를 스크립 좌표로 변환
            positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
            offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));

            // 마이룸의 겟타겟에 타겟을 넘겨줌
            GameObject.Find("MyRoomUI").GetComponent<MyRoomUICtrl>().getTarget = getTarget;
        }
    }

    //마우스 드래그
    private void OnMouseDrag()
    {
        if (!CheckIsMyRoom() || catIsOn)
            return;

        if (isCat)
            IsUp();

        // 가구 위치가 바뀌지 않은 경우
        if (transform.tag == "Furniture" && originalPos == transform.position)
            selectCircle.SetActive(true);
        else
            selectCircle.SetActive(false);

        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

        // 스크린 좌표에 변수값을 더하여 월드 좌표로 변환
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

        currentPosition.y = transform.position.y;

        if (getTarget != null)
            getTarget.transform.position = currentPosition;
    }

    // 마우스 뗌
    private void OnMouseUp()
    {
        if (!CheckIsMyRoom() || catIsOn)
            return;

        if (isCat)
            UpDownCat();

        ReturnPosition();
        isMouseDragging = false;

        if (isCat)
            afterPosition = transform.position;
    }

    // 레이캐스트로 고양이와 가구일 경우에만 타겟 반환
    private GameObject ReturnClickedObject(out RaycastHit hit)
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
