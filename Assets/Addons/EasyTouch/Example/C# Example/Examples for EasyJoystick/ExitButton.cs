using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {
	
	void OnEnable(){
		EasyButton.On_ButtonUp += On_ButtonUp;	
	}

	void OnDisable(){
		EasyButton.On_ButtonUp -= On_ButtonUp;	
	}

	void OnDestroy(){
		EasyButton.On_ButtonUp -= On_ButtonUp;	
	}
	
	void On_ButtonUp (string buttonName)
	{

        SceneManager.LoadScene("StartMenu");
	}

}
