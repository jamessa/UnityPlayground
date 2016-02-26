using UnityEngine;
using System;
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

	public IEnumerable FibonacciUnder(int max)
	{
		int[] n = { 0, 0 };
		int f;
		while (true) {
			f = n[0] + n[1];
			if (f == 0)
				f = 1;
			n[0] = n[1];
			n[1] = f;

			if (f < max)
				yield return f;
			else
				yield break;
		} 
	}

	void Start()
	{
		for (int i = 1; i <= 8; i++) {
			print(Power(2, i));
		}
			
		foreach (int i in FibonacciUnder(100)) {
			print(i);
		}
	}
}
