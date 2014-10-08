using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_pokemon_skill : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int SkillID;
		public string Name;
		public int type;
		public int category;
		public int power;
		public int accuracy;
		public int pp;
		public int attack_range;
		public int direct_flg;
		public string description;
	}
}