using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartSelector : ISelector
{
	public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
	{
		List<string> newGeneration = new List<string>();
		Individual previous = parentGeneration.Fittest;

		foreach (Individual ind in parentGeneration.Individuals)
		{
			//Fittest Individual gets to mate two times with 2nd and 3rd fittest
			if (Individual.Equals(ind,previous)) {
				newGeneration.Add(ind.GeneSequence);
				newGeneration.Add(parentGeneration.Individuals[2].GeneSequence);
			} else{
				newGeneration.Add(previous.GeneSequence);
				newGeneration.Add(ind.GeneSequence);
				previous = ind;
			}
		}
		return newGeneration;
	}
}
