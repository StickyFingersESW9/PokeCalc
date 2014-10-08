using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class PokeCalcGUI : MonoBehaviour {


	void Start() {

/*
		Layout l = gameObject.AddComponent<Layout>() as Layout;
		l.DrawTexture = texture_;

		return;
*/
		pulldown_ = gameObject.AddComponent<PulldownList>() as PulldownList;
		pulldown_.Skin = skin_;
		pulldown_.Area = new Rect( Screen.width / 4, 0.0f, Screen.width - (Screen.width / 4), Screen.height );
		pulldown_.OnChangedField += ChangeTextField;
		pulldown_.OnClickField += ActiveTextField;

		ChangeTextField( pulldown_ );

		funcGUI_ += bbbb;
		funcGUI_ += aaaa;
	}

	private string ToWideString( string str ) {

		string result = str;

		result = result.Replace( "0", "０" );
		result = result.Replace( "1", "１" );
		result = result.Replace( "2", "２" );
		result = result.Replace( "3", "３" );
		result = result.Replace( "4", "４" );
		result = result.Replace( "5", "５" );
		result = result.Replace( "6", "６" );
		result = result.Replace( "7", "７" );
		result = result.Replace( "8", "８" );
		result = result.Replace( "9", "９" );

		return result;
	}

	void Update() {

		if( null != pulldown_ ) {
			if( pulldown_.IsFinishedInput ) {

				pulldown_.IsFinishedInput = false;

				var ret =	from c in PokeTable.Instance.PokemonDB.param
							where c.Name == pulldown_.Text
							select c;

				foreach( Entity_pokemon_db.Param p in ret ) {
					str_hp_ = ToWideString( p.HP.ToString() );
					str_a_ = ToWideString( p.A.ToString() );
					str_b_ = ToWideString( p.B.ToString() );
					str_c_ = ToWideString( p.C.ToString() );
					str_d_ = ToWideString( p.D.ToString() );
					str_s_ = ToWideString( p.S.ToString() );
				}
			}
		}
	}

	void OnGUI() {

		if( null != funcGUI_ ) {
			funcGUI_();
		}
	}


	void bbbb() {

		float width_1	= Screen.width;			//!< 1 / 1  ( 1.0 ).
		float width_2	= width_1 * 0.5f;		//!< 1 / 2  ( 0.5 ).
		float width_4	= width_2 * 0.5f;		//!< 1 / 4  ( 0.25 ).
		float width_8	= width_4 * 0.5f;		//!< 1 / 8  ( 0.125 ).

		float height_1	= Screen.height;		//!< 1 / 1  ( 1.0 ).
		float height_2	= height_1 * 0.5f;		//!< 1 / 2  ( 0.5 ).
		float height_4	= height_2 * 0.5f;		//!< 1 / 4  ( 0.25 ).
		float height_8	= height_4 * 0.5f;		//!< 1 / 8  ( 0.125 ).

		float posY = 0.0f;


		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;

		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;

		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;

		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;

		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;

		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;

		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;

		GUI.Box( new Rect( 0.0f, posY, width_1, height_8 ), "" );
		posY += height_8;
	}


	void aaaa() {

		PokeGUI.Instance.PushGUISkin( skin_ );

		float width_1	= Screen.width;			//!< 1 / 1  ( 1.0 ).
		float width_2	= width_1 * 0.5f;		//!< 1 / 2  ( 0.5 ).
		float width_4	= width_2 * 0.5f;		//!< 1 / 4  ( 0.25 ).
		float width_8	= width_4 * 0.5f;		//!< 1 / 8  ( 0.125 ).
		float width_16	= width_8 * 0.5f;		//!< 1 / 16 ( 0.0625 ).
		float width_32	= width_16 * 0.5f;		//!< 1 / 32 ( 0.03125 ).

		float height_1	= Screen.height;		//!< 1 / 1  ( 1.0 ).
		float height_2	= height_1 * 0.5f;		//!< 1 / 2  ( 0.5 ).
		float height_4	= height_2 * 0.5f;		//!< 1 / 4  ( 0.25 ).
		float height_8	= height_4 * 0.5f;		//!< 1 / 8  ( 0.125 ).
		float height_16	= height_8 * 0.5f;		//!< 1 / 16 ( 0.0625 ).
		float height_32	= height_16 * 0.5f;		//!< 1 / 32 ( 0.03125 ).

		float rateH = 0.0f;
		float posY = 0.0f;

		GUI.depth = 10;

		posY += height_16;

		// １段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_4, height_8 ) );
		{
			GUILayout.Label( "ポケモン" );
		}
		GUILayout.EndArea();
		pulldown_.Area = new Rect( Screen.width / 4, posY, Screen.width - (Screen.width / 4), Screen.height - posY );

		posY += height_8;

		// ２段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_1, height_8 ) );
		{
			GUILayout.BeginArea( new Rect( 0.0f, 0.0f, width_8 + width_32, height_8 ) );
			{
				GUILayout.Label( "せいかく" );
			}
			GUILayout.EndArea();
		}
		GUILayout.EndArea();

		posY += height_8;

		// ３段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_1, height_8 ) );
		{
			GUILayout.Label( "Ｌｖ" );
		}
		GUILayout.EndArea();

		posY += height_8;

		// ４段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_1, height_8 ) );
		{
			GUILayout.BeginArea( new Rect( 0.0f, 0.0f, width_8 + width_32, height_8 ) );
			{
				GUILayout.Label( "種族値" );
			}
			GUILayout.EndArea();

			GUILayout.BeginArea( new Rect( width_8 + width_32, 0.0f, width_1 - (width_8 + width_32), height_8 ) );
			{
				PokeGUI.Instance.PushGUISkin( skin_h3_ );

				GUILayout.BeginArea( new Rect( 0.0f, 0.0f, width_1 - (width_8 + width_32), height_16 ) );
				{
					GUILayout.BeginHorizontal();
					{
						GUILayout.Label( "　ＨＰ　" );
						GUILayout.Label( "こうげき" );
						GUILayout.Label( "ぼうぎょ" );
						GUILayout.Label( "とくこう" );
						GUILayout.Label( "とくぼう" );
						GUILayout.Label( "すばやさ" );
					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndArea();
				GUILayout.BeginArea( new Rect( 0.0f, height_16, width_1 - (width_8 + width_32), height_16 ) );
				{
					GUILayout.BeginHorizontal();
					{
						GUILayout.Label( str_hp_ );
						GUILayout.Label( str_a_ );
						GUILayout.Label( str_b_ );
						GUILayout.Label( str_c_ );
						GUILayout.Label( str_d_ );
						GUILayout.Label( str_s_ );
					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndArea();

				PokeGUI.Instance.PopGUISkin();
			}
			GUILayout.EndArea();
		}
		GUILayout.EndArea();

		posY += height_8;

		// ５段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_1, height_8 ) );
		{
			GUILayout.Label( "ポケモン" );
		}
		GUILayout.EndArea();

		posY += height_8;

		// ６段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_1, height_8 ) );
		{
			GUILayout.Label( "ポケモン" );
		}
		GUILayout.EndArea();

		posY += height_8;

		// ７段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_1, height_8 ) );
		{
			GUILayout.Label( "ポケモン" );
		}
		GUILayout.EndArea();

		posY += height_8;

		// ８段目.
		GUILayout.BeginArea( new Rect( 0.0f, posY, width_1, height_8 ) );
		{
			GUILayout.Label( "ポケモン" );
		}
		GUILayout.EndArea();

		posY += height_8;


		PokeGUI.Instance.PopGUISkin();
	}


	//-----+-----+-----+-----+-----+-----+-----
	// PulldownList Event Delegater

	/**
	 * @brief テキストフィールドの入力を開始したとき.
	 */
	private void ActiveTextField( PulldownList pulldown ) {

		List<string> list = new List<string>();
		list.Add( "" );

		foreach( Entity_pokemon_db.Param p in PokeTable.Instance.PokemonDB.param ) {
			list.Add( p.Name );
		}

		pulldown_.ListItem = list;
	}

	/**
	 * @brief プルダウンのTextFieldに入力のあるポケモンをリスト化.
	 */
	private void ChangeTextField( PulldownList pulldown ) {

		List<string> list = new List<string>();
		list.Add( "" );

		if( false == System.String.IsNullOrEmpty( pulldown.Text ) ) {

			var ret =	from c in PokeTable.Instance.PokemonDB.param
						where c.Name.Contains( pulldown.Text )
						select c;

			foreach( Entity_pokemon_db.Param p in ret ) {
				list.Add( p.Name );
			}

		}
		else{
			foreach( Entity_pokemon_db.Param p in PokeTable.Instance.PokemonDB.param ) {
				list.Add( p.Name );
			}
		}

		pulldown_.ListItem = list;
	}


	[SerializeField]
	private GUISkin skin_;
	[SerializeField]
	private GUISkin skin_h3_;

	[SerializeField]
	private Texture texture_ = null;

	private PulldownList pulldown_ = null;

	private string str_hp_ = "０００"; 
	private string str_a_ = "０００"; 
	private string str_b_ = "０００"; 
	private string str_c_ = "０００"; 
	private string str_d_ = "０００"; 
	private string str_s_ = "０００"; 

	private event System.Action funcGUI_ = null;

}

