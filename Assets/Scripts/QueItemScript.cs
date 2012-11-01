using UnityEngine;
using System.Collections;

public class QueItemScript : MonoBehaviour {

	public ActionData actionData;
	
	public FiFoManager fifoManager;
	
	public bool executionTimeStarted = false;
	
	public bool isPlayerAction;
	
	//Initialize
	public void Init(FiFoManager fifoManager, ActionData actionData){
		this.actionData = actionData;
		this.fifoManager = fifoManager;
		this.isPlayerAction = actionData.isFromPlayer;
		
		
	}
	
	
	//Execute Action
	public void Act(){
		
		switch(actionData.type){
		
		case (ActionData.ActionType.Gun):
				
			break;
		case (ActionData.ActionType.Sword):
			
			break;
		case (ActionData.ActionType.Stance):
			
			break;
			
		}
	
		
	}
	
	
}
