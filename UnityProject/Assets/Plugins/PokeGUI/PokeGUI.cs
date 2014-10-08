using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PokeGUI {


	private static PokeGUI instace_ = null;
	public static PokeGUI Instance {
		get {
			if( null == instace_ ) {
				instace_ = new PokeGUI();
			}

			return instace_;
		}
	}

	public void PushGUISkin( GUISkin skin ) {

		GUI.skin = skin;
		skin_stack_.Push( skin );
	}

	public void PopGUISkin() {

		skin_stack_.Pop();
		if( 0 < skin_stack_.Count ) {
			GUISkin skin = skin_stack_.Peek() as GUISkin;
			GUI.skin = skin;
		}
	}



	private PokeGUI() {

		skin_stack_ = new Stack<GUISkin>();
	}

	private Stack<GUISkin>	skin_stack_;

}
