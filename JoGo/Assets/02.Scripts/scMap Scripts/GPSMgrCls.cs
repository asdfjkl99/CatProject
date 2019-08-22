/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                                  GPS Manager                                    //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * GPS Manager
 * 
 * This class gets GPS position from android device
 * 
 * Changes
 * 190817 Namhun Kim
 * Reference https://computer-warehouse.tistory.com/10
 **/
public class GPSMgrCls : MonoBehaviour
{
    private bool gpsInit = false;
    private LocationInfo curGPSPos; // Current GPS position

    // Singleton
    //
    public static GPSMgrCls _instance = null;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        Input.location.Start(0.5f);
        int wait = 1000;

        // Checks if the GPS is enabled by the user (-> Allow location ) 
        if (Input.location.isEnabledByUser)
        {
            while (Input.location.status == LocationServiceStatus.Initializing && wait > 0)// Initializing
            {
                wait--;
            }
            
            if (Input.location.status != LocationServiceStatus.Failed)// GPS
            {
                gpsInit = true;

                // We start the timer to check each tick (every 1 sec) the current gps position
                InvokeRepeating("RetrieveGPSData", 0.0001f, 1.0f);
            }

        }
        else // GPS is not available
        {
            Debug.Log("GPS is not available");
        }

    }

    /**
     * 190817 Namhun Kim
     * 
     * private void GetGPSData()
     * 
     * Get GPS data from android device.
     * Convert GPS data and return GPS position.
     * 
     * @param    void
     * 
     * @return   void
     **/
    public Vector2 GetGPSData()
    {
        Vector2 __pos;

        curGPSPos = Input.location.lastData; // Get GPS data

        __pos.x = curGPSPos.latitude; // Get latitude
        __pos.y = curGPSPos.longitude; // Get longtitude

        // If GPS off
        // Test on PC
        // This Location is Jochiwon Station
        if (!Input.location.isEnabledByUser)
        {
            __pos.x = 36.601106f;
            __pos.y = 127.296565f;
        }

        return __pos;
    }
}
