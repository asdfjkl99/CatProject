using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Camera Control Class
 * 
 * This class can control camera movement and rotation.
 * Camera follows player character.
 * 
 * Changes
 * 190818 Namhun Kim
 * Write this class
 **/
public class CameraCtrlCls : MonoBehaviour
{
    private Transform _targetTr; // Target to follow
    private Transform _myTr; // Camera transform

    private float _dist = 30.0f; // Distance between character and camera
    private float _height = 15.0f; // Height between floor and camera
    private float _dampTrace = 20.0f; // For soft camera following
    
    private void Start()
    {
        Initialize();
    }

    private void LateUpdate()
    {
        SetPos();
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                   Initialize                                    //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190818 Namhun Kim
     * 
     * private void Initialize()
     * 
     * Initialize member variables.
     * Get Transform components from Unity.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void Initialize()
    {
        _targetTr = GameObject.Find("Player").GetComponent<Transform>(); // Get Player's Transform component

        _myTr = this.GetComponent<Transform>(); // Get Camera's Transform component

    }

/////////////////////////////////////////////////////////////////////////////////////
//                                   Functions                                     //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190818 Namhun Kim
     * 
     * private void SetPos()
     * 
     * This function set camera position.
     * Look at the player position.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void SetPos()
    {
        // Set camera position
        _myTr.position = Vector3.Lerp(_myTr.position,
            _targetTr.position - (_targetTr.forward * _dist) + (Vector3.up * _height),
            Time.deltaTime * _dampTrace);

        // Make camera looks player
        _myTr.LookAt(_targetTr);

    }
}
