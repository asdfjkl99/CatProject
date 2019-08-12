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
 * Write
 **/
public class PlayerCtrlCls : MonoBehaviour
{
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
}
