using UnityEngine;
using Prime31.StateKitLite;

namespace Example.State
{
	public enum Player
	{
		Walking,
		Idle
	}

	public class StateSceneController : StateKitLite<Player>
	{

		// if you implement Awake in your subclass you must call base.Awake()
		void Awake ()
		{
			base.Awake ();
		}

		// in either Awake or Start the initialState must be set
		void Start ()
		{
			initialState = Player.Idle;
		}

		// if you implement Update in your subclass you must call base.Update()
		void Update ()
		{
			base.Update ();
		}

		protected void OnGUI ()
		{
			if (GUI.Button (new Rect (Screen.width * 1 / 3 - 50, 5, 100, 30), "Walk")) {
				currentState = Player.Walking;
			}

			if (GUI.Button (new Rect (Screen.width * 2 / 3 - 50, 5, 100, 30), "Idle")) {
				currentState = Player.Idle;
			}
			var centeredStyle = GUI.skin.GetStyle ("Label");
			centeredStyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 4, 100, 30), currentState.ToString (), centeredStyle);
		}

		void Walking_Enter ()
		{
			print ("Walk enter.");
		}

		void Walking_Tick ()
		{
//		print ("Walking");
		}

		void Walking_Exit ()
		{
			print ("Walk exit.");
		}

		void Idle_Enter ()
		{
			print ("Idle enter.");
		}

		void Idle_Tick ()
		{
//		print ("Idling");
		}

		void Idle_Exit ()
		{
			print ("Idle exit.");
		}
	}
}