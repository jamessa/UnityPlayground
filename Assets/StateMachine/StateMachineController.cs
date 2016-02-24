using UnityEngine;
using Prime31.StateKitLite;

namespace Example.State
{
	public enum Player
	{
		Work,
		Play
	}

	public class StateMachineController : StateKitLite<Player>
	{

		// if you implement Awake in your subclass you must call base.Awake()
		void Awake ()
		{
			base.Awake ();
		}

		// in either Awake or Start the initialState must be set
		void Start ()
		{
			initialState = Player.Play;
		}

		// if you implement Update in your subclass you must call base.Update()
		void Update ()
		{
			base.Update ();
		}

		protected void OnGUI ()
		{
			if (GUI.Button (new Rect (Screen.width * 1 / 3 - 50, 5, 100, 30), "Work")) {
				currentState = Player.Work;
			}

			if (GUI.Button (new Rect (Screen.width * 2 / 3 - 50, 5, 100, 30), "Play")) {
				currentState = Player.Play;
			}
			var centeredStyle = GUI.skin.GetStyle ("Label");
			centeredStyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 4, 100, 30), currentState.ToString (), centeredStyle);
		}

		void Work_Enter ()
		{
			print ("Work enter.");
		}

		void Work_Tick ()
		{
//		print ("Working");
		}

		void Work_Exit ()
		{
			print ("Work exit.");
		}

		void Play_Enter ()
		{
			print ("Play enter.");
		}

		void Play_Tick ()
		{
//		print ("Idling");
		}

		void Play_Exit ()
		{
			print ("Play exit.");
		}
	}
}