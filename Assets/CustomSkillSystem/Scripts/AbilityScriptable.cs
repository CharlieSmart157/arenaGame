using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityScriptable : ScriptableObject {

    public string aName = "New Ability";
    public GameObject target;
    public PlayerControllerScript owner;
    public int manaCost; //Maybe?
    public Sprite aSprite;
    public AudioClip aSound;
    public float aBaseCoolDown = 1f;

    float remainingCooldown = 0.0f;

    //TODO: SET OWNER

    public abstract void Initialize(GameObject obj);


    public abstract void castAbility();
 

}
