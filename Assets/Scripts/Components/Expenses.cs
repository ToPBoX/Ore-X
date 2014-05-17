using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[System.Serializable]
public class Expenses : MonoBehaviour {

	[SerializeField]
	public float expenseCost = 50.0f;
	public float revenue = 0.0f;
}
