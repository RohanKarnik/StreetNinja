using UnityEngine;
using System.Collections;

public class EnemyBuff1Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	public Enemy enemy;
	
	void OnClick(){
		
		if(enemy.enemyStatus.hPoTCounter > 0){
			
			player.lastEnemyBuffDebuffClicked = 0;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemy.enemyStatus.hPoTCounter > 0){
			button.enabled = true;
			if(player.lastEnemyBuffDebuffClicked == 0)
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
