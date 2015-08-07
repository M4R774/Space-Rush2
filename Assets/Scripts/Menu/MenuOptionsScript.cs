using UnityEngine;
using UnityEngine.UI; //Tarttee Ui-elementtien käyttöön
using System.Collections;

public class MenuOptionsScript : MonoBehaviour {

	public Canvas optionsMenu;
	public Button startText;
	public Button exitText;

	void Awake () {
		optionsMenu = optionsMenu.GetComponent<Canvas>();
		optionsMenu.enabled = false;
	}
}
