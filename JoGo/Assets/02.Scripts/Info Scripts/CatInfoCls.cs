//////////////////////////////////////////////////////
//                                                  //
//                 Cat Information                  //
//                                                  //
//////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////
//                CATEGORY NUMBER 0                 //
//////////////////////////////////////////////////////
public class CatInfoCls : InfoCls
{
    private int _texNo;
    private int _catNo;
    private string _name;
    private int _age;
    private int _sex;
    private int _rank;
    private float _inti;

    private int part_head;
    private int part_body;
    private int part_tail;

    private Vector3 _pos;
    private DateTime _catchDate;

    public CatInfoCls()
    {
        Initialize();
    }

    public CatInfoCls(int __id, int __texNo, int __catNo, string __name, int __breed, int __age, int __sex, int __rank, int __inti, Vector3 __pos, DateTime __date)
    {
        _category = (int)CATEGORY.CAT;
        _id = __id;
        _texNo = __texNo;
        _catNo = __catNo;
        _name = __name;
        _no = __breed;
        _age = __age;
        _sex = __sex;
        _rank = __rank;
        _inti = __inti;

        part_head = 0;
        part_body = 0;
        part_tail = 0;

        _pos = __pos;
        _catchDate = __date;
    }

    //////////////////////////////////////////////////////
    //                    Initialize                    //
    //////////////////////////////////////////////////////
    protected override void Initialize()
    {
        _category = 0;
        _no = 0;
        _texNo = 0;
        _catNo = 0;
        _name = null;
        _age = 0;
        _sex = 0;
        _rank = 0;
        _inti = 0;

        part_head = 0;
        part_body = 0;
        part_tail = 0;

        _pos.Set(0, 0, 0);
    }

    //////////////////////////////////////////////////////
    //                   Return Value                   //
    //////////////////////////////////////////////////////
    public int GetCatNo()
    {
        return _catNo;
    }

    public int GetTexNo()
    {
        return _texNo;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetAge()
    {
        return _age;
    }

    public int GetSex()
    {
        return _sex;
    }

    public int GetRank()
    {
        return _rank;
    }

    public float GetInti()
    {
        return _inti;
    }

    public int GetPartHead()
    {
        return part_head;
    }

    public int GetPartBody()
    {
        return part_body;
    }

    public int GetPartTail()
    {
        return part_tail;
    }

    public Vector3 GetPos()
    {
        return _pos;
    }

    public System.DateTime GetCatchDate()
    {
        return _catchDate;
    }

    //////////////////////////////////////////////////////
    //                     Set Value                    //
    //////////////////////////////////////////////////////

    // Set name
    public void SetName(string __name)
    {
        _name = __name;
    }

    // Add intimacy
    public float AddInti(float __inti)
    {
        _inti += __inti;

        return _inti;
    }

    // Sub intimacy
    public float SubInti(float __inti)
    {
        _inti -= __inti;

        return _inti;
    }

    // Set position
    public void SetPos(Vector3 __pos)
    {
        _pos = __pos;
    }

    //
    // Set cat information randomly
    //
    public void SetInfoRandomize()
    {
        _no = UnityEngine.Random.Range(0, 10);
        _texNo = UnityEngine.Random.Range(0, 3);
        _rank = UnityEngine.Random.Range(0, 4);
        _sex = UnityEngine.Random.Range(0, 2);
        _age = UnityEngine.Random.Range(1, 6);

        // Get name from client
        _name = CommClientDBCls._instance.GetName(0, _no);
    }

    //
    // Set decoration part
    //
    public void SetPartHead(int __num)
    {
        part_head = __num;
    }

    public void SetPartBody(int __num)
    {
        part_body = __num;
    }

    public void SetPartTail(int __num)
    {
        part_tail = __num;
    }
}
