using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_pokemon_attack_type : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int AttackTypeID;
		public string Name;
	}
}