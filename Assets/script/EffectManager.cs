using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {

	public GameObject effect_good;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Make(string request){
//		print(Random.value);
		switch(request){
		case "GOOD":
			Instantiate(effect_good, transform.position, transform.rotation);
			break;
		default:
			break;
		}
	}
}
