using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public GameObject sword;
    public bool sw;
    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false);
        sw = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (sw)
            {
                
                sw = false;
                sword.SetActive(false);
            }
            else
            {
                sw = true;
                sword.SetActive(true);
            }
           
        }
    }
}
