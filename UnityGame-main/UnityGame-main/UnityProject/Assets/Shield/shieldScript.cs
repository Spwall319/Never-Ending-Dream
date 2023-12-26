using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{

    public GameObject shield;
    private Animator mAnimator;
    public bool sh;
    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        sh = false;
        mAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (sh)
            {

                sh = false;
                shield.SetActive(false);
            }
            else
            {
                sh = true;
                shield.SetActive(true);
            }

        }
        if (mAnimator != null) {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                mAnimator.SetTrigger("Shield");
            }
        }
    }
}
