/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                                      EVENT                                      //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

/////////////////////////////////////////////////////////////////////////////////////
// 0 == Cat Event                                                                  //
// 1 == Money Event                                                                //
// 2 == Toy Event                                                                  //
// 3 == Stamp Event (From Server)                                                  //
// 4 == Festival Event (From Server)                                               //
/////////////////////////////////////////////////////////////////////////////////////

/**
 * Event Class
 *
 * This class inherit to RandEvent class and FixedEvent class.
 * 
 * Changes
 * 
 * 190812 Namhun Kim
 * Write _evtType, _dist, Initialize()
 * 190814 Namhun Kim
 * Write _location
 **/
public class EventCls : MonoBehaviour
{
    protected int _evtType; // Events type
    protected float _dist; // Distance that user between event

    protected Vector2 _location; // Event location
    
    /**
     * 190812 Namhun Kim
     * 
     * private void Initialize()
     * 
     * Initialize member variables.
     * 
     * @param    void
     * 
     * @return   void
     **/
    protected virtual void Initialize()
    {
        _evtType = 0;
        _dist = 0;

        _location.x = 0;
        _location.y = 0;
    }
}