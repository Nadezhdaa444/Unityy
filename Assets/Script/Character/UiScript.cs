using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class UiScript : MonoBehaviour

{
    CharacterStats stats;
   
    CharacterAttack characterAttack;
   [Header("Bars")]
    [SerializeField] Slider hpBar;
    [SerializeField] Slider  armorBar;
    [SerializeField] Slider  expBar;

    [Header("Stats")]
    [SerializeField] TMP_Text lvlText;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text maxAmmoText;
    void Start()
    {
        stats = FindObjectOfType<CharacterStats>();
        characterAttack = FindObjectOfType<CharacterAttack>();
    }

    void Update()
    {
        InitalizeStats();
    }
    void InitalizeStats()
    {
        hpBar.value = stats.Hp;
        armorBar.value = stats.Armor;
        expBar.value = stats.Experience;
        lvlText.text = stats.Level + "LVL";
        lvlText.text = characterAttack.HandleChangeGun ().Ammo + "/" + characterAttack.HandleChangeGun().MaxAmmo;
        lvlText.text = "$" + stats.Money;
        
    }
}
