using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargeter : MonoBehaviour
{
    private RaycastHit hit;
    public float attackRange = 300.0F;
    public string enemy;
    public bool gunTrigger;


    void FixedUpdate()
    {
        if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, attackRange))
        {
            gunTrigger = true;
        }
        else
        {
            gunTrigger = false;
        }
    }
}
