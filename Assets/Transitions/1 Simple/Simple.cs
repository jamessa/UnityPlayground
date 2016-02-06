using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Simple : MonoBehaviour
{
	public void LoadScene (string sceneString)
	{
		SceneManager.LoadScene (sceneString);
	}
}
