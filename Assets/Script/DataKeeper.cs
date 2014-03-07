using UnityEngine;
using System.Collections;

public class DataKeeper : MonoBehaviour {

	public static string playerName = "PLAYER";

	// Use this for initialization
	void Start () {
	//	playerName = "PLAYER";
	}

	public static void SetPlayerName(string name){
		playerName = name;
	}

	public static string GetPlayerName(){
		return playerName;
	}

}
