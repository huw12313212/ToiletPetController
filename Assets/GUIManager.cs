using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public NetworkManager networkManager;

	void OnGUI() {

		float width = 300;
		float height = 700;
		int index = 0;
	
		if (GUI.Button (new Rect (index*300, 0, width, height), "Test")) 
		{
			networkManager.PlaySound("assets/Shutter-02.wav",1);
		}
		index++;

		if (GUI.Button (new Rect (index*300, 0, width, height), "ha")) 
		{
			networkManager.PlaySound("assets/ahahaha.mp3",0.5f);
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
