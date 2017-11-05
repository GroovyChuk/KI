using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartFitness : IFitnessFunction
{

	public float DetermineFitness(CarState state)
	{
		return 100 - state.DistanceFromGoal() * 2 - state.AngleToGoal() - (state.NumberOfCollisions() * 20) - Mathf.Abs(state.CurrentVelocity())*10;
	}
}
