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

    public UseItemInfoCls(int __category, int __id, int __no, int __num)
    {
        _category = __category;
        _id = __id;
        _no = __no;
        _num = __num;
    }

    public UseItemInfoCls(int __category, int __no, string __name, string __desc, int __rank, float __effect, int __cost)
    {
        _category = __category;
        _id = -1;
        _no = __no;
        _name = __name;
        _desc = __desc;
        _num = -1;
        _rank = __rank;
        _effect = __effect;
        _cost = __cost;
    }

    protected override void Initialize()
    {
        _category = 1;
        _no = -1;
        _name = null;
        _desc = null;
        _num = 0;
        _rank = 0;
        _effect = 0.0f;
        _cost = 0;
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
