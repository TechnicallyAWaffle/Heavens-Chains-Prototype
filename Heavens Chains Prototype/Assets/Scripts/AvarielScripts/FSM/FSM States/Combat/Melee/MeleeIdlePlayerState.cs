using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeIdlePlayerState : AvarielMain
{
    private CombatSM _sm;
    private string previousState;

    public void Setup(CombatSM stateMachine, string stateName) 
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        this.previousState = previousState;
        animator.Play("AvarielIdle");
        base.Enter(previousState);
        playerControls.swapWeaponAction.performed += SwapWeaponCallback;
    }

    //Where weapon swaps happen
    public void SwapWeaponCallback(InputAction.CallbackContext context)
    {
        GameObject previousWeapon = activeWeapon;
        activeWeapon = weaponList[int.Parse(context.control.name)];
        if(previousWeapon.name == activeWeapon.name) 
        {
             if (activeWeapon.GetComponent<CustomTag>().HasTag("Mechanical Weapon"))
            {
                _sm.ChangeState(_sm.rangedDeployState);
            }
            else if (activeWeapon.GetComponent<CustomTag>().HasTag("Divine Weapon"))
            {
                _sm.ChangeState(_sm.meleeIdleState);
            }
        }
    }

    
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //State change logic -> charging
        if(playerControls.attackAction.triggered)
        {
            if(previousState != "Melee-Charging")
                _sm.ChangeState(_sm.meleeChargingState);
            previousState = "None";
        }
        //State change logic -> swap to ranged
    }

    public override void Exit()
    {
        playerControls.swapWeaponAction.performed -= SwapWeaponCallback;
    }
}
