using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	
	public float dragSpeed;
	private Vector3 dragOrigin;

	float speed = 2f;

	private Quaternion rotateOrigin;

	public Transform target;

	bool isGUI = true;

	public Vector2 scrollPosition;
	
	public bool newGame = true;
	public Texture tex;

	public Texture2D[] tutorials;

	public Texture prevButton;
	public Texture closeButton;
	public Texture nextButton;

	public int guiNum = 0;

	public GUISkin customGUI;

	void Start () {

		dragSpeed = PlayerPrefs.GetFloat("dragSpeed", 1f);
		if (tutorials.Length <= 0 || tutorials.Length < 1) {
			Debug.LogError ("Missing Textures!");
			return;
		}
		else {
			Debug.Log ("Textures in place! Running smoothly! :)");
		}

	}

	// Camera movement
	void Update () {

		if (!isGUI) {

			CameraDrag();

			if(Input.GetAxis ("Mouse ScrollWheel") < 0) {
				if(Camera.main.fieldOfView <= 70) {
					Camera.main.fieldOfView += 2f;
				}
				if(Camera.main.orthographicSize <= 20) {
					Camera.main.orthographicSize += 0.5f;
				}
			}

			if(Input.GetAxis("Mouse ScrollWheel") > 0) {

				if(Camera.main.fieldOfView > 20) {
					Camera.main.fieldOfView -= 2f;
				}
				if(Camera.main.orthographicSize >= 1) {
					Camera.main.orthographicSize -= 0.5f;
				}
			}

			float horz = Input.GetAxis ("Horizontal");
			float vert = Input.GetAxis ("Vertical");

			Vector3 v = transform.forward;
			v.y = 0;
			v.Normalize();

			transform.position += v * horz * speed * Time.deltaTime;
			transform.position += Vector3.up * vert * Time.deltaTime;
		}

		else {
			return;
		}
	}

	void OnDestroy() {
		PlayerPrefs.SetFloat("dragSpeed", dragSpeed);
		PlayerPrefs.Save ();
	}

	void CameraDrag() {
		if (!isGUI) {
			if (Input.GetMouseButtonDown(2)) {
				dragOrigin = Input.mousePosition;
			}
			
			else if(!Input.GetMouseButton (2)) {
				return;
			}
			
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			Vector3 move = new Vector3(pos.x * (dragSpeed * -1), 0, pos.y * (dragSpeed * -1));
			
			transform.Translate(move, Space.World);

		}
		else {
			return;
		}
	}

	void CameraRotation() {
		/*if(Input.GetMouseButton (1)) {

			float h = dragSpeed * Input.GetAxis ("Mouse X");
			float v = dragSpeed * Input.GetAxis("Mouse Y");
			transform.Rotate(v, h, 0);

			rotateOrigin = Quaternion.identity;

		}
		else if(!Input.GetMouseButton (1)){
			return;
		}

		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

		transform.Rotate (move, Space.World);*/

	}

	void OnGUI() {

		GUI.skin = customGUI;

		//Tutorial
		if(newGame == true) {
			if(tutorials.Length <= 0 || tutorials.Length < 1 || !tex) {
				Debug.LogError ("No texture!");
				return;
			}
			
			else {
				/*GUILayout.BeginArea (new Rect(0, 0, Screen.width, Screen.height));
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace ();
				GUILayout.BeginVertical();
				GUILayout.FlexibleSpace();
				GUILayout.BeginHorizontal ();
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height (100), GUILayout.Width (500));
				GUILayout.FlexibleSpace ();
				GUILayout.TextArea("Welcome to Ore-X, a tycoon game based on mining!\n" +
				                   "In order to play this game, you will need a mouse and a keyboard.\n" +
				                   "To build something, look at your toolbar below. There are many different tabs for different things.\n" +
				                   "The first thing you will want to build is an HQ. Here you can manage your buildings, staff, whatever.\n" +
				                   "It is your management building, so it is free. However, your first mining expedition will cost money.");
				GUILayout.FlexibleSpace ();
				GUILayout.EndScrollView();
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal();
				
				if (GUILayout.Button ("OK")) {
					
				}
				
				GUILayout.FlexibleSpace();
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.EndArea ();*/
				if (isGUI) {
					if (guiNum < tutorials.Length-1) {
						if(GUI.Button (new Rect(Screen.width/2, Screen.height/2+150, nextButton.width, nextButton.height), nextButton)) {
							guiNum++;
						}
					}
					else {
						if(GUI.Button(new Rect(Screen.width/2, Screen.height/2+150, closeButton.width, closeButton.height), closeButton)) {
							isGUI = false;
						}
					}

					if(guiNum == 0) {
						if(GUI.Button (new Rect(Screen.width/2-300, Screen.height/2+150, closeButton.width, closeButton.height), closeButton)) {
							isGUI = false;
						}
					}
					else {
						if(GUI.Button (new Rect(Screen.width/2-300, Screen.height/2+150, prevButton.width, prevButton.height), prevButton)) {
							guiNum--;
						}
					}

					if (tutorials[guiNum] != null) {
						GUI.DrawTexture(new Rect(Screen.width/2-300, Screen.height/2-150, 600, 300), tutorials[guiNum], ScaleMode.StretchToFill, true, 10.0f);
					}
				}
				else {
					return;
				}
			}
			
		}
		
	}

}
