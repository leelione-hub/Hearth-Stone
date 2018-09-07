using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public int MinHp = 0;
    public int MaxHp = 30;
    protected int CurrentHp = 0;
    protected UISprite uISprite;

    protected UILabel uILabel;

    private void Awake()
    {
        //uISprite = this.GetComponent<UISprite>();
        //string heroname = PlayerPrefs.GetString("hero1");
        //uISprite.spriteName = heroname;

        uILabel = this.transform.Find("hp").GetComponent<UILabel>();
        CurrentHp = MaxHp;
        uILabel.text = CurrentHp.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            uILabel.text = TakeDamage() + " ";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            uILabel.text = GetHealth() + " ";
        }
    }

    //模拟收到伤害时 玩家减少HP
    public int TakeDamage()
    {
        int damage = Random.Range(1, 5);
        CurrentHp -= damage;
        if (CurrentHp > 0 && CurrentHp <= 30) { return CurrentHp; }
        else if (CurrentHp > 30) { CurrentHp = 30; return CurrentHp; }
        else if (CurrentHp <= 0) { CurrentHp = 0; return CurrentHp; }
        return 0;
    }

    //模拟增加HP
    public int GetHealth()
    {
        int milk = Random.Range(1, 5);
        CurrentHp += milk;
        if (CurrentHp > 0 && CurrentHp <= 30) { return CurrentHp; }
        else if (CurrentHp > 30) { CurrentHp = 30; return CurrentHp; }
        else if (CurrentHp <= 0) { CurrentHp = 0; return CurrentHp; }
        return 0;
    }
}
