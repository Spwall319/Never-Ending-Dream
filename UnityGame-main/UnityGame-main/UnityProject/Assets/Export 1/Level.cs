using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level : MonoBehaviour
{
    public int xp;
    public int[] levelUpXP = new int[] { 100, 200, 300, 400, 500, 600, 700 };
    public int lvl;
    public bool maxLVL;

    public GameObject player;
    public Slider xp_slider;
    public Gradient xpgradient;
    public Image fill;
    [SerializeField]
    public AudioSource audio;
    Player my_player_script;
    // Start is called before the first frame update
    void Start()
    {
        xp = 0;
        lvl = 1;
        my_player_script = player.GetComponent<Player>();
        xp_slider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (xp >= levelUpXP[lvl - 1])
        {
            print("LEVEL");
            xp = xp - levelUpXP[lvl - 1];
            audio.Play();
            lvl++;
            my_player_script.gainLevel();
            SetXP(xp);
            if (lvl > levelUpXP.Length)
            {
                maxLVL = true;
            }
        }
    }

    public void gainXP(int gain)
    {
        xp += gain;
        print("Gained " + gain + " XP!");
        print(xp);
        xp_slider.value = xp;
        fill.color = xpgradient.Evaluate(xp_slider.normalizedValue);

    }
    public void SetXP(int exp )
    {
        xp_slider.maxValue = levelUpXP[lvl-1];
        xp_slider.minValue = 0;
        xp_slider.value = exp;

        fill.color = xpgradient.Evaluate(1f);
    }


}


    








