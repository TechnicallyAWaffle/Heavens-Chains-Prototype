using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeIdlePlayerState : AvarielMain
{
    private CombatSM _sm;

    public void Setup(CombatSM stateMachine, string stateName) 
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //State change logic -> charging
        if(playerControls.attackAction.triggered) _sm.ChangeState(_sm.meleeChargingState);
        
        //State change logic -> swap to ranged
        if(playerControls.swapWeaponAction.triggered) 
        {
            //value is the weapon placement in equipment list
            int value = playerControls.swapWeaponAction.ReadValue<int>();
            GameObject weaponEquipped = SwapWeapon(value);
            
            if (weaponEquipped && weaponEquipped.GetComponent<CustomTag>().HasTag("Mechanical Weapon"))
            {
                _sm.ChangeState(_sm.rangedDeployState);
            }

        }

    }
}
