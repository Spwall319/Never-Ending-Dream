using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    private Animator mAnimator;
    public bool equiped;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        equiped = false;
        gameObject.tag = "Untagged";
    }

    void Update()
    {
        if(mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (equiped) { mAnimator.SetTrigger("TrUnequip"); }
                else 
                { 
                    mAnimator.SetTrigger("TrEquip"); 
                    if(mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .5)
                    {
                        gameObject.tag = "tag";
                    }
                    
                }
                equiped = !equiped;
            }
        }
    }
}
