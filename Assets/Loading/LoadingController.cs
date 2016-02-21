using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingController : MonoBehaviour
{
	public GameObject LoadingScenePanel;

	protected void OnGUI ()
	{
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 3, 200, 30), "Load Asynchronously")) {
			StartCoroutine (LoadAsynchronously ());
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height * 2 / 3, 200, 30), "Load with Additive Scene")) {
			StartCoroutine (LoadWithAdditiveScene ());
		}
	}

	IEnumerator LoadAsynchronously ()
	{
		LoadingScenePanel.SetActive (true);
		yield return new WaitForSeconds (2); // just for demo
		AsyncOperation async = SceneManager.LoadSceneAsync ("Loading Second Scene");

		while (!async.isDone) {
			print ("loading progress: " + async.progress);
			yield return null;
		}
	}

	IEnumerator LoadWithAdditiveScene ()
	{
		print ("Loading additive loading scene");
		SceneManager.LoadScene ("Loading Scene", LoadSceneMode.Additive);
		yield return new WaitForSeconds (2); // just for demo

		AsyncOperation async = SceneManager.LoadSceneAsync ("Loading Second Scene");
		async.allowSceneActivation = false;
		while (!async.isDone) {
			print ("loading progress: " + async.progress);
			yield return new WaitForSeconds (1); // just for demo

			// Sometime you're not only wait for a scene but also other
			// long operation like download, you can put them here.
			if (async.progress >= 0.9f) {
				print ("Second scene loaded.");
				async.allowSceneActivation = true;
			}

		}
	}
}
