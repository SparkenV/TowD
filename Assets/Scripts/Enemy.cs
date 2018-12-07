using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour {

    [Header("Characteristics of the enemy")]
    public int health;
    public int armor;
    public float speed = 10f;

    [Space]
    public GameObject hittingTargetEffectPrefab;

    private Renderer renderer;
    private Transform target;
    private int wavePointIndex = 0;

    public Action OnHit;

    private void OnEnable()
    {
        OnHit += CheckHealthLevel;
        OnHit += TakeDamage;
    }

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;

        target = WayPoints.points[wavePointIndex];
    }

    private void TakeDamage()
    {
        health -= 100;
    }

    private void ShowHealthAsColor()
    {
        renderer.material.color = new Color(1, 1 - (health / 1000f), 1 -(health / 1000f), 1f);
        Debug.LogError("health / 1000 = " + health / 1000f);
    }

    private void CheckHealthLevel()
    {
        if (health <= 0)
            Death();
        ShowHealthAsColor();
    }

    private void Death()
    {
        GameObject effectGo = (GameObject)Instantiate(hittingTargetEffectPrefab, transform.position, transform.rotation);
        Destroy(effectGo, 2f);
        Debug.LogError("Kill!");
        Destroy(gameObject);
    }
}
