using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeIdlePlayerState : BaseState
{
    private CombatSM _sm;
    private string previousState;

    public MeleeIdlePlayerState(CombatSM stateMachine, AvarielMain avarielMain) :base("Melee-Idle", stateMachine, avarielMain)
    {
        this.stateName = "Melee-Idle";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        this.previousState = previousState;
        avarielMain.animator.Play("AvarielIdle");
        base.Enter(previousState);
        avarielMain.playerControls.swapWeaponAction.performed += SwapWeaponCallback;
    }

    //Where weapon swaps happen
    public void SwapWeaponCallback(InputAction.CallbackContext context)
    {
        GameObject previousWeapon = avarielMain.activeWeapon;
        avarielMain.activeWeapon = avarielMain.weaponList[int.Parse(context.control.name)];
        if(previousWeapon.name != avarielMain.activeWeapon.name) 
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
        //State change logic -> charging
        if(avarielMain.playerControls.attackAction.triggered)
        {
            if(previousState != "Melee-Charging")
                _sm.ChangeState(_sm.meleeChargingState);
            previousState = "None";
        }
        //State change logic -> swap to ranged
    }

    public override void Exit()
    {
        avarielMain.playerControls.swapWeaponAction.performed -= SwapWeaponCallback;
    }
}
