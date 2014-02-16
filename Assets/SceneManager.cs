using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameObject gameManager;
	private GameObject preservedGameManager;

	void Awake(){
		DontDestroyOnLoad( preservedGameManager );
	}
	// Use this for initialization
	void Start () {
		preservedGameManager = gameManager;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
