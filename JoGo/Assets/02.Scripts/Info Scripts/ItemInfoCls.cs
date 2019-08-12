//////////////////////////////////////////////////////
//                                                  //
//                 ITEM INFORMATION                 //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoCls : InfoCls
{
    // Object name
    protected string _name;
    // Object description
    protected string _desc;
    // Object amount
    protected int _num;

    //////////////////////////////////////////////////////
    //                    Initialize                    //
    //////////////////////////////////////////////////////
    public ItemInfoCls()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        _name = null;
        _desc = null;
        _num = 0;
    }

    //////////////////////////////////////////////////////
    //                   Return Value                   //
    //////////////////////////////////////////////////////
    public string GetName()
    {
        return _name;
    }

    public string GetDesc()
    {
        return _desc;
    }

    public int GetNum()
    {
        return _num;
    }
}
