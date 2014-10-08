using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_pokemon_item : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int ItemID;
		public string name;
		public string description;
		public int category;
	}
}