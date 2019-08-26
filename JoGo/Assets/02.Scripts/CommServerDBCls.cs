/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                        Communicate Server DB Class                              //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

/**
 * Communicate Server DB
 * 
 * This class is interface for communicate server.
 * This class gets data from server and return data.
 * 
 * Changes
 * 
 * 190826 Namhun Kim
 **/
public class CommServerDBCls : MonoBehaviour
{
    LitJson.JsonData _getData; // Json data

    private string _token; // ID
    private string _pwd; // Password

    private int _uid; // UID
    private int _uCoin; // User coin
    private int _uGold; // User money

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

    private void Start()
    {
        Initialize();

        this.AutoLogin();
    }
    /////////////////////////////////////////////////////////////////////////////////////
    //                                  Initialize                                     //
    /////////////////////////////////////////////////////////////////////////////////////

    /**
     * 190826 Namhun Kim
     * 
     * private void Initialize()
     * 
     * Initialize member variables.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void Initialize()
    {
        _token = null;
        _pwd = null;

        _uid = -1;
        _uCoin = -1;
        _uGold = -1;
    }

    /////////////////////////////////////////////////////////////////////////////////////
    //                                   Functions                                     //
    /////////////////////////////////////////////////////////////////////////////////////

    /**
     * 190826 Namhun Kim
     * 
     * private void GetUserData()
     * 
     * Get user data from server.
     * 
     * @param    void
     * 
     * @return   void
     **/
    private void GetUserData()
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("UID", _uid.ToString()));

        this.RequestToServer(".php", __form);

        _uCoin = int.Parse(_getData["UCoin"].ToString());
        _uGold = int.Parse(_getData["UGold"].ToString());
    }

    /**
     * 190826 Namhun Kim
     * 
     * public int GetUserMoney()
     * 
     * Get user money data from server and return data.
     * 
     * @param    void
     * 
     * @return   int __money   Player's money data.
     **/
    public int GetUserGold()
    {
        return _uGold; 
    }

    /**
     * 190826 Namhun Kim
     * 
     * public List<CatInfoCls> GetAllUserCatInfo()
     * 
     * This function gets all user's cat information.
     * Return user's all cat information.
     * 
     * @param    void
     * 
     * @return   List __catInfoList
     **/
    public List<CatInfoCls> GetAllUserCatInfo()
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("UID", _uid.ToString()));

        this.RequestToServer(".php", __form);

        List<CatInfoCls> __catInfoList = new List<CatInfoCls>();

        foreach (LitJson.JsonData __data in _getData)
        {
            __catInfoList.Add(new CatInfoCls(
                int.Parse(__data["CatID"].ToString()), // ID
                0, // Texture no
                int.Parse(__data["CatNum"].ToString()), // Cat no
                __data["CatName"].ToString(), // Name
                int.Parse(__data["CatBreed"].ToString()), // Breed
                int.Parse(__data["CatAge"].ToString()), // Age
                int.Parse(__data["CatSex"].ToString()), // Sex
                int.Parse(__data["CatRank"].ToString()), // Rank
                int.Parse(__data["CatInti"].ToString()), // Intimacy
                ParsePosition(__data["CatPos"].ToString()), // Position
                System.DateTime.Parse(__data["CatchingData"].ToString()) // Date
                )); 
        }

        return __catInfoList;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public List<UseItemInfoCls> GetAllUserItemInfo()
     * 
     * This function gets all user's item information for inventory.
     * Return user's all item information.
     * 
     * @param    void
     * 
     * @return   List __useItemList   User's all item information list.
     *                                UseItemInfoList: normal
     *                                null: Wrong category
     **/
    public List<UseItemInfoCls> GetAllUserItemInfo(CATEGORY __category)
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("UID", _uid.ToString()));

        string __phpName = null;
        string __id = null;

        if(__category == CATEGORY.FOOD)
        {
            __phpName = ".php";
            __id = "FOODBNum";
        }
        else if(__category == CATEGORY.TOY)
        {
            __phpName = ".php";
            __id = "TBNum";
        }
        else
        {
            Debug.Log("Wrong category");
            return null;
        }


        this.RequestToServer(__phpName, __form);

        List<UseItemInfoCls> __useItemList = new List<UseItemInfoCls>();

        foreach (LitJson.JsonData __data in _getData)
        {
            __useItemList.Add(new UseItemInfoCls(
                (int)__category,
                int.Parse(__data[__id].ToString()),
                int.Parse(__data["ItemNum"].ToString()),
                int.Parse(__data["ItemCount"].ToString())
                ));
        }

        return __useItemList;
    }

    /**
     * DUMMY
     **/
    public DecoItemInfoClass[] GetAllUserDecoItemInfo()
    {
        DecoItemInfoClass[] temp = null;

        return temp;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public List<FurInfoCls> GetAllUserFntInfo()
     * 
     * This function gets all user's furniture item informations for inventory or myroom.
     * Return furnitures information.
     * 
     * @param    void
     * 
     * @return   List __useItemInfo
     **/
    public List<FurInfoCls> GetAllUserFntInfo() // This is dummy
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("UID", _uid.ToString()));

        this.RequestToServer(".php", __form);

        List<FurInfoCls> __fntList = new List<FurInfoCls>();

        foreach(LitJson.JsonData __data in _getData)
        {
            __fntList.Add(new FurInfoCls(
                int.Parse(__data["FNTBNum"].ToString()),
                int.Parse(__data["ItemNum"].ToString()),
                ParsePosition(__data["FNTPos"].ToString()),
                bool.Parse(__data["FNTUsage"].ToString())
                ));
        }

        return __fntList;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public List<UseItemInfoCls> GetAllUseItemInfo()
     * 
     * This function gets all use item informations for shop.
     * Return use item informations list.
     * 
     * @param    void
     * 
     * @return   List __useItemInfo
     **/
    public List<UseItemInfoCls> GetAllUseItemInfo(CATEGORY __category)
    {
        List<UseItemInfoCls> __useItemList = new List<UseItemInfoCls>();
        string __phpName = null;

        if (__category == CATEGORY.FOOD)
        {
            __phpName = ".php";
        }
        else if (__category == CATEGORY.TOY)
        {
            __phpName = ".php";
        }
        else
        {
            Debug.Log("Wrong category");
            return null;
        }

        this.RequestToServer(__phpName, null);

        foreach(LitJson.JsonData __data in _getData)
        {
            __useItemList.Add(new UseItemInfoCls(
                (int)__category,
                int.Parse(__data["ItemNum"].ToString()),
                __data["ItemName"].ToString(),
                __data["ItemInfo"].ToString(),
                int.Parse(__data["ItemRank"].ToString()),
                float.Parse(__data["ItemEffect"].ToString()),
                int.Parse(__data["ItemCost"].ToString())
                ));
        }

        return __useItemList;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public List<FurInfoCls> GetAllFntInfo()
     * 
     * This function gets all furniture informations for shop.
     * Return furniture informations list.
     * 
     * @param    void
     * 
     * @return   List __useItemInfo
     **/
    public List<FurInfoCls> GetAllFntInfo()
    {
        List<FurInfoCls> __fntList = new List<FurInfoCls>();

        this.RequestToServer(".php", null);

        foreach (LitJson.JsonData __data in _getData)
        {
            __fntList.Add(new FurInfoCls(
                int.Parse(__data["ItemNum"].ToString()),
                __data["ItemName"].ToString(),
                __data["ItemInfo"].ToString(),
                int.Parse(__data["ItemCost"].ToString())
                ));
        }

        return __fntList;
    }

    /**
     * 190826 Namhun Kim
     * 
     * 
     **/
    public bool GetSvtSuc(int __svtNo) // This is dummy
    {
        bool isSuccess = false;

        // Get Success From Server

        return isSuccess;
    }

    /**
     * 190826 Namhun Kim
     * 
     * 
     **/
    public bool GetSvtClear() // This is dummy
    {
        bool isClear = false;

        // Get isClear From Server

        return isClear;
    }

    /**
     * 190826 Namhun Kim
     * 
     * 
     **/
    public bool GetFvtClear() // This is dummy
    {
        bool isClear = false;

        // Get isClear From Server

        return isClear;
    }

    /**
     * 
     * 
     * 
     **/
    private int UpdateBasicInfo()
    {
        // Update UID
        // Update did Tutorial
        UpdateDidTutorial(false);
        // Update user moeny
        UpdateUserGold(0);

        return 0;
    }

    /**
     * 
     * 
     * 
     **/
    public int UpdateDidTutorial(bool __didTutorial) // This is dummy
    {
        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public int UpdateUserGold()
     *  
     * This function updates user's gold amount to server.
     * 
     * @param    int __gold   User's gold amount
     * 
     * @return   int __code   Code that fail or success.
     *                        0: Success
     **/
    public int UpdateUserGold(int __gold) // This is dummy
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("UID", _uid.ToString()));
        __form.Add(new MultipartFormDataSection("UGold", __gold.ToString()));

        this.RequestToServer(".php", __form);

        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public int UpdateCatInfo()
     * 
     * This function updates cat informations to server.
     * 
     * @param    CatInfoCls __info   User's cat information.
     * 
     * @return   int        __code   Code that fail or success.
     *                      0: Success
     **/
    public int UpdateCatInfo(CatInfoCls __info) // This is dummy
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("UID", _uid.ToString()));
        __form.Add(new MultipartFormDataSection("CatID", __info.GetID().ToString()));
        __form.Add(new MultipartFormDataSection("CatNum", __info.GetCatNo().ToString()));
        __form.Add(new MultipartFormDataSection("CatName", __info.GetName().ToString()));
        __form.Add(new MultipartFormDataSection("CatBreed", __info.GetNo().ToString()));
        __form.Add(new MultipartFormDataSection("CatAge", __info.GetAge().ToString()));
        __form.Add(new MultipartFormDataSection("CatSex", __info.GetSex().ToString()));
        __form.Add(new MultipartFormDataSection("CatRank", __info.GetRank().ToString()));
        __form.Add(new MultipartFormDataSection("CatInti", __info.GetInti().ToString()));
        __form.Add(new MultipartFormDataSection("CatPos", __info.GetPos().ToString()));

        this.RequestToServer(".php", __form);

        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public int UpdateCatPos()
     * 
     * This function updates cat position to server.
     * 
     * @param    int     __catID   Cat's primary key.
     *           Vector3 __pos     Cat's position.
     *           
     * @return   int     __code    Code that fail or success
     *                             0: Success
     **/
    public int UpdateCatPos(int __catID, Vector3 __pos) { 
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("CatID", __catID.ToString()));
        __form.Add(new MultipartFormDataSection("CatPos", __pos.ToString()));

        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public int UpdateItemNum()
     * 
     * This function updates item count to server.
     * 
     * @param    CATEGORY __category   Which item that want to update.
     *           int      __id         Item's primary key.
     *           int      __num        Item's count.
     *           
     * @return   int      __code       Code that fail or success.
     **/
    public int UpdateItemNum(CATEGORY __category, int __id, int __num) {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();
        string __phpName = null;
        string __columnName = null;

        if(__category == CATEGORY.FOOD)
        {
            __columnName = "FOODBNum";
            __phpName = ".php";
        }
        else if(__category == CATEGORY.TOY)
        {
            __columnName = "TBNum";
            __phpName = ".php";
        }
        else
        {
            Debug.Log("Wrong category");
        }

        __form.Add(new MultipartFormDataSection(__columnName, __id.ToString()));
        __form.Add(new MultipartFormDataSection("ItemCount", __num.ToString()));

        this.RequestToServer(__phpName, __form);

        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public int UpdateFurPos()
     * 
     * This function updates furniture's position.
     * 
     * @param    int     __id     Furniture's primary key.
     *           Vector3 __pos    Furniture's position.
     * 
     * @return   int     __code   Code that fail or success.
     **/
    public int UpdateFurPos(int __id, Vector3 __pos)
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("FNTBNum", __id.ToString()));
        __form.Add(new MultipartFormDataSection("FNTPos", __pos.ToString()));

        this.RequestToServer(".php", __form);

        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * public int UpdateFurUsage()
     * 
     * This function updates furniture's usage.
     * 
     * @param    int  __id      Furniture's primary key.
     *           bool __usage   Is furniture use?
     *           
     * @return   int  __code    Code that fail or success.
     **/
    public int UpdateFurUsage(int __id, bool __usage)
    {
        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("FNTBNum", __id.ToString()));
        __form.Add(new MultipartFormDataSection("FNTUsage", __usage.ToString()));

        this.RequestToServer(".php", __form);

        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * 
     **/
    public int UpdateSvtSuccess(int __svtNo, bool __success)
    {
        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * 
     **/
    public int UpdateSvtClear(bool __clear) // This is dummy
    {
        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * 
     **/
    public int UpdateFvtClear(int __fvtNo, bool __clear) // This is dummy
    {
        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * private void AutoLogin()
     * 
     * This function gets login data from local for auto login.
     * This function needs login token.
     * 
     * @param    void
     * 
     * @return   int __code   Return code that error code or success
     *                        0: Success
     *                        1: Can't find LoginData file
     **/
    private int AutoLogin()
    {
        TextAsset __loginData = (TextAsset)Resources.Load("Data/LoginData"); // Get login data from local

        if (__loginData == null) // Can't find login data
        {
            Debug.Log("Can't find LoginData.json");
            return 1;
        }

        _getData = LitJson.JsonMapper.ToObject(__loginData.text);

        _token = _getData["TOKEN"].ToString(); // ID
        _pwd = _getData["PWD"].ToString(); // Password

        List<IMultipartFormSection> __form = new List<IMultipartFormSection>();

        __form.Add(new MultipartFormDataSection("TOKEN", _token));
        __form.Add(new MultipartFormDataSection("PWD", _pwd));

        return 0;
    }

    /**
     * 190826 Namhun Kim
     * 
     * private Inumerator RequsetToServer()
     * 
     * This function send request to server and gets JSON data from server.
     * 
     * @param    string                      __phpName   PHP name want to find data.
     *           List<IMultipartFormSection> __form      List that send data to server.
     * 
     * @return   void
     **/
    private IEnumerator RequestToServer(string __phpName, List<IMultipartFormSection> __form)
    {
        UnityWebRequest __www = UnityWebRequest.Post("https://" + __phpName, __form); // URL
        
        yield return __www.SendWebRequest(); // Wait for request

        // Error
        if (__www.isNetworkError || __www.isHttpError)
        {
            Debug.Log(__www.error);
        }
        // Get data
        else
        {
            _getData = LitJson.JsonMapper.ToObject(__www.downloadHandler.text);
        }
    }

    /**
     * 190826 Namhun Kim
     * 
     * private Vector3 ParsePosition()
     * 
     * This function parses string to vector3
     * 
     * @param    string  __data   String that want to parse.
     * 
     * @return   Vector3 __temp   Position that complete parsing.
     **/
    private Vector3 ParsePosition(string __data)
    {
        string[] __pos = __data.Split(','); // Split data
        Vector3 __temp = new Vector3(
            float.Parse(__pos[0]),
            float.Parse(__pos[1]),
            float.Parse(__pos[2])
            );

        return __temp;
    }
}