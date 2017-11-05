using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartTerminator : ITerminator
{
	private float chucksWrath = .2f;

	public bool JudgementDay(GenerationDB.Generation generation)
	{
		if (generation.Fittest.fitnessValue > 90.0)
			return true;
		else
			return false;
	}
}
