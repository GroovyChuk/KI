using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneG : IGene
{

	private CarController controller;
	public char ID
	{
		get
		{
			return 'G';
		}
	}

	public CarController Controller
	{
		get
		{
			return controller;
		}
		set
		{
			controller = value;
		}
	}
	public void Execute()
	{
		controller.ApplyBrakes ();
	}
}
