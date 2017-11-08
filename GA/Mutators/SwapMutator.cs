using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMutator: IMutator
{
	private List<char> geneIDs;
	private System.Random rand;

	public void AssignGene(char ID)
	{
		if (geneIDs == null)
			geneIDs = new List<char>();
		geneIDs.Add(ID);
	}

	public string Mutate(string original)
	{
		if (rand == null)
			rand = new System.Random();

		Debug.Log ("Before Mutation :" + original);

		string mutated = original;
		System.Text.StringBuilder mutatedBuilder = new System.Text.StringBuilder(mutated);

		char temp;

		//If there is only 1 Gene => return original
		if (original.Length > 1) {
			int indexOne = rand.Next (0, original.Length);
			int indexTwo = rand.Next (0, original.Length);

			Debug.Log ("IndexOne :" + indexOne);
			Debug.Log ("IndexTwo :" + indexTwo);

			//Make sure that indexes are not the same
			while (indexTwo == indexOne) {
				indexTwo = rand.Next (0, original.Length);
			}

			//Swap gene
			temp = mutated[indexOne];
			mutatedBuilder[indexOne] = mutatedBuilder [indexTwo];
			mutatedBuilder[indexTwo] = temp;
		}

		Debug.Log ("After Mutation :" + mutatedBuilder.ToString());

		return mutatedBuilder.ToString();
	}
}
