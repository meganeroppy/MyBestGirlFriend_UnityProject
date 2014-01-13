using UnityEngine;
using System.Collections;

public class SaveDataManager : MonoBehaviour {

	private static string savedPlayerName;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SavePlayerName(string name){
		savedPlayerName = name;
	}

	public static string LoadPlayerName(){
		return savedPlayerName;
	}

}
