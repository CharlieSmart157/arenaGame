using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour {

    public string abilityButtonAxisName = "Fire2";
    public Image darkMask;
    public Text coolDownTextDisplay;


    [SerializeField] private AbilityScriptable ability;
    [SerializeField] private GameObject weaponHolder;
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    private bool coolDownComplete;

    void Start()
    {
        Initialize(ability, weaponHolder);
    }

    public void Initialize(AbilityScriptable selectedAbility, GameObject weaponHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        coolDownDuration = ability.aBaseCoolDown;
        ability.Initialize(weaponHolder);
        AbilityReady();
    }

    // is called once per frame by the controller
    public void cooldownUpdate () {
        coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetButtonDown(abilityButtonAxisName))
            {
                ButtonTriggered();
            }
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady() {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown() {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCD = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCD.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    public void ButtonTriggered() {
        if (coolDownComplete)
        {
            nextReadyTime = coolDownDuration + Time.time;
            coolDownTimeLeft = coolDownDuration;
            darkMask.enabled = true;
            coolDownTextDisplay.enabled = true;

            abilitySource.clip = ability.aSound;
            abilitySource.Play();
            ability.castAbility();
        }
    }
}
