using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "Weapons")]
public class WeaponScript : ScriptableObject
{

    public int Ammo;

    public int MaxAmmo;
    public int LimitAmmo;
    public int Magazine;
    public int Damage;
    public float AttackSpeed;
    public float ReloadTime;
    public GunType GunType;
    public GameObject ProjectilePrefab;
    //private int initialAmmo =30;


    private int initialAmmo;
    private int initialMaxAmmo;
    private int initialLimitAmmo;
    private int initialMagazine;
    private int initialDamage;
    private float initialAttackSpeed;
    private float initialReloadTime;

    protected void SaveInitialValues()
    {
        initialAmmo = Ammo;
        initialMaxAmmo = MaxAmmo;
        initialLimitAmmo = LimitAmmo;
        initialMagazine = Magazine;
        initialDamage = Damage;
        initialAttackSpeed = AttackSpeed;
        initialReloadTime = ReloadTime;
    }

    public void ResetValuews()
    {
        initialAmmo = Ammo;
        initialMaxAmmo = MaxAmmo;
        initialLimitAmmo = LimitAmmo;
        initialMagazine = Magazine;
        initialDamage = Damage;
        initialAttackSpeed = AttackSpeed;
        initialReloadTime = ReloadTime;
    }
    private void OnEnable()
    {
#if UNITY_EDITOR
        
        EditorApplication.playModeStateChanged += LogPlayModeState;
#endif
    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        
        EditorApplication.playModeStateChanged -= LogPlayModeState;
#endif
    }

#if UNITY_EDITOR
    private void LogPlayModeState(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            
            Ammo = initialAmmo;
        }
    }
#endif
}
