using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbilityScriptable : AbilityScriptable
{

    public GameObject projectileEntity;
    public int initialForce = 10;

    private ProjectileAbilityTriggerable paTriggerable;


    public override void Initialize(GameObject obj)
    {
        paTriggerable = obj.GetComponent<ProjectileAbilityTriggerable>();

        paTriggerable.projectileEntity = projectileEntity;
        paTriggerable.initialForce = initialForce;
        paTriggerable.target = target;
    }

    public override void castAbility()
    {
        paTriggerable.castAbility();
    }
}
