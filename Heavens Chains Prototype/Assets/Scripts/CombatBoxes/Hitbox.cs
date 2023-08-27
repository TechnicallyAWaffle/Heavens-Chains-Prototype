using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private float damage;
    private float strength;
    public BoxCollider2D hitbox;
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

    public void OnTriggerEnter2D(Collider2D hitHurtbox)
    {
        GameObject hitHurtboxParentEntity = null;
        bool entityInBlacklist = false;
        foreach(GameObject entity in blacklist)
        {
            if(hitHurtbox.gameObject.gameObject.GetComponent<CustomTag>().HasTag("Divine Weapon"))
            {
                hitHurtboxParentEntity = hitHurtbox.gameObject.gameObject.gameObject.gameObject;
                if(entity == hitHurtboxParentEntity)
                {
                entityInBlacklist = true;
                break;
                }
                
            }
            else if(hitHurtbox.gameObject.gameObject.GetComponent<CustomTag>().HasTag("Entity"))
            {
                hitHurtboxParentEntity = hitHurtbox.gameObject.gameObject.gameObject;
                if(entity == hitHurtboxParentEntity)
                {
                entityInBlacklist = true;
                break;
                }
            }
        }
        CustomTag hitHurtboxEntityTag = hitHurtboxParentEntity.GetComponent<CustomTag>();
        CustomTag hitHurtboxHurtboxesTag = hitHurtbox.gameObject.gameObject.GetComponent<CustomTag>();
        GameObject hitboxParentEntity = hitbox.gameObject.gameObject.gameObject;
        if(entityInBlacklist == false && hitboxParentEntity != hitHurtboxParentEntity)
        {
            blacklist.Add(hitHurtboxParentEntity);
            //Debug.Log("Added " + entityCollisionData.gameObject + " to blacklist");
            //Debug.Log(">>> " + entityCollisionData.gameObject);
            if(hitHurtboxHurtboxesTag.HasTag("Entity"))
            {
                // Debug.Log("Entity Collision" + entityCollisionData.gameObject.name);
                Hurtbox hurtbox = hitHurtbox.gameObject.GetComponent<Hurtbox>();
                hitboxParentEntity.GetComponent<AttackManager>().HitboxCall(damage * hurtbox.getDamageMultiplier(), strength * hurtbox.getStrengthMultiplier());
                //hitHurtboxParentEntity, hurtboxParentEntity, damage * hitHurtbox.GetComponent<Hurtbox>().getDamageMultiplier(), strength * hitHurtbox.GetComponent<Hurtbox>().getStrengthMultiplier());
            }
            else if(hitHurtboxHurtboxesTag.HasTag("Weapon"))
            {
                //Debug.Log("Weapon Collision" + entityCollisionData.gameObject.name);
                Hurtbox hurtbox = hitHurtbox.gameObject.GetComponent<Hurtbox>();
                hitboxParentEntity.GetComponent<AttackManager>().HitboxCall(damage * hurtbox.getDamageMultiplier(), strength * hurtbox.getStrengthMultiplier());
            }
            else 
            {
                Debug.Log("Foreign Collision");
            }
      
        }
    }
}

  
       /* GameObject hitHurtboxParentEntity = null;
        bool entityInBlacklist = false;
        foreach(GameObject entity in blacklist)
        {
            
            hitHurtboxParentEntity = hitHurtbox.gameObject.gameObject.gameObject.gameObject;
            if(entity == hitHurtboxParentEntity)
            {
            entityInBlacklist = true;
            break;
            }
        }



        CustomTag hitHurtboxEntityTag = hitHurtboxParentEntity.GetComponent<CustomTag>();
        //CustomTag hitHurtboxHurtboxesTag = hitHurtbox.gameObject.gameObject.GetComponent<CustomTag>();
        GameObject hitboxParentEntity = hitbox.gameObject.gameObject.gameObject;






        if(entityInBlacklist == false && hitboxParentEntity != hitHurtboxParentEntity)
        {
            Hurtbox hurtbox = hitHurtboxParentEntity.GetComponent<Hurtbox>();
            blacklist.Add(hitHurtboxParentEntity);
            hitboxParentEntity.GetComponent<AttackManager>().HurtboxCall(hitbox.Damage, hitbox.Strength);
        }*/