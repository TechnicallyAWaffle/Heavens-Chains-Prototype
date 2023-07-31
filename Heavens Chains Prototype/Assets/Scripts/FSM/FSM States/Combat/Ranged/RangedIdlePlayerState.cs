using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedIdlePlayerState : AvarielMain
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
        else if (weaponEquipped && weaponEquipped.GetComponent<CustomTag>().HasTag("Divine Weapon"))
            {
                _sm.ChangeState(_sm.meleeIdleState);
            }

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //State change logic -> attacking
        if(playerControls.attackAction.triggered) _sm.ChangeState(_sm.rangedAttackingState);

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
        playerControls.swapWeaponAction.performed -= SwapWeaponCallback;
    }
}
