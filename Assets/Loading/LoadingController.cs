using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingController : MonoBehaviour
{

	public GameObject LoadingScene;


	protected void OnGUI ()
	{
		if (GUI.Button (new Rect (Screen.width / 2 - 100, 5, 200, 30), "Load Asynchronously")) {
			StartCoroutine (LoadingAsynchronously ());
		}
	}

	IEnumerator LoadingAsynchronously ()
	{
		LoadingScene.SetActive (true);
		AsyncOperation async = SceneManager.LoadSceneAsync ("Loading Second Scene");

		while (!async.isDone) {
			print ("loading progress: " + async.progress);
			yield return null;
		}
	}
}
