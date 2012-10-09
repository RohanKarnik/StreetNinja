using UnityEngine;
using System.Collections;

public class C2 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 0){
				
			player.stanceChosen  = 2;
		
			player.stanceChanged = true;
				//player.TurnPhases = 4;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 12;
	}
	
	void Update(){
	
		//if(player.TurnPhases > 0){
		
		if(player.stanceChosen  == 2)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.cAbilityChosen != 2)
		else
				button.defaultColor = Color.blue;
		//}
		
		
	}
}
