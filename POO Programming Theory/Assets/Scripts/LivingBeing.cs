using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

/* MEMO
Être vivant : classe abstraite
Des besoins (liste à compléter) qui l’incitent à certaines actions
Des actions : manger, boire, dormir, bouger, …
Caractéristiques (force, endurance, agilité, perception, intelligence…)
Déplacement : type (marche, course, ramper, saut, nage, vol), vitesse…
Attaque et défense naturelles
Prefab
Icone

Boucle générale
- While there are actions in the queue, pop the next one off, perform it, and maybe get a reward
- If you run out of actions, perform action selection based on current needs, to find more actions
- If you still have nothing to do, do some fallback actions

Action selection point
1. Examine objects around you, and find out what they advertise
2. Score each advertisement based on your current needs
3. Pick the best advertisement, get its action sequence
4. Push the action sequence on your queue
 */


/// <summary>
/// Tous les êtres vivants héritent de cette classe.
/// </summary>
[RequireComponent (typeof (NavMeshAgent))]
public abstract class LivingBeing : MonoBehaviour
{
	[Header ("État civil")]
	[SerializeField] private string _name;
	public string Name { get; protected set; }

	[SerializeField] private int _age;
	public int Age { get; protected set; }

	[Header ("Santé")]
	[SerializeField] private float _maxHealth;
	public float MaxHealth { get => _maxHealth; protected set => _maxHealth = value; }

	[SerializeField] private float _health;
	public float Health { get => _health; protected set => _health = value; }

	[SerializeField] private HealthState _healthState;
	public HealthState HealthState { get => _healthState; protected set => _healthState = value; }

	[Header ("Besoins")]
	public List<Need> needsList = new List<Need> ();

	private NavMeshAgent agent;

	/// <remarks>
	/// Les taux de modifications sont estimés sur la base de 200 points perdus en :
	/// * 72 heures pour être affamé.
	/// * 24 heures pour être assoiffé.
	/// * 48 heures pour être très fatigué.
	/// </remarks>
	public virtual void Awake ()
	{
		agent = GetComponent<NavMeshAgent> ();

		Health = MaxHealth;

		needsList.Add (new Need (Needs.HUNGER, 80f, -2.78f));
		needsList.Add (new Need (Needs.THIRST, 60f, -8.33f));
		needsList.Add (new Need (Needs.REST, 80f, -4.17f));
	}

	public virtual void Start ()
	{

	}

	public virtual void Update ()
	{
		foreach (Need need in needsList)
		{
			need.NeedUpdate ();
		}
	}

	public virtual void SetDestination (Vector3 _target)
	{
		agent.SetDestination (_target);
	}

	public abstract Vector3 GetRandomPosition ();
}