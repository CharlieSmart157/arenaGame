using UnityEngine;
using System.Collections;

public class Skillbar : MonoBehaviour {

	private Skill[] skills;

	private Skill activeSkill;

	void Start() {
		skills = GetComponentsInChildren<Skill>();
		SetActiveSkill((skills.Length > 0) ? skills[0] : null);
	}

	public void SetActiveSkill(Skill newActiveSkill) {
		activeSkill = newActiveSkill;
		foreach (var skill in skills) {
			skill.gameObject.SetActive(skill == activeSkill);
		}
	}

	void OnGUI() {
		GUILayout.BeginHorizontal();
		foreach (var skill in skills) {
			GUI.color = (skill == activeSkill) ? Color.yellow : Color.gray;
			if (GUILayout.Button(skill.name, GUILayout.Width(64), GUILayout.Height(64))) {
				SetActiveSkill(skill);
			}
		}
		GUILayout.EndHorizontal();
	}

}
