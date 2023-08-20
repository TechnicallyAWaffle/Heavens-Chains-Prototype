using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RailcannonScript : MonoBehaviour, IWeaponReference
{
    private Camera mainCam;
    private Transform ts;
    private LineRenderer railcannonLaser;

    // Railcannon stats
    private float railcannonMaxDistance = 4000;
    
    private List<RaycastHit2D> results = new List<RaycastHit2D>();
    
    // Layer mask
    private ContactFilter2D filter;
    private LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        ts = gameObject.GetComponent<Transform>();
        railcannonLaser = gameObject.GetComponent<LineRenderer>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mask = LayerMask.GetMask("Entities", "Terrain", "Weapons");
        filter.SetLayerMask(mask);
    }

    public void Attack()
    {
        bool hitTerrain = false;
        // Play animation
        Vector2 railcannonPosition = gameObject.transform.position;
        Physics2D.Raycast(railcannonPosition, ts.right, filter, results, railcannonMaxDistance);
        foreach(RaycastHit2D entityHit in results)
        {
            CustomTag laserCollided = entityHit.collider.gameObject.GetComponent<CustomTag>();
            if(laserCollided.HasTag("Terrain"))
            {
                hitTerrain = true;
                FireRailcannonLaser(railcannonPosition, entityHit.point);
            }
            else if(laserCollided.HasTag("Hurtbox") && laserCollided.HasTag("Enemy"))
            {
               Debug.Log("yippee!");
            }
        }
         if(hitTerrain == false)
        {
            Debug.Log(railcannonPosition);
            Debug.Log(ts.right * railcannonMaxDistance);
            FireRailcannonLaser(railcannonPosition, ts.right * railcannonMaxDistance);
            Debug.Log("Nothing Hit");
        }
    }

    public void Charge()
    {
    
    }

    public void Equip()
    {
    
    }

    void FireRailcannonLaser(Vector2 startPos, Vector2 endPos)
    {
        Debug.Log("yayy!");
        railcannonLaser.enabled = true;
        railcannonLaser.SetPosition(0, startPos);
        railcannonLaser.SetPosition(1, endPos);
        StartCoroutine(LineTimer());
    }

    private IEnumerator LineTimer()
    {
        yield return new WaitForSeconds(0.5f);
        railcannonLaser.enabled = false;
    }
}
