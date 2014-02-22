using UnityEngine;
using System.Collections;

public class TextField : MonoBehaviour {

	private static string text = "player";

	private bool completed = false;

	private float form_posX;
	private float form_posY;
	private float form_width;
	private float form_height;
	private float done_width;
	private const int MAX_LENGTH = 8;

	public GameObject gameManager;
	// Use this for initialization
	void Start () {

		form_posX = Screen.width * 0.2f;
		form_posY = Screen.height * 0.77f;
		form_width = Screen.width * 0.2f;
		form_height = Screen.height * 0.04f;
		done_width = Screen.width * 0.1f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		if(!completed){

			text = GUI.TextField( new Rect(form_posX, form_posY, form_width, form_height), text, MAX_LENGTH);
			if(GUI.Button(new Rect(form_posX + form_width, form_posY, done_width, form_height), "Done")){
				completed = true;
				gameManager.GetComponent<GameManager>().ApplyPlayerName(text);
			}
		}

	}

	public string GetText(){
		return text;
	}

	public bool CheckIsComplete(){
		return completed;
	}
}
