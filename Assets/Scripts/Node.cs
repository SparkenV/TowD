using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverNodeColor;

    private Color startNodeColor;
    private Renderer rend;
    private bool IsBuilt = false;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startNodeColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if(IsBuilt)
        {
            rend.material.color = Color.red;
            return;
        }
        rend.material.color = hoverNodeColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startNodeColor;
    }

    private void OnMouseDown()
    {
        if (!IsBuilt)
        {
            GameObject turret = BuildManager.instance.GetTurretForBuild();
            if (turret == null)
            {
                Debug.LogError("No avaliable turret!");
                return;
            }
            else
            {
                Instantiate(turret, transform.position + new Vector3(0, 0.15f, 0), transform.rotation);
                IsBuilt = true;
                return;
            }
        }
        Debug.LogError("Node is already built");
    }
}
