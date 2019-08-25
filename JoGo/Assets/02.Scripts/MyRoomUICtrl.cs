using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoomUICtrl : MonoBehaviour
{
    private GameObject RemoveButton;
    private GameObject FList;
    private GameObject selectcircle;

    // 현재 레이캐스트한 타겟을 받기 위한 변수
    public GameObject getTarget = null;

    // 가구제거 버튼 위치 설정을 위한 변수
    public Vector3 add;

    // 모델스 연결
    private GameObject Models;
    // 소파2 가구 연결
    public GameObject Sofa2;
    // 한번만 생성하기 위한 변수
    public bool isInstantiate = false;

    private void Start()
    {
        RemoveButton = GameObject.Find("RemoveButton");
        FList = GameObject.Find("FList");
        RemoveButton.SetActive(false);
        FList.SetActive(false);
        selectcircle = GameObject.Find("SelectCircle");
        Models = GameObject.Find("Models");

        Vector3 removebtnadd = new Vector3(2.5f, 45.0f, 0.0f);
        add = removebtnadd;
    }

    private void Update()
    {
        UpdateRemoveButton();
    }

    // 가구 제거 버튼 위치 설정, 활성화 여부 설정
    void UpdateRemoveButton()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(selectcircle.transform.position);

        float x = screenPos.x;

        RemoveButton.transform.position = new Vector3(x, screenPos.y, RemoveButton.transform.position.z) + add;

        if (selectcircle.activeSelf == true)
            RemoveButton.SetActive(true);
        else
            RemoveButton.SetActive(false);
    }

    // 이전 화면 돌아가기 버튼 클릭
    public void OnTouchXButton()
    {

    }

    // 가구 추가 버튼 클릭
    public void OnTouchAddFButton()
    {
        if (!FList.activeSelf)
            FList.SetActive(true);
        else
            FList.SetActive(false);
    }

    // 가구 저장 버튼 클릭
    public void OnTouchSaveButton()
    {

    }

    // 가구 제거 버튼 클릭
    public void OnTouchRemoveButton()
    {
        Destroy(getTarget);
        selectcircle.SetActive(false);
    }

    // 가구 드래그시 생성
    public void OnTouchF1()
    {
        if (!isInstantiate)
        {
            GameObject instance = Instantiate(Sofa2, Sofa2.transform.position, Sofa2.transform.rotation);
            instance.transform.parent = Models.transform;
            isInstantiate = true;
        }
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