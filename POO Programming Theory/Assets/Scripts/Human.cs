using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Human : LivingBeing
{
	public List<Action> ActionList;

	public override void Awake ()
	{
		base.Awake ();
		ActionList = new List<Action> ();
	}


	public override void Start ()
	{
		base.Start ();
	}

	public override void Update ()
	{
		bool isFinished;
		base.Update ();

		if (ActionList.Count == 0)
		{
			ActionList.Add (new Action (this, ActionType.MOVE, GetRandomPosition ()));
			
		}
		else
		{
			isFinished = ActionList[0].Execute ();
			if (isFinished)
			{
				ActionList.RemoveAt (0);
			}
		}
	}

	public override Vector3 GetRandomPosition ()
	{
		Vector2 position = (Vector2.one * 2f) + Random.insideUnitCircle.normalized * 3f;
		return transform.position + new Vector3 (position.x, 0f, position.y);
	}
}