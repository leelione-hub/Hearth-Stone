using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crad : MonoBehaviour {

    public UISprite Sprite;
    public string CardName      //防止卡牌名称被开始初始化（必须在使用才获取卡牌name，因为中间进行了多西随机变化）
    {
        get
        {
            if (Sprite == null)
            {
                Sprite = this.GetComponent<UISprite>();
            }
            return Sprite.spriteName;
        }
       
    }

    void OnPress(bool isPressed)
    {
        if (isPressed)
        {
            DesCard._instance.ShowCard(CardName);
        }

    }
    

    void Start()
    {

    }

	void Update () {
        //if (this.transform.parent == GameObject.Find("Fight"))
        //{
        //    float timer = 0;
        //    timer += Time.deltaTime;
        //    if (timer > 15f)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
	}
}
