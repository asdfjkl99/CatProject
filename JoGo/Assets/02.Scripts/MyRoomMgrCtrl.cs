using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyRoomMgrCtrl : MonoBehaviour
{
    private GameObject myRoomUI;
    private GameObject mainCamera;
    private GameObject myroomCamera;

    // 현재 상태를 받기 위한 변수
    private string currentScene;

    // 현재 씬 받아오기 0은 메인, 1은 마이룸
    public int setcamera = 0;

    // 상태 별로 기능을 제어하기 위한 스크립트 배열과 그 길이
    // 마이룸 스크립트
    public ObjectCtrl[] objectCtrls;
    public int objectctrlsLength = 0;

    private void Start()
    {
        CheckScene();
        myRoomUI = GameObject.Find("MyRoomUI");
        mainCamera = GameObject.Find("MainCamera");
        myroomCamera = GameObject.Find("MyRoomCamera");
        objectCtrls = FindObjectsOfType(typeof(ObjectCtrl)) as ObjectCtrl[];
        objectctrlsLength = objectCtrls.GetLength(0);
        //catUI = gameObject.GetComponent<CatUI>();
    }

    private void Update()
    {
        if (myRoomUI.GetComponent<MyRoomUICtrl>().isInstantiate)
        {
            objectCtrls = FindObjectsOfType(typeof(ObjectCtrl)) as ObjectCtrl[];
            objectctrlsLength = objectCtrls.GetLength(0);
        }

        CheckScene();
        ChangeUI();
    }

    // 상태 가져오기
    private void CheckScene()
    {
        if (setcamera == 0)
        {
            currentScene = "main";
        }
        else
        {
            currentScene = "myroom";
        }
    }

    // 상태 별로 함수 작동
    private void ChangeUI()
    {
        if (currentScene == "main")
        {
            MainUI();
        }
        else if (currentScene == "myroom")
        {
            MyRoomUI();
        }
    }

    // 메인 상태 기능 활성화, 마이룸 상태 기능 비활성화
    private void MainUI()
    {
        mainCamera.SetActive(true);
        myroomCamera.SetActive(false);

        for (int i = 0; i < objectctrlsLength; i++)
        {
            objectCtrls[i].isMyRoom = false;
        }
    }

    // 메인 상태 기능 비활성화, 마이룸 상태 기능 활성화
    private void MyRoomUI()
    {
        myroomCamera.SetActive(true);
        mainCamera.SetActive(false);

        for (int i = 0; i < objectctrlsLength; i++)
        {
            objectCtrls[i].isMyRoom = true;
        }
    }
}
