using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : LivingBeing
{
	private List<Action> actions;

	public override void Awake ()
	{
		base.Awake ();
		actions = new List<Action> ();
	}

	public override void Start ()
	{
		base.Start ();		
	}

	public override void Update ()
	{
		base.Update ();
	}
}