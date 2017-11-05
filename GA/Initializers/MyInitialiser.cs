using System;
using System.Collections;
using System.Collections.Generic;

public class MyInitialiser : IInitializer
{
	private List<char> genes;
	private Random rand;
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
		Individual ind = new Individual();
		System.Text.StringBuilder builder = new System.Text.StringBuilder(individualSize);
		int max = genes.Count;
		builder.Append(genes[0]);
		for(int i = 1; i < individualSize-1; i++)
		{
			builder.Append(genes[4]);
		}
		builder.Append(genes[0]);
		ind.GeneSequence= builder.ToString();
		return ind;
	}
}


