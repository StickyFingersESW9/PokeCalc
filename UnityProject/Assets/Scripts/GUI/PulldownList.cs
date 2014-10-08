using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/**
 * @brief 入力フィールド＆イベントコールバック付きプルダウンリスト.
 */
public class PulldownList : MonoBehaviour {


	/**
	 *
	 */
	public void OnGUI() {

		GUI.skin = skin_;
		GUI.depth = gui_depth_;

		GUILayout.BeginArea( area_ );

		string active_control_name = GUI.GetNameOfFocusedControl();

		string textfield_name = unique_control_name_ + "TextField0";

		// TextFiled
		string prev_text = text_;
		GUI.SetNextControlName( textfield_name );
		text_ = GUILayout.TextField( text_, 25 );
		if( text_ != prev_text ) {
			if( null != OnChangedField ) {
				OnChangedField( this );
			}
		}

		// TextField を選択したら、プルダウンリストを表示.
		if( active_control_name == textfield_name ) {

			if( prev_active_control_name_ != active_control_name ) {
				if( null != OnClickField ) {
					is_finished_input_ = true;
					OnClickField( this );
				}
			}

			scroll_ = GUILayout.BeginScrollView( scroll_ );
			if( null != listItem_ ) {
				prev_select_ = selected_;
				selected_ = GUILayout.SelectionGrid( selected_, listItem_.ToArray(), 1 );
				//Debug.Log( "" + selected_ );

				// 何か選択された.
				if( selected_ != prev_select_ ) {
					is_finished_input_ = true;

					text_ = listItem_[selected_];
					// フォーカスを移す.
					GUI.FocusControl( "" );
				}

				prev_select_ = selected_;
			}
			GUILayout.EndScrollView();
		}

		prev_active_control_name_ = active_control_name;

		GUILayout.EndArea();
	}


	private string unique_control_name_ = "PulldownList";
	public string UniqueControlName {
		set { unique_control_name_ = value; }
		get { return unique_control_name_; }
	}

	private string prev_active_control_name_ = "";

	private GUISkin skin_;
	public GUISkin Skin {
		set { skin_ = value; }
		get { return skin_; }
	}

	private int gui_depth_ = 0;
	public int GUIDepth {
		set { gui_depth_ = value; }
		get { return gui_depth_; }
	}

	private Rect area_;
	public Rect Area {
		set { area_ = value; }
		get { return area_; }
	}

	private string text_ = "";
	public string Text {
		get { return text_; }
	}

	private Vector2 scroll_;

	private int prev_select_ = -1;
	private int selected_;
	public int Selected {
		get { return selected_; }
	} 

	private bool is_text_check_ = false;
	public bool IsTextCheck {
		set { is_text_check_ = value; }
		get { return is_finished_input_; }
	}

	private bool is_finished_input_ = false;
	public bool IsFinishedInput {
		set { is_finished_input_ = value; }
		get { return is_finished_input_; }
	}

	private List<string> listItem_;
	public List<string> ListItem {
		set {
			selected_ = 0;
			listItem_ = value;
		}
		get { return listItem_; }
	}


	public event System.Action<PulldownList> OnClickField;
	public event System.Action<PulldownList> OnChangedField;

}

