using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FiFoManager : MonoBehaviour {
	
	
	public int maxNumQueuedItems = 5;
	
	public Queue<QueItemScript> actionQueue = new Queue<QueItemScript>();
	public QueItemScript currentAction;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void PushToQueue(ActionData actionData){
		
		Debug.Log("Pushing to Queue");
		
		if(actionQueue.Count >= maxNumQueuedItems)
		{
			//Force Action
			
		}
		
		QueItemScript queueItem = new QueItemScript();
		queueItem.Init(this, actionData);
		
		actionQueue.Enqueue(queueItem);
		
		/*GameObject queueItemDisplayObj = (GameObject)Instantiate(queueItemDisplayPrefab, queueItemSpawnPoint.position, queueItemSpawnPoint.rotation);
		queueItemDisplayObj.transform.parent = transform.parent;
		
		QueueItemDisplayBehaviour queueItem = queueItemDisplayObj.GetComponent<QueueItemDisplayBehaviour>();
		queueItem.Init(this, actionData);
		
		MoveQueueItemToQueuePosition(queueItem, actionQueue.Count, spawnMoveToSpeed, spawnMoveToEaseType);
		
		actionQueue.Enqueue(queueItem);*/
		
		
	}
	
	/*
	public void ShiftAllQueuedItems() {
		QueueItemDisplayBehaviour[] actionQueueAsArray = actionQueue.ToArray();
		for(int i = 0, n = actionQueueAsArray.Length; i < n; i++)
		{
			MoveQueueItemToQueuePosition(actionQueueAsArray[i], i, shiftMoveToSpeed, shiftMoveToEaseType);
		}
	}*/
	
	public void ExecuteNextAction() {
		
	}
	
}
