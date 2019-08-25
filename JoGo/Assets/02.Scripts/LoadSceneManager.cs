using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public int setCamera = 0;
    private GameObject mainMgr;

    private void Start()
    {
        mainMgr = GameObject.Find("MainUIMgr");
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadWalk()
    {
        SceneManager.LoadScene("scMap");
    }

    public void LoadSetRoom()
    {
        setCamera = 1;
        GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().setcamera = setCamera;
        mainMgr.SetActive(false);
    }

    public void LoadInventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MyRoom");
    }

    public void ChangeCamera()
    {
        setCamera = 0;
        GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().setcamera = setCamera;
        mainMgr.SetActive(true);
    }
}
