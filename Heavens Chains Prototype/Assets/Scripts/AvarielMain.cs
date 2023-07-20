using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvarielMain : MonoBehaviour
{
    [HideInInspector]
    public PlayerInput playerInput;

    public float moveSpeed = 10;
    public float dashPower = 100;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
