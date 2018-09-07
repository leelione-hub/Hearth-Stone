using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistroyCard : MonoBehaviour {

    public Transform Card01_Temp;
    public Transform Card02_Temp;
    public Transform CardIn_Temp;
    public Transform CardOut_Temp;

    public GameObject prefabcard;

    private List<GameObject> CardList=new List<GameObject>();
    private float Yoffset;  

	// Use this for initialization
	void Start () {
        Yoffset = Card02_Temp.position.y - Card01_Temp.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //   StartCoroutine(AddCard());
        //    Debug.Log(Yoffset);
        //}
	}

    public IEnumerator AddCard()
    {
        GameObject TempCard = GameObject.Instantiate(prefabcard, CardIn_Temp.position, Quaternion.identity) as GameObject;
        yield return 0;
        TempCard.transform.position = CardIn_Temp.position;
        TempCard.GetComponent<UISprite>().depth=1;    
        iTween.MoveTo(TempCard, Card01_Temp.position,1f);
        if (CardList.Count >= 5)
        {
            iTween.MoveTo(CardList[0],Card01_Temp.position+CardOut_Temp.position, 1f);

            Destroy(CardList[0], 2f);
            CardList.RemoveAt(0);
        }
        for(int i = 0; i < CardList.Count; i++)
        {
            iTween.MoveTo(CardList[i],CardList[i].transform.position+new Vector3(0, Yoffset, 0), 0.5f);
        }
        CardList.Add(TempCard);
    }
}
