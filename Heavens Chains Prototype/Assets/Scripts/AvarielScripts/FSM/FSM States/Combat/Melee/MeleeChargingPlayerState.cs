using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeChargingPlayerState : BaseState
{
    private CombatSM _sm;

    public MeleeChargingPlayerState(CombatSM stateMachine, AvarielMain avarielMain) :base("Melee-Charging", stateMachine, avarielMain)
    {
        this.stateName = "Melee-Charging";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        avarielMain.animator.Play("AvarielSwordChargeIn");
        base.Enter(previousState);
        avarielMain.playerControls.swapWeaponAction.performed += SwapWeaponCallback; //fires function something;
    }

    //Where weapon swaps happen
    public void SwapWeaponCallback(InputAction.CallbackContext context)
    {
        GameObject previousWeapon = avarielMain.activeWeapon;
        avarielMain.activeWeapon = avarielMain.weaponList[int.Parse(context.control.name)];
        if(previousWeapon.name == avarielMain.activeWeapon.name) 
        {
             if (avarielMain.activeWeapon.GetComponent<CustomTag>().HasTag("Mechanical Weapon"))
            {
                _sm.ChangeState(_sm.rangedDeployState);
            }
            else if (avarielMain.activeWeapon.GetComponent<CustomTag>().HasTag("Divine Weapon"))
            {
                _sm.ChangeState(_sm.meleeIdleState);
            }
        }
    }
    
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //State change logic -> attacking
        if(avarielMain.playerControls.attackAction.triggered) _sm.ChangeState(_sm.meleeAttackingState);
        
        //State change logic -> dash cancel
        if(avarielMain.playerControls.dashAction.triggered) _sm.ChangeState(_sm.meleeIdleState);

        //State change logic -> swap to ranged
        /*if(playerControls.swapWeaponAction.triggered) 
        {
            //value is the weapon placement in equipment list
            int value = playerControls.swapWeaponAction.ReadValue<int>();
            GameObject weaponEquipped = SwapWeapon(value);
            
            if (weaponEquipped && weaponEquipped.GetComponent<CustomTag>().HasTag("Mechanical Weapon"))
            {
                _sm.ChangeState(_sm.rangedDeployState);
            }

            else if (weaponEquipped && weaponEquipped.GetComponent<CustomTag>().HasTag("Divine Weapon"))
            {
                _sm.ChangeState(_sm.meleeIdleState);
            }
        }*/
        

    }

    public override void Exit()
    {
        avarielMain.playerControls.swapWeaponAction.performed -= SwapWeaponCallback;
    }
}
