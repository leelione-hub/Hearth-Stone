using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate       //游戏模式
{
    CardGenerating,
    Play,
    End
}

public class GameController : MonoBehaviour {

    public static GameController _instance;
    public MyCard myCard;
    public EnemyCard enemyCard;
    public CardGenerator cardGenerator;
    public Gamestate gamestate = Gamestate.CardGenerating; //默认发牌模式

    public int MaxTime=60;      //玩家思考最大时间
    public float timer=0;         //定时器
    public float MinTime = 15;      //出现导火线的时间
    public int CardNum = 4;         //每次发牌的数量

    private UISprite Fuse;       //接收导火线
    private float FuseLegth;

    public string CurrentHeroName ="hero1";        //默认开始玩家为hero1

    public int RoundIndex = 0;
    public delegate void OnNewRoundEvent(string HeroName);
    public event OnNewRoundEvent OnNewRound;

    private UILabel label;

    private bool isquite = false;
    public GameObject Tip;

	void Awake () {
        _instance = this;
        Fuse = this.transform.Find("fuse").GetComponent<UISprite>();
        FuseLegth = Fuse.width;
        Fuse.width = 0;
        cardGenerator = this.GetComponent<CardGenerator>();
        StartCoroutine(PushCardForHero1());
        
	}

    private void Start()
    {
      
    }
    void Update () {
        if (gamestate == Gamestate.Play)
        {
            timer += Time.deltaTime;

            if (timer > MaxTime)
            {
                TransformPlayer();
            }
            if ((MaxTime - timer) <= MinTime)
            {
                Fuse.width =(int)( ((MaxTime - timer) / MinTime) * FuseLegth);
            }
        }

        
	}

    public void TransformPlayer()
    {
        timer = 0;
        if (CurrentHeroName == "hero1")
        {
            CurrentHeroName = "hero2";
        }
        else
        {
            CurrentHeroName = "hero1";
        }

        RoundIndex++;
        Debug.Log(CurrentHeroName);
        OnNewRound(CurrentHeroName);
    }

    //为玩家发牌
    public IEnumerator PushCardForHero1()
    {
        for (int i = 0; i < CardNum; i++)
        {
            //发牌器 生成卡牌
            GameObject goCard = cardGenerator.RandomAddCard();
            yield return new WaitForSeconds(2f);
            //将生成的卡牌移动至目标位置
            myCard.GetCard(goCard);
        }
        for (int i = 0; i < CardNum; i++)
        {
            //发牌器 生成卡牌
            GameObject goCard = cardGenerator.RandomAddCard();
            yield return new WaitForSeconds(2f);
            //将生成的卡牌移动至目标位置
            enemyCard.GetCard(goCard);
        }

            gamestate = Gamestate.Play;
    }
}
