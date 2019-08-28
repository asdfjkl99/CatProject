using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMgr : MonoBehaviour
{
    //Contain the Mission Object 
    public GameObject stamps;
    public GameObject quiz;
    public GameObject festival;

    //Activate stamps mission
    public void SetActiveStampsTrue()
    {
        stamps.SetActive(true);
        quiz.SetActive(false);
        festival.SetActive(false);
    }

    //Activate quiz mission
    public void SetActiveQuizTrue()
    {
        stamps.SetActive(false);
        quiz.SetActive(true);
        festival.SetActive(false);
    }

    //Activate festival mission
    public void SetActiveFestivalTrue()
    {
        stamps.SetActive(false);
        quiz.SetActive(false);
        festival.SetActive(true);
    }

}
