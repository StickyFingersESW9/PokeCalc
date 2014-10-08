using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_pokemon_personality : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int PersonalityID;
		public string Name;
		public float A;
		public float B;
		public float C;
		public float D;
		public float S;
	}
}