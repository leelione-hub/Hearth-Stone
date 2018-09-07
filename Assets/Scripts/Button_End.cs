using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_End : MonoBehaviour {

    
    private UIButton self;
    private UILabel label;

    private void Awake()
    {
        self = this.GetComponent<UIButton>();
        label = this.transform.Find("gameend").GetComponent<UILabel>();
    }
    private void Start()
    {
        GameController._instance.OnNewRound += this.OnNewRound;        
    }
    public void On_Click()
    {
        if (label.text == "结束回合")
        {
            self.SetState(UIButtonColor.State.Disabled, true);       
            GameController._instance.TransformPlayer();
        }
    }

    public void OnNewRound(string heroname)
    {
        if (heroname == "hero1")
        {
            label.text = "结束回合";
            self.SetState(UIButtonColor.State.Disabled, false);
        }
        else
        {
            label.text = "对方回合";
            self.SetState(UIButtonColor.State.Disabled, true);
        }
    }
}
