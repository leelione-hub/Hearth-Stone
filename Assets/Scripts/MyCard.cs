using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCard : MonoBehaviour {

    public Transform Card_01;
    public Transform Card_02;
    public Transform Card_lose;

    public GameObject PrefabCard;
    public List<string> CardNames=new List<string>();       //储存卡牌name用来 修改UIsprite下spritename

    private List<GameObject> Cards=new List<GameObject>();  //用于将MyCards下的卡牌储存
    private List<GameObject> LoseCards = new List<GameObject>();    //测试用于丢弃卡牌储存

    private float Xoffset=0;
    
    // Use this for initialization
	void Start () {
        Xoffset = Card_02.position.x - Card_01.position.x;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
          GetCard(null);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoseCard();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DestoryCard();
        }
	}

    //目标从其他处获取卡牌储存在MyCards下
    public void GetCard(GameObject goCard)
    {
        GameObject TempCard=null;
        if (goCard == null)
        {
            //yield return new WaitForSeconds(0f);
            TempCard = NGUITools.AddChild(this.gameObject, PrefabCard);
            TempCard.GetComponent<UISprite>().spriteName = CardNames[Random.Range(0, 4)];
        }
        else
        {
            TempCard = goCard;
            TempCard.transform.parent = this.transform;
        }
        TempCard.GetComponent<UISprite>().width = 90;
        TempCard.GetComponent<UISprite>().depth = 6 + Cards.Count;
        Vector3 Newposition = Card_01.position + new Vector3(Xoffset, 0, 0) * Cards.Count;
        iTween.MoveTo(TempCard, Newposition, 1f);
        Cards.Add(TempCard);
    }

    //测试用于丢弃卡牌
    public void LoseCard()
    {
        int index = Random.Range(0, Cards.Count);
        iTween.MoveTo(Cards[index], Card_lose.position, 1f);
        LoseCards.Add(Cards[index]);
        Cards.RemoveAt(index);
        UpdateCardInfo();
        
    }

    //更新卡牌位置信息
    public  void UpdateCardInfo()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            Vector3 Newv3 = Card_01.position + new Vector3(Xoffset, 0, 0) * i;
            iTween.MoveTo(Cards[i], Newv3, 0.5f);
            Cards[i].GetComponent<UISprite>().depth = 6 + i;
        }
    }

    //销毁丢弃的卡牌（测试用）
    public void DestoryCard()
    {
        for(int i = 0; i < LoseCards.Count; i++)
        {
            //just for Fun...
            Destroy(LoseCards[i]);
            //iTween.RotateTo(LoseCards[i], this.transform.position + new Vector3(0, 180, 0), 1f);
        }
    }

    //将卡牌从MyCards中移除
    public void RemoveCard(GameObject goCard)
    {
        Cards.Remove(goCard);
    }
}
