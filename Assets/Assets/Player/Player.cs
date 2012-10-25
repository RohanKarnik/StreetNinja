using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
		//LevelStuff
		public TextAsset playerLevels;
	
		[System.Serializable]
		public class Level{
			public int lvl;
			public int xPNeeded;
			public int hP;
			public int str;
			public int def;
		}
		
		[System.Serializable]
		public class LevelArray{ 
		
			public Level playerLevelArray = new Level();
		
		}
	
		public LevelArray[] playerLevelArray = new LevelArray[100];
	

		public float hP;
		public float hPMax;
		
		public int level;
		
		public float aP;
	
		public float xP;
		public float xPNextLevel;
	
		public float str = 5;
	
		public float def;
	
		public int battleTurn;
	
		public float turnDamage;
	
		public enum BattleStatus{NotFighting,Fighting,Won,Lost};
	
		public BattleStatus playerBattleStatus;
	
		//0 = Player chooses A Abilities
		//1 = Player chooses B Abilities
		//2 = Player chooses C Abilities
		//3 = Choose to execute or redo
		//4 = A abilities execute
		//5 = B abilities execute
		//6 = C abilities execute
		//7 = Enemey's Turn
		public int TurnPhases;
	
		//Player = 0, Enemy = 1
		public int lastTurn;
	
		[System.Serializable]
		public class PlayerStatus{
		
		//Over Time Buffs
		[System.Serializable]
		public class OverTimeBuffs{
			public float hPoT;
			public int hPBuffCounter;
		
			public float aPoT;
			public int aPBuffCounter;
		
			public float StrDefUpBuff;
			public int StrDefUpBuffCounter;
		
			public float shieldBuff;
			public int shieldBuffCounter;
		}
		
		
		//Over Time DeBuff
		[System.Serializable]
		public class OverTimeDeBuffs{
			public float doTDamage;
			public int doTCounter;
		
			public int aPTax;
			public int aPTaxCounter;
			
			public int aPGenDegrade;
			public int aPGenDegradeCounter;
		
			public float StrDefDownDeBuff;
			public int StrDefDownDeBuffCounter;
		}
		
		public OverTimeBuffs overTimeBuffs;
		public OverTimeDeBuffs overTimeDeBuffs;
	}
	
		public PlayerStatus playerStatus;
		
		public Abilities playerAbilities;
	
		public int gunAbilityChosen;
		public int swordAbilityChosen;
		public int stanceChosen;
		public bool stanceChanged;
	
		//0-14, A1 = 1, A2 = 2..etc
		public int lastAbilityChosen;
	
		//0-16 PlayerBuff1 = 0, PlayerBuff2 = 1..etc
		public int lastBuffDebuffClicked;
	
		//0-16 EnemyBuff1 = 0, EnemyBuff2 = 1..etc
		public int lastEnemyBuffDebuffClicked;
	
	
		public enum LastGunHit{NoHit, Normal, Crit, Miss, BeenClicked}
		public LastGunHit lastGunHit;
	
		public enum LastSwordHit{NoHit, Hit, Miss, HasHit};
		public LastSwordHit lastSwordHit;	
	
	
		public int clickCounter;
		public int clickMax;
	
		public int numOfAttacks;
	
		public bool isGunSet;
		public bool isSwordSet;
	
		public float gameTimer;
	
	
	// Use this for initialization
	void Start () {
		
		level = 10;
		
		lastGunHit = LastGunHit.NoHit;
		lastSwordHit = LastSwordHit.NoHit;
		
		clickCounter = 0;
		
		numOfAttacks = 0;
		
		isGunSet = false;
		isSwordSet = false;
		
		fillLevelArray(playerLevelArray, playerLevels);

		
		gunAbilityChosen = -1;
		swordAbilityChosen = -1;
		stanceChosen = -1;
		
		stanceChanged = false;
		
		lastAbilityChosen = -1;
		
		lastEnemyBuffDebuffClicked = -1;
		
		lastBuffDebuffClicked = -1;
		
		turnDamage = 0;
		
		battleTurn = 0;
		TurnPhases = 0;
		lastTurn = 1;
		
		gameTimer = 0;
		
		playerBattleStatus = BattleStatus.NotFighting;
		
		//Initial Stats
		hP = playerLevelArray[level].playerLevelArray.hP;

		hPMax = playerLevelArray[level].playerLevelArray.hP;
		
		aP = 10;
		
		xP = 0;
		xPNextLevel = playerLevelArray[level+1].playerLevelArray.xPNeeded;
		
		str = playerLevelArray[level].playerLevelArray.str;
		def = playerLevelArray[level].playerLevelArray.def;
		
		populateAbilities(playerAbilities);
		populatePlayerStatus(playerStatus);
		
	}
	
	void Update(){
		
		hPMax = playerLevelArray[level].playerLevelArray.hP;
		
		str = playerLevelArray[level].playerLevelArray.str;
		def = playerLevelArray[level].playerLevelArray.def;
		
		
	}
	
	public void populateAbilities(Abilities abilities){
		
		//Random tempRandom;
		
		#region GunAbilities
		//ScarletShot
		abilities.gunAbilities.ScarletShot.cost = -15;
		
		abilities.gunAbilities.ScarletShot.damage = (int)str;
		
		//abilities.gunAbilities.ScarletShot.rangeMin =(int) str * 2;
		//abilities.gunAbilities.ScarletShot.rangeMax =(int) str * 2.2f;
		
		abilities.gunAbilities.ScarletShot.multiplier = 1.0f;
		abilities.gunAbilities.ScarletShot.xPToClip = 1;
		//DarkBullet
		abilities.gunAbilities.DarkBullet.cost = -5;
		
		abilities.gunAbilities.DarkBullet.damage = (int)(str * 1.75);
		
		//abilities.gunAbilities.DarkBullet.rangeMin =(int) str * 2.5f;
		//abilities.gunAbilities.DarkBullet.rangeMax =(int) str * 2.7f;
		
		abilities.gunAbilities.DarkBullet.multiplier = 1.3f;
		abilities.gunAbilities.DarkBullet.xPToClip = 1;
		//PlagueBlast
		abilities.gunAbilities.PlagueBlast.cost = -3;
		
		abilities.gunAbilities.PlagueBlast.damage = (int)str;
		
		//abilities.gunAbilities.PlagueBlast.rangeMin =(int) str * 2.5f;
		//abilities.gunAbilities.PlagueBlast.rangeMax =(int) str * 2.7f;
		
		abilities.gunAbilities.PlagueBlast.multiplier = 1.0f;
		abilities.gunAbilities.PlagueBlast.xPToClip = 1;
		//BlitzBarrage
		abilities.gunAbilities.BlitzBarrage.cost = -3;
		
		abilities.gunAbilities.BlitzBarrage.damage = (int)str;
		
		//abilities.gunAbilities.BlitzBarrage.rangeMin =(int) str * 2.7f;
		//abilities.gunAbilities.BlitzBarrage.rangeMax =(int) str * 2.9f;
		
		abilities.gunAbilities.BlitzBarrage.multiplier = 1.5f;
		abilities.gunAbilities.BlitzBarrage.xPToClip = 2;
		//ShadowflameShot
		abilities.gunAbilities.ShadowflameShot.cost = -3;
		
		abilities.gunAbilities.ShadowflameShot.damage = (int)str;
		
		//abilities.gunAbilities.ShadowflameShot.rangeMin =(int) str * 3f;
		//abilities.gunAbilities.ShadowflameShot.rangeMax =(int) str * 3.2f;
		
		abilities.gunAbilities.ShadowflameShot.multiplier = 1.8f;
		abilities.gunAbilities.ShadowflameShot.xPToClip = 2;
		#endregion
		
		#region SwordAbilities
		//BloodBlade
		abilities.sworddAbilities.BloodBlade.cost = -10;
		
		abilities.sworddAbilities.BloodBlade.damage =(int) (str*4);
		abilities.sworddAbilities.BloodBlade.multiplier = 1.0f;
		abilities.sworddAbilities.BloodBlade.xPToClip = 1;
		
		//DeathStrike
		abilities.sworddAbilities.DeathStrike.cost = -20;
		
		abilities.sworddAbilities.DeathStrike.damage = (int) (str*4.6f);
		abilities.sworddAbilities.DeathStrike.multiplier = 1.8f;
		abilities.sworddAbilities.DeathStrike.xPToClip = 1;
		
		//ShadowFlameSlash
		abilities.sworddAbilities.ShadowFlameSlash.cost = -40;
		
		abilities.sworddAbilities.ShadowFlameSlash.damage = (int) (str*4.6f);
		abilities.sworddAbilities.ShadowFlameSlash.multiplier = 1.8f;
		abilities.sworddAbilities.ShadowFlameSlash.xPToClip = 1;
		
		//CrimsonCut
		abilities.sworddAbilities.CrimsonCut.cost = -40;
		
		abilities.sworddAbilities.CrimsonCut.damage =(int) (str*5);
		abilities.sworddAbilities.CrimsonCut.multiplier = 1.6f;
		abilities.sworddAbilities.CrimsonCut.xPToClip = 2;
		
		//Shadowfury
		abilities.sworddAbilities.ShadowFury.cost = -80;
		
		abilities.sworddAbilities.ShadowFury.damage =(int) (str*5);
		abilities.sworddAbilities.ShadowFury.multiplier = 3.0f;
		abilities.sworddAbilities.ShadowFury.xPToClip = 3;
		
		#endregion
		
		#region Stances
		abilities.stances.StanceOfBloodlust = false;
		
		abilities.stances.StanceOfMurder = false;
		
		abilities.stances.StanceOfShadowsVengence = false;
		
		abilities.stances.StanceOfDeath = false;
		
		abilities.stances.StanceOfDarkProtection = false;
		#endregion
		
		
	}
	
		public void populatePlayerStatus(PlayerStatus tempPlayerStatus){
		
		//Overtime Buffs
		
			tempPlayerStatus.overTimeBuffs.hPoT = 0;
			tempPlayerStatus.overTimeBuffs.hPBuffCounter = 0;
		
			tempPlayerStatus.overTimeBuffs.aPoT = 0;
			tempPlayerStatus.overTimeBuffs.aPBuffCounter = 0;
		
			tempPlayerStatus.overTimeBuffs.StrDefUpBuff = 1.0f;
			tempPlayerStatus.overTimeBuffs.StrDefUpBuffCounter = 0;
		
			tempPlayerStatus.overTimeBuffs.shieldBuff = 1.0f;
			tempPlayerStatus.overTimeBuffs.shieldBuffCounter = 0;
		
		//Overtime Debuffs
			tempPlayerStatus.overTimeDeBuffs.doTDamage = 0;
			tempPlayerStatus.overTimeDeBuffs.doTCounter = 0;
		
			tempPlayerStatus.overTimeDeBuffs.aPTax = 0;
			tempPlayerStatus.overTimeDeBuffs.aPTaxCounter = 0;
			
			tempPlayerStatus.overTimeDeBuffs.aPGenDegrade = 0;
			tempPlayerStatus.overTimeDeBuffs.aPGenDegradeCounter = 0;
		
			tempPlayerStatus.overTimeDeBuffs.StrDefDownDeBuff = 1.0f;
			tempPlayerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter = 0;
		
	}
	
		public void fillLevelArray(LevelArray[] playerLevelArray, TextAsset playerLevelFile){
		
		string[] dataLines = playerLevelFile.text.Split('\n');
		
		int lineNum = 0;
        foreach (string line in dataLines)
        {	
				
			
			string[] dataNode = line.Split(',');
			
			foreach(string node in dataNode){
				
				
				if(playerLevelArray[lineNum].playerLevelArray.lvl == 0){
					playerLevelArray[lineNum].playerLevelArray.lvl = int.Parse(node);
				}

				else if(playerLevelArray[lineNum].playerLevelArray.xPNeeded == 0){
					playerLevelArray[lineNum].playerLevelArray.xPNeeded = int.Parse(node);
				}
				
				else if(playerLevelArray[lineNum].playerLevelArray.hP == 0){
					playerLevelArray[lineNum].playerLevelArray.hP = int.Parse(node);
				}
				
				else if(playerLevelArray[lineNum].playerLevelArray.str == 0){
					playerLevelArray[lineNum].playerLevelArray.str = int.Parse(node);
				}
				
				else if(playerLevelArray[lineNum].playerLevelArray.def == 0){
					playerLevelArray[lineNum].playerLevelArray.def = int.Parse(node);
				}
			}
			

				
			lineNum++;
        }
		
	}
	
}
