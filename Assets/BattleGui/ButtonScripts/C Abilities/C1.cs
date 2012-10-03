using UnityEngine;
using System.Collections;

public class C1 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 2){
				
				player.cAbilityChosen = 1;
		
				//player.TurnPhases = 4;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 11;
	}
	
	void Update(){
	
		//if(player.TurnPhases > 0){
		
			if(player.cAbilityChosen == 1)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.cAbilityChosen != 1)
		else
				button.defaultColor = Color.blue;
		//}
		
		
	}
}
