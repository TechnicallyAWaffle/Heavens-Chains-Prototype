using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private float damage;
    private float strength;
    public BoxCollider2D hurtbox;
    private List<GameObject> blacklist = new List<GameObject>();

    public float Damage
    {
        get {return damage;}
        set {damage = value;}
    }
    public float Strength
    {
        get {return strength;}
        set {strength = value;}
    }

    public void OnTriggerEnter2D(Collider2D hitHitbox)
    {
        GameObject hitHitboxParentEntity = null;
        bool entityInBlacklist = false;
        foreach(GameObject entity in blacklist)
        {
            hitHitboxParentEntity = hitHitbox.gameObject.gameObject.gameObject.gameObject;
            if(entity == hitHitboxParentEntity)
            {
            entityInBlacklist = true;
            break;
            }
        }



        CustomTag hitHitboxEntityTag = hitHitboxParentEntity.GetComponent<CustomTag>();
        //CustomTag hitHitboxHitboxesTag = hitHitbox.gameObject.gameObject.GetComponent<CustomTag>();
        GameObject hurtboxParentEntity = hurtbox.gameObject.gameObject.gameObject;

        if(entityInBlacklist == false && hurtboxParentEntity != hitHitboxParentEntity)
        {
            Hitbox hitbox = hitHitboxParentEntity.GetComponent<Hitbox>();
            blacklist.Add(hitHitboxParentEntity);
            hurtboxParentEntity.GetComponent<AttackManager>().HitboxCall(hitbox.Damage, hitbox.Strength);
        }
    }
}