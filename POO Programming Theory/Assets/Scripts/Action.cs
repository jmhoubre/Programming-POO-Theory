using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class Action
{
	public Human villager;
	public ActionType actionType;
	public Vector3 target;

	private float timer;
	private bool pauseFlag;

	public Action (Human _villager, ActionType _actionType, Vector3 _target)
	{
		villager = _villager;
		actionType = _actionType;
		target = _target;
	}

	public bool Execute ()
	{
		bool actionResult = false;

		switch (actionType)
		{
			case ActionType.NONE:
				break;
			case ActionType.MOVE:
				actionResult = ActionMove ();
				break;
			case ActionType.EAT:
				break;
			case ActionType.DRINK:
				break;
			case ActionType.SLEEP:
				break;
			case ActionType.STANDBY:
				actionResult = ActionStandby ();
				break;
			default:
				break;
		}

		return actionResult;
	}

	private bool ActionMove ()
	{
		if (target == null)
		{
			return true;
		}

		if ((target - villager.transform.position).sqrMagnitude < Constants.DISTANCE_ARRIVED)
		{
			return true;
		}

		villager.SetDestination (target);

		return false;
	}

	private bool ActionStandby ()
	{
		if (pauseFlag == false)
		{
			pauseFlag = true;
			timer = Random.Range (1f, 5f);
		}
		
		
		return false;
	}
}