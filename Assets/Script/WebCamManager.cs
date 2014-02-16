using UnityEngine;
using System.Collections;

public class WebCamManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		if(devices.Length > 0){
			WebCamTexture webCamTexture = new WebCamTexture(320, 240, 12);
			this.renderer.material.SetTexture("Webcam", webCamTexture);
			webCamTexture.Play();
		}else{
			Debug.LogError("Cannot find WebCam.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
