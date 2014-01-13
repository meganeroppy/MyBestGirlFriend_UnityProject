using UnityEngine;
using System.Collections;

public class ImageManager : MonoBehaviour {
//	private enum STATE{DEFAULT, SMILE, ANGRY};
//	private STATE cur_state;

	public GameObject girl_default;
	public GameObject girl_smile;
	public GameObject girl_angry;
	private static GameObject cur_img;
	private GameObject girlPrefab;


	// Use this for initialization
	void Start () {
//		cur_state = STATE.DEFAULT;
		cur_img = girl_default;
//		girlPrefab = Instantiate(cur_img) as GameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void switchImg(string next_img){
		//print ("ImageManager.switchImg()");
		Destroy(girlPrefab);		//destroy current image
		switch(next_img){
		case "DEFAULT":
			girlPrefab = Instantiate( girl_default) as GameObject;
			break;
		case "SMILE":
			girlPrefab = Instantiate( girl_smile) as GameObject;
			break;
		case "ANGRY":
			girlPrefab = Instantiate( girl_angry) as GameObject;
			break;
		case "NONE":
			break;
		default:
			break;
		}
	}
}
