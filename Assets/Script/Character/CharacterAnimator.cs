
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    CharacterAttack characterAttack;
    CharacterMove characterMove;

    float idleMoveX;
    float idleMoveY;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        characterAttack = GetComponent<CharacterAttack>();
        characterMove = GetComponent<CharacterMove>();
       

    }

    void Update()
    {
        HandleAnimation();
        HandleAttack();

    }

    void Animate(float moveX, float moveY, int layer)
    {
        switch (layer)
        {
            case 0:
                animator.SetLayerWeight(1, 1);
                animator.SetLayerWeight(0, 0);
                break;

            case 1:
                animator.SetLayerWeight(0, 1);
                animator.SetLayerWeight(1, 0);
                break;
        }
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

    }
    void HandleAnimation()
    {
        if (characterMove.moveDirection != Vector2.zero)
        {
            Animate(characterMove.moveX, characterMove.moveY, 1);
            idleMoveX = characterMove.moveX;
            idleMoveY = characterMove.moveY;
        }
        else
        {
            Animate(idleMoveX, idleMoveY, 0);
        }
    }
    void HandleAttack()
    {

        if (Input.GetMouseButtonDown(0) && characterAttack.canShoot && characterAttack.gunType == GunType.Pistol && characterAttack.HandleChangeGun().Ammo>0)
        {
            animator.SetFloat("ShootX", characterMove.GetShootingDirection().x);
            animator.SetFloat("ShootY", characterMove.GetShootingDirection().y);
            animator.SetBool("IsAttack", true);
        }
        else if (Input.GetMouseButtonDown(0) && characterAttack.canShoot && characterAttack.gunType == GunType.Knife)
        {
            animator.SetFloat("ShootX", characterMove.GetShootingDirection().x); 
            animator.SetFloat("ShootY", characterMove.GetShootingDirection().y);
            animator.SetTrigger("Melee");
            characterAttack.MeleeAttack();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("IsAttack", false);
            characterAttack.canShoot = true;
        }

    }

}
