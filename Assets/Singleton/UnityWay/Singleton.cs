using UnityEngine;
using System.Diagnostics.CodeAnalysis;

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
						singleton.name = "(singleton)" + typeof(Singleton);

						DontDestroyOnLoad (singleton);

						Debug.Log ("[Singleton An instance of " + typeof(Singleton) + " is need in the scene, so '" + singleton + "' was created with DontDestroyOnLoad.");
					} else {
						Debug.Log ("[Singleton Using instance already created: " + _instance.gameObject.name);
					}
					return _instance;
				}
			}
		}

		static bool applicationIsQuitting;

		public void OnDestroy ()
		{
			applicationIsQuitting = true;
		}
			
		// set to zero by default
		int counter;

		public int Add (int count)
		{
			return counter += count;
		}
	}

	/// <summary>
	/// Be aware this will not prevent a non singleton constructor
	///   such as `T myT = new T();`
	/// To prevent that, add `protected T () {}` to your singleton class.
	/// 
	/// As a note, this is made as MonoBehaviour because we need Coroutines.
	/// </summary>
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		[SuppressMessage ("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		static T _instance;

		[SuppressMessage ("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		static object _lock = new object ();

		public static T Instance {
			get {
				if (applicationIsQuitting) {
					Debug.LogWarning ("[Singleton] Instance '" + typeof(T) +
					"' already destroyed on application quit." +
					" Won't create again - returning null.");
					return null;
				}

				lock (_lock) {
					if (_instance == null) {
						_instance = (T)FindObjectOfType (typeof(T));

						if (FindObjectsOfType (typeof(T)).Length > 1) {
							Debug.LogError ("[Singleton] Something went really wrong " +
							" - there should never be more than 1 singleton!" +
							" Reopening the scene might fix it.");
							return _instance;
						}

						if (_instance == null) {
							var singleton = new GameObject ();
							_instance = singleton.AddComponent<T> ();
							singleton.name = "(singleton) " + typeof(T);

							DontDestroyOnLoad (singleton);

							Debug.Log ("[Singleton] An instance of " + typeof(T) +
							" is needed in the scene, so '" + singleton +
							"' was created with DontDestroyOnLoad.");
						} else {
							Debug.Log ("[Singleton] Using instance already created: " +
							_instance.gameObject.name);
						}
					}

					return _instance;
				}
			}
		}

		[SuppressMessage ("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		static bool applicationIsQuitting;

		/// <summary>
		/// When Unity quits, it destroys objects in a random order.
		/// In principle, a Singleton is only destroyed when application quits.
		/// If any script calls Instance after it have been destroyed, 
		///   it will create a buggy ghost object that will stay on the Editor scene
		///   even after stopping playing the Application. Really bad!
		/// So, this was made to be sure we're not creating that buggy ghost object.
		/// </summary>
		public void OnDestroy ()
		{
			applicationIsQuitting = true;
		}
	}

	public class Counter : Singleton<Counter>
	{
		int counter;

		protected Counter ()
		{
		}

		public int Add (int count)
		{
			return counter += count;
		}
	}
}