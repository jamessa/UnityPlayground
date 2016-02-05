// Editor Script must live in /Editor Folder to work nicely with Debug mode.

using UnityEngine;
using UnityEditor;
using UnityEditor.iOS.Xcode;

public class SomeBuildScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("OnPostprocessBuildiOS");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}