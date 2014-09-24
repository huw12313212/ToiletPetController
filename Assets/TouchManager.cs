using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public NetworkManager networkManager;


	//public WebSocketTest

	// Use this for initialization
	void Start () 
	{
		Input.multiTouchEnabled = false;
	}

	public GameObject lastClicked = null;
	public Vector3 lastPosition = Vector3.zero;
	public Vector3 lastTouch = Vector3.zero;
	public Camera nowCamera;

	void MouseUpdate ()
	{
		Vector3 pos = nowCamera.ScreenToWorldPoint (Input.mousePosition);
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hitInfo = Physics2D.Raycast (pos, Vector2.zero);
			Debug.Log (pos);
			if (hitInfo) {
				Debug.Log ("hit");
				if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer ("Eye")) {
					lastClicked = hitInfo.transform.gameObject;
				}
			}
		}
		else
			if (Input.GetMouseButtonUp (0)) {
				lastClicked = null;
			}
			else
				if (lastClicked != null) {
					Vector3 offset = pos - lastPosition;
					lastClicked.transform.position += offset;
					Debug.Log ("pos:" + lastClicked);
					SpriteRenderer sr = lastClicked.GetComponent<SpriteRenderer> ();
					networkManager.UpdatePosition (lastClicked.name, lastClicked.transform.position.x * 100 + 320 / 2, -lastClicked.transform.position.y * 100 + 240 / 2);
				}
		lastPosition = pos;
	}



	void TouchUpdate ()
	{

		Touch t = Input.GetTouch (0);

		Vector3 pos = nowCamera.ScreenToWorldPoint (t.position);

		if(t.phase == TouchPhase.Began)
		{
			lastTouch = pos;
			RaycastHit2D hitInfo = Physics2D.Raycast (pos, Vector2.zero);
			Debug.Log (pos);
			if (hitInfo) 
			{
				Debug.Log ("hit");
				if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer ("Eye")) 
				{
					lastClicked = hitInfo.transform.gameObject;
				}
			}
		}
		else if (t.phase==TouchPhase.Ended || t.phase==TouchPhase.Canceled) 
		{
			lastClicked = null;
		}
		else if (lastClicked != null) 
		{
			Vector3 offset = pos - lastPosition;
			lastClicked.transform.position += offset;
			Debug.Log ("pos:" + lastClicked);
			SpriteRenderer sr = lastClicked.GetComponent<SpriteRenderer> ();
			networkManager.UpdatePosition (lastClicked.name, lastClicked.transform.position.x * 100 + 320 / 2, -lastClicked.transform.position.y * 100 + 240 / 2);
			lastTouch = pos;
		}
		
		lastTouch = pos;
	}
	
	// Update is called once per frame
	void Update () 
	{
		MouseUpdate ();


	}
}
