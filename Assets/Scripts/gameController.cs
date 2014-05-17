using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;
using System.Reflection;

public class gameController : MonoBehaviour {

	public bool newGame = true;
	public float maxCash = 10000000.0f;
	public float currentCash;
	public float startingCash = 120000.0f;
	public float revenue;
	public float expenses;
	public int isNew = 1;

	public GameObject factory;
	public GameObject headQuarters;
	public GameObject mineTruck;
	public GameObject mineObj;
	public GameObject facility;

	public GameObject[] prefabObjs;

	public int headQuartLim = 1;
	public int factLim = 2;
	public int mineLim = 5;
	public int truckLim = 2;
	public int workerLim = 5;
	public int facLim = 1;

	public int headQuartNum = 0;
	public int factNum = 0;
	public int mineNum = 0;
	public int truckNum = 0;
	public int workerNum = 0;

	public GUIStyle style;

	void Start () {
		style.normal.textColor = Color.black;
		style.fontSize = 24;
		style.wordWrap = true;

		if (isNew == 1) {
			currentCash = startingCash;
			isNew = 0;
		}



	}

	void OnDestroy() {

	}

	void Update() {
		SelectionScript selectHQ = headQuarters.GetComponent<SelectionScript>();
		if (selectHQ.selected) {

		}
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, 300, 600), style);
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		GUILayout.Label("Money: $" + Convert.ToString (currentCash), style);
		GUILayout.Label("Workers: " + Convert.ToString(workerNum), style);
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(Screen.width/2-400, Screen.height-60, 800, 300), style);
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		if (GUILayout.Button("HQ", GUILayout.Width (50), GUILayout.Height (50))) {
			if (headQuarters != null) {
				SelectionScript selectHQ = headQuarters.GetComponent<SelectionScript>();
				selectHQ.selected = true;
			}
			else {
				Debug.LogWarning ("No model for headquarters!");
				return;
			}
		}
		GUILayout.EndVertical();
		GUILayout.BeginVertical();
		if (GUILayout.Button ("Factory", GUILayout.Width (50), GUILayout.Height (50))) {

		}
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

}