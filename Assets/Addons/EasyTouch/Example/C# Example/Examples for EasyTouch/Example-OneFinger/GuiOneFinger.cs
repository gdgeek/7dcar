using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuiOneFinger : MonoBehaviour {

	void OnGUI() {
	            
		GUI.matrix = Matrix4x4.Scale( new Vector3( Screen.width / 1024.0f, Screen.height / 768.0f, 1f ) );
		
		GUI.Box( new Rect( 0, -4, 1024, 30 ), "" );
		GUILayout.Label("Examples with one finger");
			
		// Back to menu menu
		if (GUI.Button( new Rect(412,700,200,50),"Main menu")){
			SceneManager.LoadScene("StartMenu");
		}	
	}
}
