//////////////////////////////////////////////////////
//                                                  //
//               USE ITEM INFORMATION               //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////
//               CATEGORY NUMBER 1, 2               //
//////////////////////////////////////////////////////
public class UseItemInfoCls : ItemInfoCls
{
    // Item rank
    private int _rank;
    // Item effect amount
    private float _effect;

    //////////////////////////////////////////////////////
    //                    Initialize                    //
    //////////////////////////////////////////////////////
    public UseItemInfoCls()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        _category = 1;
        _no = 0;
        _name = null;
        _desc = null;
        _num = 0;
        _rank = 0;
        _effect = 0.0f;
    }

    //////////////////////////////////////////////////////
    //                   Return Value                   //
    //////////////////////////////////////////////////////
    public int GetRank()
    {
        return _rank;
    }

    public float GetEffect()
    {
        return _effect;
    }
}
