using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {
    //public MyCard myCard;
    //public GameController gameController;

    public Transform ToCard;
    public Transform FormCard;

    public GameObject PrefabCard;

    public string[] CardName;

    public float ChangeTime=2f;     //卡牌变换的持续时间
    public float ChangeSpeed=20;    //卡牌变换速度
    private bool IsChange = false;      //判定是否应该变换

    public float timer;         //定时器
    private UISprite TempCardSprite;

    //private bool IsPressDown = true;

	void Start () {
		
	}
	void Update () {
        timer += Time.deltaTime;
        //测试代码
        //if (Input.GetKeyDown(KeyCode.Space)&&IsPressDown)
        //{
        //    //myCard.GetCard(RandomAddCard());
        //    RandomAddCard();
            
        //    IsPressDown = false;
        //}
        if (IsChange)
        {                    
            int index = (int)(timer / (ChangeTime / ChangeSpeed));
            index %= 20;
            //让卡牌以目标速度切换
            TempCardSprite.spriteName = CardName[index];
            if (timer > ChangeTime)
            {
                IsChange = false;
                timer = 0;
                //IsPressDown = true;
                //重新生成随机卡牌
                TempCardSprite.spriteName = CardName[Random.Range(0, CardName.Length)];               
            }
            
        }

	}

    //在指定位置生成一张卡牌并移动至目标位置
    public GameObject RandomAddCard()
    {
       GameObject TempCard = NGUITools.AddChild(this.gameObject, PrefabCard);
        TempCard.transform.position = FormCard.transform.position;
        TempCardSprite = TempCard.GetComponent<UISprite>();
        iTween.MoveTo(TempCard, ToCard.transform.position, 1f);
        IsChange = true;
        return TempCard;
    }
}
