using UnityEngine;
using System.Collections;

public class RaycastEffect : MonoBehaviour {

	void OnFire() {
		var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100f)) {
			hit.collider.SendMessage("OnTakeDamage", 1, SendMessageOptions.DontRequireReceiver);
		}
	}

}
