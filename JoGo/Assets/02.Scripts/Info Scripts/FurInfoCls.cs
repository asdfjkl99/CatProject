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
    string _name;
    string _desc;
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

    public FurInfoCls(int __id, int __no, Vector3 __pos, bool __usage)
    {
        _category = (int)CATEGORY.FNT;
        _id = __id;
        _no = __no;
        _pos = __pos;
        _usage = __usage;
    }

    public FurInfoCls(int __no, string __name, string __desc, int __cost)
    {
        _category = (int)CATEGORY.FNT;
        _no = __no;
        _name = __name;
        _desc = __desc;
        _cost = __cost;
    }

    protected override void Initialize()
    {
        _category = 4;
        _no = 0;
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
