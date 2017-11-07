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

		// Only add positive Fitness to FitnessSum
		for (int i = 0; i < potentialIndividuals.Count; i++) {
			if (potentialIndividuals[i].Fitness > 0)
				fitnessSum += potentialIndividuals[i].Fitness;
		}

		// avoid divide by 0 error
		if (fitnessSum == 0)
			fitnessSum++;

		// calculate weighted probability of each individual to determine how often an individual will be selected
		// individuals with negative fitness value dont get added at all
		for (int i = 0; i < potentialIndividuals.Count; i++) {
			if (potentialIndividuals [i].Fitness > 0)
				weightedProbability = potentialIndividuals [i].Fitness / fitnessSum;
			else
				weightedProbability = .0f;

			timesAdded = (int) Math.Floor (weightedProbability * potentialIndividuals.Count * 2);
			//Debug.Log (weightedProbability + " * " + potentialIndividuals.Count + "* 2 = " + timesAdded);
			for (int j = 0; j < timesAdded; j++) {
				selectedIndividuals.Add (potentialIndividuals [i]);
				Debug.Log (potentialIndividuals [i].Fitness);
			}

		}
		Debug.Log ("Count: " + selectedIndividuals.Count);
		Debug.Log ("fill up");
		// Fill up free spots with random individuals to reach two times the size of the original generation 
		for (int i = selectedIndividuals.Count; i < potentialIndividuals.Count * 2; i++) {
			int randomIndividual = UnityEngine.Random.Range (0, potentialIndividuals.Count);
			Debug.Log (potentialIndividuals[randomIndividual].Fitness);
			selectedIndividuals.Add (potentialIndividuals[randomIndividual]);
		}
		Debug.Log ("--------------------------------");
		AssemblyCSharp.MyFunctions.Shuffle (selectedIndividuals);

		for (int i = 0; i < selectedIndividuals.Count; i++) {
			newGeneration.Add (selectedIndividuals [i].GeneSequence);
			Debug.Log (selectedIndividuals [i].Fitness);
		}
		return newGeneration;
	}
		
}
