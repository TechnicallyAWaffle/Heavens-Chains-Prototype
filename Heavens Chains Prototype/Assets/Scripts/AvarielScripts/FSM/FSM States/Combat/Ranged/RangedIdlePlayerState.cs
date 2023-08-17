using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedIdlePlayerState : BaseState
{
    private CombatSM _sm;
    private string previousState;
    private GameObject previousWeapon;
    private Transform ts;
    private Transform entityShooter;
    private Camera mainCam;

    public RangedIdlePlayerState(CombatSM stateMachine, AvarielMain avarielMain) :base("Ranged-Idle", stateMachine, avarielMain)
    {
        this.stateName = "Ranged-Idle";
        _sm = stateMachine;
        entityShooter = avarielMain.gameObject.transform;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        avarielMain.playerControls.swapWeaponAction.performed += SwapWeaponCallback; //fires function something;
        ts = avarielMain.activeWeapon.GetComponent<Transform>();
        
    }

    //Where weapon swaps happen
    public void SwapWeaponCallback(InputAction.CallbackContext context)
    {
        previousWeapon = avarielMain.activeWeapon;
        avarielMain.activeWeapon = avarielMain.weaponList[int.Parse(context.control.name)];
        Debug.Log(avarielMain.activeWeapon);
        if(previousWeapon.name != avarielMain.activeWeapon.name) 
        {
             if (avarielMain.activeWeapon.GetComponent<CustomTag>().HasTag("Mechanical Weapon"))
            {
                previousWeapon.GetComponent<SpriteRenderer>().enabled = false;
                _sm.ChangeState(_sm.rangedDeployState);
            }
            else if (avarielMain.activeWeapon.GetComponent<CustomTag>().HasTag("Divine Weapon"))
            {
                previousWeapon.GetComponent<SpriteRenderer>().enabled = false;
                _sm.ChangeState(_sm.meleeIdleState);
            }
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        ts.position = new Vector3(entityShooter.position.x,entityShooter.position.y+(float)0.24, 0);
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 transformXY = new Vector2(ts.position.x, ts.position.y);
        
        Vector2 rotation = mousePos - transformXY;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        ts.rotation = Quaternion.Euler(0, 0, rotZ);

        //State change logic -> attacking
        if(avarielMain.playerControls.attackAction.triggered) _sm.ChangeState(_sm.rangedAttackingState);
    }

    public override void Exit()
    {
        avarielMain.playerControls.swapWeaponAction.performed -= SwapWeaponCallback;
    }
}
