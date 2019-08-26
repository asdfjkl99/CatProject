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

public enum CATEGORY
{
    CAT,
    FOOD,
    TOY,
    DECO,
    FNT
}

public class InfoCls : MonoBehaviour
{
    protected int _id;
    // Object Category
    protected int _category;
    // Object Number
    protected int _no;
    // Object Cost
    protected int _cost;

    //////////////////////////////////////////////////////
    //                    Initialize                    //
    //////////////////////////////////////////////////////
    public InfoCls()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        _id = 0;
        _category = 0;
        _no = 0;
        _cost = 0;
    }

    //////////////////////////////////////////////////////
    //                   Return Value                   //
    //////////////////////////////////////////////////////
    public int GetID()
    {
        return _id;
    }
    public int GetCategory()
    {
        return _category;
    }

    public int GetNo()
    {
        return _no;
    }
    
    public int GetCost()
    {
        return _cost;
    }
}
