using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvarielMain : MonoBehaviour
{
    
    //Input system actions and playerControls instantiation
    protected struct playerActions {
        public InputActionMap inputActions;
        public InputAction moveAction; // Default: WASD
        public InputAction fallAction; // Default: Shift
        public InputAction dashAction; // Default: Space
        public InputAction swapWeaponAction; //Default 1,2, etc
        public InputAction attackAction; //Default LMB
    }
    protected playerActions playerControls;

    //Avariel player stats && misc conditions
    protected float moveSpeed = 7500;
    protected float dashPower = 100;
    protected float glidePower = 50;
    protected static float defaultMoveSpeed = 7500;
    protected bool flipped = false;
    protected List<GameObject> weaponList = new List<GameObject>();
    protected GameObject activeWeapon;
    
    //State machine stuff
    protected Vector2 input;
    protected StateMachine stateMachine;
    protected Rigidbody2D rb;
    public string stateName { get; protected set; }

    //Octant enums
    protected enum octant {
        N = 1, NW = 2, W = 3, SW = 4, S = 5, SE = 6, E = 7, NE = 8
    }

    //Mouse position and octant finder struct
    protected struct mousePosition {
        public float x; // Mouse x position
        public float y; // Mouse y position
        
        public mousePosition(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public float getMouseAngle() {
            return Mathf.Rad2Deg* Mathf.Acos(x / (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2))));
        }

        public octant getOctant() {
            float mouseAngle = getMouseAngle();
            if (ySign()) {
                if (mouseAngle < 22.5) return octant.E;
                else if (mouseAngle < 67.5) return octant.NE;
                else if (mouseAngle < 112.5) return octant.N;
                else if (mouseAngle < 157.5) return octant.NW;
                else return octant.W;
            } else {
                if (mouseAngle < 22.5) return octant.E;
                else if (mouseAngle < 67.5) return octant.SE;
                else if (mouseAngle < 112.5) return octant.S;
                else if (mouseAngle < 157.5) return octant.SW;
                else return octant.W;
            }
        }

        public string getOctantDirection() {
            octant mouseOctant = getOctant();
            if (mouseOctant == octant.W || mouseOctant == octant.E) {
                return "Horizontal";
            } else if (mouseOctant == octant.N || mouseOctant == octant.S) {
                return "Vertical";
            } else {
                return "Diagonal";
            }
        }
        public bool xSign() {
            return (x > 0);
        }
        public bool ySign() {
            return (y > 0);
        }
    }
    protected mousePosition mousePos;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerControls.inputActions = new InputActionMap();
        playerControls.inputActions.Enable();

        playerControls.moveAction = playerInput.actions["Move"];
        playerControls.fallAction = playerInput.actions["Fall"];
        playerControls.dashAction = playerInput.actions["Dash"];
        playerControls.swapWeaponAction = playerInput.actions["Swap Weapon"];
        playerControls.attackAction = playerInput.actions["Attack"];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseRelative = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        if (flipped) {
            mousePos.x = mouseRelative.x * (float)(-1);
            mousePos.y = mouseRelative.y;
        } else {
            mousePos.x = mouseRelative.x;
            mousePos.y = mouseRelative.y;
        }
    }

    public GameObject SwapWeapon(string inputName)
    {
        if (inputName == activeWeapon.name)
        {
            return null;
        }
        else
        {
            return weaponList[0];
        }
    }

    public virtual void Enter(string previousState) {}
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
