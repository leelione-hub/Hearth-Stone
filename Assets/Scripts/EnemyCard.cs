using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCard : MonoBehaviour {

    private List<GameObject> Cards = new List<GameObject>();
    public Transform Card_03;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetCard(GameObject goCard)
    {
        GameObject TempCard = null;       
        TempCard = goCard;
        TempCard.transform.parent = this.transform;        
        TempCard.GetComponent<UISprite>().width = 90;
        TempCard.GetComponent<UISprite>().depth = 6 + Cards.Count;
        Vector3 Newposition = Card_03.position;
        iTween.MoveTo(TempCard, Newposition, 1f);
        Cards.Add(TempCard);
    }
}
