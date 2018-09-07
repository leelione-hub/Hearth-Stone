using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2 :Hero {

    // Use this for initialization
  

    private void Start()
    {
        uISprite = this.GetComponent<UISprite>();
        string heroname = PlayerPrefs.GetString("hero2");
        uISprite.spriteName = heroname;
    }
}
