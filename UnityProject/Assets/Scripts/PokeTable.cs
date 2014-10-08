using UnityEngine;
using System.Collections;



public class PokeTable : MonoBehaviour {


	private static PokeTable instance_ = null;
	public static PokeTable Instance {
		get { return instance_; }
	}


	void Awake() {

		instance_ = this;
	}


	[SerializeField]
	private Entity_pokemon_db pokemon_db_ = null;
	public Entity_pokemon_db PokemonDB {
		get { return pokemon_db_; }
	}

	[SerializeField]
	private Entity_pokemon_personality pokemon_personality_ = null;
	public Entity_pokemon_personality PokemonPersonality {
		get { return pokemon_personality_; }
	}

	[SerializeField]
	private Entity_pokemon_type pokemon_type_ = null;
	public Entity_pokemon_type PokemonType {
		get { return pokemon_type_; }
	}

	[SerializeField]
	private Entity_pokemon_type_matrix pokemon_type_matrix_ = null;
	public Entity_pokemon_type_matrix PokemonTypeMatrix {
		get { return pokemon_type_matrix_; }
	}

	[SerializeField]
	private Entity_pokemon_skill pokemon_skill_ = null;
	public Entity_pokemon_skill PokemonSkill {
		get { return pokemon_skill_; }
	}

	[SerializeField]
	private Entity_pokemon_item pokemon_item_ = null;
	public Entity_pokemon_item PokemonItem {
		get { return pokemon_item_; }
	}

	[SerializeField]
	private Entity_pokemon_attack_target pokemon_attack_target_ = null;
	public Entity_pokemon_attack_target PokemonAttackTarget {
		get { return pokemon_attack_target_; }
	}

	[SerializeField]
	private Entity_pokemon_attack_type pokemon_attack_type_ = null;
	public Entity_pokemon_attack_type PokemonAttackType {
		get { return pokemon_attack_type_; }
	}

}
