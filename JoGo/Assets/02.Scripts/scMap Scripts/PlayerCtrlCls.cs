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
 * 190821 Namhun Kim
 * Rotate speed set to 10.0f
 * Fix player rotates
 **/
public class PlayerCtrlCls : MonoBehaviour
{
    private Transform _myTr; // Player's Transform component

    private float _rotSpeed; // Rotate speed
    
    private Vector2 _oldTouchPos; // Old touch position

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

        _rotSpeed = 10.0f;
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
     * 
     * Changes 190821
     * Fix bug
     **/
    private void RotatePlayer()
    {
        float __dist = 0.0f; // Distance between old touch position and new touch position

        // On mobile device
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch");

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 __newTouchPos = Input.GetTouch(0).position;

                if (_oldTouchPos.x + __newTouchPos.x + _oldTouchPos.y + __newTouchPos.y < 0) // Rotation direction 
                    __dist *= -1.0f;

                __dist = Vector2.Distance(_oldTouchPos, __newTouchPos); // Calculate distance between old position and new position
                _myTr.Rotate(Vector3.up * _rotSpeed * Time.deltaTime * __dist); // Rotate player character

                _oldTouchPos = __newTouchPos; // Renew old touch position
            }
        }
        // On PC
        // Algorithm is same as mobile device
        else if (Input.GetMouseButton(0))
        {
            Vector2 __newTouchPos = Input.mousePosition;

            __dist = Vector2.Distance(_oldTouchPos, __newTouchPos);

            if (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") < 0)
                __dist *= -1.0f;

            _myTr.Rotate(Vector3.up * _rotSpeed * Time.deltaTime * __dist);

            _oldTouchPos = __newTouchPos;
        }
        else
            _oldTouchPos = Input.GetTouch(0).position;
    }
}

