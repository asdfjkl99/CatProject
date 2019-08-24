using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
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
        SceneManager.LoadScene("MyRoom");
    }

    public void LoadInventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Cat_Interaction");
    }
}
