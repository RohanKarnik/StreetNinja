using UnityEngine;
using System.Collections;

public class EnemyDeBuff2Switc : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	public Enemy enemy;
	
	void OnClick(){
		
		if(enemy.enemyStatus.playerSpecificDebuff1Counter > 0){
			
			player.lastEnemyBuffDebuffClicked = 5;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemy.enemyStatus.playerSpecificDebuff2Counter > 0){
			button.enabled = true;
			if(player.lastEnemyBuffDebuffClicked == 5)
				button.defaultColor = Color.white;
			else
				button.defaultColor = Color.clear;
		}
		else{
			button.enabled = false;
			button.defaultColor = Color.clear;
		}
	}
}
