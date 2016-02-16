using UnityEngine;
using System.Collections;

public class CoroutinesExample : MonoBehaviour
{
	public float smoothing = 1f;
	public Transform target;

	void Start ()
	{
		StartCoroutine (MyCoroutine (target));
		var logger = new Logger ();
		StartCoroutine (logger.Distance (transform, target));
	}

	IEnumerator MyCoroutine (Transform t)
	{
		while (Vector3.Distance (transform.position, t.position) > 0.05f) {
			transform.position = Vector3.Lerp (transform.position, t.position, smoothing * Time.deltaTime);
			yield return null;
		}
		Debug.Log ("Reached the target.");
		yield return new WaitForSeconds (3f);
		Debug.Log ("MyCoroutine is now finished");
	}

	// Calling coroutine from non Monobehaviour 
	class Logger
	{
		public IEnumerator Distance (Transform a, Transform b)
		{
			while (true) {
				Debug.Log ("Distance " + Vector3.Distance (a.position, b.position));
				yield return new WaitForSeconds (3f);
			}
		}
	}
}
