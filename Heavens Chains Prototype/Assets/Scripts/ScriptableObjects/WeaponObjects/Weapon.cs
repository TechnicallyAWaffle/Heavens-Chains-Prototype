using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    [SerializeField]
    public float damage;
    public float strength;
    public string primaryAttackAnimation;
    public string secondaryAttackAnimation;
    public GameObject weaponObject;
}