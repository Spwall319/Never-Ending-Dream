using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemylook : MonoBehaviour
{
    public float Speed = 20f;
    public Transform FollowPos;
    void Update()
    {
        Quaternion rotTarget = Quaternion.LookRotation(FollowPos.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, Speed * Time.deltaTime);
    }
}


