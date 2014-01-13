using UnityEngine;
using System.Collections;

public class Effect_good : MonoBehaviour {
	private const float DURATION = 1.2f;
	private float t_time;
	// Use this for initialization
	void Start () {
		t_time = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.realtimeSinceStartup - t_time >= DURATION){
			Destroy(this.gameObject);
		}
	}
}
