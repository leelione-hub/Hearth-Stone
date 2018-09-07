using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : Hero {

    private void Start()
    {
        uISprite = this.GetComponent<UISprite>();
        string heroname = PlayerPrefs.GetString("hero1");
        uISprite.spriteName = heroname;
    }
}
