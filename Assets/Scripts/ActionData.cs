using UnityEngine;
using System.Collections;

[System.Serializable]
public class ActionData : MonoBehaviour {
	
	public enum ActionType{
		None,
		Gun,
		Sword,
		Stance
	};
	
	public ActionType type = ActionType.None;
	
	public int typeChosen = 0;
	
	public float damage = 0.0f;
	
	public float executeTime = 0.0f;
	
	public float actionTime = 0.0f;
	
	public bool isFromPlayer = false;
	
	/*
	 * Need to have some variable for effects
	 * 
	 */
	
	public ActionData(){
		
	}
	
	public ActionData(ActionType type,float damage, float executeTime, float actionTime, bool isFromPlayer, int typeChosen){
		this.type = type;
		this.damage = damage;
		this.executeTime = executeTime;
		this.actionTime = actionTime;
		this.isFromPlayer = isFromPlayer;
		this.typeChosen = typeChosen;
		
	}
	
	public ActionData(ActionData actionData){
	
		this.type = actionData.type;
		this.damage = actionData.damage;
		this.executeTime = actionData.executeTime;
		this.actionTime = actionData.actionTime;
		this.isFromPlayer = actionData.isFromPlayer;
		this.typeChosen = actionData.typeChosen;
	}
	
	
}
