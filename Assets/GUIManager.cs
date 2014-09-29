using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	public bool random = false;
	public bool loop = false;
	public List<string> animations;
	public bool servo = true;

	public float width = 30;
	public float height = 30;

	public List<string> soundLists;
	public float soundVolume;

	public NetworkManager networkManager;

	void OnGUI() {

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
	

		foreach (string soundName in soundLists) 
		{
			if (GUI.Button (new Rect (index*width, indexZ*height, width, height), soundName)) 
			{
				networkManager.PlaySound(soundName,soundVolume);
			}
			index++;	
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
