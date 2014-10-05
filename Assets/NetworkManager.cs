using UnityEngine;
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

	public void PlayAnimation(string str)
	{
		JSONObject data = new JSONObject();
		
		data.AddField("command","playAnimation");
		data.AddField("name",str);
		
		ws.Send(data.ToString());
		Debug.Log (data.ToString());
	}

	public void setLoop(bool value)
	{

		JSONObject data = new JSONObject();
		
		data.AddField("command","loop");
		data.AddField("value",value);
		
		ws.Send(data.ToString());
		Debug.Log (data.ToString());
	}

	public void setRandom(bool value)
	{
		JSONObject data = new JSONObject();
		
		data.AddField("command","random");
		data.AddField("value",value);
		
		ws.Send(data.ToString());
		Debug.Log (data.ToString());
	}

	public void FlipServo()
	{
		servoState = !servoState;
		Servo(servoState);
	}

	public void Servo(bool up)
	{
		servoState = up;
		JSONObject data = new JSONObject();
		
		data.AddField("command","servo");
		data.AddField("target",name);
		data.AddField("value",up);
		
		ws.Send(data.ToString());
		Debug.Log (data.ToString());

	}

	public void PlaySound(string name,float volume)
	{
		JSONObject data = new JSONObject();
		
		data.AddField("command","playSound");
		data.AddField("target",name);
		data.AddField("volume",volume);

		ws.Send(data.ToString());
		Debug.Log (data.ToString());
	}

	public void UpdatePosition(string name,float x,float y)
	{
			JSONObject data = new JSONObject();
			
			data.AddField("command","updatePosition");
			data.AddField("target",name);
			data.AddField("x",x);
			data.AddField("y",y);
			ws.Send(data.ToString());
		Debug.Log (data.ToString());
	}


	public bool servoState = true;

	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.W))
		{
			JSONObject data = new JSONObject();

			data.AddField("command","playSound");
			data.AddField("target","assets/Shutter-02.wav");

			Debug.Log("W pressed");
			ws.Send(data.ToString());
			Debug.Log (data.ToString());
		}
	}
}
