using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCard : MonoBehaviour {

    private List<GameObject> Cards = new List<GameObject>();        //用来储存战场之上的卡牌
    public Transform Card_01;
    public Transform Card_02;
    private float Xoffset = 0f;                                     //战场上卡牌的间距

    private void Start()
    {
        Xoffset = Card_01.position.x - Card_02.position.x;
    }

    //将接收的卡牌 放置在Fight之下
    public void AddFightCard(GameObject goCard)
    {

        goCard.transform.parent = this.transform;
        Cards.Add(goCard);
        Vector3 TemVec3 = OffsetPosition();
        iTween.MoveTo(goCard,TemVec3, 0.5f);
        Destroy(goCard.GetComponent<DragbleCard>());

    }

    //用于计算 此时放置卡牌在战场的偏移
    public Vector3 OffsetPosition()
    {
        Vector3 offsetposition = new Vector3();
        int index = Cards.Count / 2;
        if (Cards.Count % 2 == 0)
        {
            offsetposition = new Vector3(Card_01.position.x + Xoffset * index, Card_01.position.y, Card_01.position.z);           
        }
        else
        {
            offsetposition = new Vector3(Card_01.position.x - Xoffset * index, Card_01.position.y, Card_01.position.z);
        }
        return offsetposition;
    }

}
