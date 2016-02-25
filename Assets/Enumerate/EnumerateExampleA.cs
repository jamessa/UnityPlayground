using UnityEngine;
using System.Collections;

public class EnumerateExampleA : MonoBehaviour
{
	public int Power(int number, int exponent)
	{
		int counter = 0;
		int result = 1;
		while (counter++ < exponent) {
			result *= number;
		}
		return result;
	}

	public static IEnumerable EPower(int number, int exponent)
	{
		int counter = 0;
		int result = 1;
		while (counter++ < exponent) {
			result *= number;
			yield return result;
		}
	}

	void Start()
	{
		for (int i = 1; i <= 8; i++) {
			print(Power(2, i));
		}
			
		foreach (int i in EPower(2,8)) {
			print(i);
		}
	}
}
