using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartTerminator : ITerminator
{

	int generationCount = 1;

	public bool JudgementDay(GenerationDB.Generation generation)
	{
		if (generation.Fittest.fitnessValue > 95.0 || generationCount == 20) {
			generationCount = 1;
			return true;
		}
		else {
			generationCount++;
			return false;
		}
	}
}
