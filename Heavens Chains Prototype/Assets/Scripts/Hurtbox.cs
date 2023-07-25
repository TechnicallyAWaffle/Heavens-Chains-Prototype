using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float strength;
    public BoxCollider2D hurtbox;
    private List<GameObject> blacklist = new List<GameObject>();

    public float getDamage(){ return damage; }

    public float getStrength(){ return strength; }

    public void OnTriggerEnter2D(Collider2D hitHitbox)
    {
        GameObject hitHitboxParent = null;
        bool entityInBlacklist = false;
        foreach(GameObject entity in blacklist)
        {
            if(hitHitbox.gameObject.gameObject.GetComponent<CustomTag>().HasTag("Divine Weapon"))
            {
                if(entity == hitHitbox.gameObject.gameObject.gameObject.gameObject)
                {
                entityInBlacklist = true;
                break;
                }
                hitHitboxParent = hitHitbox.gameObject.gameObject.gameObject.gameObject;
            }
            else if(hitHitbox.gameObject.gameObject.GetComponent<CustomTag>().HasTag("Entity"))
            {
                if(entity == hitHitbox.gameObject.gameObject.gameObject)
                {
                entityInBlacklist = true;
                break;
                }
                hitHitboxParent = hitHitbox.gameObject.gameObject.gameObject.gameObject;
            }
        }
        CustomTag hitHitboxEntityTag = hitHitboxParent.GetComponent<CustomTag>();
        CustomTag hitHitboxHitboxesTag = hitHitbox.gameObject.gameObject.GetComponent<CustomTag>();
        GameObject hurtboxParentEntity = hurtbox.gameObject.gameObject.gameObject;
        if(entityInBlacklist == false && !hitHitboxEntityTag.HasTag("Player"))
        {
            blacklist.Add(hitHitboxParent);
            //Debug.Log("Added " + entityCollisionData.gameObject + " to blacklist");
            //Debug.Log(">>> " + entityCollisionData.gameObject);
            if(hitHitboxHitboxesTag.HasTag("Entity"))
            {
              // Debug.Log("Entity Collision" + entityCollisionData.gameObject.name);
                hurtbox.gameObject.gameObject.gameObject.GetComponent<AttackManager>()
                .onEntityCollide(gameObject.GetComponent<CustomTag>(), 
                hitHitboxParent, hurtboxParentEntity, damage * hitHitbox.GetComponent<Hitbox>().getDamageMultiplier, strength * hitHitbox.GetComponent<Hitbox>().getStrengthMultiplier);
            }
            else if(hitHitboxHitboxesTag.HasTag("Weapon"))
            {
                //Debug.Log("Weapon Collision" + entityCollisionData.gameObject.name);
                hurtbox.gameObject.gameObject.gameObject.GetComponent<AttackManager>()
                .onEntityCollide(gameObject.GetComponent<CustomTag>(), 
                hitHitboxParent, hurtboxParentEntity, damage * hitHitbox.GetComponent<Hitbox>().getDamageMultiplier, strength * hitHitbox.GetComponent<Hitbox>().getStrengthMultiplier);
            }
            else 
            {
                Debug.Log("Foreign Collision");
            }
        }
    }

}
