using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour, IAttackReference
{
    public Animator animator;
    public bool parryEnabled = false;
    public CustomTag collidee;
    private string activeWeaponScript;
   
   
    //collidee = entity we're colliding with
    //collider = entity that called this method
    public void onEntityCollide(CustomTag collider, GameObject recieverEntity, GameObject senderEntity, float damage, float strength)
    {
        collidee = recieverEntity.GetComponent<CustomTag>();
        if(collidee.HasTag("Player"))
        {
            Vector2 direction = (recieverEntity.transform.position - senderEntity.transform.position).normalized;
            recieverEntity.GetComponent<Rigidbody2D>().AddForce(direction * strength, ForceMode2D.Impulse);
            //recieverEntity.GetComponent<AvarielMain>().stunPlayer(0.75f);
            Debug.Log("Player Collision" + recieverEntity.name);
            //entity.GetComponent<AvarielMain>().updatePlayerCurrentRadiance(-1 * (damage));
        }
        else if(collidee.HasTag("Enemy"))
        {   
            Vector2 direction = (recieverEntity.transform.position - senderEntity.transform.position).normalized;
            recieverEntity.GetComponent<Rigidbody2D>().AddForce(direction * strength, ForceMode2D.Impulse);
            //string scriptName = recieverEntity.GetComponent<EnemyConfiguration>().enemyName;
                /*if(scriptName == "GuardianAngel")
                {
                    //recieverEntity.GetComponent<GuardianAngelBT>().updateEnemyCurrentRadiance(-damage);
                }*/
        }
        else
        {
            Debug.Log("Non-player/enemy collision");
        }
    }

    public void onWeaponCollide(CustomTag collider, GameObject recieverEntity, GameObject senderEntity, float damage, float strength)
    {
        collidee = recieverEntity.GetComponent<CustomTag>();
        if(collidee.HasTag("Divine Weapon"))
        {
            Debug.Log("Clash");
            Vector2 direction = (recieverEntity.transform.position - senderEntity.transform.position).normalized;
            recieverEntity.GetComponent<Rigidbody2D>().AddForce(direction * strength, ForceMode2D.Impulse);
        }
        if(collidee.HasTag("Mechanical Weapon"))
        {   
            Debug.Log("Reflect");
        }
    }
    public void onParry()
    {
        //Debug.Log("Parry");
    }

    /*public void OnCollisionEnter2D(Collision2D entityCollisionData)
    {
        Debug.Log("collided - call from entity");
        Debug.Log(entityCollisionData.gameObject.name);
        onCollide(entityCollisionData.gameObject.GetComponent<CustomTag>(), 
        gameObject.GetComponent<CustomTag>(), entityCollisionData.collider, 0);
    }
    */
    
    
}

