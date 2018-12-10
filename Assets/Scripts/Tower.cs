using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] private int health;
    [SerializeField] private int armor;



    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(120f, 120f, 120f);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(100f, 100f, 100f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
        }
    }
}
