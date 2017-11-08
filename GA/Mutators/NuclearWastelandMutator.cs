using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearWastelandMutator : IMutator
{

	private float mutationRate = .5f;
	private List<char> geneIDs;

	public void AssignGene(char ID)
	{
		if (geneIDs == null)
			geneIDs = new List<char>();
		geneIDs.Add(ID);
	}

	public string Mutate(string original)
	{
		System.Text.StringBuilder mutated = new System.Text.StringBuilder();
		for (int i = 0; i < original.Length; i++) {
			int randomInt = UnityEngine.Random.Range (1, 10);
			if(randomInt <= (mutationRate * 10)){
				mutated.Append (geneIDs [UnityEngine.Random.Range (0, geneIDs.Count)]);
			} else
				mutated.Append(original[i]);
		}
		//Debug.Log ("Mutated: " + original + " to " + mutated.ToString());
		return mutated.ToString();
	}

}
