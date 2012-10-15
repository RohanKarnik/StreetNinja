using UnityEngine;
using System.Collections;

public class EnemyBuff3Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	public Enemy enemy;
	
	void OnClick(){
		
		if(enemy.enemyStatus.shieldBuffCounter > 0){
			
			player.lastEnemyBuffDebuffClicked = 2;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemy.enemyStatus.shieldBuffCounter > 0){
			button.enabled = true;
			if(player.lastEnemyBuffDebuffClicked == 2)
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
