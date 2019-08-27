/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                                  EVENT MANAGER                                  //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * EventManager Class
 * 
 * This class manages all events.
 * 
 * Changes
 * 
 * 190811 Namhun Kim
 * - Write Initialize(), SetEventsActive(), Timer()
 * 190812 Namhun Kim
 * - Write DistCheck()
 * - Change "Timer" coroutine name to "EventTimer"
 * 190825 Namhun Kim
 * - Write MoveEventsOnUpdateMap()
 **/
public class EventMgrCls : MonoBehaviour
{
    private WaitForSeconds _secChangeEvent = new WaitForSeconds(300.0f); // Event Timer time
    private WaitForSeconds _secDistCheck = new WaitForSeconds(1.0f); // Disatnce Check time

    private GameObject _allEvents; // This variable has empty gameobject that all events have.
    private GameObject[] _events; // This varaialbes list has each events information.

    private Vector3 _eventsLoc; // Jochiwon latitude longtitude

    // Singleton
    //
    public static EventMgrCls _instance = null;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);

        // Keep Event On Load Scene
        DontDestroyOnLoad(this.gameObject);

        Initialize();

        StartCoroutine("EventTimer");
        StartCoroutine("DistCheckTimer");
    }

    /////////////////////////////////////////////////////////////////////////////////////
    //                                   Initialize                                    //
    /////////////////////////////////////////////////////////////////////////////////////

    /**
     * 190811 Namhun Kim
     * 
     * Initialize member variables.
     * 
     * @param    void
     * 
     * @return   void
     * 
     * Changes
     * 
     * 190824 Namhun Kim
     * - add jochiwon latitude longtitude
     **/
    private void Initialize()
    {
        // Get events
        //
        _allEvents = GameObject.Find("Events");

        if (_allEvents == null)
            Debug.Log("Can't find events Object");

        _events = GameObject.FindGameObjectsWithTag("EVENT");

        if (_events == null)
            Debug.Log("Can't find EVENT tag Object");

        // Jochiwon latituide longtitude
        _eventsLoc.x = 127.298111f; // latitude
        _eventsLoc.y = 0.0f;
        _eventsLoc.z = 36.601281f; // longtitude
        
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                   Functions                                     //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190811 Namhun Kim
     * 
     * public void SetEventsActive()
     * 
     * Set all events active.
     * This function can make all events are active or deactive.
     * 
     * @param    bool __active   active true or false.
     * 
     * @return   void
     **/
    public void SetEventsActive(bool __active)
    {
        _allEvents.SetActive(__active);
    }
    
    /**
     * 190811 Namhun Kim
     * 
     * private IEnumerator EventTimer()
     * 
     * Send Message to change evnets each 5 minutes.
     * Each 5 minutes, event's information changes randomly by InitEventInfo() function.
     * 
     * @param     void
     * 
     * @return    void
     * 
     * Changes
     * 
     * 190812 Namhun Kim
     * - Name changes "Timer" to "EventTimer"
     **/
    private IEnumerator EventTimer()
    {
        while (true)
        {
            yield return _secChangeEvent; // wait 5 minutes

            Debug.Log("Change Event");

            foreach (GameObject __evt in _events)
            {
                __evt.SetActive(true);
                __evt.SendMessage("InitEventInfo"); // Send message on each events
            }
        }
    }

    /**
     * 190812 Namhun Kim
     * 
     * Send message to check distance each 1 secs.
     * Each 1 secs, check distance by CalculateDist() function on RandomEvent class.
     * 
     * @param    void
     * 
     * @return   void
     **/
     private IEnumerator DistCheckTimer()
    {
        while (true)
        {
            yield return _secDistCheck; // wait 1 seconds

            foreach (GameObject __evt in _events)
            {
                if (__evt.activeSelf)
                {
                    __evt.SendMessage("CalculateDist"); // Send message on each events
                }
            }
        }
    }

    /**
     * 190825 Namhun Kim
     * 
     * Transform latitude longtitude to Unity coordinate.
     * And move position if player move.
     * 
     * @param    Vector3 __latLon   This is latitude and longtitude position.
     * 
     * @return   void
     **/
    public void MoveEventsOnUpdateMap(Vector3 __latLon)
    {
        float __latLonDist = Vector3.Distance(_eventsLoc, __latLon); // Move distance
        Vector3 __normal = Vector3.Normalize(__latLon - _eventsLoc); // Normal vector

        __latLonDist = 20.828792f * __latLonDist / 0.001131f; // Change to unity coordinate

        _allEvents.GetComponent<Transform>().SetPositionAndRotation(Vector3.up * 2.5f + -__normal * __latLonDist, Quaternion.Euler(0.0f,0.0f,0.0f)); // Set position
    }
}

