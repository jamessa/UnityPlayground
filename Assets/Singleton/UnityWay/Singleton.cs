using UnityEngine;

namespace Example.Singleton.UnityWay
{
	// http://wiki.unity3d.com/index.php/Singleton
	public class Singleton : MonoBehaviour
	{
		static Singleton _instance;
		static object _lock = new object ();

		public static Singleton Instance {
			get {
				if (applicationIsQuitting) {
					Debug.LogWarning ("[Singleton] Instance '" + typeof(Singleton) + "' already destroyed on application quit. Won't create again - returning null.");
					return null;
				}

				lock (_lock) {
					if (_instance == null) {
						var singleton = new GameObject ();
						_instance = singleton.AddComponent<Singleton> ();
						singleton.name = "(singleton)" + typeof(Singleton).ToString ();

						DontDestroyOnLoad (singleton);

						Debug.Log ("[Singleton An instance of " + typeof(Singleton).ToString () + " is need in the scene, so '" + singleton + "' was created with DontDestroyOnLoad.");
					} else {
						Debug.Log ("[Singleton Using instance already created: " + _instance.gameObject.name);
					}
					return _instance;
				}
			}
		}
	
		static bool applicationIsQuitting = false;

		public void OnDestroy ()
		{
			applicationIsQuitting = true;
		}
			
		// set to zero by default
		int Counter;

		public int Add (int count)
		{
			return Counter += count;
		}
	}
}