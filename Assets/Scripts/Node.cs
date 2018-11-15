using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    [SerializeField]
    private GameObject turretPrefab;
    private GameObject turret;
    // Use this for initialization
    private void OnMouseDown()
    {
        // left click - get info from selected tile
        
        if (Input.GetMouseButtonDown(0))
        {
            if(turret == null)
            {
                turret = Instantiate(turretPrefab, transform);
            }
            else
            {
                Destroy(turret);
                turret = null;
            }
        }
        

    }
}
