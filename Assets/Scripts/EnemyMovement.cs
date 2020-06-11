using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Block> path;

	// Use this for initialization
	void Start () {
        StartCoroutine(FollowPath());
        print("Hey I'm back at Start");
	}

    IEnumerator FollowPath()
    {
        print("Starting patrol..");
        foreach (Block waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print(waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }
}
