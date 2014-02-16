using UnityEngine;
using System.Collections;

public class DataKeeper : MonoBehaviour {

	public static string playerName = "PLAYER";

	// Use this for initialization
	void Start () {
	//	playerName = "PLAYER";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SetPlayerName(string name){
		playerName = name;
	}

	public static string GetPlayerName(){
		return playerName;
	}

}
