using UnityEngine;
using UnityEngine.SceneManagement;

namespace Example.Transitions.Simple
{
	public class Simple : MonoBehaviour
	{
		public void LoadScene (string sceneString)
		{
			SceneManager.LoadScene (sceneString);
		}
	}
}