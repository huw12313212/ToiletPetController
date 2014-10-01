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

		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "Happy")) 
		{
			CancelInvoke();

			networkManager.PlayAnimation("Happy");
			networkManager.PlaySound("assets/Hehehe.mp3",1);
			networkManager.Servo(true);

			Invoke("ServoDown",1);
			Invoke("ServoUp",2);
			Invoke("ServoDown",3);
			Invoke("Blink", 3);
			Invoke("ServoUp",4);
		}

		index++;

		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "LeftRight")) 
		{
			CancelInvoke();
			
			networkManager.PlayAnimation("LeftRight");
			networkManager.PlaySound("assets/Hehehe.mp3",1);
			networkManager.Servo(true);
			
			Invoke("ServoDown",1);
			Invoke("ServoUp",2);
			Invoke("ServoDown",3);
			Invoke("ServoUp",4);

		}
		index++;
		
		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "Pat")) 
		{
			CancelInvoke();
			
			networkManager.PlayAnimation("Normal");
			networkManager.PlaySound("assets/BatBat.mp3",1);
			networkManager.Servo(true);
			
			Invoke("ServoDown",1);
			Invoke("ServoUp",2);
			Invoke("ServoDown",3);
			Invoke("ServoUp",4);
			
		}

		index++;
		
		if (GUI.Button (new Rect (index*width, indexZ*height, width, height), "NO")) 
		{
			CancelInvoke();
			
			networkManager.PlayAnimation("Angry");
			networkManager.PlaySound("assets/What.mp3",1);
			networkManager.Servo(true);
			
			Invoke("ServoDown",1);
			Invoke("ServoUp",2);
			Invoke("ServoDown",3);
			Invoke("ServoUp",4);
			
		}


	}

	public void ServoDown()
	{
		networkManager.Servo(false);
	}

	public void ServoUp()
	{
		networkManager.Servo(true);
	}

	public void Blink()
	{
		networkManager.PlayAnimation("Happy");
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
