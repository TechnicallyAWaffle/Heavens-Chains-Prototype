using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvarielMain : MonoBehaviour, IDamageableReference
{
    
    //Input system actions and playerControls instantiation
    public struct playerActions {
        public InputActionMap inputActions;
        public InputAction moveAction; // Default: WASD
        public InputAction fallAction; // Default: Shift
        public InputAction dashAction; // Default: Space
        public InputAction swapWeaponAction; //Default 1,2, etc
        public InputAction attackAction; //Default LMB
    }
    public playerActions playerControls;   

    //Avariel player stats && misc conditions
    public float health = 3;
    public float moveSpeed = 7500;
    public float dashPower = 100;
    public float glidePower = 50;
    public float defaultMoveSpeed = 7500;
    public bool flipped = false;
    public List<Weapon> weaponList = new List<Weapon>() {null, null, null, null, null};
    public Weapon activeWeapon;
    public Animator animator;
    
    //State machine stuff
    public Vector2 input;
    public StateMachine stateMachine;
    public Rigidbody2D rb;

    //References
    [SerializeField]
    public WorldManager worldManager;

    //Octant enums
    public enum octant {
        N = 1, NW = 2, W = 3, SW = 4, S = 5, SE = 6, E = 7, NE = 8
    }

    //Mouse position and octant finder struct
    public struct mousePosition {
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
    public mousePosition mousePos;

    void Awake()
    {
        animator = GetComponent<Animator>();
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

    void Start()
    {
        weaponList.Insert(0, Instantiate(worldManager.globalWeaponList[0], rb.position, Quaternion.identity, gameObject.transform));
        weaponList.Insert(1, Instantiate(worldManager.globalWeaponList[0], rb.position, Quaternion.identity, gameObject.transform));
        //Replace with loop later

        //weaponList[1] = Instantiate(weaponList[1], rb.position, Quaternion.identity, gameObject.transform);
        activeWeapon = weaponList[0];
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
        if ((!mousePos.xSign() && !flipped) || (mousePos.xSign() && flipped)) flipPlayer();
    }

    public void flipPlayer()
    {
        if(flipped == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
            flipped = true;
        }
        else if(flipped == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
            flipped = false;
        }
    }

    public void TakeDamage(float damageAmount)
    {

    }

    public void Die()
    {
    }

    public void RecieveHealing(float healingAmount)
    {
    }

    public void GetStunned(float stunDuration)
    {
    }
}
