using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SelectionScript))]
public class SelectionEditor : Editor {

	public override void OnInspectorGUI() {
		SelectionScript selected = (SelectionScript)target;
		selected.selected = EditorGUILayout.Toggle("Selected", selected.selected, GUILayout.MaxHeight (128));
	}

}
