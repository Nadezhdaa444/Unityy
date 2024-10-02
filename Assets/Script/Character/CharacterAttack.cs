using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public bool canShoot = true;

    public GunType gunType = GunType.Pistol;
    

    [Header("Melee Attack")]
    [SerializeField] Transform meleeAttackPoint;
    [SerializeField] float meleeAttackRange = 1f;
    public List<WeaponScript> weapons;

    [Header("References")]
    [SerializeField] GameObject bulletPref;



    // Start is called before the first frame update
    CharacterMove playerMove;
    CharacterStats stats;
    void Start()
    {
        playerMove = GetComponent<CharacterMove>();
        stats = GetComponent<CharacterStats>();
       
    }

    // Update is called once per frame
    void Update()
    {
        HandleChangeGun();
    }
    public void Bullet()
    {
        if (canShoot)
        {
            Instantiate(HandleChangeGun().ProjectilePrefab, transform.position + playerMove.GetShootingDirection(), Quaternion.identity);
            canShoot = false;
            HandleChangeGun().Ammo -= 1;
        }
    }


    public void MeleeAttack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(meleeAttackPoint.position, meleeAttackRange);

        if (enemy != null)
            Debug.Log(enemy.name);
        else
            Debug.Log("YA UDARIL");

    }

    public WeaponScript HandleChangeGun()
    {
        WeaponScript weapon1 = null;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            gunType = GunType.Pistol;

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunType = GunType.Knife;

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunType = GunType.Crossbow;
        }

        foreach (var weapon in weapons)
        {
            if (weapon.GunType == gunType)
            {
                weapon1 = weapon;
            }

        }
        Debug.Log(gunType);
        return weapon1;

    }

    
   
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(meleeAttackPoint.position, meleeAttackRange);
    }

}
