using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_pokemon_type : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int TypeID;
		public string Name;
	}
}