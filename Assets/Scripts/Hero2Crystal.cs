using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2Crystal : MonoBehaviour {

    public int UsableCrystal;       //可用水晶
    public int TotalCrystal;        //当前水晶
    public int MaxCrystal;          //最大水晶

    //public UISprite[] Crystal;
    private UILabel self;

    private void Awake()
    {
        self = this.GetComponent<UILabel>();
    }

    // Use this for initialization
    void Start()
    {        
        GameController._instance.OnNewRound += this.OnNewRound;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    UpdateCrystal();
    //}

    //更新水晶信息
    public void UpdateCrystal()
    {
        self.text = UsableCrystal + "/" + TotalCrystal;
    }

    //判断当前水晶是否可以减少然后减少水晶
    public bool GetCrystal(int num)
    {
        if (UsableCrystal >= num)
        {
            UsableCrystal -= num;
            UpdateCrystal();
            return true;
        }
        else { return false; }
    }

    //增加可用水晶数量并更新 当前可用水晶数量
    public void AddTotalCrastalNum()
    {
        if (TotalCrystal < MaxCrystal)
        {
            TotalCrystal++;
        }
        UsableCrystal = TotalCrystal;
        UpdateCrystal();
    }
    public void OnNewRound(string heroname)
    {
        if (heroname=="hero2")
        {
            AddTotalCrastalNum();
        }
    }
}
