using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject storeBtn;
    public GameObject walkBtn;
    public GameObject setRoomBtn;
    public GameObject inventoryBtn;
    public GameObject backBtn;

    public int setcamera = 0;
    private int originalcamera = 0;

    private int clickCount = 0;

    private void Start()
    {

    }

    private void Update()
    {
        GetCameraNum();
        CheckCameraNum();
    }

    private void GetCameraNum()
    {
        setcamera = GameObject.Find("LoadSceneMgr").GetComponent<LoadSceneManager>().setCamera;
    }

    private void CheckCameraNum()
    {
        if (originalcamera != setcamera)
        {
            clickCount = 2;
            SetActiveFalse();
        }
    }

    public void SetActiveTrue()
    {
        storeBtn.SetActive(true);
        walkBtn.SetActive(true);
        setRoomBtn.SetActive(true);
        inventoryBtn.SetActive(true);
        backBtn.SetActive(true);

        clickCount++;
    }

    public void SetActiveFalse()
    {
        if (clickCount == 2)
        {
            storeBtn.SetActive(false);
            walkBtn.SetActive(false);
            setRoomBtn.SetActive(false);
            inventoryBtn.SetActive(false);
            backBtn.SetActive(false);
            clickCount = 0;
        }
    }


}
