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
                entityCollisionData.collider.gameObject, entityCollisionData.otherCollider.transform.parent.gameObject, swordDamage, swordStrength);
            }
            else if(hitHitboxHitboxesTag.HasTag("Weapon"))
            {
                //Debug.Log("Weapon Collision" + entityCollisionData.gameObject.name);
                entityCollisionData.gameObject.GetComponent<AttackManager>()
                .onWeaponCollide(gameObject.GetComponent<CustomTag>(), 
                entityCollisionData.collider.gameObject, entityCollisionData.otherCollider.transform.parent.gameObject, swordDamage, (swordStrength / 2));
            }
            else 
            {
                Debug.Log("Foreign Collision");
            }
        }
    }

}
