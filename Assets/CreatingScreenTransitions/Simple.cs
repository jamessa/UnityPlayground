using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Simple : MonoBehaviour
{
	public void LoadScene2 ()
	{
		SceneManager.LoadScene ("Screen2");
	}
}
