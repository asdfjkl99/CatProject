//////////////////////////////////////////////////////
//                                                  //
//           DECORATION ITEM INFORMATION            //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////
//                CATEGORY NUMBER 3                 //
//////////////////////////////////////////////////////
public class DecoItemInfoClass : ItemInfoCls
{
    //
    // 0 ~ 2
    // 0 = head
    // 1 = body
    // 2 = tail
    //
    private int _part;

//////////////////////////////////////////////////////
//                    Initialize                    //
//////////////////////////////////////////////////////
    protected override void Initialize()
    {
        _category = 3;
        _no = 0;
        _name = null;
        _desc = null;
        _num = 0;
        _part = 0;
    }

//////////////////////////////////////////////////////
//                   Return Value                   //
//////////////////////////////////////////////////////
    public int GetPart()
    {
        return _part;
    }
}
