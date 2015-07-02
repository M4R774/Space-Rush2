using UnityEngine;
using UnityEngine.UI; //Tarttee Ui-elementtien käyttöön
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false; //QuitMenu pelin alkaessa piilossa
	}

	//Quit menu esiin, muiden nappien disablointi
	public void ExitPress() {
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress() {
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel() {
		Application.LoadLevel (1);
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
}