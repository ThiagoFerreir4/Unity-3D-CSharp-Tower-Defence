﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();
	public void AddTower(Waypoint baseWaypoint)
    {
        print(towerQueue.Count);
        int numberOfTowers = towerQueue.Count;

        if (numberOfTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform.transform;
        baseWaypoint.isPlaceable = false;

        // set the baseWaypoints
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        // set the placeable flags

        oldTower.baseWaypoint.isPlaceable = true; // Free up the block
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
