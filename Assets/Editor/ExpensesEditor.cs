using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Expenses))]
public class ExpensesEditor : Editor {

	public override void OnInspectorGUI () {

		Expenses expenseFinal = (Expenses)target;

		expenseFinal.expenseCost = EditorGUILayout.FloatField("Expense Cost", expenseFinal.expenseCost, GUILayout.MaxHeight (128));
		expenseFinal.revenue = EditorGUILayout.FloatField("Revenue for each worker", expenseFinal.revenue, GUILayout.MaxHeight(128));

	}

}
