using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CollisionPlayer : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;
    double damage;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public GameObject enemy;
    public GameObject player;
    EnemyAI my_enemy_script;
    Player my_player_script;


    void Start()
    {
        currentHP = maxHP;
        SetMaxHealth(maxHP);
        my_enemy_script = enemy.GetComponent<EnemyAI>();
        my_player_script = player.GetComponent<Player>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (my_enemy_script.getAttack())
        {
            damage = (my_enemy_script.getDamage() * ((1 -(System.Math.Pow(my_player_script.getDefense(), .5) / 10))));
            currentHP -= System.Convert.ToInt32(damage);
            print(my_enemy_script.getDamage()-damage);
            if (currentHP <= 0)
            {
                print("You died!");

            }
            SetHealth(currentHP);
        }
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}



