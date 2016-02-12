﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Example.Singleton
{

	public class SimpleTransition : MonoBehaviour
	{
		public void LoadScene (string sceneString)
		{
			print ("[Pure] " + Pure.Singleton.Instance.Add (1));
			print ("[Singleton]" + UnityWay.Singleton.Instance.Add (1));
			SceneManager.LoadScene (sceneString);
		}
	}

}