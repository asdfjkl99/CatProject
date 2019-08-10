/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                                Communicate Client                               //
//                                                                                 //
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

/**
 * CommClientDB Class
 * 
 * This class helps to communicate client database.
 * This can load resoruce files, DB, etc from local device.
 * 
 * 190809 Namhun Kim
 * Write Initialize(), GetName(), GetDesc(), GetUseItemInfo(), FindXMLWithCategory()
 **/
public class CommClientDBCls : MonoBehaviour
{
    // This variables have each DB on memory
    //
    XmlDocument _cats; // cat DB
    XmlDocument _foods; // food item DB 
    XmlDocument _toys; // toy item DB
    XmlDocument _fnts; // furniture item DB

    // Singleton
    //
    public static CommClientDBCls _instance = null;

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
    }


/////////////////////////////////////////////////////////////////////////////////////
//                                   Initialize                                    //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 20190809 Namhun Kim
     *
     * Initialize member variables and load XML files to member variables
     * 
     * @param    void
     * @return   void
     **/
    private void Initialize()
    {
        // Load XML file
        //
        _cats = new XmlDocument();
        _foods = new XmlDocument();
        _toys = new XmlDocument();
        _fnts = new XmlDocument();

        TextAsset txtAsset = (TextAsset)Resources.Load("DB/CATDB");
        _cats.LoadXml(txtAsset.text);

        txtAsset = (TextAsset)Resources.Load("DB/FOODDB");
        _foods.LoadXml(txtAsset.text);

        txtAsset = (TextAsset)Resources.Load("DB/TOYDB");
        _toys.LoadXml(txtAsset.text);

        txtAsset = (TextAsset)Resources.Load("DB/FNTDB");
        _fnts.LoadXml(txtAsset.text);
    }


/////////////////////////////////////////////////////////////////////////////////////
//                                 Public Function                                 //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 
     **/
    public int LoadModel(int __category, int __no, int __texNo) // This is dummy
    {
        return 0;
    }

    /**
     * 
     **/
    public int LoadImage(int __category, int __no) // This is dummy
    {
        return 0;
    }

    /**
     * 
     **/
    public int LoadMusic(string __fileName) // This is dummy
    {
        // Can't find file
        if (false)
        {
            return -1;
        }

        return 0;
    }


    /**
    * 20190809 NamHun Kim
    * 
    * Get object name from XML and return name string
    * 
    * @param    int __category   Want to find object's category no
    * @param    int __no         Want to find object's no
    * @return                    Object name string
    *                            string: normal
    *                            null: Wrong _no param or __categroy param. Can't find object;
    **/
    public string GetName(int __category, int __no)
    {
        string __name = null;
        XmlNodeList __nodeList = FindXmlWithCategory(__category);

        // Category is wrong
        // ERROR CODE #2
        if(__nodeList == null)
        {
            Debug.Log("ERROR CODE#2. Wrong category");
            return null;
        }
        
        // Find name in DB
        foreach (XmlNode __node in __nodeList)
        {
            // Find with tag
            if (__node.SelectSingleNode("NO").InnerText == __no.ToString())
            {
                __name = __node.SelectSingleNode("NAME").InnerText;
                break;
            }
        }

        // No is wrong
        // ERROR CODE #1
        if (__name == null)
            Debug.Log("ERROR CODE#1. Wrong no");

        return __name;
    }

    /**
    * 20190809 NamHun Kim
    * 
    * Get object description from XML and return description string
    * 
    * @param    int __category   Want to find object's category no
    * @param    int __no         Want to find object's no
    * @return                    Object description string
    *                            string: normal
    *                            null: Wrong __no param or __cateogory param. Can't find object
    **/
    public string GetDesc(int __category, int __no) // This is dummy
    {
        string __desc = null;
        XmlNodeList __nodeList = FindXmlWithCategory(__category);

        // Category is wrong
        // ERROR CODE #2
        if(__nodeList == null)
        {
            Debug.Log("ERROR CODE#2. Wrong category");
            return null;
        }

        // Find decription in DB
        foreach (XmlNode __node in __nodeList)
        {
            // Find with tag
            if (__node.SelectSingleNode("NO").InnerText == __no.ToString())
            {
                __desc = __node.SelectSingleNode("DESC").InnerText;
                break;
            }
        }

        // No is wrong
        // ERROR CODE #1
        if (__desc == null)
            Debug.Log("ERROR CODE#1. Wrong no");

        return __desc;
    }

    /**
    * 20190809 NamHun Kim
    * 
    * Get object rank integer from XML and return rank integer
    * 0 = S
    * 1 = A
    * 2 = B
    * 3 = C
    * 
    * @param    int __category   Want to find object's category no
    * @param    int __no         Want to find object's no
    * @return                    Object integer rank
    *                            0 ~ 3: normal.
    *                               -1: Wrong __no param. Can't find object.
    *                               -2: Wrong __category param. Can't find category.
    **/
    public int GetRank(int __category, int __no)
    {
        int __rank = -1;
        XmlNodeList __nodeList = FindXmlWithCategory(__category);

        // Category is wrong (Rank is not exist)
        // ERROR CODE #2
        if(__nodeList[0].SelectSingleNode("RANK") == null)
        {
            Debug.Log("ERROR CODE#2. Wrong category");
            return -2;
        }

        // Find rank in DB
        foreach (XmlNode __node in __nodeList)
        {
            // Find with tag
            if (__node.SelectSingleNode("NO").InnerText == __no.ToString())
            {
                // Convert string to integer
                __rank = XmlConvert.ToInt32(__node.SelectSingleNode("RANK").InnerText); ;
                break;
            }
        }

        // No is wrong
        // ERROR CODE #1
        if (__rank == -1)
            Debug.Log("ERROR CODE#1. Wrong no");

        return __rank;
    }

    /**
    * 20190809 NamHun Kim
    * 
    * Get object effect value from XML and return effect value.
    * 
    * @param    int __category   Want to find object's category no
    * @param    int __no         Want to find object's no
    * @return                    Object integer rank
    *                            0 ~ 100.0f: normal.
    *                               -1.0f: Wrong __no param. Can't find object.
    *                               -2.0f: Wrong __category param. Can't find category.
    **/
    public float GetEffect(int __category, int __no)
    {
        float __effect = -1.0f;
        XmlNodeList __nodeList = FindXmlWithCategory(__category);

        // Category is wrong (Rank is not exist)
        // ERROR CODE #2
        if (__nodeList[0].SelectSingleNode("EFFECT") == null)
        {
            Debug.Log("ERROR CODE#2. Wrong category");
            return -2.0f;
        }

        // Find rank in DB
        foreach (XmlNode __node in __nodeList)
        {
            // Find with tag
            if (__node.SelectSingleNode("NO").InnerText == __no.ToString())
            {
                // Convert string to integer
                __effect = (float)XmlConvert.ToDouble(__node.SelectSingleNode("EFFECT").InnerText); ;
                break;
            }
        }

        // No is wrong
        // ERROR CODE #1
        if (__effect == -1.0f)
            Debug.Log("ERROR CODE#1. Wrong no");

        return __effect;
    }

    ///////////////////
    // This is dummy //
    ///////////////////
    
    //public DecoItemInfoClass GetDecoItemInfo(int __no)
    //{
    //    int __category = 3;

    //    return null;
    //}


/////////////////////////////////////////////////////////////////////////////////////
//                                Private Function                                 //
/////////////////////////////////////////////////////////////////////////////////////
    /**
     * 20190809 Namhun Kim
     * 
     * Find XML file with category and return XML node list
     * 
     * @param    int __category   Want to find object category no
     * @return                    Correct XML node list
     *                            XmlNodeList: normal
     *                            null: Wrong __category param. Can't find object
     **/
    private XmlNodeList FindXmlWithCategory(int __category)
    {
        XmlNodeList __nodeList = null;

        // find correct DB with category
        switch (__category)
        {
            case 0: // This is cat
                __nodeList = _cats.SelectNodes("CATINFO/CAT");
                break;
            case 1: // This is food item
                __nodeList = _foods.SelectNodes("FOODINFO/FOOD");
                break;
            case 2: // This is toy item
                __nodeList = _toys.SelectNodes("TOYINFO/TOY");
                break;
            case 3: // This is decoration item
                Debug.Log("Dummy");
                break;
            case 4: // This is furniture item
                __nodeList = _fnts.SelectNodes("FURNITUREINFO/FNT");
                break;
            default: // ERROR CODE #2
                Debug.Log("Wrong Category!! Category range is 0~4");
                return null;
        }

        return __nodeList;
    }
}

