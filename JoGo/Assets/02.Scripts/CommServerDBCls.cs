//////////////////////////////////////////////////////
//                                                  //
//                Communicate Server                //
//                                                  //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommServerDBCls : MonoBehaviour
{
    // User ID
    private int uid;

    // Singleton
    //
    public static CommServerDBCls _instance = null;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);
    }

    //////////////////////////////////////////////////////
    //                  Get From Server                 //
    //////////////////////////////////////////////////////

    //
    // ALL FUNCTION IS DUMMY
    //
    public int GetUserMoney()
    {
        int __money = 1000000;

        return __money; // This is dummy
    }

    public CatInfoCls[] GetAllCatInfo()
    {
        CatInfoCls[] temp = null;
        // Get From Server
        int allCatAmount = 3; // This is dummy

        for (int i = 0; i < allCatAmount; ++i)
        {
            temp[i] = new CatInfoCls();
            // Get From Server
            temp[i] = GetCatInfo(i);
        }

        return temp;
    }

    public UseItemInfoCls[] GetAllItemInfo() // This is dummy
    {
        UseItemInfoCls[] temp = null;

        return temp;
    }

    public DecoItemInfoClass[] GetAllDecoItemInfo() // This is dummy
    {
        DecoItemInfoClass[] temp = null;

        return temp;
    }

    public FurInfoCls[] GetAllFurInfo() // This is dummy
    {
        FurInfoCls[] temp = null;

        return temp;
    }

    public CatInfoCls GetCatInfo(int __catNo)
    {
        CatInfoCls temp = null;

        // GET FROM SERVER
        temp.SetInfoRandomize(); // This is dummy

        Debug.Log(temp.GetNo());

        return temp;
    }

    public FurInfoCls GetFurInfo(int __no, int __furNo) // This is dummy
    {
        FurInfoCls temp = new FurInfoCls();

        return temp;
    }

    public int GetItemNum(int __category, int __no)
    {
        int num = 0;

        switch (__category)
        {
            case 1:
                // Food Item
                num = 10; // This is dummy
                break;
            case 2:
                // Toy Item
                num = 10; // This is dummy
                break;
            case 3:
                // Decoration Item
                num = 1; // This is dummy
                break;
            default:
                // ERROR CODE #
                break;
        }

        return num;
    }

    public int GetItemCost(int __category, int __no)
    {
        int cost = 0;

        switch (__category)
        {
            case 1:
                // Food Item
                cost = 100; // This is dummy
                break;
            case 2:
                // Toy Item
                cost = 1000; // This is dummy
                break;
            case 3:
                // Decoration Item
                cost = 10000; // This is dummy
                break;
            case 4:
                // Furniture Item
                cost = 10000; // This is dummy
                break;
            default:
                // ERROR CODE #
                break;
        }

        return cost;
    }

    public bool GetSvtSuc(int __svtNo) // This is dummy
    {
        bool isSuccess = false;

        // Get Success From Server

        return isSuccess;
    }

    public bool GetSvtClear() // This is dummy
    {
        bool isClear = false;

        // Get isClear From Server

        return isClear;
    }

    public bool GetFvtClear() // This is dummy
    {
        bool isClear = false;

        // Get isClear From Server

        return isClear;
    }

    //////////////////////////////////////////////////////
    //                 Update On Server                 //
    //////////////////////////////////////////////////////
    private int UpdateBasicInfo()
    {
        // Update UID
        // Update did Tutorial
        UpdateDidTutorial(false);
        // Update user moeny
        UpdateUserMoney(0);

        return 0;
    }

    public int UpdateDidTutorial(bool __didTutorial) // This is dummy
    {
        return 0;
    }

    public int UpdateUserMoney(int __money) // This is dummy
    {
        return 0;
    }

    public int UpdateCatInfo(CatInfoCls __info) // This is dummy
    {
        return 0;
    }

    public int UpdateCatPos(int __catNo, Vector3 __pos) // This is dummy
    {
        return 0;
    }

    public int UpdateItemNum(int __category, int __no, int __num) // This is dummy
    {
        return 0;
    }

    public int UpdateFurPos(int __no, int __furNo, Vector3 __pos) // This is dummy
    {
        return 0;
    }

    public int UpdateFurUsage(int __no, int __furNo, bool __usage) // This is dummy
    {
        return 0;
    }

    public int UpdateSvtSuccess(int __svtNo, bool __success) // This is dummy
    {
        return 0;
    }

    public int UpdateSvtClear(bool __clear) // This is dummy
    {
        return 0;
    }

    public int UpdateFvtClear(int __fvtNo, bool __clear) // This is dummy
    {
        return 0;
    }
}
