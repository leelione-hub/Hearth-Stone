using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1Crystal : MonoBehaviour {

    public int UsableCrystal;       //可用水晶
    public int TotalCrystal;        //当前水晶
    public int MaxCrystal;          //最大水晶

    public UISprite[] Crystal;
    private UILabel self;


	// Use this for initialization
	void Start () {
         self = this.GetComponent<UILabel>();
        GameController._instance.OnNewRound += this.OnNewRound;
	}
	
	// Update is called once per frame
	void Update ()
    {
      UpdateCrystal();       
	}

    //更新水晶信息
    public void UpdateCrystal()
    {
        //让可用水晶与最大水晶之间水晶隐藏
        for(int i = TotalCrystal; i < MaxCrystal; i++)
        {
            Crystal[i].gameObject.SetActive(false);
        }
        //让可用水晶显示出来
        for (int i = 0; i < TotalCrystal; i++)
        {
            Crystal[i].gameObject.SetActive(true);
        }
        //让当前可用水晶与可用水晶之间水晶显示为暗水晶
        for (int i = UsableCrystal; i < TotalCrystal; i++)
        {
            Crystal[i].spriteName = "TextInlineImages_TextInlineImages_11";
        }
        //让当前可用水晶显示正确的sprite
        for (int i = 0; i < UsableCrystal; i++)
        {
            if (i == 9)
            {
                Crystal[i].spriteName = "TextInlineImages_TextInlineImages_10";
            }
            Crystal[i].spriteName = "TextInlineImages_TextInlineImages_" + (i + 1);
        }
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
        if (heroname == "hero1")
        {
            AddTotalCrastalNum();
        }
    }
}

