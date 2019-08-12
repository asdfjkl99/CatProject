//////////////////////////////////////////////////////
//                                                  //
//              FURNITURE INFORMATION               //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////
//                CATEGORY NUMBER 4                 //
//////////////////////////////////////////////////////
public class FurInfoCls : InfoCls
{
    // Furniture unique number
    private int _furNo;
    // Furniture position
    private Vector3 _pos;
    // Furniture usage
    private bool _usage;

    //////////////////////////////////////////////////////
    //                    Initialize                    //
    //////////////////////////////////////////////////////
    public FurInfoCls()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        _category = 4;
        _no = 0;
        _furNo = 0;
        _pos.Set(0, 0, 0);
        _usage = false;
    }

    //////////////////////////////////////////////////////
    //                   Return Value                   //
    //////////////////////////////////////////////////////
    public Vector3 GetPos()
    {
        return _pos;
    }

    public bool GetUsage()
    {
        return _usage;
    }

    //////////////////////////////////////////////////////
    //                     Set Value                    //
    //////////////////////////////////////////////////////
    public void SetPosition(Vector3 __pos)
    {
        _pos = __pos;
    }

    public void SetUsage(bool __usage)
    {
        _usage = __usage;
    }
}
