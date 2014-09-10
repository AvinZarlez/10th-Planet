using UnityEngine;
using System.Collections;

public class died : MonoBehaviour {

	public Animator childAnimtor;
	public GameObject endmenu;
	public GameObject ingamedisplay;

	void OnTriggerEnter2D(Collider2D col)
	{

		childAnimtor.SetTrigger("died");
		endmenu.SetActive(true);
		ingamedisplay.SetActive(false);


}
}
