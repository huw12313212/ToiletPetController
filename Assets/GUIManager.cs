using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	public bool random = false;
	public bool loop = false;
	public List<string> animations;
	public bool servo = false;

	public NetworkManager networkManager;

	void OnGUI() {

		float width = 300;
		float height = 300;
		int index = 0;
		int indexZ = 0;


		foreach(string anim in animations)
		{
			if (GUI.Button (new Rect (index*width, indexZ*height, width, height), anim)) 
			{
				networkManager.setRandom(false);
				networkManager.PlayAnimation(anim);
			}
			
			index++;
		}
		indexZ++;
		index = 0;
	
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

		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "servo:"+servo)) 
		{
			servo = !servo;
			networkManager.Servo(servo);
		}


		indexZ++;
		index = 0;
		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "random("+random+")")) 
		{
			random = !random;
			networkManager.setRandom(random);
		}
		index++;
		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "loop("+loop+")")) 
		{
			loop = !loop;
			networkManager.setLoop(loop);
		}
		index++;

		indexZ++;
		index = 0;


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
