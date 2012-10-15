using UnityEngine;
using System.Collections;

public class SwordAbilityButton : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	void OnClick(){
		
		if(player.TurnPhases >= 0 && player.TurnPhases < 4){
			player.lastAbilityChosen = 0;
			
			player.TurnPhases = 2;

		}
	}
	
	void Update(){
		if(player.TurnPhases >= 0 && player.TurnPhases < 4){
			button.defaultColor = Color.white;
			button.enabled = true;
		}
		else{
			button.enabled = false;
		}
	}
}
