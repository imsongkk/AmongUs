﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewFloater : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private List<Sprite> sprites;

    private bool[] crewStates = new bool[12];
    private float timer = 0.5f;
    private float distance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<12; i++)
		{
            SpawnFloatingCrew((EPlayerColor)i, Random.Range(0f, distance));
		}
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnFloatingCrew((EPlayerColor)Random.Range(0, 12), distance);
            timer = 0.3f;
        }
    }

    public void SpawnFloatingCrew(EPlayerColor playerColor, float dist)
	{
        if (!crewStates[(int)playerColor])
        {
            crewStates[(int)playerColor] = true;
            float angle = Random.Range(0f, 2 * Mathf.PI);
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * dist;
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            float floatingSpeed = Random.Range(1f, 4f);
            float rotateSpeed = Random.Range(-3f, 3f);
            var crew = Instantiate(prefab, spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            crew.SetFloatingCrew(sprites[Random.Range(0, sprites.Count)], playerColor, direction, floatingSpeed, rotateSpeed, Random.Range(0.5f, 1f));
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        Debug.Log(gameObject.name + " , " + collision.gameObject.name);
        var crew = collision.GetComponent<FloatingCrew>();
        if (crew != null)
		{
            crewStates[(int)crew.playerColor] = false;
            Destroy(crew.gameObject);
		}
	}
}
