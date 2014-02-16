using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//system
	//public static int num = 0;

	public static float w;
	public static float h;
	private enum OS{WINDOWS, IOS, ANDROID, UNKNOWN};
	private static OS cur_OS;
	private bool DataKeeperIsExist;

//	private float margin_side;
//	private float margin_updown;
	public enum SCENE{TITLE, MAIN, SETUP};
	public static SCENE cur_scene;

	//scenario
	public enum SCENARIO{SCENARIO1, SCENARIO2, END1};
	public static SCENARIO cur_scenario = SCENARIO.SCENARIO1;

	//status
	private static string playerName;
	private int point_total;
	public string tmp = "not editted";

	//Managers
//	public GameObject GUIManager;
//	public GameObject ImageManager;
	public GameObject webcamManager;
	//public GameObject dataKeeper;
	//private GameObject dataKeeperPrefab;
	public GameObject effectManager;
	private GameObject effectManagerPrefab;
	public GameObject imageManager;
	private GameObject imageManagerPrefab;
	public GameObject messageManager;
	private GameObject messageManagerPrefab;
	public GameObject GUIManager;
	private GameObject GUIManagerPrefab;
	
	void Awake(){
		cur_OS = AnalyzeOS();
		w = Screen.width;
		h = Screen.height;
		//		margin_side = w * 0.02f;
		//		margin_updown = h * 0.02f;

		//if(GameObject.FindWithTag("DataKeeper") == null){
		//	DontDestroyOnLoad(dataKeeper);
		//	dataKeeperPrefab = Instantiate(dataKeeper) as GameObject;
		//}

	}

	// Use this for initialization
	void Start () {
	
		GUIManagerPrefab = Instantiate(GUIManager) as GameObject;

		string levelName = Application.loadedLevelName;
		switch(levelName){
		case "Title":
			cur_scene = SCENE.TITLE;
			tmp = "eidtted";
			break;
		case "Main":
			cur_scene = SCENE.MAIN;
			imageManagerPrefab = Instantiate(imageManager) as GameObject;
			effectManagerPrefab = Instantiate(effectManager) as GameObject;
			messageManagerPrefab = Instantiate(messageManager) as GameObject;
			//playerName = dataKeeper.GetComponent<DataKeeper>().GetPlayerName();
			point_total = 0;
			break;
		case "Setup":
			cur_scene = SCENE.SETUP;
			imageManagerPrefab = Instantiate(imageManager) as GameObject;
			messageManagerPrefab = Instantiate(messageManager) as GameObject;
			break;
		default:
			print (levelName);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(num);
	}

//	void startConversation(){
//		Application.LoadLevel("Main");
//	}

	public void addPoint(int point){
		if(point >= 1){
			effectManager.GetComponent<EffectManager>().Make("GOOD");

	//		num += 1;
		}

		point_total += point;
	}

	public int GetPoint(){
		return point_total;
	}

	public void ApplyPlayerName(string name){
		playerName = name;
		DataKeeper.SetPlayerName(name);
		//dataKeeper.GetComponent<DataKeeper>().SetPlayerName(name);
	}

	public string GetPlayerName(){
		return DataKeeper.GetPlayerName();
	}

	public SCENE GetCureentScene(){
		return cur_scene;
	}

	private OS AnalyzeOS(){
		string tmp = SystemInfo.operatingSystem.ToUpper();

		if(tmp.Contains("ANDROID")){
			return OS.ANDROID;
		}else if(tmp.Contains("WINDOWS")){
			return OS.WINDOWS; 
		}else  if(tmp.Contains("IOS")){
			return OS.IOS;
		}else{
			return OS.UNKNOWN;
		}
	}

	public string GetCurOS(){
		return cur_OS.ToString();
	}
}
