using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Threading;
using System;



public class Player : MonoBehaviour
{
    // Animator
    private Animator mAnimator;

    //Movement
    public float speed = .1f;
    public float sidespeed = 1.0f;
    float x;
    float z;
    public bool equiped;
    public Transform transform;

    //Sword Appear and Disappear
    public GameObject swordInHand;
    public GameObject swordOnBack;

    //Timer
    String previousSeconds;
    String previousMinute;
    int difference;
    public GameObject player;
    Level my_level_script;

    //Attack
    public bool Attack;
    public int damage;
    public int slashDamage;
    public int stabDamage;
    public int jumpDamage;
    public int layer;
    public int lev;
    public int timeInBetweenAttacks;
    public bool alreadyAttack;

    //StaggerTiming
    public int stagger;
    public int lightStagger;
    public int mediumStagger;
    public int heavyStagger;

    //States
    public bool invincible;
    

    //Defense
    public int defense;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        equiped = false;
        swordInHand.SetActive(equiped);

        previousSeconds = DateTime.Now.ToString("ss");
        previousMinute = DateTime.Now.ToString("mm");

        my_level_script = player.GetComponent<Level>();

        Attack = false;
        lev = 1;
    }

    void Update()
    {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);

        if (mAnimator != null)
        {
            if (mAnimator.GetCurrentAnimatorStateInfo(3).normalizedTime < .5 && swordInHand.tag == "PlayerWeaponAttacking")
            {
                Attack = true;
                layer = 3;
            }
            if (mAnimator.GetCurrentAnimatorStateInfo(4).normalizedTime < .5 && swordInHand.tag == "PlayerWeaponAttacking")
            {
                Attack = true;
                layer = 4;
            }

            if ((mAnimator.GetCurrentAnimatorStateInfo(3).normalizedTime >= .99) && mAnimator.GetCurrentAnimatorStateInfo(5).normalizedTime >= .2)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        roll();
                    }
                    else
                    {
                        mAnimator.SetTrigger("Walking");
                        if (Input.GetKey(KeyCode.LeftShift)) { transform.position += transform.forward * Time.deltaTime * speed * 200; }
                        else { transform.position += transform.forward * Time.deltaTime * speed * 100; }
                    }
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKeyDown(KeyCode.Space)) { mAnimator.SetTrigger("ST"); }
                    else { mAnimator.SetTrigger("Walking"); transform.Translate(movement * sidespeed); }

                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKeyDown(KeyCode.Space)) { mAnimator.SetTrigger("ST"); }
                    else { mAnimator.SetTrigger("Walking"); transform.Translate(movement * sidespeed); }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKeyDown(KeyCode.Space)) { mAnimator.SetTrigger("BHS"); }
                    else { mAnimator.SetTrigger("Walking"); transform.position -= transform.forward * Time.deltaTime * speed * 75; }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        if (equiped) { mAnimator.SetTrigger("TrUnequip"); }
                        else { mAnimator.SetTrigger("TrEquip"); }
                        equiped = !equiped;
                    }
                }
                if (!(Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.D)) && (Input.GetKeyDown(KeyCode.Space)) && (Input.GetKeyDown(KeyCode.Mouse0)))
                {
                    mAnimator.SetTrigger("Jump");
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (equiped)
                    {
                        stagger = lightStagger;
                        mAnimator.SetTrigger("Stab");
                        damage = stabDamage + (lev);
                        if (mAnimator.GetCurrentAnimatorStateInfo(3).normalizedTime > .45)
                        {
                            swordInHand.tag = "PlayerWeaponAttacking";
                        }
                        previousSeconds = DateTime.Now.ToString("ss");
                        previousMinute = DateTime.Now.ToString("mm");
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (equiped)
                    {
                        stagger = mediumStagger;
                        mAnimator.SetTrigger("Slash");
                        print("Slashing");
                        damage = slashDamage + (lev);
                        swordInHand.tag = "PlayerWeaponAttacking";
                        previousSeconds = DateTime.Now.ToString("ss");
                        previousMinute = DateTime.Now.ToString("mm");
                    }
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (equiped)
                    {
                        stagger = heavyStagger;
                        mAnimator.SetTrigger("Jump Attack");
                        damage = jumpDamage + (lev);
                        if (mAnimator.GetCurrentAnimatorStateInfo(4).normalizedTime > .8)
                        {
                            swordInHand.tag = "PlayerWeaponAttacking";
                        }
                        previousSeconds = DateTime.Now.ToString("ss");
                        previousMinute = DateTime.Now.ToString("mm");
                    }
                }
                if ((mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .5 && mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= .6))
                {
                    swordInHand.SetActive(equiped);
                    swordOnBack.SetActive(!equiped);
                }
            }

        }
        if (swordInHand.tag == "PlayerWeaponAttacking" && Attack)
        {
            Attacking();
        }
    }
    void roll()
    {
        if (mAnimator.GetCurrentAnimatorStateInfo(5).normalizedTime >= 1)
        {
            mAnimator.SetTrigger("Roll");
        }
    }
    void Attacking()
    {
        if (swordInHand.tag == "PlayerWeaponAttacking")
        {
            if (mAnimator.GetCurrentAnimatorStateInfo(layer).normalizedTime >= .8)
            {
                swordInHand.tag = "NotAttacking";
                Attack = false;
            }
        }
    }
    void resetAttack()
    {
        alreadyAttack = false;
    }
    public int getStabDamage() { return stabDamage; }
    public int getSlashDamage() { return slashDamage; }
    public int getDamage() { return damage; }
    public int getDefense() {return defense; }
    public float getStagger() { return stagger; }
    public bool getAttack()
    {
        if (!alreadyAttack)
        {
            alreadyAttack = true;
            Invoke(nameof(resetAttack), timeInBetweenAttacks);
            return Attack;
        }
        return false;
    }
    public void gainLevel()
    {
        lev ++;
        print("Gained " + lev + " Level!");
    }
    public bool getInvincible() { return invincible; }
    public void unInvicible() { invincible = false; }
}




