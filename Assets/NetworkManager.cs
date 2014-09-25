﻿using UnityEngine;
using System.Collections;
using WebSocketSharp;


public class NetworkManager : MonoBehaviour {

	public string WSAddress = "ws://10.0.1.37";
	public string WSPort = "9300";
	public delegate void ReceivedMessage(string str);

	WebSocket ws;
	// Use this for initialization
	void Start () {

		ws = new WebSocket (WSAddress+":"+WSPort);
		ws.Connect ();
		Debug.Log ("test");

		ws.OnMessage += (object sender, MessageEventArgs e) => 
		{
			Debug.Log(e.Data);
		};
	}

	public void SendMessage(string str)
	{
		ws.Send(str);
	}

	public void PlaySound(string name,float volume)
	{
		JSONObject data = new JSONObject();
		
		data.AddField("command","playSound");
		data.AddField("target",name);
		data.AddField("volume",volume);

		ws.Send(data.ToString());
	}

	public void UpdatePosition(string name,float x,float y)
	{
			JSONObject data = new JSONObject();
			
			data.AddField("command","updatePosition");
			data.AddField("target",name);
			data.AddField("x",x);
			data.AddField("y",y);
			ws.Send(data.ToString());
	}



	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.W))
		{
			JSONObject data = new JSONObject();

			data.AddField("command","playSound");
			data.AddField("target","assets/Shutter-02.wav");

			Debug.Log("W pressed");
			ws.Send(data.ToString());
		}
	}
}