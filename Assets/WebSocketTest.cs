using UnityEngine;
using System.Collections;
using WebSocketSharp;

public class WebSocketTest : MonoBehaviour {

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

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W))
		{
			Debug.Log("W pressed");
			ws.Send("W pressed");
		}
	}
}
