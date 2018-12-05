using UnityEngine;

public class AimCursor : AimBase {
	
	public override Ray GetAimRay() {
		return Camera.main.ScreenPointToRay(Input.mousePosition);
	}

	public override void DrawReticle() {
		if (reticle == null) return;
		var rect = new Rect(Input.mousePosition.x - (reticle.width / 2), (Screen.height - Input.mousePosition.y) - (reticle.height / 2), reticle.width, reticle.height);
		GUI.DrawTexture(rect, reticle);
	}

}
