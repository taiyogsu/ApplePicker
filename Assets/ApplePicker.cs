using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject		basketPrefab;
	public int 				numBaskets = 3;
	public float 			basketBottomY = -14;
	public float			basketSpacingY = 2f;
	public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject> ();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AppleDestroyed(){
		//Destroy all the falling apples
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
		foreach (GameObject tGo in tAppleArray) {
			Destroy (tGo);
		}

		//Destroy one of the Baskets
		//Get the index of the last basket in baskelist
		int basketIndex = basketList.Count-1;
		//Get a rference to that Basket GameObejct
		GameObject tBasketGO = basketList[basketIndex];
		//Remove the Basket from the List and destroy the GameObject
		basketList.RemoveAt( basketIndex);
		Destroy (tBasketGO);

		//restart the game, doesnt affect Highscore.score
		if (basketList.Count == 0) {
			Application.LoadLevel ("_Scene_0");
		}
	}
}
