using UnityEngine;
using System.Collections;

public class Bloco : MonoBehaviour
{
	public GameObject particula;
	public GameController gm;

	void Update ()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);	//alterando a rotação do cubo
	}

	public void OnTriggerEnter (Collider col)	//quando algum objeto entrar no collider deste objeto ou vice-versa
	{
		if (col.gameObject.CompareTag ("Player")) {	//verifica se o objeto tem a tag Player
			gm.AlteraPontos (100);	//altera a pontuação para 100
			gm.DestroiBloco ();		//executa o metodo de "Destrui o bloco"
			Instantiate (particula, this.transform.position, Quaternion.identity);		//Instancia a particula
			Destroy (this.gameObject);	//destoi o gameobject atual;
		}
	}
}
