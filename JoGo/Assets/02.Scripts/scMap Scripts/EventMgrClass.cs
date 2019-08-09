//////////////////////////////////////////////////////
//                                                  //
//                   EVENT MANAGER                  //
//                                                  //
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMgrClass : MonoBehaviour
{
    // Singleton
    public static EventMgrClass _instance = null;

    // Timer
    private WaitForSeconds waitSec = new WaitForSeconds(300.0f);
    
    private GameObject allEvents;
    private GameObject[] events;

    private void Awake()
    {
        // Keep Event On Load Scene
        if(_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine("Timer");

        Initialize();
    }

    //
    // Initialize
    //
    private void Initialize()
    {
        // Get events
        allEvents = GameObject.Find("Events");

        if (allEvents == null)
            Debug.Log("Can't find events Object");

        events = GameObject.FindGameObjectsWithTag("EVENT");

        if (events == null)
            Debug.Log("Can't find EVENT tag Object");
    }

    // Manage events active
    public void SetEventsActive(bool active)
    {
        allEvents.SetActive(active);
    }

    // Timer Coroutine
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return waitSec;

            Debug.Log("Change Event");

            foreach(GameObject evt in events)
            {
                evt.SetActive(true);
                evt.SendMessage("InitEventInfo");
            }
        }
    }
}
