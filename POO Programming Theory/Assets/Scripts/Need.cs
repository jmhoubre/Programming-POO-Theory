using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class Need
{
	[SerializeField] private Needs _needType;
	public Needs NeedType { get => _needType; private set => _needType = value; }

	// De 0 à 100.
	[SerializeField] private float _needLevel;
	public float NeedLevel
	{
		get => _needLevel;
		private set => _needLevel = Mathf.Clamp (value, -100, 100);
	}

	// Accroissement/diminution par heure.
	[SerializeField] public float needHourModificationRate = 0f;

	public Need (Needs _type, float _level, float _modificationRate)
	{
		NeedType = _type;
		NeedLevel = _level;
		needHourModificationRate = _modificationRate;
	}

	public void NeedUpdate ()
	{
		NeedLevel += needHourModificationRate * Constants.HOUR_TO_SECONDS_MULT * Constants.TIME_MULTIPLIER * Time.deltaTime;
	}

	public void NeedModify (float _amount)
	{
		NeedLevel += _amount;
	}
}