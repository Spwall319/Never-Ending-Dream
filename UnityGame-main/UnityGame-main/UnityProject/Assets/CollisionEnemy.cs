using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionEnemy : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;
    public int enemyDamge = 1;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public GameObject enemy;
    public GameObject player;
    Player my_player_script;
    Level my_level_script;
    EnemyAI enemyAI;

    public int xp;

    void Start()
    {
        currentHP = maxHP;
        SetMaxHealth(maxHP);
        my_player_script = player.GetComponent<Player>();
        my_level_script = player.GetComponent<Level>();
        enemyAI = enemy.GetComponent<EnemyAI>();
        xp = 150;
    }
    void OnTriggerEnter(Collider other)
    {
        if (my_player_script.getAttack())
        {
            currentHP -= my_player_script.getDamage();
            currentHP = 0;
            if (currentHP <= 0)
            {
                print("Enemy Killed");
                my_level_script.gainXP(xp);
                Destroy(enemy);
            }
            enemyAI.hit(my_player_script.getStagger());
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



