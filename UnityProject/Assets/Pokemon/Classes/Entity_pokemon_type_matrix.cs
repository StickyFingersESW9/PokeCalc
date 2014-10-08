using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_pokemon_type_matrix : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int TypeMatrixID;
		public string Name;
		public float Normal;
		public float Fire;
		public float Water;
		public float Electric;
		public float Grass;
		public float Psychic;
		public float Fighting;
		public float Poison;
		public float Ground;
		public float Flying;
		public float Dragon;
		public float Bug;
		public float Rock;
		public float Ghost;
		public float Ice;
		public float Steel;
		public float Dark;
		public float Fairy;
	}
}