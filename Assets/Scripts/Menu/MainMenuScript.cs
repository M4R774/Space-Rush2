using UnityEngine;
using UnityEngine.UI; //Tarttee Ui-elementtien käyttöön
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	
	public Canvas quitMenu;
	public Canvas optionsMenu;
	public Button startText;
	public Button exitText;
	public Button optionsText;
	public Slider musicSlider;
	public Slider fxSlider;
	public Text controlButton;
	
	private bool touchControl = true;
	
	void Awake () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		optionsText = optionsText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		controlButton = controlButton.GetComponent<Text> ();
		musicSlider = musicSlider.GetComponent<Slider> ();
		fxSlider = fxSlider.GetComponent<Slider> ();
		quitMenu.enabled = false; //QuitMenu pelin alkaessa piilossa

		touchControl = PlayerPrefsX.GetBool("control", true);
		musicSlider.value = PlayerPrefs.GetFloat("music");
		fxSlider.value = PlayerPrefs.GetFloat("fx");
	}
	
	// Options menu pressed
	public void OptionsPress() {
		optionsMenu.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
	}
	
	//Quit menu esiin, muiden nappien disablointi
	public void ExitPress() {
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}
	
	public void NoPress() {
		quitMenu.enabled = false;
		optionsMenu.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		exitText.enabled = true;
	}
	
	public void StartLevel() {
		Application.LoadLevel ("Main");
	}
	public void Back() {
		Application.LoadLevel (0);
	}
	public void Next() {
		Application.LoadLevel (2);
	}
	
	public void ExitGame () {
		Application.Quit ();
	}
	
	public void toggleControl() {
		if (touchControl) {
			touchControl = false;
			controlButton.text = "Tilt";
		} else {
			touchControl = true;
			controlButton.text = "Touch";
		}
		PlayerPrefsX.SetBool("control", touchControl);
	}
	
	public void sliderValueChanged() {
		PlayerPrefs.SetFloat("music", musicSlider.value);
		PlayerPrefs.SetFloat("fx", fxSlider.value);
	}
}