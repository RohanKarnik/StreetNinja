using UnityEngine;
using System.Collections;

public class BattleGui : MonoBehaviour {
	
	public Player player;
	
	public Enemy enemy;
	
	public float gameTimer;
	
	public int screenCounter = 0;
	
	public UILabel screenLabel;
	
	
	//Keeps track of number of turns
	public int turns;
	
	//0 = Player chooses Gun Abilities
	//1 = Player chooses Sword Abilities
	//2 = Player chooses Stance Abilities
	//3 = Choose to execute or redo
	//4 = A abilities execute
	//5 = B abilities execute
	//6 = C abilities execute
	//7 = Enemey's Turn
	public int turnPhases;
	
	//Abilities Buttons
	[System.Serializable]
	public class AbilitiesButtons{
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
	}
	
	public AbilitiesButtons abilitiesButtons;
	
	//NGUI GUI
	[System.Serializable]
	
	//BattleInfo
	public class BattleInfo{

		public UIPanel gunAbilitiesPanel;
		public UIPanel swordAbilitiesPanel;
		public UIPanel stanceAbilitiesPanel;
		
		public UIPanel battleInfoGunIconPanel;
		public UIPanel battleInfoSwordIconPanel;
		public UIPanel battleInfoStanceIconPanel;
		
		public UIPanel playerBuffsPanel;
		public UIPanel playerDeBuffsPanel;
		public UIPanel enemyBuffsPanel;
		public UIPanel enemyDeBuffsPanel;
		
		//BattleInfo
		public UIPanel battleInfoPanel;
		
		public UIFilledSprite battleInfoAbility1Box;
		public UIFilledSprite battleInfoAbility2Box;
		public UIFilledSprite battleInfoAbility3Box;
		public UIFilledSprite battleInfoAbility4Box;
		public UIFilledSprite battleInfoAbility5Box;
		
		public UILabel battleInfoLabel;
	
		public UIFilledSprite battleInfoGunAbility1;
		public UIFilledSprite battleInfoGunAbility2;
		public UIFilledSprite battleInfoGunAbility3;
		public UIFilledSprite battleInfoGunAbility4;
		public UIFilledSprite battleInfoGunAbility5;
		public UIFilledSprite battleInfoSwordAbility1;
		public UIFilledSprite battleInfoSwordAbility2;
		public UIFilledSprite battleInfoSwordAbility3;
		public UIFilledSprite battleInfoSwordAbility4;
		public UIFilledSprite battleInfoSwordAbility5;
		public UIFilledSprite battleInfoStanceAbility1;
		public UIFilledSprite battleInfoStanceAbility2;
		public UIFilledSprite battleInfoStanceAbility3;
		public UIFilledSprite battleInfoStanceAbility4;
		public UIFilledSprite battleInfoStanceAbility5;
	
		public UILabel turnsLabel;
	
		//Shown Damage Icons
		public UILabel playerHpHealLabel;
		public UILabel playerHpDamageLabel;
	
		public UILabel playerApGenLabel;
	
		public UILabel turnTotalDamageLabel;
	
		public UILabel enemyHpDamageLabel;
		public UILabel enemyHpPlusLabel;
	}
	
	public BattleInfo battleInfo;
	
	//TOP
	[System.Serializable]
	public class TOP{
	
		public UISlider playerHealthSlider;
		public UILabel playerHpPercent;
		
		public UISlider playerAPSlider;
		public UILabel playerAP;
		
		public UILabel playerLevel;
		
		
		public UISlider enemyHealthSlider;
		public UILabel enemyHpPercent;
		
		public UILabel enemyLevel;
		
	}
	
	public TOP GuiTop;
	
	//PlayerOverTime Icons
	[System.Serializable]
	public class PlayerOverTimeIcons{
		//Buffs
		public UIFilledSprite hPoTIcon;
		public UILabel hPoTTurnLabel;
	
		public UIFilledSprite aPoTIcon;
		public UILabel aPoTTurnLabel;
	
		public UIFilledSprite strDefUpIcon;
		public UILabel strDefUpLabel;
		
		public UIFilledSprite shieldIcon;
		public UILabel shieldLabel;
		
		
		//Debuffs
		public UIFilledSprite doTIcon;
		public UILabel doTLabel;
		
		public UIFilledSprite aPCostUpIcon;
		public UILabel aPCostUpLabel;
		
		public UIFilledSprite aPGenDownIcon;
		public UILabel apGenDownLabel;
		
		public UIFilledSprite strDefDownIcon;
		public UILabel strDefDownLabel;
		
	}
	
	public PlayerOverTimeIcons playerOverTimeIcons;
	
	//EnemyOverTime Icons
	[System.Serializable]
	public class EnemyOverTimeIcons{
		//Buffs
		public UIFilledSprite enemyHPoTIcon;
		public UILabel enemyHPoTIconLabel;
		
		public UIFilledSprite strDefUpIcon;
		public UILabel strDefUpLabel;
		
		public UIFilledSprite shieldIcon;
		public UILabel shieldLabel;
		
		public UIFilledSprite enemySpecificIcon;
		public UILabel enemySpecificLabel;
	
		//Debuff
		public UIFilledSprite enemyDoTIcon;
		public UILabel enemyDoTIconLabel;
	
		public UIFilledSprite strDefDownIcon;
		public UILabel strDefDownLabel;
		
		public UIFilledSprite playerDebuff1Icon;
		public UILabel playerDebuff1Label;
		
		public UIFilledSprite playerDebuff2Icon;
		public UILabel playerDebuff2Label;
	}
	
	public EnemyOverTimeIcons enemyOverTimeIcons;
	
	
	//Botom
	[System.Serializable]
	public class BOTTOM{
		
		public UISlider playerXpSlider;
		
		public UIButton gunAbilityButton;

		
		public UIButton swordAbilityButton;
		
		public UIButton stanceAbilityButton;

		
		public UILabel playerBuffDeBuffDescription;
		
		public UIButton playerBuffSwitch1;
		public UIButton playerBuffSwitch2;
		public UIButton playerBuffSwitch3;
		public UIButton playerBuffSwitch4;
		public UIButton playerDeBuffSwitch1;
		public UIButton playerDeBuffSwitch2;
		public UIButton playerDeBuffSwitch3;
		public UIButton playerDeBuffSwitch4;
		
		public UILabel enemyBuffDeBuffDescription;
		
		public UIButton enemyBuffSwitch1;
		public UIButton enemyBuffSwitch2;
		public UIButton enemyBuffSwitch3;
		public UIButton enemyBuffSwitch4;
		public UIButton enemyDeBuffSwitch1;
		public UIButton enemyDeBuffSwitch2;
		public UIButton enemyDeBuffSwitch3;
		public UIButton enemyDeBuffSwitch4;
		
		//TODO: ADD Battle Info variable into Bottom class for Inspector's sake
		
	}
	
	public BOTTOM GuiBottom;
	
	// Update is called once per frame
	void Update () {
		
		switch(player.playerBattleStatus){
		
		case Player.BattleStatus.NotFighting:
			if(screenLabel != null)
				screenLabel.text = "Next fight About to Commence";
			
			#region Hide Everything
			
			//Shown Damage
			if(battleInfo.playerApGenLabel != null)
				battleInfo.playerApGenLabel.text =  "";
			if(battleInfo.playerHpDamageLabel != null)
				battleInfo.playerHpDamageLabel.text = "";
			if(battleInfo.playerHpHealLabel != null)
				battleInfo.playerHpHealLabel.text = "";
			if(battleInfo.enemyHpPlusLabel != null)
				battleInfo.enemyHpPlusLabel.text = "";
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.text = "";
			
			//Description Box
			if(battleInfo.battleInfoPanel != null){
				battleInfo.battleInfoPanel.enabled = false;	
			}
			if(battleInfo.gunAbilitiesPanel != null){
				battleInfo.gunAbilitiesPanel.enabled = false;	
			}
			if(battleInfo.swordAbilitiesPanel != null)
				battleInfo.swordAbilitiesPanel.enabled = false;
			if(battleInfo.stanceAbilitiesPanel != null)
				battleInfo.stanceAbilitiesPanel.enabled = false;
			
			if(battleInfo.battleInfoGunIconPanel != null)
				battleInfo.battleInfoGunIconPanel.enabled = false;
			if(battleInfo.battleInfoSwordIconPanel != null)
				battleInfo.battleInfoSwordIconPanel.enabled = false;
			if(battleInfo.battleInfoStanceIconPanel != null)
				battleInfo.battleInfoStanceIconPanel.enabled = false;
			
			//OverTime Stuff
			if(battleInfo.playerBuffsPanel != null)
				battleInfo.playerBuffsPanel.enabled = false;
			if(battleInfo.playerDeBuffsPanel != null)
				battleInfo.playerDeBuffsPanel.enabled = false;
			if(battleInfo.enemyBuffsPanel != null)
				battleInfo.enemyBuffsPanel.enabled = false;
			if(battleInfo.enemyDeBuffsPanel != null)
				battleInfo.enemyDeBuffsPanel.enabled = false;
			
			if(GuiBottom.playerBuffDeBuffDescription != null)
				GuiBottom.playerBuffDeBuffDescription.text = "";
			if(GuiBottom.enemyBuffDeBuffDescription != null)
				GuiBottom.enemyBuffDeBuffDescription.text = "";
			
			if(battleInfo.turnTotalDamageLabel != null)
				battleInfo.turnTotalDamageLabel.text = "";
			
			#endregion
			break;
			
		case Player.BattleStatus.Fighting:
			if(screenLabel != null)
				screenLabel.text = "";
			
			#region UnHide Panels
			//Description Box
			if(battleInfo.battleInfoPanel != null){
				battleInfo.battleInfoPanel.enabled = true;	
			}
			if(battleInfo.gunAbilitiesPanel != null){
				battleInfo.gunAbilitiesPanel.enabled = true;	
			}
			if(battleInfo.swordAbilitiesPanel != null)
				battleInfo.swordAbilitiesPanel.enabled = true;
			if(battleInfo.stanceAbilitiesPanel != null)
				battleInfo.stanceAbilitiesPanel.enabled = true;
			
			if(battleInfo.battleInfoGunIconPanel != null)
				battleInfo.battleInfoGunIconPanel.enabled = true;
			if(battleInfo.battleInfoSwordIconPanel != null)
				battleInfo.battleInfoSwordIconPanel.enabled = true;
			if(battleInfo.battleInfoStanceIconPanel != null)
				battleInfo.battleInfoStanceIconPanel.enabled = true;
			
			//OverTime Stuff
			if(battleInfo.playerBuffsPanel != null)
				battleInfo.playerBuffsPanel.enabled = true;
			if(battleInfo.playerDeBuffsPanel != null)
				battleInfo.playerDeBuffsPanel.enabled = true;
			if(battleInfo.enemyBuffsPanel != null)
				battleInfo.enemyBuffsPanel.enabled = true;
			if(battleInfo.enemyDeBuffsPanel != null)
				battleInfo.enemyDeBuffsPanel.enabled = true;
			#endregion
			
			
			#region Fighting
		
		//Lock Player's hp and Ap
		if(player.hP <= 0)
			player.hP = 0;
		else if(player.hP > player.hPMax){
			player.hP = player.hPMax;	
		}
		if(player.aP > 100)
			player.aP = 100;
		else if(player.aP <= 0){
			player.aP = 0;	
		}
		
		//TOP
		#region Player
		//PlayerHP
		if(GuiTop.playerHealthSlider != null)
			GuiTop.playerHealthSlider.sliderValue = (1 * (player.hP/player.hPMax));
		if(GuiTop.playerHpPercent != null)
			GuiTop.playerHpPercent.text = "" + (int)(100 * (player.hP/player.hPMax)) + "%";
		
		
		//PlayerAP
		if(GuiTop.playerAPSlider != null){
			GuiTop.playerAPSlider.foreground.localScale = new Vector3( ((100 - player.aP)/100) *
				350,
				GuiTop.playerAPSlider.foreground.localScale.y,
				GuiTop.playerAPSlider.foreground.localScale.z);
		}
		if(GuiTop.playerAP != null)
			GuiTop.playerAP.text = "" + player.aP;
		
		//PlayerLevel
		if(GuiTop.playerLevel != null)
			GuiTop.playerLevel.text = "Level ~ " + (player.level + 1);
		#endregion
		
		#region Enemy
		//EnemyHP
		if(GuiTop.enemyHealthSlider != null)
			GuiTop.enemyHealthSlider.sliderValue = (1 * (enemy.hP/enemy.hpMax));
			/*GuiTop.enemyHealthSlider.foreground.localScale = new Vector3((enemy.hP / enemy.hpMax) *
				423,
				GuiTop.enemyHealthSlider.foreground.localScale.y,
				GuiTop.enemyHealthSlider.foreground.localScale.z);*/
		if(GuiTop.enemyHpPercent != null)
			GuiTop.enemyHpPercent.text = "" + (int)(100 * (enemy.hP/enemy.hpMax)) + "%";
		
		//Enemy Level
		if(GuiTop.enemyLevel != null)
			GuiTop.enemyLevel.text = "Level ~ " + enemy.level;
		
		#endregion
		
		
		//MIDDLE
		#region Middle
		//Turn Damage
		if(battleInfo.turnTotalDamageLabel != null){
			if(player.TurnPhases >= 1 && player.TurnPhases < 8)
				battleInfo.turnTotalDamageLabel.text = "TurnDam: -" + player.turnDamage;
			else
				battleInfo.turnTotalDamageLabel.text = "";
		}

		
		//ShownDamage
		if(battleInfo.enemyHpDamageLabel != null)
			battleInfo.enemyHpPlusLabel.OnUpdate();
		
		if(player.TurnPhases == 0){
			if(battleInfo.playerHpHealLabel != false)
				battleInfo.playerHpHealLabel.enabled = false;
			if(battleInfo.playerHpDamageLabel != false)
				battleInfo.playerHpDamageLabel.enabled = false;
			if(battleInfo.playerApGenLabel != false)
				battleInfo.playerApGenLabel.enabled = false;
			
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.enabled = false;
			if(battleInfo.enemyHpPlusLabel != null)
				battleInfo.enemyHpPlusLabel.enabled = false;
		}
		#endregion
		
		#region Update Ability Buttons
		if(abilitiesButtons.A1Button != null)
			abilitiesButtons.A1Button.UpdateColor(true,true);
		if(abilitiesButtons.A2Button != null)
			abilitiesButtons.A2Button.UpdateColor(true,true);
		if(abilitiesButtons.A3Button != null)
			abilitiesButtons.A3Button.UpdateColor(true,true);
		if(abilitiesButtons.A4Button != null)
			abilitiesButtons.A4Button.UpdateColor(true,true);
		if(abilitiesButtons.A5Button != null)
			abilitiesButtons.A5Button.UpdateColor(true,true);
		if(abilitiesButtons.B1Button != null)
			abilitiesButtons.B1Button.UpdateColor(true,true);
		if(abilitiesButtons.B2Button != null)
			abilitiesButtons.B2Button.UpdateColor(true,true);
		if(abilitiesButtons.B3Button != null)
			abilitiesButtons.B3Button.UpdateColor(true,true);
		if(abilitiesButtons.B4Button != null)
			abilitiesButtons.B4Button.UpdateColor(true,true);
		if(abilitiesButtons.B5Button != null)
			abilitiesButtons.B5Button.UpdateColor(true,true);
		if(abilitiesButtons.C1Button != null)
			abilitiesButtons.C1Button.UpdateColor(true,true);
		if(abilitiesButtons.C2Button != null)
			abilitiesButtons.C2Button.UpdateColor(true,true);
		if(abilitiesButtons.C3Button != null)
			abilitiesButtons.C3Button.UpdateColor(true,true);
		if(abilitiesButtons.C4Button != null)
			abilitiesButtons.C4Button.UpdateColor(true,true);
		if(abilitiesButtons.C5Button != null)
			abilitiesButtons.C5Button.UpdateColor(true,true);
		#endregion
		
		//BOTTOM
		#region BOTTOM
		string headingText = "";
		string abilityText = "No ability chosen";
		
		//OverTimeIvons
		#region OverTimeIcons
		
		#region Player OverTime Icons
		
		//Update RestedOverIcons
		#region Update RestedOverIcons
		//UpdateButtonColor
		if(GuiBottom.playerBuffSwitch1 != null)
			GuiBottom.playerBuffSwitch1.UpdateColor(true, true);
		if(GuiBottom.playerBuffSwitch2 != null)
			GuiBottom.playerBuffSwitch2.UpdateColor(true, true);
		if(GuiBottom.playerBuffSwitch3 != null)
			GuiBottom.playerBuffSwitch3.UpdateColor(true, true);
		if(GuiBottom.playerBuffSwitch4 != null)
			GuiBottom.playerBuffSwitch4.UpdateColor(true, true);
		if(GuiBottom.playerDeBuffSwitch1 != null)
			GuiBottom.playerDeBuffSwitch1.UpdateColor(true,true);
		if(GuiBottom.playerDeBuffSwitch2 != null)
			GuiBottom.playerDeBuffSwitch2.UpdateColor(true,true);
		if(GuiBottom.playerDeBuffSwitch3 != null)
			GuiBottom.playerDeBuffSwitch3.UpdateColor(true,true);
		if(GuiBottom.playerDeBuffSwitch4 != null)
			GuiBottom.playerDeBuffSwitch4.UpdateColor(true,true);
		
		
		//UpdateDescriptBox
		if(player.lastBuffDebuffClicked == 0){
			GuiBottom.playerBuffDeBuffDescription.text = "Hp Up\n" +
				"Hp Up by " + player.playerStatus.overTimeBuffs.hPoT + "% for "
					+ player.playerStatus.overTimeBuffs.hPBuffCounter + " turns";
		}
		else if(player.lastBuffDebuffClicked == 1){
			GuiBottom.playerBuffDeBuffDescription.text = "Ap GenUp\n" +
				"Ap Gen by " + player.playerStatus.overTimeBuffs.aPoT + "% For "
					+ player.playerStatus.overTimeBuffs.aPBuffCounter + " turns";
		}
		else if(player.lastBuffDebuffClicked == 2){
			GuiBottom.playerBuffDeBuffDescription.text = "Str/Def Up\n" +
				"Str/Def Up by " + player.playerStatus.overTimeBuffs.StrDefUpBuffCounter + "% for "
					+ player.playerStatus.overTimeBuffs.StrDefUpBuffCounter+ " turns";
		}
		else if(player.lastBuffDebuffClicked == 3){
			GuiBottom.playerBuffDeBuffDescription.text = "Shield Buff\n" +
				"Player is Shieled for "
					+ player.playerStatus.overTimeBuffs.shieldBuffCounter + " turns";
		}
		else if(player.lastBuffDebuffClicked == 4){
			GuiBottom.playerBuffDeBuffDescription.text = "Damage Over Time\n" +
				"Player takes " + player.playerStatus.overTimeDeBuffs.doTDamage + "dam for "
					+ player.playerStatus.overTimeDeBuffs.doTCounter + " turns";
		}
		else if(player.lastBuffDebuffClicked == 5){
			GuiBottom.playerBuffDeBuffDescription.text = "Ap Gen Down\n" +
				"Ap Gen Decreased by " + (player.playerStatus.overTimeDeBuffs.aPGenDegrade) + " for "
					+ player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter + " turns";
		}
		else if(player.lastBuffDebuffClicked == 6){
			GuiBottom.playerBuffDeBuffDescription.text = "Ap Cost Up\n" +
				"Ap Cost Increase by " + player.playerStatus.overTimeDeBuffs.aPTax+ " for "
					+ player.playerStatus.overTimeDeBuffs.aPTaxCounter + " turns";
		}
		else if(player.lastBuffDebuffClicked == 7){
			GuiBottom.playerBuffDeBuffDescription.text = "Str/Def Down\n" +
				"Str/Def Down by " + player.playerStatus.overTimeDeBuffs.StrDefDownDeBuff + "% for "
					+ player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter + " turns";
		}
		
		else
			GuiBottom.playerBuffDeBuffDescription.text = "";
		#endregion
		
		
		#region Buffs
		//Hp over TimeBuff
		if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0){
			if(playerOverTimeIcons.hPoTIcon != null)
				playerOverTimeIcons.hPoTIcon.fillAmount = 1;
			if(playerOverTimeIcons.hPoTTurnLabel != null)
				playerOverTimeIcons.hPoTTurnLabel.text = "" + (player.playerStatus.overTimeBuffs.hPBuffCounter);
		}
		else{
			if(playerOverTimeIcons.hPoTIcon != null)
				playerOverTimeIcons.hPoTIcon.fillAmount = 0;
			if(playerOverTimeIcons.hPoTTurnLabel != null)
				playerOverTimeIcons.hPoTTurnLabel.text = "";
		}
		
		//Ap over TimeBuff
		if(player.playerStatus.overTimeBuffs.aPBuffCounter > 0){
			if(playerOverTimeIcons.aPoTIcon != null)
				playerOverTimeIcons.aPoTIcon.fillAmount = 1;
			if(playerOverTimeIcons.aPoTTurnLabel != null)
				playerOverTimeIcons.aPoTTurnLabel.text = "" + (player.playerStatus.overTimeBuffs.aPBuffCounter);
		}
		else{
			if(playerOverTimeIcons.aPoTIcon != null)
				playerOverTimeIcons.aPoTIcon.fillAmount = 0;
			if(playerOverTimeIcons.aPoTTurnLabel != null)
				playerOverTimeIcons.aPoTTurnLabel.text = "";
		}
		
		//StrDef Buff
		if(player.playerStatus.overTimeBuffs.StrDefUpBuffCounter > 0){
			if(playerOverTimeIcons.strDefUpIcon != null)
				playerOverTimeIcons.strDefUpIcon.fillAmount = 1;
			if(playerOverTimeIcons.strDefUpLabel != null)
				playerOverTimeIcons.strDefUpLabel.text = "" + (player.playerStatus.overTimeBuffs.StrDefUpBuffCounter);
			
		}
		else{
			if(playerOverTimeIcons.strDefUpIcon != null)
				playerOverTimeIcons.strDefUpIcon.fillAmount = 0;
			if(playerOverTimeIcons.strDefUpLabel != null)
				playerOverTimeIcons.strDefUpLabel.text = "";
		}
		
		//Shield Buff
		if(player.playerStatus.overTimeBuffs.shieldBuffCounter > 0){
			if(playerOverTimeIcons.shieldIcon != null)
				playerOverTimeIcons.shieldIcon.fillAmount = 1;
			if(playerOverTimeIcons.shieldLabel != null)
				playerOverTimeIcons.shieldLabel.text = "" + player.playerStatus.overTimeBuffs.shieldBuffCounter;
		}
		else{
			if(playerOverTimeIcons.shieldIcon != null)
				playerOverTimeIcons.shieldIcon.fillAmount = 0;
			if(playerOverTimeIcons.shieldLabel != null)
				playerOverTimeIcons.shieldLabel.text = "";
		}
		#endregion
		
		#region DeBuff
		
		//Damage over time
		if(player.playerStatus.overTimeDeBuffs.doTCounter > 0){
			if(playerOverTimeIcons.doTIcon != null)
				playerOverTimeIcons.doTIcon.fillAmount = 1;
			if(playerOverTimeIcons.doTLabel != null)
				playerOverTimeIcons.doTLabel.text = "" + player.playerStatus.overTimeDeBuffs.doTCounter;
		}
		else{
			if(playerOverTimeIcons.doTIcon != null)
				playerOverTimeIcons.doTIcon.fillAmount = 0;
			if(playerOverTimeIcons.doTLabel != null)
				playerOverTimeIcons.doTLabel.text = "";
		}
		
		//AP Tax
		if(player.playerStatus.overTimeDeBuffs.aPTaxCounter > 0){
			if(playerOverTimeIcons.aPCostUpIcon != null)
				playerOverTimeIcons.aPCostUpIcon.fillAmount = 1;
			if(playerOverTimeIcons.aPCostUpLabel != null)
				playerOverTimeIcons.aPCostUpLabel.text = "" + player.playerStatus.overTimeDeBuffs.aPTaxCounter;
		}
		else{
			if(playerOverTimeIcons.aPCostUpIcon != null)
				playerOverTimeIcons.aPCostUpIcon.fillAmount = 0;
			if(playerOverTimeIcons.aPCostUpLabel != null)
				playerOverTimeIcons.aPCostUpLabel.text = "";
		}
		
		//AP Gen Degrade
		if(player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter > 0){
			if(playerOverTimeIcons.aPGenDownIcon != null)
				playerOverTimeIcons.aPGenDownIcon.fillAmount = 1;
			if(playerOverTimeIcons.apGenDownLabel != null)
				playerOverTimeIcons.apGenDownLabel.text = "" + player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter;
		}
		else{
			if(playerOverTimeIcons.aPGenDownIcon != null)
				playerOverTimeIcons.aPGenDownIcon.fillAmount = 0;
			if(playerOverTimeIcons.apGenDownLabel != null)
				playerOverTimeIcons.apGenDownLabel.text = "";
		}
		
		//StrDefDown Debuff
		if(player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter > 0){
			if(playerOverTimeIcons.strDefDownIcon != null)
				playerOverTimeIcons.strDefDownIcon.fillAmount = 1;
			if(playerOverTimeIcons.strDefDownLabel != null)
				playerOverTimeIcons.strDefDownLabel.text = "" + player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter;
		}
		else{
			if(playerOverTimeIcons.strDefDownIcon != null)
				playerOverTimeIcons.strDefDownIcon.fillAmount = 0;
			if(playerOverTimeIcons.strDefDownLabel != null)
				playerOverTimeIcons.strDefDownLabel.text = "";
		}
		
		#endregion
		
		#endregion
		
		#region Enemy OverTime Icons
		
		//Update RestedOverIcons
		#region Update RestedOver Icons
		//Update RestedOverIcons
		
		//UpdateButtonColor
		if(GuiBottom.enemyBuffSwitch1 != null)
			GuiBottom.enemyBuffSwitch1.UpdateColor(true, true);
		if(GuiBottom.enemyBuffSwitch2 != null)
			GuiBottom.enemyBuffSwitch2.UpdateColor(true, true);
		if(GuiBottom.enemyBuffSwitch3 != null)
			GuiBottom.enemyBuffSwitch3.UpdateColor(true, true);
		if(GuiBottom.enemyBuffSwitch4 != null)
			GuiBottom.enemyBuffSwitch4.UpdateColor(true, true);
		
		if(GuiBottom.enemyDeBuffSwitch1 != null)
			GuiBottom.enemyDeBuffSwitch1.UpdateColor(true,true);
		if(GuiBottom.enemyDeBuffSwitch2 != null)
			GuiBottom.enemyDeBuffSwitch2.UpdateColor(true,true);
		if(GuiBottom.enemyDeBuffSwitch3 != null)
			GuiBottom.enemyDeBuffSwitch3.UpdateColor(true,true);
		if(GuiBottom.enemyDeBuffSwitch4 != null)
			GuiBottom.enemyDeBuffSwitch4.UpdateColor(true,true);
		
		
		//UpdateDescriptBox
		if(player.lastEnemyBuffDebuffClicked == 0){
			GuiBottom.enemyBuffDeBuffDescription.text = "Hp Up\n" +
				"Hp Up by " + enemy.enemyStatus.hPoT + "% for "
					+ enemy.enemyStatus.hPoTCounter + " turns";
		}
		else if(player.lastEnemyBuffDebuffClicked == 1){
			GuiBottom.enemyBuffDeBuffDescription.text = "EnemySpecific Buff 1\n" +
				"Does special effect for "
					+ enemy.enemyStatus.enemySpecificBuffCounter + " turns";
		}
		else if(player.lastEnemyBuffDebuffClicked == 2){
			GuiBottom.enemyBuffDeBuffDescription.text = "Shield Buff\n" +
				"Enemy is Shieled for "
					+ enemy.enemyStatus.shieldBuffCounter + " turns";
		}
		else if(player.lastEnemyBuffDebuffClicked == 3){
			GuiBottom.enemyBuffDeBuffDescription.text = "Str/Def Up\n" +
				"Str/Def Up by " + player.playerStatus.overTimeBuffs.StrDefUpBuffCounter + "% for "
					+ player.playerStatus.overTimeBuffs.StrDefUpBuffCounter+ " turns";
		}
		else if(player.lastEnemyBuffDebuffClicked == 4){
			GuiBottom.enemyBuffDeBuffDescription.text = "Damage Over Time\n" +
				"Enemy takes " + enemy.enemyStatus.doT + "dam for "
					+ enemy.enemyStatus.doTCounter + " turns";
		}
		else if(player.lastEnemyBuffDebuffClicked == 5){
			GuiBottom.enemyBuffDeBuffDescription.text = "Player Specific Debuff1\n" +
				"Enemy negatively effected by player for "
					+ enemy.enemyStatus.playerSpecificDebuff1Counter + " turns";
		}
		else if(player.lastEnemyBuffDebuffClicked == 6){
			GuiBottom.enemyBuffDeBuffDescription.text = "Player Specific Debuff2\n" +
				"Enemy negatively effected by player for "
					+ enemy.enemyStatus.playerSpecificDebuff1Counter + " turns";
		}
		else if(player.lastEnemyBuffDebuffClicked == 7){
			GuiBottom.enemyBuffDeBuffDescription.text = "Str/Def Down\n" +
				"Enemy Str/Def Down by " + enemy.enemyStatus.strDefDownDebuff + "% for "
					+ enemy.enemyStatus.strDefDownDebuffCounter + " turns";
		}
		
		else
			GuiBottom.enemyBuffDeBuffDescription.text = "";
		
		
		#endregion
		
		#region Buffs
		
		//DoT
		if(enemy.enemyStatus.hPoTCounter > 0){
			if(enemyOverTimeIcons.enemyHPoTIcon != null)
				enemyOverTimeIcons.enemyHPoTIcon.fillAmount = 1;
			if(enemyOverTimeIcons.enemyHPoTIconLabel != null)
				enemyOverTimeIcons.enemyHPoTIconLabel.text = "" + enemy.enemyStatus.hPoTCounter;
		}
		else{
			if(enemyOverTimeIcons.enemyHPoTIcon != null)
				enemyOverTimeIcons.enemyHPoTIcon.fillAmount = 0;
			if(enemyOverTimeIcons.enemyHPoTIconLabel != null)
				enemyOverTimeIcons.enemyHPoTIconLabel.text = "";
		}
		
		//SrtDefUp Buff
		if(enemy.enemyStatus.strDefUpBuffCounter > 0){
			if(enemyOverTimeIcons.strDefUpIcon != null)
				enemyOverTimeIcons.strDefUpIcon.fillAmount = 1;
			if(enemyOverTimeIcons.strDefUpLabel != null)
				enemyOverTimeIcons.strDefUpLabel.text = "" + enemy.enemyStatus.strDefUpBuffCounter;
		}
		else{
			if(enemyOverTimeIcons.strDefUpIcon != null)
				enemyOverTimeIcons.strDefUpIcon.fillAmount = 0;
			if(enemyOverTimeIcons.strDefUpLabel != null)
				enemyOverTimeIcons.strDefUpLabel.text = "";
		}
		
		//Shield Buff
		if(enemy.enemyStatus.shieldBuffCounter > 0){
			if(enemyOverTimeIcons.shieldIcon != null)
				enemyOverTimeIcons.shieldIcon.fillAmount = 1;
			if(enemyOverTimeIcons.shieldLabel != null)
				enemyOverTimeIcons.shieldLabel.text = "" + enemy.enemyStatus.shieldBuffCounter;
		}
		else{
			if(enemyOverTimeIcons.shieldIcon != null)
				enemyOverTimeIcons.shieldIcon.fillAmount = 0;
			if(enemyOverTimeIcons.shieldLabel != null)
				enemyOverTimeIcons.shieldLabel.text = "";
		}
		
		//EnemySpecific Buff
		if(enemy.enemyStatus.enemySpecificBuffCounter > 0){
			if(enemyOverTimeIcons.enemySpecificIcon != null)
				enemyOverTimeIcons.enemySpecificIcon.fillAmount = 1;
			if(enemyOverTimeIcons.enemySpecificLabel != null)
				enemyOverTimeIcons.enemySpecificLabel.text = "" + enemy.enemyStatus.enemySpecificBuffCounter;
		}
		else{
			if(enemyOverTimeIcons.enemySpecificIcon != null)
				enemyOverTimeIcons.enemySpecificIcon.fillAmount = 0;
			if(enemyOverTimeIcons.enemySpecificLabel != null)
				enemyOverTimeIcons.enemySpecificLabel.text = "";
		}
		
		#endregion
		
		#region Debuffs
		
		//DoT
		if(enemy.enemyStatus.doTCounter > 0){
			if(enemyOverTimeIcons.enemyDoTIcon != null)
				enemyOverTimeIcons.enemyDoTIcon.fillAmount = 1;
			if(enemyOverTimeIcons.enemyDoTIconLabel != null)
				enemyOverTimeIcons.enemyDoTIconLabel.text = "" + enemy.enemyStatus.doTCounter;
		}
		else{
			if(enemyOverTimeIcons.enemyDoTIcon != null)
				enemyOverTimeIcons.enemyDoTIcon.fillAmount = 0;
			if(enemyOverTimeIcons.enemyDoTIconLabel != null)
				enemyOverTimeIcons.enemyDoTIconLabel.text = "";
		}
		
		//StrDefDown Debuff
		if(enemy.enemyStatus.strDefDownDebuffCounter > 0){
			if(enemyOverTimeIcons.strDefDownIcon != null)
				enemyOverTimeIcons.strDefDownIcon.fillAmount = 1;
			if(enemyOverTimeIcons.strDefDownLabel != null)
				enemyOverTimeIcons.strDefDownLabel.text = "" + enemy.enemyStatus.strDefDownDebuffCounter;
		}
		else{
			if(enemyOverTimeIcons.strDefDownIcon != null)
				enemyOverTimeIcons.strDefDownIcon.fillAmount = 0;
			if(enemyOverTimeIcons.strDefDownLabel != null)
				enemyOverTimeIcons.strDefDownLabel.text = "";
		}
		
		//PlayerSpecific Debuff 1
		if(enemy.enemyStatus.playerSpecificDebuff1Counter > 0){
			if(enemyOverTimeIcons.playerDebuff1Icon != null)
				enemyOverTimeIcons.playerDebuff1Icon.fillAmount = 1;
			if(enemyOverTimeIcons.playerDebuff1Label != null)
				enemyOverTimeIcons.playerDebuff1Label.text = "" + enemy.enemyStatus.playerSpecificDebuff1Counter;
		}
		else{
			if(enemyOverTimeIcons.playerDebuff1Icon != null)
				enemyOverTimeIcons.playerDebuff1Icon.fillAmount = 0;
			if(enemyOverTimeIcons.playerDebuff1Label != null)
				enemyOverTimeIcons.playerDebuff1Label.text = "";
		}
		
		//PlayerSpecific Debuff 2
		if(enemy.enemyStatus.playerSpecificDebuff2Counter > 0){
			if(enemyOverTimeIcons.playerDebuff2Icon != null)
				enemyOverTimeIcons.playerDebuff2Icon.fillAmount = 1;
			if(enemyOverTimeIcons.playerDebuff2Label != null)
				enemyOverTimeIcons.playerDebuff2Label.text = "" + enemy.enemyStatus.playerSpecificDebuff2Counter;
		}
		else{
			if(enemyOverTimeIcons.playerDebuff2Icon != null)
				enemyOverTimeIcons.playerDebuff2Icon.fillAmount = 0;
			if(enemyOverTimeIcons.playerDebuff2Label != null)
				enemyOverTimeIcons.playerDebuff2Label.text = "";
		}
		#endregion
		
		
		#endregion
				
		#endregion 
		
		// Draw Turns
		if(battleInfo.turnsLabel != null){
			if(player.TurnPhases < 8)
				battleInfo.turnsLabel.text = "Player";
			else
				battleInfo.turnsLabel.text = "Enemy";
		}
		
		//Update Ability buttons
		if(GuiBottom.gunAbilityButton != null)
			GuiBottom.gunAbilityButton.UpdateColor(true,true);
		if(GuiBottom.swordAbilityButton != null)
			GuiBottom.swordAbilityButton.UpdateColor(true,true);
		if(GuiBottom.stanceAbilityButton != null)
			GuiBottom.stanceAbilityButton.UpdateColor(true,true);
	
		//XP Bar
		if(GuiBottom.playerXpSlider != null)
			GuiBottom.playerXpSlider.foreground.localScale = new Vector3((player.xP/ player.xPNextLevel) *
				1024,
				GuiBottom.playerXpSlider.foreground.localScale.y,
				GuiBottom.playerXpSlider.foreground.localScale.z);
	
		//UpdatingBattleInfo
		#region UpdateBattleInfo
		
		//Hide Apropriate Ability Icons
		#region Hide Ability Icons
		switch(player.TurnPhases){
		//Player is picking Gun Abilities
		case 1:
				
			switch(player.lastAbilityChosen){
			case 1:	
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 1;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 2:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 1;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 3:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 1;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 4:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 1;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 5:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 1;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			default:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
			break;
			}
			break;
		//Player is picking Sword Abilities
		case 2:
			switch(player.lastAbilityChosen){
			case 6:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 1;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 7:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 1;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 8:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 1;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 9:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 1;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 10:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 1;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			default:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			}	
			break;
		//Player is picking Sttances
		case 3:
			switch(player.lastAbilityChosen){
			case 11:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 1;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 12:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 1;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 13:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 1;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 14:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 1;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			case 15:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 1;
				break;
			default:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			}
			break;
			
		default:
				if(battleInfo.battleInfoGunAbility1 != null)
					battleInfo.battleInfoGunAbility1.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility2 != null)
					battleInfo.battleInfoGunAbility2.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility3 != null)
					battleInfo.battleInfoGunAbility3.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility4 != null)
					battleInfo.battleInfoGunAbility4.fillAmount = 0;
				if(battleInfo.battleInfoGunAbility5 != null)
					battleInfo.battleInfoGunAbility5.fillAmount = 0;
				
				if(battleInfo.battleInfoSwordAbility1 != null)
					battleInfo.battleInfoSwordAbility1.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility2 != null)
					battleInfo.battleInfoSwordAbility2.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility3 != null)
					battleInfo.battleInfoSwordAbility3.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility4 != null)
					battleInfo.battleInfoSwordAbility4.fillAmount = 0;
				if(battleInfo.battleInfoSwordAbility5 != null)
					battleInfo.battleInfoSwordAbility5.fillAmount = 0;
				
				if(battleInfo.battleInfoStanceAbility1 != null)
					battleInfo.battleInfoStanceAbility1.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility2 != null)
					battleInfo.battleInfoStanceAbility2.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility3 != null)
					battleInfo.battleInfoStanceAbility3.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility4 != null)
					battleInfo.battleInfoStanceAbility4.fillAmount = 0;
				if(battleInfo.battleInfoStanceAbility5 != null)
					battleInfo.battleInfoStanceAbility5.fillAmount = 0;
				break;
			}
		#endregion
		
		
		//Choose Abilities
		#region Choose Abilities
		//Player has chosen No Abilities
		if(player.TurnPhases == 0){
			
			//Hide Ability Boxes
			//NGUITools.SetActive(GameObject.Find("AbilitiesPanel") as GameObject, false)
			if(battleInfo.battleInfoAbility1Box != null)
				battleInfo.battleInfoAbility1Box.fillAmount = 0;
			if(battleInfo.battleInfoAbility2Box != null)
				battleInfo.battleInfoAbility2Box.fillAmount = 0;
			if(battleInfo.battleInfoAbility3Box != null)
				battleInfo.battleInfoAbility3Box.fillAmount = 0;
			if(battleInfo.battleInfoAbility4Box != null)
				battleInfo.battleInfoAbility4Box.fillAmount = 0;
			if(battleInfo.battleInfoAbility5Box != null)
				battleInfo.battleInfoAbility5Box.fillAmount = 0;
			
				
			//Hide Ability label
			headingText = "";
			
			
		}
		#endregion
		
		//Turn Phase 1 ~ Player has chosen Gun Abilities
		else if(player.TurnPhases == 1){
		
			
			//Set BattleInfo
			#region GunAbilities
				
			if(player.lastAbilityChosen == 1){
				
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				
				
				abilityText = "Gun Ability ~ Scarlet Shot\n" +
					"DMG: " + player.playerAbilities.gunAbilities.ScarletShot.rangeMin + " - " +
						player.playerAbilities.gunAbilities.ScarletShot.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.ScarletShot.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.ScarletShot.multiplier);
			

	

			}
			else if(player.lastAbilityChosen == 2){
				
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				
				abilityText = "Gun Ability ~ Dark Bullet\n" +
					"DMG: " + player.playerAbilities.gunAbilities.DarkBullet.rangeMin + " - " +
						player.playerAbilities.gunAbilities.DarkBullet.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.DarkBullet.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.DarkBullet.multiplier);
				


			}
			else if(player.lastAbilityChosen == 3){
				
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Gun Ability ~ Plague Blast\n" +
					"DMG: " + player.playerAbilities.gunAbilities.PlagueBlast.rangeMin + " - " +
						player.playerAbilities.gunAbilities.PlagueBlast.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.PlagueBlast.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.PlagueBlast.multiplier);
				
			
			}
			else if(player.lastAbilityChosen == 4){
				
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Gun Ability ~ Blitz Barrage\n" +
					"DMG: " + player.playerAbilities.gunAbilities.BlitzBarrage.rangeMin + " - " +
						player.playerAbilities.gunAbilities.BlitzBarrage.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.BlitzBarrage.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.BlitzBarrage.multiplier);
				

			}
			else if(player.lastAbilityChosen == 5){
				
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 1;
				
				abilityText = "Gun Ability ~ Shadowflame Shot\n" +
					"DMG: " + player.playerAbilities.gunAbilities.ShadowflameShot.rangeMin + " - " +
						player.playerAbilities.gunAbilities.ShadowflameShot.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.ShadowflameShot.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.ShadowflameShot.multiplier);
				

			}
			else{
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "";
			}
			
			headingText = abilityText;
			
			#endregion
		}
		
		//Turn Phase 2 ~ Player has chosen Sword Abilities
		else if(player.TurnPhases == 2){
			
			#region Sword Abilities			
			if(player.lastAbilityChosen == 6){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Sword Ability ~ Blood Blade\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.BloodBlade.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.BloodBlade.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.BloodBlade.multiplier);
				
				
			}
			else if(player.lastAbilityChosen == 7){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Sword Ability ~ Death Strike\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.DeathStrike.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.DeathStrike.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.DeathStrike.multiplier);
				
				
			}
			else if(player.lastAbilityChosen == 8){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Sword Ability ~ Shadowflame Slash\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.ShadowFlameSlash.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.ShadowFlameSlash.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.ShadowFlameSlash.multiplier);
				
				
			}
			else if(player.lastAbilityChosen == 9){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Sword Ability ~ Crimson Cut\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.CrimsonCut.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.CrimsonCut.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.CrimsonCut.multiplier);
				
				
			}
			else if(player.lastAbilityChosen == 10){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 1;
				
				abilityText = "Sword Ability ~ Shadowfury\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.ShadowFury.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.ShadowFury.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.ShadowFury.multiplier);
				
				
			}
			else{
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "";
			}
			
			headingText = abilityText;
			
			#endregion
			
		}
		
		//Turn Phase 3 ~ Player has chosen Change Stance
		else if(player.TurnPhases == 3){
		
			#region Stances
			if(player.lastAbilityChosen == 11){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				
				abilityText = "Stance ~ Shade of Bloodlust\n" +
					"Increases damage done by 25%\nAnd damage taken by 25% (Offensive)";
				
				
			}
			else if(player.lastAbilityChosen == 12){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				
				abilityText = "Stance ~ Shade of Murder\n" +
					"Health Gains increased by 25% (Health Regen)";
				
			}
			else if(player.lastAbilityChosen == 13){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Stance ~ Shade of Shadow Vengence\n" +
					"Reduces Damage done by 25%\nAnd Reduces damage taken by 25% (Defensive)";
				
			}
			else if(player.lastAbilityChosen == 14){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "Stance ~ Shade of Death\n" +
					"Increases AP generation by 25% (AP Regen)";
				
			}
			else if(player.lastAbilityChosen == 15){
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 1;
				
				abilityText = "Stance ~ Shade of Dark Protection\n" +
					"Reduces all DoT damage by 50%";
				
			}
			else{
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
				
				abilityText = "";
			}
			
			headingText = abilityText;
			
			#endregion
			
		}
		
		
		//Turn Phase 4 ~ Execute Sword Abilities
		#region Execute Sword Abilities
		else if(player.TurnPhases == 4){
			if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
			
			
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
					
				}
				else if(player.swordAbilityChosen == 2){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.DeathStrike.damage + "HP";
					
				}
				else if(player.swordAbilityChosen == 3){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.ShadowFlameSlash.damage + "HP";
					
				}
				else if(player.swordAbilityChosen == 4){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.CrimsonCut.damage + "HP";
					
				}
				else if(player.swordAbilityChosen == 5){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.ShadowFury.damage + "HP";
				}
				
				
				if(battleInfo.playerApGenLabel != null){
					battleInfo.playerApGenLabel.text = tempPlayerApCostLabel;
					battleInfo.playerApGenLabel.enabled = true;	
				}
				
				if(battleInfo.enemyHpDamageLabel != null){
					battleInfo.enemyHpDamageLabel.text = tempEnemyDamLabel;
					battleInfo.enemyHpDamageLabel.enabled = true;
				}
				
			}
		}
		#endregion
		
		//Turn Phase 5 ~ Execute Gun Abilities
		#region Execute Gun Abilities
		else if(player.TurnPhases == 5){
			//Hide Panels
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;

			
			
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
				
				if(battleInfo.enemyHpDamageLabel != null){
					battleInfo.enemyHpDamageLabel.text = tempEnemyDamLabel;
					battleInfo.enemyHpDamageLabel.enabled = true;
				}
				
				if(battleInfo.playerApGenLabel != null){
					battleInfo.playerApGenLabel.text = tempPlayerApBoost;
					battleInfo.playerApGenLabel.enabled = true;
				}
				
				
			}
			
		}
		#endregion
		
		//Turn Phase 6 ~ StanceChange
		#region execute StanceChange
		else if(player.TurnPhases == 6){
			
			//Hide Panels
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;

			
			//Reset ShownIcons
			if(battleInfo.playerHpHealLabel != null)
				battleInfo.playerHpHealLabel.enabled = false;
			if(battleInfo.playerApGenLabel != null)
				battleInfo.playerApGenLabel.enabled = false;
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.enabled = false;
			
			
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
		#endregion
		
		//Turn Phase 7 ~ Apply OverTime Effects
		#region Apply OverTimeEffects
		else if(player.TurnPhases == 7){
			
			//Hide Panels
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;
			
			
			string tempPlayerHpBoost = "";
			string tempPlayerApBoost = "";
			
			string tempEnemyDamLabel = "";
			
			
			if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0)
				tempPlayerHpBoost = "+" + (int)(player.hP * player.playerStatus.overTimeBuffs.hPoT) + "HP";
			if(player.playerStatus.overTimeBuffs.aPBuffCounter > 0)
				tempPlayerApBoost = "+" + player.playerStatus.overTimeBuffs.aPoT + "AP";
			
			if(enemy.enemyStatus.doTCounter > 0)
				tempEnemyDamLabel = "-" + (int)(enemy.hP * enemy.enemyStatus.doT) + "HP";
			
			
			headingText = "Battle Update: Applying OvertimeEffects";
			
			
			//Show effects
			if(battleInfo.playerHpHealLabel != null){
				battleInfo.playerHpHealLabel.text = tempPlayerHpBoost;
				battleInfo.playerHpHealLabel.enabled = true;
			}
			if(battleInfo.playerApGenLabel != null){
				battleInfo.playerApGenLabel.text = tempPlayerApBoost;
				battleInfo.playerApGenLabel.enabled = true;
			}
			if(battleInfo.enemyHpDamageLabel !=null){
				battleInfo.enemyHpDamageLabel.text = tempEnemyDamLabel;
				battleInfo.enemyHpDamageLabel.enabled = true;
			}
			
		}
		#endregion
		
		//Turn Phase 8 ~ Enemy's turn
		#region Enemies Turn
		else if(player.TurnPhases == 8){
			
			//Hide Panels
				if(battleInfo.battleInfoAbility1Box != null)
					battleInfo.battleInfoAbility1Box.fillAmount = 1;
				if(battleInfo.battleInfoAbility2Box != null)
					battleInfo.battleInfoAbility2Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility3Box != null)
					battleInfo.battleInfoAbility3Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility4Box != null)
					battleInfo.battleInfoAbility4Box.fillAmount = 0;
				if(battleInfo.battleInfoAbility5Box != null)
					battleInfo.battleInfoAbility5Box.fillAmount = 0;

			headingText = "Battle Update: Enemy's Turn";
			
			//Reset ShownIcons
			if(battleInfo.playerHpHealLabel != null)
				battleInfo.playerHpHealLabel.enabled = false;
			if(battleInfo.playerApGenLabel != null)
				battleInfo.playerApGenLabel.enabled = false;
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.enabled = false;
			
			
			
			if(battleInfo.playerHpDamageLabel != null)
				battleInfo.playerHpDamageLabel.text = "-" + enemy.enemyStatus.previousDam + "HP";	
			
			
			if(battleInfo.playerHpDamageLabel != null)
				battleInfo.playerHpDamageLabel.enabled = true;
			
		}
		#endregion
		
		//Draw Battle Info
		if(battleInfo.battleInfoLabel != null)
			battleInfo.battleInfoLabel.text = headingText;
		#endregion
		
		
		#endregion		
		
		//Lock Player's hp
		if(player.hP <= 0)
			player.hP = 0;
		else if(player.hP > player.hPMax){
			player.hP = player.hPMax;	
		}
		if(player.aP > 100)
			player.aP = 100;
		else if(player.aP <= 0){
			player.aP = 0;	
		}
		#endregion
			
			break;
		case Player.BattleStatus.Won:
			if(screenLabel != null)
				screenLabel.text = "Player has Won";
			
			#region Hide Everything
			
			//Shown Damage
			if(battleInfo.playerApGenLabel != null)
				battleInfo.playerApGenLabel.text =  "";
			if(battleInfo.playerHpDamageLabel != null)
				battleInfo.playerHpDamageLabel.text = "";
			if(battleInfo.playerHpHealLabel != null)
				battleInfo.playerHpHealLabel.text = "";
			if(battleInfo.enemyHpPlusLabel != null)
				battleInfo.enemyHpPlusLabel.text = "";
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.text = "";
			
			//Description Box
			if(battleInfo.battleInfoPanel != null){
				battleInfo.battleInfoPanel.enabled = false;	
			}
			if(battleInfo.gunAbilitiesPanel != null){
				battleInfo.gunAbilitiesPanel.enabled = false;	
			}
			if(battleInfo.swordAbilitiesPanel != null)
				battleInfo.swordAbilitiesPanel.enabled = false;
			if(battleInfo.stanceAbilitiesPanel != null)
				battleInfo.stanceAbilitiesPanel.enabled = false;
			
			if(battleInfo.battleInfoGunIconPanel != null)
				battleInfo.battleInfoGunIconPanel.enabled = false;
			if(battleInfo.battleInfoSwordIconPanel != null)
				battleInfo.battleInfoSwordIconPanel.enabled = false;
			if(battleInfo.battleInfoStanceIconPanel != null)
				battleInfo.battleInfoStanceIconPanel.enabled = false;
			
			//OverTime Stuff
			if(battleInfo.playerBuffsPanel != null)
				battleInfo.playerBuffsPanel.enabled = false;
			if(battleInfo.playerDeBuffsPanel != null)
				battleInfo.playerDeBuffsPanel.enabled = false;
			if(battleInfo.enemyBuffsPanel != null)
				battleInfo.enemyBuffsPanel.enabled = false;
			if(battleInfo.enemyDeBuffsPanel != null)
				battleInfo.enemyDeBuffsPanel.enabled = false;
			
			if(GuiBottom.playerBuffDeBuffDescription != null)
				GuiBottom.playerBuffDeBuffDescription.text = "";
			if(GuiBottom.enemyBuffDeBuffDescription != null)
				GuiBottom.enemyBuffDeBuffDescription.text = "";
			
			if(battleInfo.turnTotalDamageLabel != null)
				battleInfo.turnTotalDamageLabel.text = "";
			
			#endregion
			break;
		case Player.BattleStatus.Lost:
			if(screenLabel != null)
				screenLabel.text = "Player has Lost";
			#region Hide Everything
			
			//Shown Damage
			if(battleInfo.playerApGenLabel != null)
				battleInfo.playerApGenLabel.text =  "";
			if(battleInfo.playerHpDamageLabel != null)
				battleInfo.playerHpDamageLabel.text = "";
			if(battleInfo.playerHpHealLabel != null)
				battleInfo.playerHpHealLabel.text = "";
			if(battleInfo.enemyHpPlusLabel != null)
				battleInfo.enemyHpPlusLabel.text = "";
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.text = "";
			
			//Description Box
			if(battleInfo.battleInfoPanel != null){
				battleInfo.battleInfoPanel.enabled = false;	
			}
			if(battleInfo.gunAbilitiesPanel != null){
				battleInfo.gunAbilitiesPanel.enabled = false;	
			}
			if(battleInfo.swordAbilitiesPanel != null)
				battleInfo.swordAbilitiesPanel.enabled = false;
			if(battleInfo.stanceAbilitiesPanel != null)
				battleInfo.stanceAbilitiesPanel.enabled = false;
			
			if(battleInfo.battleInfoGunIconPanel != null)
				battleInfo.battleInfoGunIconPanel.enabled = false;
			if(battleInfo.battleInfoSwordIconPanel != null)
				battleInfo.battleInfoSwordIconPanel.enabled = false;
			if(battleInfo.battleInfoStanceIconPanel != null)
				battleInfo.battleInfoStanceIconPanel.enabled = false;
			
			//OverTime Stuff
			if(battleInfo.playerBuffsPanel != null)
				battleInfo.playerBuffsPanel.enabled = false;
			if(battleInfo.playerDeBuffsPanel != null)
				battleInfo.playerDeBuffsPanel.enabled = false;
			if(battleInfo.enemyBuffsPanel != null)
				battleInfo.enemyBuffsPanel.enabled = false;
			if(battleInfo.enemyDeBuffsPanel != null)
				battleInfo.enemyDeBuffsPanel.enabled = false;
			
			if(GuiBottom.playerBuffDeBuffDescription != null)
				GuiBottom.playerBuffDeBuffDescription.text = "";
			if(GuiBottom.enemyBuffDeBuffDescription != null)
				GuiBottom.enemyBuffDeBuffDescription.text = "";
			
			if(battleInfo.turnTotalDamageLabel != null)
				battleInfo.turnTotalDamageLabel.text = "";
			
			#endregion
			break;
		}
		
			
	}
}