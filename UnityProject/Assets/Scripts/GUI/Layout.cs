using UnityEngine;
using System.Collections;

public class Layout : MonoBehaviour {

	private Texture textute_ = null;
	public Texture DrawTexture {
		set { textute_ = value; }
		get { return textute_; }
	}

	void OnGUI () {
	
		GUI.depth = 10;

		if( null != textute_ ) {
			//GUI.Box( new Rect( 0, 0, Screen.width, Screen.height ), textute_ );
			GUI.DrawTexture( new Rect( 0, 0, Screen.width, Screen.height ), textute_, ScaleMode.StretchToFill );
		}
	}
}
