using UnityEngine;
using System.Collections;


public class PokeStatusCalc : MonoBehaviour {

	/**
	 * @brief .
	 */
	public void SetCalcTargetPokemon( int pokemonId ) {

		pokemon_id_ = pokemonId;

		db_status_ = PokeTable.Instance.PokemonDB.param[pokemon_id_];
		tribal_ = new PokeStatus.PokeTribal( db_status_ );
	}

	/**
	 * @brief ポケモンのステータスを計算します.
	 */
	public void Calculate() {

		status_.HP = ((tribal_.HP * 2 + individual_.HP + effort_.HP / 4) * level_ / 100) + 10 + level_;

		status_.A = ((tribal_.A * 2 + individual_.A + effort_.A / 4) * level_ / 100) + 5;
		status_.B = ((tribal_.B * 2 + individual_.B + effort_.B / 4) * level_ / 100) + 5;
		status_.C = ((tribal_.C * 2 + individual_.C + effort_.C / 4) * level_ / 100) + 5;
		status_.D = ((tribal_.D * 2 + individual_.D + effort_.D / 4) * level_ / 100) + 5;
		status_.S = ((tribal_.S * 2 + individual_.S + effort_.S / 4) * level_ / 100) + 5;

		// 性格補正.
		status_ *= PokeTable.Instance.PokemonPersonality.param[personality_];
	}


	public PokeStatusCalc() {

		status_ = new PokeStatus.StatusBase( 0, 0, 0, 0, 0, 0 );

		individual_ = new PokeStatus.PokeIndividual( 0, 0, 0, 0, 0, 0 );
		effort_ = new PokeStatus.PokeEffort( 0, 0, 0, 0, 0, 0 );

	}

	//! 計算用に設定されたポケモンＩＤ.
	private int pokemon_id_ = 0;

	//! ＤＢから引いた固定値.
	private Entity_pokemon_db.Param db_status_ = null;


	//! .
	private int level_;
	public int Level {
		set { level_ = value; }
		get { return level_; }
	}
	//! .
	private int personality_;
	public int Personality {
		set { personality_ = value; }
		get { return personality_; }
	}

	//! .
	private PokeStatus.PokeTribal tribal_;
	//! .
	private PokeStatus.PokeIndividual individual_;
	public PokeStatus.PokeIndividual Individual {
		get { return individual_; }
	}
	//! .
	private PokeStatus.PokeEffort effort_;
	public PokeStatus.PokeEffort Effort {
		get { return effort_; }
	}

	//! .
	private PokeStatus.StatusBase status_;
	public PokeStatus.StatusBase Status {
		get { return status_; }
	}

}

