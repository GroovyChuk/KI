using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartSelector : ISelector
{
	public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
	{
		List<Individual> potentialIndividuals = parentGeneration.Individuals; // all individuals
		List<Individual> selectedIndividuals = new List<Individual>(); // individuals chosen according to fitness	
		List<string> newGeneration = new List<string>(); // Gene Sequence of choosen individuals in order of recombination	

		float fitnessSum = .0f;
		int timesAdded = 0;
		float weightedProbability = .0f;

		for (int i = 0; i < potentialIndividuals.Count; i++) {
			fitnessSum += potentialIndividuals[i].Fitness;
		}

		for (int i = 0; i < potentialIndividuals.Count; i++) {
			if (fitnessSum > 0) {
				weightedProbability =  potentialIndividuals[i].Fitness / fitnessSum;
			} else {
				weightedProbability =  1 - (potentialIndividuals[i].Fitness / fitnessSum);
			} 

			// can't be more than 100
			if (weightedProbability > 1)
				weightedProbability = 1;

			timesAdded = (int) Math.Floor (weightedProbability * potentialIndividuals.Count * 2);

			for (int j = 0; j < timesAdded; j++) {
				selectedIndividuals.Add (potentialIndividuals [i]);
				//Debug.Log (potentialIndividuals [i].Fitness);
			}

		}
		//Debug.Log ("fill up");
		// Fill up free spots with fittest individual 
		for (int i = selectedIndividuals.Count; i < potentialIndividuals.Count * 2; i++) {
			Debug.Log (parentGeneration.Fittest.Fitness);
			selectedIndividuals.Add (parentGeneration.Fittest);
		}
		//Debug.Log ("--------------------------------");
		//Debug.Log ("Count: " + selectedIndividuals.Count);
		AssemblyCSharp.MyFunctions.Shuffle (selectedIndividuals);

		for (int i = 0; i < selectedIndividuals.Count; i++) {
			Debug.Log (selectedIndividuals [i].Fitness);
			newGeneration.Add (selectedIndividuals [i].GeneSequence);
		}
			
		return newGeneration;
	}
		
}
