using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPointCrossover : IRecombiner
{
	public string Combine(string parentA, string parentB)
	{
		int crossPoint1 = UnityEngine.Random.Range (0, parentA.Length-1);
		int crossPoint2 = UnityEngine.Random.Range (crossPoint1, parentA.Length);

		Debug.Log ("A : " + parentA + " [Length:"+ parentA.Length +"]");
		Debug.Log ("B : " + parentB + " [Length:"+ parentB.Length +"]");
		Debug.Log ("Point1 : " + crossPoint1);
		Debug.Log ("Point2 : " + crossPoint2);
		Debug.Log ("ParentA sbstr (0,cp1): " + parentA.Substring(0,crossPoint1));
		Debug.Log ("ParentB sbstr (cp1,cp2): " + parentB.Substring(crossPoint1, crossPoint2 - crossPoint1));
		Debug.Log ("ParentB sbstr (cp2,parentA.Length-cp2): " + parentA.Substring(crossPoint2,parentA.Length-crossPoint2));

		string result = parentA.Substring(0,crossPoint1) + parentB.Substring(crossPoint1, crossPoint2 - crossPoint1) + parentA.Substring(crossPoint2,parentA.Length-crossPoint2);

		Debug.Log ("Crossed : " + result);

		return result;
	}
}
