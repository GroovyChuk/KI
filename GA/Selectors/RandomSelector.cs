using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelector : ISelector
{
	public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
	{
		List<Individual> potentialIndividuals = parentGeneration.Individuals; // all individuals
		List<string> newGeneration = new List<string>();

		for (int i = 0; i < potentialIndividuals.Count * 2; i++) {
			int randomIndividual = UnityEngine.Random.Range (0, potentialIndividuals.Count);
			newGeneration.Add (potentialIndividuals[randomIndividual].GeneSequence);
		}
		return newGeneration;
	}
}
