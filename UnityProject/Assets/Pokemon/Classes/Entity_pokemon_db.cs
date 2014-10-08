using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_pokemon_db : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int PrimaryID;
		public int PokemonID;
		public int FromID;
		public int MegaID;
		public string Name;
		public int HP;
		public int A;
		public int B;
		public int C;
		public int D;
		public int S;
		public int Type1;
		public int Type2;
		public float Height;
		public float Weight;
		public string Ability1;
		public string Ability2;
		public string Hidden_ability;
	}
}