using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    [SerializeField] float damageMultiplier;
    [SerializeField] float strengthMultiplier;

    public float getDamageMultiplier(){ return damageMultiplier; }

    public float getStrengthMultiplier(){ return strengthMultiplier; }
}
