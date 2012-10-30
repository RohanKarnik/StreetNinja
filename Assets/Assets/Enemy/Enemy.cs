using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
		//public UIImageButton enemyIcon;
	
	public tk2dSprite Enemysprite;
	
	public Player player;
	
	public GunMiniGameScipt myGunMiniGame;
	public SwordMiniGameScript mySwordMiniGame;
	
	
	void OnClick(){
			//If clicked during Sword Minigame
		if(player.TurnPhases == 4){
			SwordMiniGameScript other = mySwordMiniGame.clickScreenButton.GetComponent<SwordMiniGameScript>();
			other.OnClick();
		}
			//If clicked during Gun Minigame
		if(player.TurnPhases == 5){
			GunMiniGameScipt other = mySwordMiniGame.clickScreenButton.GetComponent<GunMiniGameScipt>();
			other.OnClick();
		}
		
			//Ifclicked during ability select
			if(player.TurnPhases >= 0 &&
		player.TurnPhases < 4){
			
				if(player.gunAbilityChosen > 0 ||
				player.swordAbilityChosen > 0 ||
				player.stanceChanged == true){
					isClicked = true;
			
			}
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
