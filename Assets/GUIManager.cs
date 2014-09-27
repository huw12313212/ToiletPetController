using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public NetworkManager networkManager;

	void OnGUI() {

		float width = 100;
		float height = 100;
		int index = 0;
		int indexZ = 0;
	
		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "Test")) 
		{
			networkManager.PlaySound("assets/Shutter-02.wav",1);
		}
		index++;

		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "ha")) 
		{
			networkManager.PlaySound("assets/ahahaha.mp3",0.5f);
		}

		indexZ++;
		index = 0;

		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "up")) 
		{
			networkManager.Servo(true);
		}
		index++;

		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "down")) 
		{
			networkManager.Servo(false);
		}
		// assets/ahahaha.mp3
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
