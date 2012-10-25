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
	
	public float tempTotalDamage = 0;
	

	
	// Update is called once per frame
	void Update () {
		turns = player.battleTurn;
		turnPhases = player.TurnPhases;
		lastTurn = player.lastTurn;
		
	
		if(menuPage == "main"){
			
			player.playerBattleStatus = Player.BattleStatus.NotFighting;
			
			if(screenCounter == 0){
			
			//delay
			gameTimer = Time.time + 3;
			
			screenCounter++;
			}
				
		
			if(Time.time >= gameTimer){
				
				menuPage = "battle";
				
				//menuPage = "gunMiniGame";
				//player.playerBattleStatus = Player.BattleStatus.GunDial;
				
				player.playerBattleStatus = Player.BattleStatus.Fighting;
				
			}
		}
		
		if(menuPage == "battle"){
			
			//Check to see if there's a Winner
			if(player.hP <= 0){
				gameTimer = Time.time + 3;
				
				player.playerBattleStatus = Player.BattleStatus.Lost;
				menuPage = "lose";
			}
			else if(enemy.hP <= 0){
				gameTimer = Time.time + 3;
				
				player.playerBattleStatus = Player.BattleStatus.Won;
				menuPage = "win";
			}
			
			#region Battle
			
			//Player Chooses Abilities
			if(player.TurnPhases >= 0 && player.TurnPhases < 4){
				
				//Wait for enemy to be clicked
				#region Enemy Clicked
				if(enemy.isClicked == true){
					
					if(player.swordAbilityChosen > 0){
						player.TurnPhases = 4;
					
						//Wait
						player.gameTimer = Time.time + 3;
					
						enemy.isClicked = false;
					}
					else if(player.gunAbilityChosen > 0){
						player.TurnPhases = 5;
						
						
						//Wait
						player.gameTimer = Time.time + 3;
					
						enemy.isClicked = false;
					}
					else if(player.stanceChanged == true){
						player.TurnPhases = 6;
						
						//Wait
						player.gameTimer = Time.time + 3;
					
						enemy.isClicked = false;
						
					}
					else{
						player.TurnPhases = 7;
						
						//Wait
						player.gameTimer = Time.time + 3;
					
						enemy.isClicked = false;
					}
				}
				#endregion
				
			}	
			
			
			//Execute Sword Ability Phase
			else if(player.TurnPhases == 4){
				
				if(player.clickCounter >= player.clickMax){
					
					switch(player.swordAbilityChosen){
					case 1:
						player.aP += player.playerAbilities.sworddAbilities.BloodBlade.cost;
						break;
					case 2:
						player.aP += player.playerAbilities.sworddAbilities.DeathStrike.cost;
						break;
					case 3:
						player.aP += player.playerAbilities.sworddAbilities.ShadowFlameSlash.cost;
						break;
					case 4:
						player.aP += player.playerAbilities.sworddAbilities.CrimsonCut.cost;
						break;
					case 5:
						player.aP += player.playerAbilities.sworddAbilities.ShadowFury.cost;
						break;
					default:
						player.aP = 0;
						break;
						
					}
					
					
					player.clickCounter = 0;
					
					player.gameTimer = Time.time + 3;
					
					
					//Advance turn
					if(player.gunAbilityChosen > 0){
						player.TurnPhases = 5;
					}
					else{
						if(player.stanceChanged == true)
							player.TurnPhases = 6;
						else
							player.TurnPhases = 7;	
					}
				}
				
				if(player.lastSwordHit == Player.LastSwordHit.Hit){
				
					//Execute Sword Abilities
					ExecuteSwordAbilities(player.swordAbilityChosen);
					
					
					player.lastSwordHit = Player.LastSwordHit.HasHit;
				}

				
				else if(player.lastSwordHit == Player.LastSwordHit.Miss){
				
					//EndGun Dial
					player.clickCounter = player.clickMax;
					
					player.lastSwordHit = Player.LastSwordHit.NoHit;	
				}
				
				
				
			}
			
			//Execute Gun Ability
			else if(player.TurnPhases == 5){
				
				if(player.clickCounter == player.clickMax){
					
					player.clickCounter = 0;
					
					player.gameTimer = Time.time + 3;
					
					if(player.stanceChanged == true)
						player.TurnPhases = 6;
					else
						player.TurnPhases = 7;
				}
				
				
				if(player.lastGunHit == Player.LastGunHit.Normal){
					//execute gun abilities
					ExecuteGunAbilities(player.clickCounter,false);
					
					player.lastGunHit = Player.LastGunHit.NoHit;
					
				}
				
				else if(player.lastGunHit == Player.LastGunHit.Crit){
					//execute gun abilities
					ExecuteGunAbilities(player.clickCounter,true);
					
					player.lastGunHit = Player.LastGunHit.NoHit;
				}
				
				if(player.lastGunHit == Player.LastGunHit.Miss){
					//EndGun Dial
					player.clickCounter = player.clickMax;
					
					player.lastGunHit = Player.LastGunHit.NoHit;
				}
				
			}
			
			//Execute Stance Change if need be
			else if(player.TurnPhases == 6){
				
				if(Time.time >= player.gameTimer){
					
					if(player.stanceChosen != 0)
						ChangeStance(player.stanceChosen);
					
					//Wait
					player.gameTimer = Time.time + 3;
					
					player.TurnPhases = 7;
				}
			}
			
			//Apply OverTime Effects
			else if(player.TurnPhases == 7){
				
				if(Time.time >= player.gameTimer){
					
					#region Player OverTimeEffects
					//TODO: APPLY STANCE EFFECTS
					//OverTimeBuffs
					if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0){
						
						//Apply Hp-Stance
						if(player.playerAbilities.stances.StanceOfMurder == true)
							player.hP = (int)((player.playerAbilities.stances.StanceOfMHealthRegen)
								* (player.hP * player.playerStatus.overTimeBuffs.hPoT));
							
						else
							player.hP += (int)(player.hP * player.playerStatus.overTimeBuffs.hPoT);
						
						player.playerStatus.overTimeBuffs.hPBuffCounter--;
					}
				
					if(player.playerStatus.overTimeBuffs.aPBuffCounter > 0){
			
						//Apply Ap-Stance
						if(player.playerAbilities.stances.StanceOfDeath == true)
							player.aP += (int)(player.playerAbilities.stances.StanceOfDApGenBoost *
								player.playerStatus.overTimeBuffs.aPoT);
							
						else	
							player.aP += player.playerStatus.overTimeBuffs.aPoT;
						
						player.playerStatus.overTimeBuffs.aPBuffCounter--;
					}
					
					if(player.playerStatus.overTimeBuffs.StrDefUpBuffCounter > 0){
						
						//TODO: Apply Effect
						
						player.playerStatus.overTimeBuffs.StrDefUpBuffCounter--;
					}
					
					if(player.playerStatus.overTimeBuffs.shieldBuffCounter > 0){
						
						//TODO: Apply Effect
						
						player.playerStatus.overTimeBuffs.shieldBuffCounter--;
					}
					
					//OverTimeDebuffs
					if(player.playerStatus.overTimeDeBuffs.doTCounter > 0){
						//TODO: Apply Effect
						
						//Apply Stance Effect
						
						
						player.playerStatus.overTimeDeBuffs.doTCounter--;
					}
					
					if(player.playerStatus.overTimeDeBuffs.aPTaxCounter > 0){
						//TODO: Apply Effect
						
						player.playerStatus.overTimeDeBuffs.aPTaxCounter--;
					}
					
					if(player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter > 0){
						//TODO: Apply Effect
						
						player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter--;
					}
					if(player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter > 0){
						//TODO: Apply Effect
						
						player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter--;
					}
					
					
					
					//Cap AP
					if(player.aP > 100)
						player.aP = 100;
					#endregion
					
					
					#region EnemyOverTime Effects
					//OverTime effects
					if(enemy.enemyStatus.doTCounter > 0){
					
						enemy.hP -= (int)enemy.enemyStatus.doT;
						enemy.enemyStatus.doTCounter--;
					}
					if(enemy.enemyStatus.hPoTCounter > 0){
					
						enemy.hP += (int)enemy.enemyStatus.hPoT;
						enemy.enemyStatus.hPoTCounter--;
					}

					#endregion
					
					//Enemy's turn
					ExecuteEnemysTurn();
					
					//Delay
					player.gameTimer = Time.time + 3;
					player.TurnPhases= 8;
					
				}
				
			}
			
			//Enemy's Turn
			else if(player.TurnPhases == 8){
				
				if(Time.time >= player.gameTimer){
					
					
					//start over again
					turns++;
					resetTurns();
					
				}
			}
			
			#endregion
			
		}
		
		if(menuPage == "win"){
			player.TurnPhases = 0;
			
			if(Time.time >= gameTimer){
				resetFight();
				
				screenCounter = 0;
				
				menuPage = "main";
				
				player.playerBattleStatus = Player.BattleStatus.NotFighting;
			}
		}
		
		if(menuPage == "lose"){
			player.TurnPhases = 0;
			
			if(Time.time >= gameTimer){
				resetFight();

				
				screenCounter = 0;
				
				menuPage = "Main";
				
				player.playerBattleStatus = Player.BattleStatus.NotFighting;
			}
		}
		
	}
	
	public void resetFight(){
		
		#region enemy
		enemy.hP = enemy.hpMax;
		enemy.isClicked = false;
		enemy.enemyStatus.previousAttack = 0;
		enemy.enemyStatus.hPoTCounter = 0;
		enemy.enemyStatus.strDefUpBuffCounter = 0;
		enemy.enemyStatus.shieldBuffCounter = 0;
		enemy.enemyStatus.enemySpecificBuffCounter = 0;
		enemy.enemyStatus.doTCounter = 0;
		enemy.enemyStatus.strDefDownDebuffCounter = 0;
		enemy.enemyStatus.playerSpecificDebuff1Counter = 0;
		enemy.enemyStatus.playerSpecificDebuff2Counter = 0;
		#endregion
		
		#region player
		player.gunAbilityChosen = -1;
		player.swordAbilityChosen = -1;
		player.stanceChosen = -1;
		
		player.stanceChanged = false;
		
		player.lastAbilityChosen = -1;
		
		player.lastEnemyBuffDebuffClicked = -1;
		
		player.lastBuffDebuffClicked = -1;
		
		player.turnDamage = 0;
		
		player.battleTurn = 0;
		player.TurnPhases = 0;
		player.lastTurn = 1;
		
		player.gameTimer = Time.time;
		
		player.playerBattleStatus = Player.BattleStatus.NotFighting;
		
		//Initial Stats
		player.hP = player.playerLevelArray[player.level].playerLevelArray.hP;

		player.hPMax = player.playerLevelArray[player.level].playerLevelArray.hP;
		
		player.aP = 0;
		
		player.xP = 0;
		player.xPNextLevel = player.playerLevelArray[player.level+1].playerLevelArray.xPNeeded;
		
		player.str = player.playerLevelArray[player.level].playerLevelArray.str;
		player.def = player.playerLevelArray[player.level].playerLevelArray.def;
		#endregion
		
		
	}
	

	public void resetTurns(){
		
		
		//Ammend and Reset Turn variables
		if(player.gunAbilityChosen > -1)
			player.gunAbilityChosen = 0;
		if(player.swordAbilityChosen > -1)
			player.swordAbilityChosen = 0;
		
		player.stanceChanged = false;
		
		player.turnDamage = 0;
		
		tempTotalDamage = 0;
		
		player.lastAbilityChosen = 0;
		
		player.battleTurn++;
		
		player.TurnPhases = 0;
		
		player.clickCounter = 0;
		
		player.numOfAttacks = 0;
		
		player.isGunSet = false;
		player.isSwordSet = false;
		
		#region BattleAbilities
		player.playerAbilities.gunAbilities.ScarletShot.lastApBoost = 0;
		player.playerAbilities.gunAbilities.ScarletShot.lastDamage = 0;
		
		player.playerAbilities.gunAbilities.DarkBullet.lastApBoost = 0;
		player.playerAbilities.gunAbilities.DarkBullet.lastDamage = 0;
		
		player.playerAbilities.gunAbilities.PlagueBlast.lastApBoost = 0;
		player.playerAbilities.gunAbilities.PlagueBlast.lastDamage = 0;
		
		player.playerAbilities.gunAbilities.BlitzBarrage.lastApBoost = 0;
		player.playerAbilities.gunAbilities.BlitzBarrage.lastDamage = 0;
		
		player.playerAbilities.gunAbilities.ShadowflameShot.lastApBoost = 0;
		player.playerAbilities.gunAbilities.ShadowflameShot.lastDamage = 0;
		#endregion
		
	}
	
	public void ExecuteGunAbilities(int clickCounter, bool isCrit){
		player.numOfAttacks++;
		
		//ScarletShot
		if(player.gunAbilityChosen == 1){
			
			//Apply Ap - (Stance)
			if(player.playerAbilities.stances.StanceOfDeath == true)
				player.playerAbilities.gunAbilities.ScarletShot.lastApBoost = (int)(-1 *(player.playerAbilities.stances.StanceOfDApGenBoost *
					player.playerAbilities.gunAbilities.ScarletShot.cost));
			else
				player.playerAbilities.gunAbilities.ScarletShot.lastApBoost = (-1 * player.playerAbilities.gunAbilities.ScarletShot.cost);
			
			//Accrue Damage
			if(isCrit == true)
				tempTotalDamage = (int) player.playerAbilities.gunAbilities.ScarletShot.damage * 2;
			else
				tempTotalDamage = (int) player.playerAbilities.gunAbilities.ScarletShot.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.gunAbilities.ScarletShot.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
			
			player.aP += (int)player.playerAbilities.gunAbilities.ScarletShot.lastApBoost;
			
			//Apply Clip Effect if last tap
		}
		//DarkBullet
		else if(player.gunAbilityChosen == 2){
			
			//Apply Ap-Stance
			if(player.playerAbilities.stances.StanceOfDeath == true)
				player.playerAbilities.gunAbilities.DarkBullet.lastApBoost = (int)(-1 *(player.playerAbilities.stances.StanceOfDApGenBoost *
					player.playerAbilities.gunAbilities.DarkBullet.cost));
			else
				player.playerAbilities.gunAbilities.DarkBullet.lastApBoost = (-1 * player.playerAbilities.gunAbilities.DarkBullet.cost);
			
			//Accrue Damage
			if(isCrit == true)
				tempTotalDamage = (int) player.playerAbilities.gunAbilities.DarkBullet.damage * 2;
			else
				tempTotalDamage = (int) player.playerAbilities.gunAbilities.DarkBullet.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.gunAbilities.DarkBullet.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
			
			player.aP += (int)player.playerAbilities.gunAbilities.DarkBullet.lastApBoost;
		}
		//PlagueBlast
		else if(player.gunAbilityChosen == 3){
			
			//Apply Ap-Stance
			if(player.playerAbilities.stances.StanceOfDeath == true)
				player.playerAbilities.gunAbilities.PlagueBlast.lastApBoost = (int)(-1 *(player.playerAbilities.stances.StanceOfDApGenBoost *
					player.playerAbilities.gunAbilities.PlagueBlast.cost));
			else
				player.playerAbilities.gunAbilities.PlagueBlast.lastApBoost = (-1 * player.playerAbilities.gunAbilities.PlagueBlast.cost);
			
			//Accrue Damage
			if(isCrit == true)
				tempTotalDamage = player.playerAbilities.gunAbilities.PlagueBlast.damage * 2;
			else
				tempTotalDamage = player.playerAbilities.gunAbilities.PlagueBlast.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.gunAbilities.PlagueBlast.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
			
			player.aP += (int)player.playerAbilities.gunAbilities.PlagueBlast.lastApBoost;
		}
		//BlitzBarage
		else if(player.gunAbilityChosen == 4){
			
			//Apply Ap-Stance
			if(player.playerAbilities.stances.StanceOfDeath == true)
				player.playerAbilities.gunAbilities.BlitzBarrage.lastApBoost = (int)(-1 *(player.playerAbilities.stances.StanceOfDApGenBoost *
					player.playerAbilities.gunAbilities.BlitzBarrage.cost));
			else
				player.playerAbilities.gunAbilities.BlitzBarrage.lastApBoost = (-1 * player.playerAbilities.gunAbilities.BlitzBarrage.cost);
			
			//Accrue Damage
			if(isCrit == true)
				tempTotalDamage = player.playerAbilities.gunAbilities.BlitzBarrage.damage * 2;
			else
				tempTotalDamage = player.playerAbilities.gunAbilities.BlitzBarrage.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.gunAbilities.BlitzBarrage.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
			
			player.aP += (int)player.playerAbilities.gunAbilities.BlitzBarrage.lastApBoost;
		}
		//ShadowFlameShot
		else if(player.gunAbilityChosen == 5){
			
			//Apply Ap-Stance
			if(player.playerAbilities.stances.StanceOfDeath == true)
				player.playerAbilities.gunAbilities.ShadowflameShot.lastApBoost = (int)(-1 *(player.playerAbilities.stances.StanceOfDApGenBoost *
					player.playerAbilities.gunAbilities.ShadowflameShot.cost));
			else
				player.playerAbilities.gunAbilities.ShadowflameShot.lastApBoost = (-1 * player.playerAbilities.gunAbilities.ShadowflameShot.cost);
			
			//Accrue Damage
			if(isCrit == true)
				tempTotalDamage = player.playerAbilities.gunAbilities.ShadowflameShot.damage * 2;
			else	
				tempTotalDamage = player.playerAbilities.gunAbilities.ShadowflameShot.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.gunAbilities.ShadowflameShot.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
			
			player.aP += (int) player.playerAbilities.gunAbilities.ShadowflameShot.lastApBoost;
			
		}
		
		
	}
	
	public void ExecuteSwordAbilities(int chosenAbility){
		player.numOfAttacks++;
		
		//Bloodblade
		if(player.swordAbilityChosen == 1){
			//player.aP += player.playerAbilities.sworddAbilities.BloodBlade.cost;
			
			//Accrue Damage
			tempTotalDamage = player.playerAbilities.sworddAbilities.BloodBlade.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.sworddAbilities.BloodBlade.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
		}
		//DeathStrike
		else if(player.swordAbilityChosen == 2){
			//player.aP += player.playerAbilities.sworddAbilities.DeathStrike.cost;
			
			//Accrue Damage
			tempTotalDamage = player.playerAbilities.sworddAbilities.DeathStrike.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.sworddAbilities.DeathStrike.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
		}
		//ShadowFury
		else if(player.swordAbilityChosen == 3){
			//player.aP += player.playerAbilities.sworddAbilities.ShadowFury.cost;
			
			//Accrue Damage
			tempTotalDamage = player.playerAbilities.sworddAbilities.ShadowFury.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.sworddAbilities.ShadowFury.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
		}
		//CrimsonCut
		else if(player.swordAbilityChosen == 4){
			//player.aP += player.playerAbilities.sworddAbilities.CrimsonCut.cost;
			
			//Accrue Damage
			tempTotalDamage = player.playerAbilities.sworddAbilities.CrimsonCut.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.sworddAbilities.CrimsonCut.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;
		}
		//ShadowFlameSlash
		else if(player.swordAbilityChosen == 5){
			//player.aP += player.playerAbilities.sworddAbilities.ShadowFlameSlash.cost;
			
			//Accrue Damage
			tempTotalDamage = player.playerAbilities.sworddAbilities.ShadowFlameSlash.damage;
			
			//Apply Dam-Stance
			if(player.playerAbilities.stances.StanceOfBloodlust == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfBLOffensiveIncrease);
			
			else if(player.playerAbilities.stances.StanceOfShadowsVengence == true)
				tempTotalDamage = (int)(tempTotalDamage * player.playerAbilities.stances.StanceOfSVOffensiveDecrease);
			
			
			player.turnDamage += tempTotalDamage;
			player.playerAbilities.sworddAbilities.ShadowFlameSlash.lastDamage = (int)tempTotalDamage;
			enemy.hP -= tempTotalDamage;;
		}
	}
	
	public void ChangeStance(int chosenAbility){
		
		if(player.stanceChosen == 1){
			player.playerAbilities.stances.StanceOfBloodlust = true;
			player.playerAbilities.stances.StanceOfMurder = false;
			player.playerAbilities.stances.StanceOfShadowsVengence = false;
			player.playerAbilities.stances.StanceOfDeath = false;
			player.playerAbilities.stances.StanceOfDarkProtection = false;
		}
		else if(player.stanceChosen == 2){
			player.playerAbilities.stances.StanceOfBloodlust = false;
			player.playerAbilities.stances.StanceOfMurder = true;
			player.playerAbilities.stances.StanceOfShadowsVengence = false;
			player.playerAbilities.stances.StanceOfDeath = false;
			player.playerAbilities.stances.StanceOfDarkProtection = false;
		}
		else if(player.stanceChosen == 3){
			player.playerAbilities.stances.StanceOfBloodlust = false;
			player.playerAbilities.stances.StanceOfMurder = false;
			player.playerAbilities.stances.StanceOfShadowsVengence = true;
			player.playerAbilities.stances.StanceOfDeath = false;
			player.playerAbilities.stances.StanceOfDarkProtection = false;
		}
		else if(player.stanceChosen == 4){
			player.playerAbilities.stances.StanceOfBloodlust = false;
			player.playerAbilities.stances.StanceOfMurder = false;
			player.playerAbilities.stances.StanceOfShadowsVengence = false;
			player.playerAbilities.stances.StanceOfDeath = true;
			player.playerAbilities.stances.StanceOfDarkProtection = false;
		}
		else if(player.stanceChosen == 5){
			player.playerAbilities.stances.StanceOfBloodlust = false;
			player.playerAbilities.stances.StanceOfMurder = false;
			player.playerAbilities.stances.StanceOfShadowsVengence = false;
			player.playerAbilities.stances.StanceOfDeath = false;
			player.playerAbilities.stances.StanceOfDarkProtection = true;
		}
	}
	
	public void ExecuteEnemysTurn(){
		int tempAttack = Random.Range(1,3);
					
					if(tempAttack == 1){
						enemy.enemyStatus.previousAttack = 0;
			
						if(player.playerAbilities.stances.StanceOfBloodlust == true){
							enemy.enemyStatus.previousDam = (int)(5 * player.playerAbilities.stances.StanceOfBLDefensiveDecrease);
							player.hP -= enemy.enemyStatus.previousDam ;
						}
						else if(player.playerAbilities.stances.StanceOfShadowsVengence == true){
							enemy.enemyStatus.previousDam = (int)(5 * player.playerAbilities.stances.StanceOfSVDeffensiveIncrease);
							player.hP -= enemy.enemyStatus.previousDam ;
						}
						else{
							enemy.enemyStatus.previousDam = 5;
							player.hP -= enemy.enemyStatus.previousDam ;
						}
					}
					else{
						enemy.enemyStatus.previousAttack = 1;
			
						if(player.playerAbilities.stances.StanceOfBloodlust == true){
							enemy.enemyStatus.previousDam = (int)(10 * player.playerAbilities.stances.StanceOfBLDefensiveDecrease);
							player.hP -= enemy.enemyStatus.previousDam;
						}
						else if(player.playerAbilities.stances.StanceOfShadowsVengence == true){
							enemy.enemyStatus.previousDam = (int)(10 * player.playerAbilities.stances.StanceOfSVDeffensiveIncrease);
							player.hP -= enemy.enemyStatus.previousDam;
						}
						else{
							enemy.enemyStatus.previousDam = 10;
							player.hP -= enemy.enemyStatus.previousDam;
						}
					}
	}
	
}