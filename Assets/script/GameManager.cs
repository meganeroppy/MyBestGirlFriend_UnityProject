using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//system
	public static float w;
	public static float h;

//	private float margin_side;
//	private float margin_updown;
	public enum SCENE{TITLE, MAIN, SETUP};
	public static SCENE cur_scene;

	//scenario
	public enum SCENARIO{SCENARIO1, SCENARIO2, END1};
	public static SCENARIO cur_scenario = SCENARIO.SCENARIO1;

	//status
	private static string tmpPlayerName;
	private static int point_total;


	//Managers
//	public GameObject GUIManager;
//	public GameObject ImageManager;
	public GameObject webcamManager;

	void Awake(){
		w = Screen.width;
		h = Screen.height;
		//		margin_side = w * 0.02f;
		//		margin_updown = h * 0.02f;
	}

	// Use this for initialization
	void Start () {

		tmpPlayerName = SaveDataManager.LoadPlayerName();

		string levelName = Application.loadedLevelName;
		switch(levelName){
		case "Title":
			cur_scene = SCENE.TITLE;
			break;
		case "Main":
			cur_scene = SCENE.MAIN;
			point_total = 0;
			break;
		case "Setup":
			cur_scene = SCENE.SETUP;
			break;
		default:
			print (levelName);
			break;
		}



	}
	
	// Update is called once per frame
	void Update () {
	}

//	void startConversation(){
//		Application.LoadLevel("Main");
//	}

	public static void addPoint(int point){
		if(point >= 1){
			GameObject.Find("EffectManager").SendMessage("M" +
				"ake", "GOOD", SendMessageOptions.RequireReceiver);
		}

		point_total += point;
	}

	public static int GetPoint(){
		return point_total;
	}

	public static void ApplyPlayerName(string name){
		tmpPlayerName = name;
		SaveDataManager.SavePlayerName(name);
	}

	public static string GetPlayerName(){
		return tmpPlayerName;
	}


}
