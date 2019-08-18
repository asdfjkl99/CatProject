/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                                 Player Control                                  //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Player Control Class
 * 
 * This class can control Player object.
 * This contains player's informations.
 * 
 * Changes
 * 
 * 190812 Namhun Kim
 * Write class
 * 190818 Namhun Kim
 * Write player object's rotation for camera
 **/
public class PlayerCtrlCls : MonoBehaviour
{
    private Transform _myTr; // Player's Transform component

    private float _rotSpeed; // Rotate speed

    // Singleton
    //
    public static PlayerCtrlCls _instance = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Initialize();
    }
    private void Update()
    {
        RotatePlayer();
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
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void Initialize()
    {
        _myTr = this.GetComponent<Transform>();

        _rotSpeed = 300.0f;
    }

/////////////////////////////////////////////////////////////////////////////////////
//                                    Funtions                                     //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 190818 Namhun Kim
     * 
     * private void RotatePlayer()
     * 
     * Rotate player's transform.
     * Rotation Speed = 100.0f
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void RotatePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            _myTr.Rotate(Vector3.up * Time.deltaTime * _rotSpeed * Input.GetAxis("Mouse Y"));
        }

    }
}

