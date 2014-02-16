using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour{

	public GameObject gameManager;
	public GUIStyle GUISafe;

	public GameObject safe;
	private GameObject safePrefab;
	
	void Awake(){
		DontDestroyOnLoad(safe);
	}

	// Use this for initialization
	void Start () {
		if(gameManager.GetComponent<GameManager>().GetCureentScene() == GameManager.SCENE.TITLE){
			Debug.Log("safe has been made");
			safePrefab = Instantiate(safe) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	//void OnGUI(){
	//	GUI.Box(new Rect(0, 0, Screen.width, Screen.height), safe, GUISafe);
	//}
}
