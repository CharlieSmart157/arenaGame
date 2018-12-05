using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {

    public GameObject target;
    public int manaCost; //Maybe?
    public int cooldown;
    int remainingCooldown;

    public void tryToCast()
    {
        if (remainingCooldown == 0 && canCast())
        {
            castAbility();
        }
    }

    bool canCast()
    {
        return true;
    }

    public virtual void castAbility() {
        expendCooldown();
    }

    void expendCooldown() {
        remainingCooldown = cooldown;
    }
}
