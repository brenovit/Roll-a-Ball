using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
	public Text label;
	public float minutos;

	private string tempo;
	private float tempSeg = 1;
	private int segundos = 0;

	public GameController gm;

	void LateUpdate ()
	{
		if (!GameController.jogoAcabou) {
			Relogio ();
		}
	}

	private void Relogio ()
	{
		tempSeg = tempSeg - Time.deltaTime;
		segundos = (int)tempSeg;

		if (segundos == 0) {
			tempSeg = 60;
			minutos--;
		}

		tempo = string.Format ("{0}:{1}", minutos.ToString ("00"), segundos.ToString ("00"));

		label.text = tempo;

		if (minutos < 0) {
			gm.PerdeuJogo ();
			return;
		}
	}
}
