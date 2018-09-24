using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuNew : MonoBehaviour {

	public Animator CameraObject;

	[Header("Load Screen")]
	public string sceneName; 

	[Header("Panels")]
	public GameObject PanelControls;
	public GameObject PanelVideo;
	public GameObject PanelGame;
	public GameObject PanelKeyBindings;
	public GameObject PanelMovement;
	public GameObject PanelCombat;
	public GameObject PanelGeneral;
	public GameObject PanelareYouSure;

	[Header("SFX")]
	public GameObject hoverSound;
	public GameObject sfxhoversound;
	public GameObject clickSound;

	// campaign button sub menu


	// highlights
	[Header("Highlight Effects")]
	public GameObject lineGame;
	public GameObject lineVideo;
	public GameObject lineControls;
	public GameObject lineKeyBindings;
	public GameObject lineMovement;
	public GameObject lineCombat;
	public GameObject lineGeneral;

	public void  PlayCampaign (){
		PanelareYouSure.gameObject.SetActive(false);
		
	}

	public void NewGame(){
		if(sceneName != "")
		SceneManager.LoadScene(sceneName);
	}

	

	public void  Position2 (){
		
		CameraObject.SetFloat("Animate",1);
        PanelKeyBindings.gameObject.SetActive(true);
        lineKeyBindings.gameObject.SetActive(true);
    }

	public void  Position1 (){
		CameraObject.SetFloat("Animate",0);
	}

	public void  GamePanel (){
		PanelKeyBindings.gameObject.SetActive(true);
		lineKeyBindings.gameObject.SetActive(true);
	}

	public void  VideoPanel (){
        PanelKeyBindings.gameObject.SetActive(true);
        lineKeyBindings.gameObject.SetActive(true);
    }

	public void  ControlsPanel (){
        PanelKeyBindings.gameObject.SetActive(true);
        lineKeyBindings.gameObject.SetActive(true);
    }

	public void  KeyBindingsPanel (){
        PanelKeyBindings.gameObject.SetActive(true);
        lineKeyBindings.gameObject.SetActive(true);
    }

	public void  MovementPanel (){
		PanelMovement.gameObject.SetActive(true);
		PanelCombat.gameObject.SetActive(false);
		PanelGeneral.gameObject.SetActive(false);

		lineMovement.gameObject.SetActive(true);
		lineCombat.gameObject.SetActive(false);
		lineGeneral.gameObject.SetActive(false);
	}

	public void  CombatPanel (){
		PanelMovement.gameObject.SetActive(false);
		PanelCombat.gameObject.SetActive(true);
		PanelGeneral.gameObject.SetActive(false);

		lineMovement.gameObject.SetActive(false);
		lineCombat.gameObject.SetActive(true);
		lineGeneral.gameObject.SetActive(false);
	}

	public void  GeneralPanel (){
		PanelMovement.gameObject.SetActive(false);
		PanelCombat.gameObject.SetActive(false);
		PanelGeneral.gameObject.SetActive(true);

		lineMovement.gameObject.SetActive(false);
		lineCombat.gameObject.SetActive(false);
		lineGeneral.gameObject.SetActive(true);
	}

	public void  PlayHover (){
		hoverSound.GetComponent<AudioSource>().Play();
	}

	public void  PlaySFXHover (){
		sfxhoversound.GetComponent<AudioSource>().Play();
	}

	public void  PlayClick (){
		clickSound.GetComponent<AudioSource>().Play();
	}

	// Are You Sure - Quit Panel Pop Up
	public void  AreYouSure (){
		PanelareYouSure.gameObject.SetActive(true);
	}

	public void  No (){
		PanelareYouSure.gameObject.SetActive(false);
	}

	public void  Yes (){
		Application.Quit();
	}
}