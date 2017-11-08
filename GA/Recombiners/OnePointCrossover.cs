using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePointCrossover : IRecombiner
{
	public string Combine(string parentA, string parentB)
	{
		int crossPoint = UnityEngine.Random.Range (0, parentA.Length);
		return parentA.Substring(0,crossPoint) + parentB.Substring(crossPoint, parentB.Length - crossPoint);
	}
}
