using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RailcannonScript : MonoBehaviour, IWeaponReference
{
    private Camera mainCam;
    private Transform ts;
    public GameObject entityShooter;

    // Start is called before the first frame update
    void Start()
    {
        ts = gameObject.GetComponent<Transform>();
        entityShooter = gameObject;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //mask = LayerMask.GetMask("Entities", "Terrain", "Weapons");
        //filter.SetLayerMask(mask);
    }

    public void Attack()
    {
        // Play animation
        
    }

    public void Charge()
    {
    
    }

    public void Equip()
    {
    
    }
}
