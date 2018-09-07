using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesCard : MonoBehaviour {
    //单列模式
    public static DesCard _instance;
    private UISprite Sprite;
    public float ShowTime=2;
    public  float timer=0;

    void Awake()
    {
        _instance = this;

        Sprite = this.GetComponent<UISprite>();

        this.gameObject.SetActive(false);
    }

    //用于外界调用、显示
    public void ShowCard(string CardName)
    {
        this.gameObject.SetActive(true);

        Sprite.spriteName = CardName;

        timer = 0;
        iTween.FadeTo(this.gameObject,0,2f);
       
    }

	void Start () {

    }
	
	void Update () {
        timer += Time.deltaTime;
        iTween.FadeTo(this.gameObject, 0, 2f);
        if (timer > ShowTime)
        {
            this.gameObject.SetActive(false);
        }
    }
}
