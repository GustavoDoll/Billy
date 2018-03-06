using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tocaanimacao : MonoBehaviour {
	public Animator animacao;
	public GameObject objeto;
	public GameObject balao;
	public GameObject Tela1;
	public GameObject texto;
	public GameObject texto2;
	public GameObject tela2;
	public AudioSource lvlpass;
	public Transform hud;
	public Text txtTempo;
	public AudioSource fala;
	public AudioSource somElefante;
	Vector3 posicao;
	public AudioSource MusicadeFundo;
	public static float tempo;

	bool validacao = false;
	bool chave = true;
	// Use this for initialization
	void Start () {
		tempo = 60.0f;
		MusicadeFundo.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp (0) && validacao == false && chave ==  true) {
			animacao.Play ("Idle");
			texto.SetActive (true);
			texto2.SetActive (true);
			fala.Play ();
			somElefante.Stop ();
			Destroy (balao);
			validacao = true;
		} 
		if (Input.GetMouseButtonDown(0) && validacao == true && chave == true) {
			texto.SetActive (false);
			texto2.SetActive (false);
			objeto.SetActive (true);

			hud.gameObject.SetActive (true);
			StartCoroutine (ContadorDeTempo ());
			Tela1.SetActive (true);
			chave = false;
		}


		SegueToque ();

		txtTempo.text = "Tempo:" + tempo.ToString ();


		if (tempo == 0) {
			Application.LoadLevel ("Teste");
		}
	}
		
	void SegueToque(){

		Ray ray;
		RaycastHit hit;

		ray = Camera.main.ScreenPointToRay (Input.mousePosition); 

		// Coordenada do toque
		if(Input.GetButton("Fire1")){
			if(Physics.Raycast(ray, out hit)){
				// Coordenada do que no plano 3D
				posicao = new Vector3(hit.point.x, hit.point.y, 0.0f);
			}
		}

		// Move o objeto
		objeto.transform.position = Vector3.Lerp(objeto.transform.position, posicao, 7.0f * Time.deltaTime);

	}

	IEnumerator ContadorDeTempo(){
		yield return new WaitForSeconds (1.0f);
		tempo--;
		StartCoroutine (ContadorDeTempo ());

	}
}
