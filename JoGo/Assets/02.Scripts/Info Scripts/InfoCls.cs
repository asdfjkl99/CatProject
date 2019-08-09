//////////////////////////////////////////////////////
//                                                  //
//                    BASIC INFO                    //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////
// 0 == Cat                                         //
// 1 == Food Item                                   //
// 2 == Toy Item                                    //
// 3 == Decoration Item                             //
// 4 == Furniture Item                              //
//////////////////////////////////////////////////////

public class InfoCls : MonoBehaviour
{
    // Object Category
    protected int _category;
    // Object Number
    protected int _no;

    //////////////////////////////////////////////////////
    //                    Initialize                    //
    //////////////////////////////////////////////////////
    public InfoCls()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        _category = 0;
        _no = 0;
    }

    //////////////////////////////////////////////////////
    //                   Return Value                   //
    //////////////////////////////////////////////////////
    public int GetCategory()
    {
        return _category;
    }

    public int GetNo()
    {
        return _no;
    }
}
