using UnityEngine;
using System.Collections;

public class Bloco : MonoBehaviour
{
	public GameObject particula;
	public GameController gm;

	void Update ()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	public void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			gm.AlteraPontos (100);
			gm.DestroiBloco ();
			Instantiate (particula, this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
