using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
		public UIImageButton enemyIcon;
	
		public Player player;
	
		void OnClick(){
			if(player.TurnPhases == 0){
				isClicked = true;
			}
		}

		public float hP;
	
		public float hpMax;
	
		public int level;
	
		public bool isClicked;
		

		[System.Serializable]		
		public class EnemyStatus{
		
		//Attack 1 = 0, Attack 2 = 1, Null -1
		public int previousAttack;
		public int previousDam;
		
		
		//OverTime Buffs
		public float hPoT;
		public int hPoTCounter;
		
		public float strDefUpBuff;
		public int strDefUpBuffCounter;
		
		public float shieldBuff;
		public int shieldBuffCounter;
		
		public float enemySpecificBuff;
		public int enemySpecificBuffCounter;
	
		//OverTime DeBuffs
		public float doT;
		public int doTCounter;
		
		public float strDefDownDebuff;
		public int strDefDownDebuffCounter;
		
		public float playerSpecificDebuff1;
		public int playerSpecificDebuff1Counter;
		
		public float playerSpecificDebuff2;
		public int playerSpecificDebuff2Counter;
		
	}
	
	public EnemyStatus enemyStatus;
	
	
	// Use this for initialization
	void Start () {
	
		hP = 1000;
		hpMax = 1000;
		
		level = 1;
		
		isClicked = false;
		
		
		//TODO: Populate enemyStatus struct
		enemyStatus.previousAttack = 0;
		
		
		//OverTime Buffs
		enemyStatus.hPoT = 1.0f;
		enemyStatus.hPoTCounter = 0;
		
		enemyStatus.strDefUpBuff = 1.0f;
		enemyStatus.strDefUpBuffCounter = 0;
		
		enemyStatus.shieldBuff = 1.0f;
		enemyStatus.shieldBuffCounter = 0;
		
		enemyStatus.enemySpecificBuff = 1.0f;
		enemyStatus.enemySpecificBuffCounter = 0;
	
		//OverTime DeBuffs
		enemyStatus.doT = 1.0f;
		enemyStatus.doTCounter = 0;
		
		enemyStatus.strDefDownDebuff = 1.0f;
		enemyStatus.strDefDownDebuffCounter = 0;
		
		enemyStatus.playerSpecificDebuff1 = 1.0f;
		enemyStatus.playerSpecificDebuff1Counter = 0;
		
		enemyStatus.playerSpecificDebuff2 = 1.0f;
		enemyStatus.playerSpecificDebuff2Counter = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
