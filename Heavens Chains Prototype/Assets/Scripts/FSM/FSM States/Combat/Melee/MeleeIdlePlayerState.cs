using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        playerControls.swapWeaponAction.performed += SwapWeaponCallback; //fires function something;
    }

    //Where weapon swaps happen
    public void SwapWeaponCallback(InputAction.CallbackContext context)
    {
        Debug.Log(context.control.name + 1);
        GameObject weaponEquipped = SwapWeapon(context.control.name);
        if (weaponEquipped && weaponEquipped.GetComponent<CustomTag>().HasTag("Mechanical Weapon"))
            {
                _sm.ChangeState(_sm.rangedDeployState);
            }

    }

    
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //State change logic -> charging
        if(playerControls.attackAction.triggered) _sm.ChangeState(_sm.meleeChargingState);
        Debug.Log("balls");
        //State change logic -> swap to ranged
        

    }

    public override void Exit()
    {
        playerControls.swapWeaponAction.performed -= SwapWeaponCallback;
    }
}
