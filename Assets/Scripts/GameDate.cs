
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDate : MonoBehaviour {

    public static GameDate _gamedate;

    public string[] HeroNames =
       {"吉安娜·普罗德摩尔",
        "雷克萨",
        "乌瑟尔·光明使者",
        "加尔鲁什·地狱咆哮",
        "玛法里奥·怒风",
        "古尔丹",
        "萨尔",
        "安杜因·乌瑞恩",
        "瓦蕾拉·桑古纳尔" };

    public string[] cardName;

    void Start () {
        _gamedate = this;
	}
	

}
