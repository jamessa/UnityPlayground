using UnityEngine;
using System.Collections;

public class CoroutinesExample : MonoBehaviour
{
	public float smoothing = 1f;
	public Transform target;

	void Start ()
	{
		StartCoroutine (MyCoroutine (target));
	}

	IEnumerator MyCoroutine (Transform t)
	{
		while (Vector3.Distance (transform.position, t.position) > 0.05f) {
			transform.position = Vector3.Lerp (transform.position, t.position, smoothing * Time.deltaTime);
			Debug.Log ("Moving toward target. " + Vector3.Distance (transform.position, t.position));
			yield return null;
		}
	
		Debug.Log ("Reached the target.");

		yield return new WaitForSeconds (3f);

		Debug.Log ("MyCoroutine is now finished");
	}

}

