using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcollide : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D hitHitbox)
    {
        Debug.Log("hit");
    }
}
