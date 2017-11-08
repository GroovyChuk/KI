using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtLeastOnceInitializer : IInitializer
{
	private List<char> genes;
	private System.Random rand;
	public void AssignGene(char ID)
	{
		if (genes == null)
		{
			genes = new List<char>();
		}
		genes.Add(ID);
	}

	public List<Individual> CreateInitialGeneration(int generationSize, int individualSize)
	{
		List<Individual> list = new List<Individual>();
		for(int i = 0; i < generationSize; i++)
		{
			list.Add(GenerateIndividual(individualSize));
		}
		return list;
	}

	private Individual GenerateIndividual(int individualSize)
	{
		if (rand == null)
			rand = new System.Random();
		
		Individual ind = new Individual();
		System.Text.StringBuilder builder = new System.Text.StringBuilder(individualSize);
		int max = genes.Count;

		//Copy of genes
		List<char> shuffledGenes = new List<char>(genes);

		//Add random genes on top of the copylist => (inividualSize == genes.Count)
		for (int i = genes.Count; i < individualSize; ++i) 
		{
			int randomIndex = rand.Next (0, shuffledGenes.Count);
			shuffledGenes.Add(shuffledGenes[randomIndex]);
		}

		//Debug.Log("GeneCopy Size: " + shuffledGenes.Count);

		//Shuffle genes
		AssemblyCSharp.MyFunctions.Shuffle (shuffledGenes);

		//Append all genes
		for(int i = 0; i < individualSize; i++)
		{
			builder.Append(shuffledGenes[i]);
		}

		ind.GeneSequence= builder.ToString();
		//Debug.Log (ind.geneSequence);

		return ind;
	}
}
