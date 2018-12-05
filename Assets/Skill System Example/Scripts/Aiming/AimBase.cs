using UnityEngine;
using System.Collections;

public class AimBase : MonoBehaviour {

	public LayerMask layerMask = 1;
	public Texture2D reticle;

	private Skill skill;

	void Awake() {
		skill = GetComponent<Skill>();
	}

	public virtual Ray GetAimRay() {
		return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
	}

	void Update() {
		RaycastHit hit;
		if (Physics.Raycast(GetAimRay(), out hit, 100f, layerMask)) {
			skill.target = hit.collider.gameObject;
		}
	}

	void OnGUI() {
		DrawReticle();
		DrawTargetName();
	}

	public virtual void DrawReticle() {
		if (reticle == null) return;
		var rect = new Rect((Screen.width - reticle.width) / 2, (Screen.height - reticle.height) / 2, reticle.width, reticle.height);
		GUI.DrawTexture(rect, reticle);
	}

	public virtual void DrawTargetName() {
		if (skill.target == null) return;
		var size = GUI.skin.label.CalcSize(new GUIContent(skill.target.name));
		var rect = new Rect((Screen.width - size.x) / 2, ((Screen.height - size.y) / 2) - 50, size.x, size.y);
		GUI.Label(rect, skill.target.name);
	}

}
