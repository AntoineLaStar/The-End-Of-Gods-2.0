using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenuNew : MonoBehaviour {

	// toggle buttons
	public GameObject fullscreentext;
	public GameObject shadowofftext;
	public GameObject shadowofftextLINE;
	public GameObject shadowlowtext;
	public GameObject shadowlowtextLINE;
	public GameObject shadowhightext;
	public GameObject shadowhightextLINE;
	public GameObject showhudtext;
	public GameObject tooltipstext;
	public GameObject difficultynormaltext;
	public GameObject difficultynormaltextLINE;
	public GameObject difficultyhardcoretext;
	public GameObject difficultyhardcoretextLINE;
	public GameObject cameraeffectstext;
	public GameObject invertmousetext;
	public GameObject vsynctext;
	public GameObject motionblurtext;
	public GameObject ambientocclusiontext;
	public GameObject texturelowtext;
	public GameObject texturelowtextLINE;
	public GameObject texturemedtext;
	public GameObject texturemedtextLINE;
	public GameObject texturehightext;
	public GameObject texturehightextLINE;
	public GameObject aaofftext;
	public GameObject aaofftextLINE;
	public GameObject aa2xtext;
	public GameObject aa2xtextLINE;
	public GameObject aa4xtext;
	public GameObject aa4xtextLINE;
	public GameObject aa8xtext;
	public GameObject aa8xtextLINE;

	public void  Start (){
		
	}

	public void  Update (){
		
	}

	public void  FullScreen (){
		Screen.fullScreen = !Screen.fullScreen;

		if(Screen.fullScreen == true){
			fullscreentext.GetComponent<Text>().text = "on";
		}
		else if(Screen.fullScreen == false){
			fullscreentext.GetComponent<Text>().text = "off";
		}
	}

	
	
}