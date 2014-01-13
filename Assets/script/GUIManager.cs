using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	//system
	private float w;
	private float h;
	private bool readyToTitle;
	private bool readyToMain;
	private bool inputting;
	
	//MessageManager
	private string cur_text;
	//public GameObject msgManager;

	//about choices
	private bool questioned;
	private string[] choice = new string[4];
	private int[] point = new int[4];
	private string[] reaction = new string[4];

	//logo
//	private float logo_width;
//	private float logo_height;
	
	//MsgWindow
	private float win_width;
	private float win_height;

	//button
	private float btn_width;
	private float btn_height;
	
	//skin
	public GUIStyle skin_MsgWindow;
	public GUIStyle skin_Choices;
	public GUIStyle skin_Title;

	//
	public GameObject webcamManager;
	//
	// Use this for initialization
	void Start () {

		//Instantiate(msgManager);

		w = GameManager.w;
		h = GameManager.h;
		readyToTitle = false;
		readyToMain = false;
		inputting = false;
		
		//logo
//		logo_width = w * 0.6f;
//		logo_height = h * 0.3f;

		//about choices
		questioned = false;
		for(int i = 0 ; i < 4 ; i++){
			choice[i] = "CHOICE" + i.ToString();
		}
		
		//MsgWindow
//		win_width = w * 0.9f;
//		win_height = h * 0.17f;
		win_width = w;
		win_height = h * 0.22f;
		
		
		//button
		btn_width = w * 0.3f;
		btn_height = h * 0.15f;

		//text
		cur_text = "Test program will get started";	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){

		switch(GameManager.cur_scene){
		case GameManager.SCENE.TITLE:
			switch(GameManager.cur_scenario){
			case GameManager.SCENARIO.SCENARIO1:
				GUI.Box( new Rect(w * 0.21f, h *0.45f, w * 0.02f, w * 0.02f),"->", skin_Title);
				break;
			case GameManager.SCENARIO.SCENARIO2:
				GUI.Box( new Rect(w * 0.21f, h *0.50f, w * 0.02f, w * 0.02f),"->", skin_Title);
				break;
			case GameManager.SCENARIO.END1:
				GUI.Box( new Rect(w * 0.21f, h *0.55f, w * 0.02f, w * 0.02f),"->", skin_Title);
				break;
			default:
				break;
			}


			if( GUI.Button(new Rect(w * 0.3f, h * 0.45f, w * 0.4F, h * 0.05f), "Scenario1", skin_Title) ){
				GameManager.cur_scenario = GameManager.SCENARIO.SCENARIO1;
			}
			if( GUI.Button(new Rect(w * 0.3f, h * 0.50f, w * 0.4F, h * 0.05f), "Scenario2", skin_Title) ){
				GameManager.cur_scenario = GameManager.SCENARIO.SCENARIO2;
			}
			if( GUI.Button(new Rect(w * 0.3f, h * 0.55f, w * 0.4F, h * 0.05f), "End1", skin_Title) ){
				GameManager.cur_scenario = GameManager.SCENARIO.END1
					;
			}

			//GUI.Box(new Rect( (w * 0.5f) - (logo_width * 0.5f), h * 0.2f, logo_width, logo_height), "Imagine Love Simulation", skin); 
			//		GUI.Box(new Rect( (w * 0.5f) - (logo_width * 0.5f), (h * 0.3f), logo_width, logo_height * 3.0f), testImg); 
			if(GUI.Button(new Rect(w * 0.1f, h * 0.75f, btn_width, btn_height), "Imagine")){
				Debug.Log("Imagine Mode is being developed.");
				//
				GameObject webcam = Instantiate(webcamManager) as GameObject;
				//
			}
			if(GUI.Button(new Rect(w * 0.6f, h * 0.75f, btn_width, btn_height), "Fiction")){
//				Application.LoadLevel("Main");
				Application.LoadLevel("Setup");
			}
			break;
		case GameManager.SCENE.MAIN:
			/*///////////////test//////////////////
			if(GUI.Button(new Rect(0, 0, w *0.33f, 100), "TEST DEFAULT")){
				GameObject.Find("ImageManager").SendMessage("switchImg", "DEFAULT", SendMessageOptions.DontRequireReceiver);
			}
			if(GUI.Button(new Rect(w *0.33f, 0, w *0.33f, 100), "TEST SMILE")){
				GameObject.Find("ImageManager").SendMessage("switchImg", "SMILE", SendMessageOptions.DontRequireReceiver);
			}
			if(GUI.Button(new Rect(w *0.66f, 0, w *0.33f, 100), "TEST ANGRY")){
				GameObject.Find("ImageManager").SendMessage("switchImg", "ANGRY", SendMessageOptions.DontRequireReceiver);
			}
			*/////////////////test//////////////////
			if(questioned){
				if(GUI.Button(new Rect( 0, h * 0.8f, win_width * 0.5f, win_height * 0.5f), choice[0], skin_Choices)){
					GameManager.addPoint(this.point[0]);
					DispText(reaction[0]);
					questioned = false;
				}
				if(GUI.Button(new Rect( w * 0.5f, h * 0.8f, win_width * 0.5f, win_height * 0.5f), choice[1], skin_Choices)){
					GameManager.addPoint(this.point[1]);
					DispText(reaction[1]);
					questioned = false;
				}
				if(GUI.Button(new Rect( 0, h * 0.9f, win_width * 0.5f, win_height * 0.5f), choice[2], skin_Choices)){
					GameManager.addPoint(this.point[2]);
					DispText(reaction[2]);
					questioned = false;
				}
				if(GUI.Button(new Rect( w * 0.5f, h * 0.9f, win_width * 0.5f, win_height * 0.5f), choice[3], skin_Choices)){
					GameManager.addPoint(this.point[3]);
					DispText(reaction[3]);
					questioned = false;
				}
			}else{
				if(GUI.Button(new Rect( (w * 0.5f) - (win_width * 0.5f), h * 0.8f, win_width, win_height), cur_text, skin_MsgWindow)){
					if(readyToTitle){
						Application.LoadLevel("Title");
					}else{
						DispText();
					}
				}
			}
			break;
		case GameManager.SCENE.SETUP:
			if(GUI.Button(new Rect( (w * 0.5f) - (win_width * 0.5f), h * 0.8f, win_width, win_height), cur_text, skin_MsgWindow)){
				if(inputting){
					TouchScreenKeyboard keyboard;
					do{
						keyboard = TouchScreenKeyboard.Open("PLAYER");
					}while(keyboard.text == "");
					GameManager.ApplyPlayerName(keyboard.text);
					inputting = false;
				}else if(readyToMain){
					Application.LoadLevel("Main");
				}else{
					DispText();
				}
			}

			break;
		default:
			break;
		}
	}

	void DispText(){
		string tmp_text = MessageManager.AnalyzeLine();
		switch(tmp_text){
			case "END":
				readyToTitle = true;
				break;
			case "ENDSETUP":
				readyToMain = true;
				break;
			case "INPUTNAME":
				inputting = true;
				break;
			case " ":
				DispText();
				break;
		default:
			cur_text = tmp_text;
			break;
		}
	}

	void DispText(string text){
		string tmp_text = MessageManager.AnalyzeLine(text);
		switch(tmp_text){
		case "END":
			readyToTitle = true;
			break;
		case "ENDSETUP":
			readyToMain = true;
			break;
		case "INPUTNAME":
			inputting = true;
			break;
		default:
			cur_text = tmp_text;
			break;
		}
	}

	public void MakeChoices(string[] questionArray){
		string[] tmpArray;
		for(int i = 0 ; i < 4 ; i++){
			tmpArray = questionArray[i].Split(':');
			choice[i] = tmpArray[0];
			point[i] = int.Parse(tmpArray[1]);
			reaction[i] = tmpArray[2];
		}
		questioned = true;
	} 

	public void DispResult(string[] resultArray){

		if(GameManager.GetPoint() >=3){
			DispText(resultArray[0]);
		}else{
			DispText(resultArray[1]);
		}
	}
}
