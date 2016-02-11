using UnityEngine;

public class TurnColorScript : MonoBehaviour
{

	void OnEnable ()
	{
		EventManager.OnClicked += TurnColor;
	}

	void OnDisabled ()
	{
		EventManager.OnClicked -= TurnColor;

	}

	void TurnColor ()
	{
		var color = new Color (Random.value, Random.value, Random.value);
		GetComponent<Renderer> ().material.color = color;
	}
}
