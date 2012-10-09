using UnityEngine;
using System.Collections;

public class BattleGui : MonoBehaviour {
	
	public Player player;
	
	public Enemy enemy;
	
	public float gameTimer;
	
	public int screenCounter = 0;
	
	public int aAbility;
	
	
	//Keeps track of number of turns
	public int turns;
	
	//0 = Player chooses A Abilities
	//1 = Player chooses B Abilities
	//2 = Player chooses C Abilities
	//3 = Choose to execute or redo
	//4 = A abilities execute
	//5 = B abilities execute
	//6 = C abilities execute
	//7 = Enemey's Turn
	public int turnPhases;
	
	//Abilities Buttons
	public UIButton A1Button;
	public UIButton A2Button;
	public UIButton A3Button;
	public UIButton A4Button;
	public UIButton A5Button;
	public UIButton B1Button;
	public UIButton B2Button;
	public UIButton B3Button;
	public UIButton B4Button;
	public UIButton B5Button;
	public UIButton C1Button;
	public UIButton C2Button;
	public UIButton C3Button;
	public UIButton C4Button;
	public UIButton C5Button;
	
	//NGUI GUI
	public UILabel playerStatusBox;
	public UILabel battleInfoBox;
	
	public UIFilledSprite hPoTIcon;
	public UILabel hPoTTurnLabel;
	
	public UIFilledSprite aPoTIcon;
	public UILabel aPoTTurnLabel;
	
	public UILabel enemyStatusBox;
	
	public UILabel turnsLabel;
	
	public UIFilledSprite shieldIcon;
	public UILabel shieldLabel;
	
	//Enemy Icons
	public UIFilledSprite enemyHPoTIcon;
	public UILabel enemyHPoTIconLabel;
	
	public UIFilledSprite enemyDoTIcon;
	public UILabel enemyDoTIconLabel;
	
	public UIFilledSprite enemyCanCastIcon;
	public UILabel enemyCanCastLabel;
	
	//Shown Damage Icons
	public UILabel playerHpHealLabel;
	public UILabel playerHpDamageLabel;
	
	public UILabel playerApGenLabel;
	
	public UILabel turnTotalDamageLabel;
	
	public UILabel enemyHpDamageLabel;
	public UILabel enemyHpPlusLabel;
	
	
	// Update is called once per frame
	void Update () {
		
		if(turnTotalDamageLabel != null)
			turnTotalDamageLabel.text = "TurnDam: -" + player.turnDamage;
		
		if(enemyHpDamageLabel != null)
			enemyHpPlusLabel.OnUpdate();
		
		if(player.TurnPhases == 0){
			if(playerHpHealLabel != false)
				playerHpHealLabel.enabled = false;
			if(playerHpDamageLabel != false)
				playerHpDamageLabel.enabled = false;
			if(playerApGenLabel != false)
				playerApGenLabel.enabled = false;
			
			if(enemyHpDamageLabel != null)
				enemyHpDamageLabel.enabled = false;
			if(enemyHpPlusLabel != null)
				enemyHpPlusLabel.enabled = false;
		}
		
		#region Update Buttons
		if(A1Button != null)
			A1Button.UpdateColor(true,true);
		if(A2Button != null)
			A2Button.UpdateColor(true,true);
		if(A3Button != null)
			A3Button.UpdateColor(true,true);
		if(A4Button != null)
			A4Button.UpdateColor(true,true);
		if(A5Button != null)
			A5Button.UpdateColor(true,true);
		if(B1Button != null)
			B1Button.UpdateColor(true,true);
		if(B2Button != null)
			B2Button.UpdateColor(true,true);
		if(B3Button != null)
			B3Button.UpdateColor(true,true);
		if(B4Button != null)
			B4Button.UpdateColor(true,true);
		if(B5Button != null)
			B5Button.UpdateColor(true,true);
		if(C1Button != null)
			C1Button.UpdateColor(true,true);
		if(C2Button != null)
			C2Button.UpdateColor(true,true);
		if(C3Button != null)
			C3Button.UpdateColor(true,true);
		if(C4Button != null)
			C4Button.UpdateColor(true,true);
		if(C5Button != null)
			C5Button.UpdateColor(true,true);
		#endregion
		
		
		string headingText = "";
		string abilityText = "No ability chosen";
		
		#region BattleUI
		playerStatusBox.text = "Player\nHP : " + player.hP + "\nAP : " + player.aP;
		
		if(enemyStatusBox != null)
			enemyStatusBox.text = "Enemy\nHP : " + enemy.hP;
		
		#region Player OverTime Icons
		//Hp over TimeBuff
		if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0){
			if(hPoTIcon != null)
				hPoTIcon.fillAmount = 1;
			if(hPoTTurnLabel != null)
				hPoTTurnLabel.text = "" + (player.playerStatus.overTimeBuffs.hPBuffCounter);
		}
		else{
			if(hPoTIcon != null)
				hPoTIcon.fillAmount = 0;
			if(hPoTTurnLabel != null)
				hPoTTurnLabel.text = "";
		}
		
		//Ap over TimeBuff
		if(player.playerStatus.overTimeBuffs.aPBuffCounter > 0){
			if(aPoTIcon != null)
				aPoTIcon.fillAmount = 1;
			if(aPoTTurnLabel != null)
				aPoTTurnLabel.text = "" + (player.playerStatus.overTimeBuffs.aPBuffCounter);
		}
		else{
			if(aPoTIcon != null)
				aPoTIcon.fillAmount = 0;
			if(aPoTTurnLabel != null)
				aPoTTurnLabel.text = "";
		}
		
		//Shield Buff
		if(player.playerStatus.overTimeBuffs.shieldBuffCounter > 0){
			if(shieldIcon != null)
				shieldIcon.fillAmount = 1;
			if(shieldLabel != null)
				shieldLabel.text = "" + player.playerStatus.overTimeBuffs.shieldBuffCounter;
		}
		else{
			if(shieldIcon != null)
				shieldIcon.fillAmount = 0;
			if(shieldLabel != null)
				shieldLabel.text = "";
		}
		
		#endregion
		
		#region Enemy OverTime Icons
		//Hp over TimeBuff
		if(enemy.hPoTCounter > 0){
			if(enemyHPoTIcon != null)
				enemyHPoTIcon.fillAmount = 1;
			if(enemyHPoTIconLabel != null)
				enemyHPoTIconLabel.text = "" + enemy.hPoTCounter;
		}
		else{
			if(enemyHPoTIcon != null)
				enemyHPoTIcon.fillAmount = 0;
			if(enemyHPoTIconLabel != null)
				enemyHPoTIconLabel.text = "";
		}
		//
		
		//Dam over Time
		if(enemy.doTCounter > 0){
			if(enemyDoTIcon != null)
				enemyDoTIcon.fillAmount = 1;
			if(enemyDoTIconLabel != null)
				enemyDoTIconLabel.text = "" + enemy.doTCounter;
		}
		else{
			if(enemyDoTIcon != null)
				enemyDoTIcon.fillAmount = 0;
			if(enemyDoTIconLabel != null)
				enemyDoTIconLabel.text = "";
		}
		
		//CanCast Debuff
		if(enemy.canCastCounter > 0){
			if(enemyCanCastIcon != null)
				enemyCanCastIcon.fillAmount = 1;
			if(enemyCanCastLabel != null)
				enemyCanCastLabel.text = "" + enemy.canCastCounter;
		}
		else{
			if(enemyCanCastIcon != null)
				enemyCanCastIcon.fillAmount = 0;
			if(enemyCanCastLabel != null)
				enemyCanCastLabel.text = "";	
		}
		
		#endregion
		
		//Turns
		if(turnsLabel != null){
			if(player.TurnPhases < 8)
				turnsLabel.text = "Player's Turn";
			else
				turnsLabel.text = "Enemy's Turn";
				
		}
		
		#endregion
		
		
		//Player chooses Abilities
		if(player.TurnPhases == 0){
			
			//BattleInfo
			#region GunAbilities
			if(player.lastAbilityChosen == 1){
				
				abilityText = "Gun Ability ~ Scarlet Shot\n" +
					"DMG: " + player.playerAbilities.gunAbilities.ScarletShot.rangeMin + " - " +
						player.playerAbilities.gunAbilities.ScarletShot.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.ScarletShot.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.ScarletShot.multiplier);
			
				/*if(player.playerAbilities.abilitiesA.a1level == 1)
					abilityText = "Ability A1 Lvl l: Generates 20 AP.\nHeals you for 3% each turn for the next 2 turns";
			
				else if(player.playerAbilities.abilitiesA.a1level == 2)
					abilityText = "Ability A1 Lvl 2: Generates 20 AP.\nHeals you for 5% each turn for the next 2 turns";
			
				else if(player.playerAbilities.abilitiesA.a1level == 3)
					abilityText = "Ability A1 Lvl 3: Generates 30 AP.\nHeals you for 5% each turn for the next 3 turns";*/

	

			}
			else if(player.lastAbilityChosen == 2){
				
				abilityText = "Gun Ability ~ Dark Bullet\n" +
					"DMG: " + player.playerAbilities.gunAbilities.DarkBullet.rangeMin + " - " +
						player.playerAbilities.gunAbilities.DarkBullet.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.DarkBullet.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.DarkBullet.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a2level == 1)
					abilityText = "Ability A2 LvL 1: AP Swipes, 15%-20AP, 15%-25AP,\n35%-30AP,35%-35AP";
				else if(player.playerAbilities.abilitiesA.a2level == 2)
					abilityText = "Ability A2 LvL 2: AP Swipes, 10%-20AP, 10%-25AP,\n40%-30AP,40%-35AP";
				else if(player.playerAbilities.abilitiesA.a2level == 3)
					abilityText = "Ability A2 LvL 3: AP Swipes, 5%-20AP, 5%-25AP,\n45%-30AP,45%-35AP";*/

			}
			else if(player.lastAbilityChosen == 3){
				
				abilityText = "Gun Ability ~ Plague Blast\n" +
					"DMG: " + player.playerAbilities.gunAbilities.PlagueBlast.rangeMin + " - " +
						player.playerAbilities.gunAbilities.PlagueBlast.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.PlagueBlast.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.PlagueBlast.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a3level == 1)
					abilityText = "Ability A3 LvL 1: Generates 15 AP.\nGenerates 10AP each turn for next 2 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 2)
					abilityText = "Ability A3 LvL 2: Generates 15 AP.\nGenerates 10AP each turn for next 3 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 3)
					abilityText = "Ability A3 LvL 3: Generates 15 AP.\nGenerates 15AP each turn for next 3 turns";*/
			
			}
			else if(player.lastAbilityChosen == 4){
				
				abilityText = "Gun Ability ~ Blitz Barrage\n" +
					"DMG: " + player.playerAbilities.gunAbilities.BlitzBarrage.rangeMin + " - " +
						player.playerAbilities.gunAbilities.BlitzBarrage.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.BlitzBarrage.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.BlitzBarrage.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a4level == 1)
					abilityText = "Ability A4 LvL 1: Generates 25 AP.\nGenerates 5AP each turn for next 2 turns";
				else if (player.playerAbilities.abilitiesA.a4level == 2)
					abilityText = "Ability A4 LvL 2: Generates 25 AP.\nGenerates 5AP each turn for next 3 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 3)
					abilityText = "Ability A4 LvL 3: Generates 25 AP.\nGenerates 10AP each turn for next 3 turns";*/

			}
			else if(player.lastAbilityChosen == 5){
				
				abilityText = "Gun Ability ~ Shadowflame Shot\n" +
					"DMG: " + player.playerAbilities.gunAbilities.ShadowflameShot.rangeMin + " - " +
						player.playerAbilities.gunAbilities.ShadowflameShot.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.ShadowflameShot.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.ShadowflameShot.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a5level == 1)
					abilityText = "Ability A5 LvL 1: Generates 20 AP + 3 AP\n each turn for rest of battle";
				else if (player.playerAbilities.abilitiesA.a5level == 2)
					abilityText = "Ability A5 LvL 2: Generates 20 AP + 5 AP\n each turn for rest of battle";
				else if (player.playerAbilities.abilitiesA.a5level == 3)
					abilityText = "Ability A5 LvL 3: Generates 30 AP + 5 AP\n each turn for rest of battle";*/

			}
			#endregion
		
			#region Sword Abilities
			else if(player.lastAbilityChosen == 6){
				
				abilityText = "Sword Ability ~ Blood Blade\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.BloodBlade.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.BloodBlade.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.BloodBlade.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b1level == 1){
					abilityText = "Ability B1 LvL1: Costs " + player.playerAbilities.abilitiesB.b1aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL1 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b1level == 2){
					abilityText = "Ability B1 LvL2: Costs " + player.playerAbilities.abilitiesB.b1aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL2 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b1level == 3){
					abilityText = "Ability B1 LvL2: Costs " + player.playerAbilities.abilitiesB.b1aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL3 * 100) +
							"%HP";
				}*/
			}
			else if(player.lastAbilityChosen == 7){
				
				abilityText = "Sword Ability ~ Death Strike\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.DeathStrike.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.DeathStrike.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.DeathStrike.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b2level == 1){
					abilityText = "Ability B2 LvL1: Costs " + player.playerAbilities.abilitiesB.b2aPCost +
						" AP\nDoes Mid-Dam (25hP) and DoT to ememy for " + player.playerAbilities.abilitiesB.b2doTTurnsLvL1 +
							" turns";
				}
				
				else if(player.playerAbilities.abilitiesB.b2level == 2){
					abilityText = "Ability B2 LvL2: Costs " + player.playerAbilities.abilitiesB.b2aPCost +
						" AP\nDoes High-Dam (50hP) and DoT to ememy for " + player.playerAbilities.abilitiesB.b2doTTurnsLvL2 +
							" turns";
				}
				
				else if(player.playerAbilities.abilitiesB.b2level == 2){
					abilityText = "Ability B2 LvL3: Costs " + player.playerAbilities.abilitiesB.b2aPCost +
						" AP\nDoes High-Dam (50hP) and DoT to ememy for  " + player.playerAbilities.abilitiesB.b2doTTurnsLvL3 +
							" turns";
				}*/
			}
			else if(player.lastAbilityChosen == 8){
				
				abilityText = "Sword Ability ~ Shadowflame Slash\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.ShadowFlameSlash.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.ShadowFlameSlash.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.ShadowFlameSlash.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b3level == 1){
					abilityText = "Ability B3 LvL1: Costs " + player.playerAbilities.abilitiesB.b3aPCost +
						" AP\nDoes High-Dam (50hP) and dispells enemy's buffs";
				}
				
				else if(player.playerAbilities.abilitiesB.b3level == 2){
					abilityText = "Ability B3 LvL2: Costs " + player.playerAbilities.abilitiesB.b3aPCost +
						" AP\nDoes Higher-Dam (75hP) and dispells enemy's buffs";
				}
				
				else if(player.playerAbilities.abilitiesB.b3level == 3){
					abilityText = "Ability B3 LvL3: Costs " + player.playerAbilities.abilitiesB.b3aPCost +
						" AP\nDoes Higher-Dam (75hP) and prevents enemy from casting buffs";
				}*/
			}
			else if(player.lastAbilityChosen == 9){
				
				abilityText = "Sword Ability ~ Crimson Cut\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.CrimsonCut.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.CrimsonCut.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.CrimsonCut.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b4level == 1){
					abilityText = "Ability B4 LvL1: Costs " + player.playerAbilities.abilitiesB.b4aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL1 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b4level == 2){
					abilityText = "Ability B4 LvL2: Costs " + player.playerAbilities.abilitiesB.b4aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL2 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b4level == 3){
					abilityText = "Ability B4 LvL3: Costs " + player.playerAbilities.abilitiesB.b4aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL3 * 100) +
							"%HP";
				}*/
			}
			else if(player.lastAbilityChosen == 10){
				
				abilityText = "Sword Ability ~ Shadowfury\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.ShadowFury.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.ShadowFury.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.ShadowFury.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b5level == 1){
					abilityText = "Ability B5 LvL1: Costs " + player.playerAbilities.abilitiesB.b5aPCost +
						" AP\nDoes Mega-Dam (100HP) and ups Crit Area";
				}
				
				else if(player.playerAbilities.abilitiesB.b5level == 2){
					abilityText = "Ability B5 LvL2: Costs " + player.playerAbilities.abilitiesB.b5aPCost +
						" AP\nDoes Mega-Dam (100HP) and is a guaranteed Crit";
				}
				
				else if(player.playerAbilities.abilitiesB.b5level == 3){
					abilityText = "Ability B5 LvL3: Costs " + player.playerAbilities.abilitiesB.b5aPCost +
						" AP\nDoes Mega-Dam (100HP) and casts Big DoT for 3 turns";
				}*/
			}
			#endregion
			
			#region Stances
			else if(player.lastAbilityChosen == 11){
				
				abilityText = "Stance ~ Shade of Bloodlust\n\n" +
					"Increases damage done by 25%\nAnd damage taken by 25% (Offensive)";
				
				/*if(player.playerAbilities.abilitiesC.c1level == 1){
					abilityText = "Ability C1 LvL1 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c1ApDiscount + " less AP\n" +
						"But " + (100 * player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1) + "% less effective" +
						" for " + player.playerAbilities.abilitiesC.c1DeBuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c1level == 2){
					abilityText = "Ability C1 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c1ApDiscount + " less AP\n" +
						"But " + (100 * player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL2) + "% less effective" +
						" for " + player.playerAbilities.abilitiesC.c1DeBuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c1level == 3){
					abilityText = "Ability C1 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c1ApDiscount + " less AP\n" +
						"But " + (100 * player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL3) + "% less effective" +
						" for " + player.playerAbilities.abilitiesC.c1DeBuffTurns + " turns";
				}*/
			}
			else if(player.lastAbilityChosen == 12){
				
				abilityText = "Stance ~ Shade of Murder\n\n\n" +
					"Health Gains increased by 25% (Health Regen)";
				
				/*if(player.playerAbilities.abilitiesC.c2level == 1){
					abilityText = "Ability C2 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c2ApTax + " more AP\n" +
						"But " + (100 * (player.playerAbilities.abilitiesC.c2AbilityBuffLvL1 - 1.0f)) + "% more effective" +
						" for " + player.playerAbilities.abilitiesC.c2BuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c2level == 2){
					abilityText = "Ability C2 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c2ApTax + " more AP\n" +
						"But " + (100 * (player.playerAbilities.abilitiesC.c2AbilityBuffLvL2 - 1.0f)) + "% more effective" +
						" for " + player.playerAbilities.abilitiesC.c2BuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c2level == 3){
					abilityText = "Ability C2 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c2ApTax + " more AP\n" +
						"But " + (100 * (player.playerAbilities.abilitiesC.c2AbilityBuffLvL3 - 1.0f)) + "% more effective" +
						" for " + player.playerAbilities.abilitiesC.c2BuffTurns + " turns";
				}*/
			}
			else if(player.lastAbilityChosen == 13){
				
				abilityText = "Stance ~ Shade of Ruthlessness\n\n" +
					"Reduces Damage done by 25%\nAnd Reduces damage taken by 25% (Defensive)";
				
				/*if(player.playerAbilities.abilitiesC.c3level == 1){
					abilityText = "Ability C3 LvL1 Costs: " + player.playerAbilities.abilitiesC.c3ApCost + "AP" +
						"\nA Abilities base generation in increased by " + player.playerAbilities.abilitiesC.c3ApGenBuffLvL1 +
						"AP\nFor the next " + player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL1 +  " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c3level == 2){
					abilityText = "Ability C3 LvL1 Costs: " + player.playerAbilities.abilitiesC.c3ApCost + "AP" +
						"\nA Abilities base generation in increased by " + player.playerAbilities.abilitiesC.c3ApGenBuffLvL2 +
						"AP\nFor the next " + player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL2 +  " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c3level == 3){
					abilityText = "Ability C3 LvL1 Costs: " + player.playerAbilities.abilitiesC.c3ApCost + "AP" +
						"\nA Abilities base generation in increased by " + player.playerAbilities.abilitiesC.c3ApGenBuffLvL3 +
						"AP\nFor the next " + player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL3 +  " turns";
				}*/
			}
			else if(player.lastAbilityChosen == 14){
				
				abilityText = "Stance ~ Shade of Death\n\n\n" +
					"Increases AP generation by 25% (AP Regen)";
				
				/*if(player.playerAbilities.abilitiesC.c4level == 1){
					abilityText = "Ability C4 LvL1 Costs: " + player.playerAbilities.abilitiesC.c4ApCost + "AP" +
						"\nCasts a shield on self that absorbs " + (100 * player.playerAbilities.abilitiesC.c4BubbleBuffLvL1) + "%" +
						" of total health\n" +
						"Fades away in 2 turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c4level == 2){
					abilityText = "Ability C4 LvL1 Costs: " + player.playerAbilities.abilitiesC.c4ApCost + "AP" +
						"\nCasts a shield on self that absorbs " + (100 * player.playerAbilities.abilitiesC.c4BubbleBuffLvL2) + "%" +
						" of total health\n" +
						"Fades away in 2 turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c4level == 3){
					abilityText = "Ability C4 LvL1 Costs: " + player.playerAbilities.abilitiesC.c4ApCost + "AP" +
						"\nCasts a shield on self that absorbs " + (100 * player.playerAbilities.abilitiesC.c4BubbleBuffLvL3) + "%" +
						" of total health\n" +
						"Fades away in 2 turns";
				}*/
			}
			else if(player.lastAbilityChosen == 15){
				
				abilityText = "Stance ~ Shade of Dark Protection\n\n\n" +
					"Reduces all DoT damage by 50%";
				
				/*if(player.playerAbilities.abilitiesC.c5level == 1){
					abilityText = "Ability C5 LvL1 Costs: " + player.playerAbilities.abilitiesC.c5ApCost + "AP" +
						"\nB abilities cost 10 less AP for next " + player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL1 + " turns\n" +
						"A abilities generate 10AP more for " + player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl1 + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c5level == 2){
					abilityText = "Ability C5 LvL1 Costs: " + player.playerAbilities.abilitiesC.c5ApCost + "AP" +
						"\nB abilities cost 10 less AP for next " + player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL2 + " turns\n" +
						"A abilities generate 10AP more for " + player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl2 + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c5level == 3){
					abilityText = "Ability C5 LvL1 Costs: " + player.playerAbilities.abilitiesC.c5ApCost + "AP" +
						"\nB abilities cost 10 less AP for next " + player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL3 + " turns\n" +
						"A abilities generate 10AP more for " + player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl3 + " turns";
				}*/
			}
			#endregion
			
			headingText = "Battle Update: Time to choose abilities\n" + abilityText;
		}
		
		
		
		//Execute Sword Abilities
		else if(player.TurnPhases == 4){
			
			string tempPlayerApCostLabel = "";
			
			string tempEnemyDamLabel = "";
			
			if(player.swordAbilityChosen == -1)
				headingText = "Battle Update: No Sword Ability Chosen";
				
			//DamageShown
			else{
				if(player.swordAbilityChosen == 1)
					headingText = "Battle Update: Executing Blood Blade";
				else if(player.swordAbilityChosen == 2)
					headingText = "Battle Update: Executing Death Strike";
				else if(player.swordAbilityChosen == 3)
					headingText = "Battle Update: Executing Shadowflame Slash";
				else if(player.swordAbilityChosen == 4)
					headingText = "Battle Update: Executing Crimson Cut";
				else if(player.swordAbilityChosen == 5)
					headingText = "Battle Update: Executing Shadowfury";
					
			
				if(player.swordAbilityChosen == 1){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.BloodBlade.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b1level == 1)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL1) + "HP";
					else if(player.playerAbilities.abilitiesB.b1level == 2)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL2) + "HP";
					else if(player.playerAbilities.abilitiesB.b1level == 3)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL3) + "HP";*/
				}
				else if(player.swordAbilityChosen == 2){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.DeathStrike.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b2level == 1)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b2DamageLvL1 + "HP";
					else if(player.playerAbilities.abilitiesB.b2level == 2)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b2DamageLvL2 + "HP";
					else if(player.playerAbilities.abilitiesB.b2level == 3)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b2DamageLvL3 + "HP";*/
					
				}
				else if(player.swordAbilityChosen == 3){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.ShadowFlameSlash.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b3level == 1)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b3DamageLvL1 + "HP";
					else if(player.playerAbilities.abilitiesB.b3level == 2)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b3DamageLvL2 + "HP";
					else if(player.playerAbilities.abilitiesB.b3level == 3)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b3DamageLvL3 + "HP";*/
				}
				else if(player.swordAbilityChosen == 4){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.CrimsonCut.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b4level == 1)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL1) + "HP";
					else if(player.playerAbilities.abilitiesB.b4level == 2)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL2) + "HP";
					else if(player.playerAbilities.abilitiesB.b4level == 3)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL3) + "HP";*/
					
					
				}
				else if(player.swordAbilityChosen == 5){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.ShadowFury.damage + "HP";
				}
				
				
				if(playerApGenLabel != null){
					playerApGenLabel.text = tempPlayerApCostLabel;
					playerApGenLabel.enabled = true;	
				}
				
				if(enemyHpDamageLabel != null){
					enemyHpDamageLabel.text = tempEnemyDamLabel;
					enemyHpDamageLabel.enabled = true;
				}
				
			}
		}
		
		//Execute Gun Abilities
		else if(player.TurnPhases == 5){
			//Reset ShownIcons
			//if(enemyHpDamageLabel != null)
				//enemyHpDamageLabel.enabled = false;
			//if(playerApGenLabel != null)
				//playerApGenLabel.enabled = false;
			
			
			string tempEnemyDamLabel = "";
			
			string tempPlayerApBoost = "";
			
			
			if(player.gunAbilityChosen == -1)
				headingText = "Battle Update: No Gun Ability Chosen";
			
			else{
				if(player.gunAbilityChosen == 1)
					headingText = "Battle Update: Executing Scarlet Shot";
				else if(player.gunAbilityChosen == 2)
					headingText = "Battle Update: Executing Dark Bullet";
				else if(player.gunAbilityChosen == 3)
					headingText = "Battle Update: Executing Plague Blast";
				else if(player.gunAbilityChosen == 4)
					headingText = "Battle Update: Executing Blitz Barrage";
				else if(player.gunAbilityChosen == 5)
					headingText = "Battle Update: Executing Shadowflame Shot";
				
				if(player.gunAbilityChosen == 1){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.ScarletShot.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.ScarletShot.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.ScarletShot.cost) + "AP";
				}

				else if(player.gunAbilityChosen == 2){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.DarkBullet.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.DarkBullet.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.DarkBullet.cost) + "AP";
				}
				else if(player.gunAbilityChosen == 3){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.PlagueBlast.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.PlagueBlast.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.PlagueBlast.cost) + "AP";
				}
				else if(player.gunAbilityChosen== 4){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.BlitzBarrage.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.BlitzBarrage.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.BlitzBarrage.cost) + "AP";
				}
				else if(player.gunAbilityChosen == 5){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.ShadowflameShot.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.ShadowflameShot.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.ShadowflameShot.cost) + "AP";
					
					/*if(player.playerAbilities.abilitiesC.c5level == 1)
						tempPlayerApBoost = "+" + player.playerAbilities.abilitiesA.a5ApBoostLvl1 + "AP";
					else if(player.playerAbilities.abilitiesC.c5level == 2)
						tempPlayerApBoost = "+" + player.playerAbilities.abilitiesA.a5ApBoostLvl1 + "AP";	
					else if(player.playerAbilities.abilitiesC.c5level == 3)
						tempPlayerApBoost = "+" + player.playerAbilities.abilitiesA.a5ApBoostLvl1 + "AP";*/
				}
				
				if(enemyHpDamageLabel != null){
					enemyHpDamageLabel.text = tempEnemyDamLabel;
					enemyHpDamageLabel.enabled = true;
				}
				
				if(playerApGenLabel != null){
					playerApGenLabel.text = tempPlayerApBoost;
					playerApGenLabel.enabled = true;
				}
				
				
			}
			
		}
		
		//Execute StanceChange
		else if(player.TurnPhases == 6){
			//Reset ShownIcons
			if(playerHpHealLabel != null)
				playerHpHealLabel.enabled = false;
			if(playerApGenLabel != null)
				playerApGenLabel.enabled = false;
			if(enemyHpDamageLabel != null)
				enemyHpDamageLabel.enabled = false;
			
			
			if(player.stanceChosen == -1)
				headingText = "Battle Update: Stance Chosen";
			else{
				if(player.stanceChosen == 1)
					headingText = "Battle Update: Changing Stance to Shade of Bloodlust";
				else if(player.stanceChosen == 2)
					headingText = "Battle Update: Changing Stance to Shade of Murder";
				else if(player.stanceChosen == 3)
					headingText = "Battle Update: Changing Stance to Shade of Ruthlessness";
				else if(player.stanceChosen == 4)
					headingText = "Battle Update: Changing Stance to Shade of Death";
				else if(player.stanceChosen == 5)
					headingText = "Battle Update: Changing Stance to Shade of Dark Protection";
				
			}
		}
		
		//Apply OverTime Effects
		else if(player.TurnPhases == 7){
			//Reset ShownIcons
			//if(playerHpHealLabel != null)
				//playerHpHealLabel.enabled = false;
			//if(playerApGenLabel != null)
				//playerApGenLabel.enabled = false;
			//if(enemyHpDamageLabel != null)
				//enemyHpDamageLabel.enabled = false;
			
			string tempPlayerHpBoost = "";
			string tempPlayerApBoost = "";
			
			string tempEnemyDamLabel = "";
			
			
			if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0)
				tempPlayerHpBoost = "+" + (int)(player.hP * player.playerStatus.overTimeBuffs.hPoT) + "HP";
			if(player.playerStatus.overTimeBuffs.aPBuffCounter > 0)
				tempPlayerApBoost = "+" + player.playerStatus.overTimeBuffs.aPoT + "AP";
			
			if(enemy.doTCounter > 0)
				tempEnemyDamLabel = "-" + (int)(enemy.hP * enemy.doT) + "HP";
			
			
			headingText = "Battle Update: Applying OvertimeEffects";
			
			
			//Show effects
			if(playerHpHealLabel != null){
				playerHpHealLabel.text = tempPlayerHpBoost;
				playerHpHealLabel.enabled = true;
			}
			if(playerApGenLabel != null){
				playerApGenLabel.text = tempPlayerApBoost;
				playerApGenLabel.enabled = true;
			}
			if(enemyHpDamageLabel !=null){
				enemyHpDamageLabel.text = tempEnemyDamLabel;
				enemyHpDamageLabel.enabled = true;
			}
			
		}
		
		//Enemy's turn
		else if(player.TurnPhases == 8){
			//Reset ShownIcons
			if(playerHpHealLabel != null)
				playerHpHealLabel.enabled = false;
			if(playerApGenLabel != null)
				playerApGenLabel.enabled = false;
			if(enemyHpDamageLabel != null)
				enemyHpDamageLabel.enabled = false;
			
			
			
			if(battleInfoBox != null)
				headingText = "Battle Update: Enemy's Turn\n" +
					"Enemy Attacking Player";
			
			
			
			if(enemy.previousAttack == 0){
				if(playerHpDamageLabel != null)
					playerHpDamageLabel.text = "-25HP";	
			}
			
			else if(enemy.previousAttack == 1){
				if(playerHpDamageLabel != null)
					playerHpDamageLabel.text = "-50HP";	
			}
			
			if(playerHpDamageLabel != null)
				playerHpDamageLabel.enabled = true;
			
		}
		
		if(battleInfoBox != null)
			battleInfoBox.text = headingText;
		
	}
}
