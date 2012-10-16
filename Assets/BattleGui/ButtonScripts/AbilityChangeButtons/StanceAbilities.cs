using UnityEngine;
using System.Collections;

public class StanceAbilities : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	public UIFilledSprite stanceAbilitySkin1;
	public UIFilledSprite stanceAbilitySkin2;
	public UIFilledSprite stanceAbilitySkin3;
	public UIFilledSprite stanceAbilitySkin4;
	public UIFilledSprite stanceAbilitySkin5;
	
	void OnClick(){
		
		if(player.TurnPhases >= 0 && player.TurnPhases < 4){
			player.lastAbilityChosen = 0;
			
			player.TurnPhases = 3;

		}
	}
	
	void Update(){
		
		//Update Ability Logo
		switch(player.stanceChosen){
		case 1:			
			stanceAbilitySkin1.color = Color.white;
			stanceAbilitySkin2.color = Color.clear;
			stanceAbilitySkin3.color = Color.clear;
			stanceAbilitySkin4.color = Color.clear;
			stanceAbilitySkin5.color = Color.clear;
			break;
		case 2:			
			stanceAbilitySkin1.color = Color.clear;
			stanceAbilitySkin2.color = Color.white;
			stanceAbilitySkin3.color = Color.clear;
			stanceAbilitySkin4.color = Color.clear;
			stanceAbilitySkin5.color = Color.clear;
			break;
		case 3:			
			stanceAbilitySkin1.color = Color.clear;
			stanceAbilitySkin2.color = Color.clear;
			stanceAbilitySkin3.color = Color.white;
			stanceAbilitySkin4.color = Color.clear;
			stanceAbilitySkin5.color = Color.clear;
			break;
		case 4:			
			stanceAbilitySkin1.color = Color.clear;
			stanceAbilitySkin2.color = Color.clear;
			stanceAbilitySkin3.color = Color.clear;
			stanceAbilitySkin4.color = Color.white;
			stanceAbilitySkin5.color = Color.clear;
			break;
		case 5:			
			stanceAbilitySkin1.color = Color.clear;
			stanceAbilitySkin2.color = Color.clear;
			stanceAbilitySkin3.color = Color.clear;
			stanceAbilitySkin4.color = Color.clear;
			stanceAbilitySkin5.color = Color.white;
			break;
		default:			
			stanceAbilitySkin1.color = Color.clear;
			stanceAbilitySkin2.color = Color.clear;
			stanceAbilitySkin3.color = Color.clear;
			stanceAbilitySkin4.color = Color.clear;
			stanceAbilitySkin5.color = Color.clear;
			break;
		}
		
	}
}
