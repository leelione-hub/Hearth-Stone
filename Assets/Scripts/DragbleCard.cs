using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragbleCard :UIDragDropItem{

    public int num=1;     //默认出一张卡牌需要消耗的水晶

    //重写OnDragDropRelease方法 实现基本拖拽功能
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        //只有卡牌处在 fightarea之下才可以放置卡牌
        if (surface.tag == "Fightarea" && surface.tag != null)
        {
            Hero1Crystal hero1Crystal = GameObject.Find("hero1crystal").GetComponent<Hero1Crystal>();
            bool Succes = hero1Crystal.GetCrystal(num);
            if (Succes)
            {
                //水晶数量足够时直接移动卡牌||当卡牌放置到目标位置时从Mycard中删除当前卡牌
                this.transform.parent.GetComponent<MyCard>().RemoveCard(this.gameObject);
                surface.transform.GetComponent<FightCard>().AddFightCard(this.gameObject);
            }
            else
            {
                transform.parent.GetComponent<MyCard>().UpdateCardInfo();
            }

            

        }
        //当卡牌的位置并不在 目标位置时 重置卡牌位置
        else
        {
            if (this.transform.parent == surface)
            {
                surface.transform.GetComponent<FightCard>().AddFightCard(this.gameObject);
            }
            else
            {
                transform.parent.GetComponent<MyCard>().UpdateCardInfo();
            }
        }

    }

}
