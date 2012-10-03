using UnityEngine;
using System.Collections;

public class BattleScript : MonoBehaviour {
	
	
	public string menuPage = "main";
	
	public int screenCounter = 0;
	
	public float gameTimer;
	
	public Player player;
	public Enemy enemy;
	
	//Keeps track of number of turns
	public int turns;
	
	//0 = Player chooses Abilities
	//4 = A abilities execute
	//5 = B abilities execute
	//6 = C abilities execute
	//7 = Apply OverTimeEffects
	//8 = Enemey's Turn
	public int turnPhases;
	
	//Player = 0, Enemy = 1
	public int lastTurn;
	
	
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		turns = player.battleTurn;
		turnPhases = player.TurnPhases;
		lastTurn = player.lastTurn;
		
	
		if(menuPage == "main"){
			
			if(screenCounter == 0){
			
			//delay
			gameTimer = Time.time;
			
			screenCounter++;
			}
				
		
			if(Time.time >= gameTimer){
				
				menuPage = "battle";
				
			}
		}
		
		if(menuPage == "battle"){
			
			//Player Chooses Abilities
			if(player.TurnPhases == 0){
				
				if(enemy.isClicked == true){
					player.TurnPhases = 4;
					
					//Wait
					player.gameTimer = Time.time + 3;
					
					enemy.isClicked = false;
				}
				
				
			}	
			
			//Execute A ability
			else if(player.TurnPhases == 4){
				
				
				if(Time.time >= player.gameTimer){
					
					if(player.aAbilityChosen != 0)
						executeAAbilities(player.aAbilityChosen);
					
					//Wait
					player.gameTimer = Time.time + 3;
					
					player.TurnPhases = 5;
				}
				
			}
			
			//Execute B Ability
			else if(player.TurnPhases == 5){
				
				if(Time.time >= player.gameTimer){
					
					if(player.aAbilityChosen != 0)
						executeBAbilities(player.bAbilityChosen);
					
					//Wait
					player.gameTimer = Time.time + 3;
					
					player.TurnPhases = 6;
				}
			}
			
			//Execute C Ability
			else if(player.TurnPhases == 6){
				
				if(Time.time >= player.gameTimer){
					
					if(player.aAbilityChosen != 0)
						executeCAbilities(player.cAbilityChosen);
					
					//Wait
					player.gameTimer = Time.time + 3;
					
					player.TurnPhases = 7;
				}
			}
			
			//Apply OverTime Effects
			else if(player.TurnPhases == 7){
				
				if(Time.time >= player.gameTimer){
					
					#region Player OverTimeEffects
					//OverTime effects
					if(player.playerStatus.hPBuffCounter > 0){
		
						player.hP += (player.hP * player.playerStatus.hPoT);
						player.playerStatus.hPBuffCounter--;
					}
				
					if(player.playerStatus.aPBuffCounter > 0){
			
						player.aP += player.playerStatus.aPoT;
						player.playerStatus.aPBuffCounter--;
					}
					
					//Buff and Debuff Counters
					if(player.playerStatus.aAbilitiesBuffCounter > 0){
						player.playerStatus.aAbilitiesBuffCounter--;
					}
					
					if(player.playerStatus.bAbilitiesApDiscountCounter > 0){
						player.playerStatus.bAbilitiesApDiscountCounter--;
					}
					
					if(player.playerStatus.bAbilitiesApTaxCounter > 0){
						player.playerStatus.bAbilitiesApTaxCounter--;
					}
					if(player.playerStatus.bAbilitiesBuffCounter > 0){
						player.playerStatus.bAbilitiesBuffCounter--;	
					}
					if(player.playerStatus.bAbilitiesDeBuffCounter > 0){
						player.playerStatus.bAbilitiesDeBuffCounter--;
					}
					if(player.playerStatus.shieldBuffCounter > 0){
						player.playerStatus.shieldBuffCounter--;
					}
					
					
					
					//Cap AP
					if(player.aP > 100)
						player.aP = 100;
					#endregion
					
					#region EnemyOverTime Effects
					//OverTime effects
					if(enemy.doTCounter > 0){
					
						enemy.hP -= (int)enemy.doT;
						enemy.doTCounter--;
					}
					if(enemy.hPoTCounter > 0){
					
						enemy.hP += (int)enemy.hPoT;
						enemy.hPoTCounter--;
					}
					if(enemy.canCastCounter > 0){
					
						enemy.canCastCounter--;
						
						if(enemy.canCastCounter == 0)
							enemy.canCast = true;
						
					}
					#endregion
					
					//Delay
					player.gameTimer = Time.time + 3;
					player.TurnPhases= 8;
					
				}
				
			}
			
			//Enemy's Turn
			else if(player.TurnPhases == 8){
				
				if(Time.time >= player.gameTimer){
					int tempAttack = Random.Range(1,3);
					
					if(tempAttack == 1)
						player.hP -= 25;
					else
						player.hP -= 50;
				
					//start over again
					resetTurns();
					
				}
			}
			
	
		}
		
	}
	

	public void resetTurns(){
		
		
		//Ammend and Reset Turn variables
		player.aAbilityChosen = 0;
		player.bAbilityChosen = 0;
		player.cAbilityChosen = 0;
		
		player.lastAbilityChosen = 0;
		
		player.battleTurn++;
		
		player.TurnPhases = 0;
		
	}
	
	//Note: A Abilities affected by: C-3
	public void executeAAbilities(int chosenAbility){
		//TODO: Pop Rock Bonus
		//Add float value when ammended with ability
		
		#region A-1
		//[A-1]Generate X AP. Heals Y% for the next Z turns. (HoT)
		if(chosenAbility == 1){
			if(player.playerAbilities.abilitiesA.a1level == 1){
				player.aP += player.playerAbilities.abilitiesA.a1ApBoost;
				
				player.playerStatus.hPoT = player.playerAbilities.abilitiesA.a1hoTPercentLvL1;
				player.playerStatus.hPBuffCounter = player.playerAbilities.abilitiesA.a1hoTTurnsLvL1;
			}
			if(player.playerAbilities.abilitiesA.a1level == 2){
				player.aP += player.playerAbilities.abilitiesA.a1ApBoost;
				
				player.playerStatus.hPoT = player.playerAbilities.abilitiesA.a1hoTPercentLvL2;
				player.playerStatus.hPBuffCounter = player.playerAbilities.abilitiesA.a1hoTTurnsLvL2;
				
			}
			if(player.playerAbilities.abilitiesA.a1level == 3){
				player.aP += player.playerAbilities.abilitiesA.a1ApBoost;
				
				player.playerStatus.hPoT = player.playerAbilities.abilitiesA.a1hoTPercentLvL3;
				player.playerStatus.hPBuffCounter = player.playerAbilities.abilitiesA.a1hoTTurnsLvL3;
			}
		}
		#endregion
		
		#region A-2
		/*[A-2] (Lvl1)15%, (Lvl2)10%, (Lvl3)5% chance to generate 20AP,
			15%, 10%, 5% chance to generate 25AP,
			35%, 40%, 45% chance to generate 30AP,
			35%, 40%, 45% chance to generate 35AP,
			*/
		else if(chosenAbility == 2){

			int tempRandom = 0;
			
			int rangeA = 0;
			int rangeB = 0;
			int rangeC = 0;
			int rangeD = 0;
			
			
			if(player.playerAbilities.abilitiesA.a2level == 1){
				
				rangeA = player.playerAbilities.abilitiesA.a2APSwipesALvL1;
				rangeB = rangeA + player.playerAbilities.abilitiesA.a2APSwipesBLvL1;
				rangeC = rangeC + player.playerAbilities.abilitiesA.a2APSwipesCLvL1;
				rangeD = rangeD + player.playerAbilities.abilitiesA.a2APSwipesDLvL1;
				
				tempRandom = Random.Range(1,rangeD + 1);
				
				if(tempRandom <= rangeA){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostA;
				}
				else if(tempRandom <= rangeB && tempRandom > rangeA){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostB;
				}
				else if(tempRandom <= rangeC && tempRandom > rangeB){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostC;
				}
				else if(tempRandom <= rangeD && tempRandom > rangeC){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostD;
				}
				
			}
			
			else if(player.playerAbilities.abilitiesA.a2level == 2){
				
				rangeA = player.playerAbilities.abilitiesA.a2APSwipesALvL2;
				rangeB = rangeA + player.playerAbilities.abilitiesA.a2APSwipesBLvL2;
				rangeC = rangeC + player.playerAbilities.abilitiesA.a2APSwipesCLvL2;
				rangeD = rangeD + player.playerAbilities.abilitiesA.a2APSwipesDLvL2;
				
				tempRandom = Random.Range(1,rangeD + 1);
				
				if(tempRandom <= rangeA){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostA;
				}
				else if(tempRandom <= rangeB && tempRandom > rangeA){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostB;
				}
				else if(tempRandom <= rangeC && tempRandom > rangeB){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostC;
				}
				else if(tempRandom <= rangeD && tempRandom > rangeC){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostD;
				}
			}
			
			else if(player.playerAbilities.abilitiesA.a2level == 3){
				rangeA = player.playerAbilities.abilitiesA.a2APSwipesALvL2;
				rangeB = rangeA + player.playerAbilities.abilitiesA.a2APSwipesBLvL3;
				rangeC = rangeC + player.playerAbilities.abilitiesA.a2APSwipesCLvL3;
				rangeD = rangeD + player.playerAbilities.abilitiesA.a2APSwipesDLvL3;
				
				tempRandom = Random.Range(1,rangeD + 1);
				
				if(tempRandom <= rangeA){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostA;
				}
				else if(tempRandom <= rangeB && tempRandom > rangeA){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostB;
				}
				else if(tempRandom <= rangeC && tempRandom > rangeB){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostC;
				}
				else if(tempRandom <= rangeD && tempRandom > rangeC){
					player.aP += player.playerAbilities.abilitiesA.a2aPBoostD;
				}
			}
			
		}
		#endregion
		
		#region A-3
		/*[A-3]Lvl 1 Generate 15AP. Gen 10AP for next 2 turns. 
				2 Gen 15AP. Gen 10AP for next 3 turns.
				3 Gen 15AP. Gen 15AP for next 3 turns.
				All unstackable with self*/
		else if(chosenAbility == 3){
			
			player.aP += player.playerAbilities.abilitiesA.a3ApBoost;
			
			//Apply C Ability Boost
			if(player.playerStatus.aAbilitiesBuffCounter > 0)
			{
				if(player.playerAbilities.abilitiesC.c3level == 1)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL1;
				else if(player.playerAbilities.abilitiesC.c3level == 2)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL2;
				else if(player.playerAbilities.abilitiesC.c3level == 3)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL3;
				
			}
			
			if(player.playerAbilities.abilitiesA.a3level == 1){
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a3aoTBoostLvL1;
				player.playerStatus.aPBuffCounter = player.playerAbilities.abilitiesA.a3aoTTurnsLvL1;	
			}
			
			else if(player.playerAbilities.abilitiesA.a3level == 2){
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a3aoTBoostLvL2;
				player.playerStatus.aPBuffCounter = player.playerAbilities.abilitiesA.a3aoTTurnsLvL2;	
			}
			
			else if(player.playerAbilities.abilitiesA.a3level == 3){
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a3aoTBoostLvL3;
				player.playerStatus.aPBuffCounter = player.playerAbilities.abilitiesA.a3aoTTurnsLvL3;	
			}
			
		}
		#endregion
		
		#region A-4
		/*[A-4] Gen 25 AP. Gen 5AP for next 2 turns.
				Gen 25 AP. Gen 5AP for next 3 turns.
				Gen 25 AP. Gen 10AP for next 3 turns.
				All unstackable with self*/
		else if(chosenAbility == 4){
			
			player.aP += player.playerAbilities.abilitiesA.a4ApBoost;
			
			//Apply C Ability Boost
			if(player.playerStatus.aAbilitiesBuffCounter > 0)
			{
				if(player.playerAbilities.abilitiesC.c3level == 1)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL1;
				else if(player.playerAbilities.abilitiesC.c3level == 2)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL2;
				else if(player.playerAbilities.abilitiesC.c3level == 3)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL3;
				
			}
			
			if(player.playerAbilities.abilitiesA.a4level == 1){
				
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a4aoTBoostLvL1;
				player.playerStatus.aPBuffCounter = player.playerAbilities.abilitiesA.a4aoTTurnsLvL1;
			}
			
			else if(player.playerAbilities.abilitiesA.a4level == 2){
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a4aoTBoostLvL2;
				player.playerStatus.aPBuffCounter = player.playerAbilities.abilitiesA.a4aoTTurnsLvL2;
			}
			
			else if(player.playerAbilities.abilitiesA.a4level == 3){
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a4aoTBoostLvL3;
				player.playerStatus.aPBuffCounter = player.playerAbilities.abilitiesA.a4aoTTurnsLvL3;
			}
			
		}
		#endregion
		
		#region A-5
		/*[A-5] Gen 20 AP + 3 AP each turn for rest of battle.
				Gen 20 AP + 5 AP each turn for rest of battle.
				Gen 30 AP + 5 AP each turn for rest of battle.
				All unstackable with self*/
		else if(chosenAbility == 5){
			
			//Apply C Ability Boost
			if(player.playerStatus.aAbilitiesBuffCounter > 0)
			{
				if(player.playerAbilities.abilitiesC.c3level == 1)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL1;
				else if(player.playerAbilities.abilitiesC.c3level == 2)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL2;
				else if(player.playerAbilities.abilitiesC.c3level == 3)
					player.aP += player.playerAbilities.abilitiesC.c3ApGenBuffLvL3;
				
			}
			
			player.playerStatus.aPBuffCounter = player.playerAbilities.abilitiesA.a5aoTTurns;
			
			if(player.playerAbilities.abilitiesA.a5level == 1){
				player.aP += player.playerAbilities.abilitiesA.a5ApBoostLvl1;
				
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a5aoTBoostLvL1;
			}
			
			else if(player.playerAbilities.abilitiesA.a5level == 2){
				player.aP += player.playerAbilities.abilitiesA.a5ApBoostLvl2;
				
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a5aoTBoostLvL2;
			}
			
			else if(player.playerAbilities.abilitiesA.a5level == 3){
				player.aP += player.playerAbilities.abilitiesA.a5ApBoostLvl3;
				
				player.playerStatus.aPoT = player.playerAbilities.abilitiesA.a5aoTBoostLvL3;
			}
			
		}
		#endregion
	}
	
	//TODO: Implement B-5 Effects
	public void executeBAbilities(int chosenAbility){
		//TODO: Pop Rock Bonus
		//Add float value when ammended with ability
		
		#region B-1
		/*[B-1] Costs 20AP
				Mid Damage + 5% heal
				Mid Damage +10% heal
				Mid Damage + 15% heal*/
		if(chosenAbility == 1){
			
			#region Apply C Abilities
			//Apply C Abilities
			float tempBuff = 1.0f;
			
			//Ability C-1 Buff
			if(player.playerStatus.bAbilitiesBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Ability C-2 Debuff
			if(player.playerStatus.bAbilitiesDeBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Amend Ap According to tax and discount
			if(player.playerStatus.bAbilitiesApTaxCounter > 0)
				player.aP -= player.playerAbilities.abilitiesC.c2ApTax;
			if(player.playerStatus.bAbilitiesApDiscountCounter > 0)
				player.aP += player.playerAbilities.abilitiesC.c1ApDiscount;
			#endregion
			
		
			if(player.playerAbilities.abilitiesB.b1level == 1){
				player.aP -= player.playerAbilities.abilitiesB.b1aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b1Damage * tempBuff);
				
				player.hP += (player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL1);
			}
			
			if(player.playerAbilities.abilitiesB.b1level == 2){
				player.aP -= player.playerAbilities.abilitiesB.b1aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b1Damage * tempBuff);
				
				player.hP += (player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL2);
			}
			
			if(player.playerAbilities.abilitiesB.b1level == 3){
				player.aP -= player.playerAbilities.abilitiesB.b1aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b1Damage * tempBuff);
				
				player.hP += (player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL2);
			}			
		}
		
		#endregion
		
		#region B-2
		//DoT on enemy is 15Dam
		
		/*[B-2] Costs 35AP
				Mid damage + Cast a DoT on the enemy for next 2 turns
				High damage + Cast a DoT on the enemy for next 2 turns
				High damage + Cast a DoT on the enemy for next 3 turns*/
		
		if(chosenAbility == 2){
			
			#region Apply C Abilities
			//Apply C Abilities
			float tempBuff = 1.0f;
			
			//Ability C-1 Buff
			if(player.playerStatus.bAbilitiesBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Ability C-2 Debuff
			if(player.playerStatus.bAbilitiesDeBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Amend Ap According to tax and discount
			if(player.playerStatus.bAbilitiesApTaxCounter > 0)
				player.aP -= player.playerAbilities.abilitiesC.c2ApTax;
			if(player.playerStatus.bAbilitiesApDiscountCounter > 0)
				player.aP += player.playerAbilities.abilitiesC.c1ApDiscount;
			#endregion
		
			if(player.playerAbilities.abilitiesB.b2level == 1){
				player.aP -= player.playerAbilities.abilitiesB.b2aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b2DamageLvL1 * tempBuff);
				
				enemy.doT = 15;
				enemy.doTCounter = 2;	
			}
			if(player.playerAbilities.abilitiesB.b2level == 2){
				
				player.aP -= player.playerAbilities.abilitiesB.b2aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b2DamageLvL2 * tempBuff);
				
				enemy.doT = 15;
				enemy.doTCounter = 2;	
			}
			
			if(player.playerAbilities.abilitiesB.b2level == 3){
				
				player.aP -= player.playerAbilities.abilitiesB.b2aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b2DamageLvL3 * tempBuff);
				
				enemy.doT = 15;
				enemy.doTCounter = 3;	
			}
			
		}
		
		#endregion
		
		#region B-3
		/*B-3] Costs 50AP
				High damage + dispel all enemy buffs
				Higher damage + dispel all enemy buffs
				Higher Damage + prevent enemy from casting any buff*/
		
		if(chosenAbility == 3){
			
			#region Apply C Abilities
			//Apply C Abilities
			float tempBuff = 1.0f;
			
			//Ability C-1 Buff
			if(player.playerStatus.bAbilitiesBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Ability C-2 Debuff
			if(player.playerStatus.bAbilitiesDeBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Amend Ap According to tax and discount
			if(player.playerStatus.bAbilitiesApTaxCounter > 0)
				player.aP -= player.playerAbilities.abilitiesC.c2ApTax;
			if(player.playerStatus.bAbilitiesApDiscountCounter > 0)
				player.aP += player.playerAbilities.abilitiesC.c1ApDiscount;
			#endregion
			
			
			if(player.playerAbilities.abilitiesB.b3level == 1){
				player.aP -= player.playerAbilities.abilitiesB.b3aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b3DamageLvL1 * tempBuff);
				
				//TODO: Need to ammend if enemy has more things to buff
				enemy.hPoTCounter = 0;
			}
			
			if(player.playerAbilities.abilitiesB.b3level == 2){
				player.aP -= player.playerAbilities.abilitiesB.b3aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b3DamageLvL2 * tempBuff);
				
				//TODO: Need to ammend if enemy has more things to buff
				enemy.hPoTCounter = 0;
			}
			
			if(player.playerAbilities.abilitiesB.b3level == 3){
				player.aP -= player.playerAbilities.abilitiesB.b3aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b3DamageLvL3 * tempBuff);
				
				enemy.canCast = false;
			}
			
		}
		
		#endregion
		
		#region B-4
		/*B-4] Costs 70AP
				Mid Dmg + 50% heal
				Mid Damage + 60% heal
				Mid Damage +70% heal*/
		if(chosenAbility == 4){
			
			#region Apply C Abilities
			//Apply C Abilities
			float tempBuff = 1.0f;
			
			//Ability C-1 Buff
			if(player.playerStatus.bAbilitiesBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Ability C-2 Debuff
			if(player.playerStatus.bAbilitiesDeBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Amend Ap According to tax and discount
			if(player.playerStatus.bAbilitiesApTaxCounter > 0)
				player.aP -= player.playerAbilities.abilitiesC.c2ApTax;
			if(player.playerStatus.bAbilitiesApDiscountCounter > 0)
				player.aP += player.playerAbilities.abilitiesC.c1ApDiscount;
			#endregion
			
			
			if(player.playerAbilities.abilitiesB.b4level == 1){
				player.aP -= player.playerAbilities.abilitiesB.b4aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b4Damage * tempBuff);
				
				player.hP += (player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL1);
			}
			
			if(player.playerAbilities.abilitiesB.b4level == 1){
				player.aP -= player.playerAbilities.abilitiesB.b4aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b4Damage * tempBuff);
				
				player.hP += (player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL2);
			}
			
			if(player.playerAbilities.abilitiesB.b4level == 1){
				player.aP -= player.playerAbilities.abilitiesB.b4aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b4Damage * tempBuff);
				
				player.hP += (player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL3);
			}
		}
		
		#endregion
		
		#region B-5
		//TODO: Crit Area, Critical Attack, DoT effect
		/*[B-5] Costs 90AP
				Mega Damage. Crit area is bigger than usual
				Mega Damage. Guaranteed Crit
				Mega Damage. Guaranteed Crit. Casts a powerful DoT on enemy for 3 turns.*/
		
		if(chosenAbility == 5){
			
			#region Apply C Abilities
			//Apply C Abilities
			float tempBuff = 1.0f;
			
			//Ability C-1 Buff
			if(player.playerStatus.bAbilitiesBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Ability C-2 Debuff
			if(player.playerStatus.bAbilitiesDeBuffCounter > 0){
				tempBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
			}
			//Amend Ap According to tax and discount
			if(player.playerStatus.bAbilitiesApTaxCounter > 0)
				player.aP -= player.playerAbilities.abilitiesC.c2ApTax;
			if(player.playerStatus.bAbilitiesApDiscountCounter > 0)
				player.aP += player.playerAbilities.abilitiesC.c1ApDiscount;
			#endregion
		
			if(player.playerAbilities.abilitiesB.b5level == 1){
				
				player.aP -=  player.playerAbilities.abilitiesB.b5aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b5Damage * tempBuff);
				
				//TODO:Increase Crit Area
				
			}
			
			if(player.playerAbilities.abilitiesB.b5level == 2){
				
				player.aP -=  player.playerAbilities.abilitiesB.b5aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b5Damage * tempBuff);
				
				//TODO: Guaranteed Crit
				
			}
			
			if(player.playerAbilities.abilitiesB.b5level == 3){
				
				player.aP -=  player.playerAbilities.abilitiesB.b5aPCost;
				
				enemy.hP -= (int)(player.playerAbilities.abilitiesB.b5Damage * tempBuff);
				
				//TODO: Guaranteed Crit
				
				enemy.doT = player.playerAbilities.abilitiesB.b5doTLvL3;
				enemy.doTCounter = player.playerAbilities.abilitiesB.b5doTTurnsLvL3;
			}
			
		}
		
		#endregion
		
		
	}
	
	public void executeCAbilities(int chosenAbility){
		#region C-1
		/*[C-1] Free
				B abilities cost 10AP less but are 15% less effective for next 2 turns. C-2 negates
				B abilities cost 10AP less but are 10% less effective for next 2 turns. C-2 negates
				B abilities cost 10AP less but are 5% less effective for next 2 turns. C-2 negates*/
		if(chosenAbility == 1){
			if(player.playerAbilities.abilitiesC.c1level == 1){
				player.playerStatus.bAbilitiesApDiscount = player.playerAbilities.abilitiesC.c1ApDiscount;
				
				player.playerStatus.bAbilitiesDeBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1;
				player.playerStatus.bAbilitiesDeBuffCounter = player.playerAbilities.abilitiesC.c1DeBuffTurns;
				
				//Negate C2
				player.playerStatus.bAbilitiesBuffCounter = 0;
				
			}
			
			if(player.playerAbilities.abilitiesC.c1level == 2){
				player.playerStatus.bAbilitiesApDiscount = player.playerAbilities.abilitiesC.c1ApDiscount;
				
				player.playerStatus.bAbilitiesDeBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL2;
				player.playerStatus.bAbilitiesDeBuffCounter = player.playerAbilities.abilitiesC.c1DeBuffTurns;
				
				//Negate C2
				player.playerStatus.bAbilitiesBuffCounter = 0;
			}
			
			if(player.playerAbilities.abilitiesC.c1level == 3){
				player.playerStatus.bAbilitiesApDiscount = player.playerAbilities.abilitiesC.c1ApDiscount;
				
				player.playerStatus.bAbilitiesDeBuff = player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL3;
				player.playerStatus.bAbilitiesDeBuffCounter = player.playerAbilities.abilitiesC.c1DeBuffTurns;
				
				//Negate C2
				player.playerStatus.bAbilitiesBuffCounter = 0;
			}
		}
		
		#endregion
		
		#region C-2
		/*C-2] Free
			B Abilities cost 10 more AP but are 15% more effective for next 2 turns. C-1 Negates
			B Abilities cost 10 more AP but are 20% more effective for next 2 turns. C-1 Negates
			B Abilities cost 10 more AP but are 25% more effective for next 2 turns. C-1 Negates*/
		if(chosenAbility == 2){
			if(player.playerAbilities.abilitiesC.c2level == 1){
				player.playerStatus.bAbilitiesApTax = player.playerAbilities.abilitiesC.c2ApTax;
				
				player.playerStatus.bAbilitiesBuff = player.playerAbilities.abilitiesC.c2AbilityBuffLvL1;
				player.playerStatus.bAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c2BuffTurns;
				
				//Negate C1
				player.playerStatus.bAbilitiesDeBuffCounter = 0;
			}
			
			if(player.playerAbilities.abilitiesC.c2level == 2){
				player.playerStatus.bAbilitiesApTax = player.playerAbilities.abilitiesC.c2ApTax;
				
				player.playerStatus.bAbilitiesBuff = player.playerAbilities.abilitiesC.c2AbilityBuffLvL2;
				player.playerStatus.bAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c2BuffTurns;
				
				//Negate C1
				player.playerStatus.bAbilitiesDeBuffCounter = 0;
			}
			
			if(player.playerAbilities.abilitiesC.c2level == 3){
				player.playerStatus.bAbilitiesApTax = player.playerAbilities.abilitiesC.c2ApTax;
				
				player.playerStatus.bAbilitiesBuff = player.playerAbilities.abilitiesC.c2AbilityBuffLvL3;
				player.playerStatus.bAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c2BuffTurns;
				
				//Negate C1
				player.playerStatus.bAbilitiesDeBuffCounter = 0;
			}
		}
		#endregion
		
		#region C-3
		if(chosenAbility == 3){
			/*[C-3] Costs 50 AP
			A abilities base generation in increased by 5AP for next 2 turns. Affects APoT (A-3, A-4, A-5)
			A abilities base generation in increased by 10AP for next 2 turns. Affects APoT (A-3, A-4, A-5)
			A abilities base generation in increased by 10AP for next 3 turns. Affects APoT (A-3, A-4, A-5)*/
			if(player.playerAbilities.abilitiesC.c3level == 1){
				
				player.aP -= player.playerAbilities.abilitiesC.c3ApCost;
				
				player.playerStatus.aAbilitiesBuff = player.playerAbilities.abilitiesC.c3ApGenBuffLvL1;
				player.playerStatus.aAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL1;
			}
			
			if(player.playerAbilities.abilitiesC.c3level == 2){
				
				player.aP -= player.playerAbilities.abilitiesC.c3ApCost;
				
				player.playerStatus.aAbilitiesBuff = player.playerAbilities.abilitiesC.c3ApGenBuffLvL2;
				player.playerStatus.aAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL2;
			}
			
			if(player.playerAbilities.abilitiesC.c3level == 3){
				player.playerStatus.aAbilitiesBuff = player.playerAbilities.abilitiesC.c3ApGenBuffLvL3;
				player.playerStatus.aAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL3;
			}
		}
		#endregion
		
		#region C-4
		if(chosenAbility == 4){
			/*C-4] Costs 50 AP
			Casts a protective shield on yourself that absorbs 10% of your total health. Fades away in 2 turns
			Casts a protective shield on yourself that absorbs 20% of your total health. Fades away in 2 turns
			Casts a protective shield on yourself that absorbs 30% of your total health. Fades away in 2 turns*/
			if(player.playerAbilities.abilitiesC.c4level == 1){
				
				player.aP -= player.playerAbilities.abilitiesC.c4ApCost;
				
				player.playerStatus.shieldBuff = player.playerAbilities.abilitiesC.c4BubbleBuffLvL1;
				player.playerStatus.shieldBuffCounter = player.playerAbilities.abilitiesC.c4BubbleBuffTurns;
				
			}
			
			if(player.playerAbilities.abilitiesC.c4level == 2){
				
				player.aP -= player.playerAbilities.abilitiesC.c4ApCost;
				
				player.playerStatus.shieldBuff = player.playerAbilities.abilitiesC.c4BubbleBuffLvL1;
				player.playerStatus.shieldBuffCounter = player.playerAbilities.abilitiesC.c4BubbleBuffTurns;
				
			}
			
			if(player.playerAbilities.abilitiesC.c4level == 3){
				
				player.aP -= player.playerAbilities.abilitiesC.c4ApCost;
				
				player.playerStatus.shieldBuff = player.playerAbilities.abilitiesC.c4BubbleBuffLvL1;
				player.playerStatus.shieldBuffCounter = player.playerAbilities.abilitiesC.c4BubbleBuffTurns;
				
			}
		}
		#endregion
		
		#region C-5
		if(chosenAbility == 5){
			/*[C-5] Costs 70AP
			B abilities cost 10 less AP for next 2 turns. A abilities generate 10AP more for 2 turns.
			B abilities cost 10 less AP for next 3 turns. A abilities generate 10AP more for 3 turns.
			B abilities cost 10 less AP for next 4 turns. A abilities generate 10AP more for 4 turns.*/
			if(player.playerAbilities.abilitiesC.c5level == 1){
				
				player.aP -= player.playerAbilities.abilitiesC.c5ApCost;
				
				player.playerStatus.bAbilitiesApDiscount = player.playerAbilities.abilitiesC.c5AbilityBBuff;
				player.playerStatus.bAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL1;
				
				player.playerStatus.aAbilitiesBuff = player.playerAbilities.abilitiesC.c5AbilityABuff;
				player.playerStatus.aAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl1;
				
			}
			
			if(player.playerAbilities.abilitiesC.c5level == 2){
				player.aP -= player.playerAbilities.abilitiesC.c5ApCost;
				
				player.playerStatus.bAbilitiesApDiscount = player.playerAbilities.abilitiesC.c5AbilityBBuff;
				player.playerStatus.bAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL2;
				
				player.playerStatus.aAbilitiesBuff = player.playerAbilities.abilitiesC.c5AbilityABuff;
				player.playerStatus.aAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl2;
			}
			
			if(player.playerAbilities.abilitiesC.c5level == 3){
				player.aP -= player.playerAbilities.abilitiesC.c5ApCost;
				
				player.playerStatus.bAbilitiesApDiscount = player.playerAbilities.abilitiesC.c5AbilityBBuff;
				player.playerStatus.bAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL3;
				
				player.playerStatus.aAbilitiesBuff = player.playerAbilities.abilitiesC.c5AbilityABuff;
				player.playerStatus.aAbilitiesBuffCounter = player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl3;
			}
		}
		#endregion
	}
	
}