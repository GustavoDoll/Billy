using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blococpto : MonoBehaviour {
	bool chave1;
	bool chave2;
	bool chave3;
	bool chaveSom;
	bool chave;
	bool key1;
	bool key2;
	bool key3;
	public GameObject Elefante;
	public GameObject Tela2;
	public GameObject tela1;
	public AudioSource lvlpass;
	public AudioSource lvlcompleted;
	public GameObject TextoFinal2;
	public GameObject TextoFinal1;




	void OnCollisionStay(Collision c){
		
			 if (c.collider.tag == "quadCol1") {
				chave = true;
				
			} else if (c.collider.tag == "quadCOl2" && chave == true) {

				chave2 = true;
				
			} else if (c.collider.tag == "quadCol3" && chave2 == true) {

				chave3 = true;
				
			} 
		else if (c.collider.tag == "quadCol4" && chave3 == true) {
			lvlpass.Play ();	
			Tela2.SetActive (true);
			tocaanimacao.tempo += 10.0f;
			tela1.SetActive (false);

		} 
	

		if (c.collider.tag == "triCol1") {
			key1 = true;
		
		}
		else if (c.collider.tag=="triCol2" && key1 == true) {
			key2 = true;

		}
		else if (c.collider.tag=="triCol3" && key2 == true) {
			key3 = true;

		}
		else if (c.collider.tag=="triCol4" && key3 == true) {
			lvlcompleted.Play ();
			Tela2.SetActive (false);
			TextoFinal1.SetActive (true);
			TextoFinal2.SetActive (true);
			Elefante.GetComponent<Animator>().Play("Move");

		}
}
}
