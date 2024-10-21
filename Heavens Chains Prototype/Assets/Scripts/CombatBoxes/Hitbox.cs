using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
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
        Debug.Log("TRIGGERED");
        GameObject hitHurtboxParentEntity = hitHurtbox.transform.root.gameObject;
        bool entityInBlacklist = false;
        foreach(GameObject entity in blacklist)
        {
            if(entity == hitHurtboxParentEntity)
            {
                entityInBlacklist = true;
                break;             
            }
        }
        GameObject hitboxParentEntity = transform.root.gameObject;
        if(entityInBlacklist == false && hitboxParentEntity != hitHurtboxParentEntity)
        {
            blacklist.Add(hitHurtboxParentEntity);
            Hurtbox hurtbox = hitHurtbox.gameObject.GetComponent<Hurtbox>();
            hitboxParentEntity.GetComponent<AttackManager>().HitboxCall(damage * hurtbox.getDamageMultiplier(), strength * hurtbox.getStrengthMultiplier(), 
            hitHurtboxParentEntity, gameObject);
        }
        else 
        {
            Debug.Log("Foreign Collision");
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