using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackReference
{
    void onWeaponCollide(CustomTag collider, GameObject recieverEntity, GameObject senderEntity, float damage, float strength);
    void onEntityCollide(CustomTag collider, GameObject recieverEntity, GameObject senderEntity, float damage, float strength);
    void onParry();
}
