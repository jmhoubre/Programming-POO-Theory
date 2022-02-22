public enum HealthState { HEALTHY, SICK, POISONED, WOUNDED, DEAD }
public enum Needs { HUNGER, THIRST, REST }
public enum ActionType { NONE, MOVE, EAT, DRINK, SLEEP }

public class Constants
{
	public const float HOUR_TO_SECONDS_MULT = 1f / 3600f;
	public const float TIME_MULTIPLIER = 300f; // Secondes IRL pour 1 seconde de jeu.
	public const float DISTANCE_ARRIVED = 1f;
}