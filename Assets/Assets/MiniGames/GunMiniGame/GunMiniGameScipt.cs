using UnityEngine;
using System.Collections;

public class GunMiniGameScipt : MonoBehaviour {

	
	
	public UIButton gunDialButton;
	
	public UIFilledSprite gunDialMaskCrit1;
	public UIFilledSprite gunDialMaskCrit2;
	public UIFilledSprite gunDialMaskCrit3;
	public UIFilledSprite gunDialMaskCrit4;
	public UIFilledSprite gunDialMaskCrit5;
	public UIFilledSprite gunDialMaskCrit6;
	
	public UIFilledSprite gunDialMaskNormal1;
	public UIFilledSprite gunDialMaskNormal2;
	public UIFilledSprite gunDialMaskNormal3;
	public UIFilledSprite gunDialMaskNormal4;
	public UIFilledSprite gunDialMaskNormal5;
	public UIFilledSprite gunDialMaskNormal6;

	
	public UIFilledSprite arrow;
	
	public int ArrowSpeed;
	
	public int StartingDial = 1;
	
	public Player player;
	
	public Vector3 stopPosition;
	public float attackDistanceFromCenter;
	
	[System.Serializable]
	public class Mask{
		public float fillAmount;
		
		public float rangeMin;
		public float rangeMax;
	}
	
	[System.Serializable]
	public class GunAbilityMaskGroup{
		
		public Mask critMask = new Mask();
		
		public Mask normalMask = new Mask();
		
		public int numOfTaps;
	
	}
	
	[System.Serializable]
	public class GunAbilityDials{
	
		public GunAbilityMaskGroup[] scarletShot = new GunAbilityMaskGroup[1];
		
		public GunAbilityMaskGroup[] darkBullet = new GunAbilityMaskGroup[2];
		
		public GunAbilityMaskGroup[] plagueBlast = new GunAbilityMaskGroup[4];
		
		public GunAbilityMaskGroup[] blitzBarrage = new GunAbilityMaskGroup[5];
		
		public GunAbilityMaskGroup[] shadowFlameShot = new GunAbilityMaskGroup[6];
		
	}
	
	public GunAbilityDials gunAbilityDials = new GunAbilityDials();
	
	
	public float clickCounter = 0;
	
	public float distanceFromCenter;
	
	
	public Vector3 initialPosition;
	public Vector3 currentPosition;
	public Vector3 referenceRight;
	
	public enum Attack{NoHit,Normal,Crit, Miss};
	public Attack currentAttack = Attack.NoHit;

	
	public bool isRotating;
	
	
	public void populateMasks(){
		
		
		#region Scarlet Shot
		gunAbilityDials.scarletShot[0].numOfTaps = 1;
		//1
		gunAbilityDials.scarletShot[0].critMask.rangeMin = 316;
		gunAbilityDials.scarletShot[0].critMask.rangeMax = 330;
		gunAbilityDials.scarletShot[0].critMask.fillAmount = ((gunAbilityDials.scarletShot[0].critMask.rangeMax -
			gunAbilityDials.scarletShot[0].critMask.rangeMin)/360);
			
		gunAbilityDials.scarletShot[0].normalMask.rangeMin = 240;
		gunAbilityDials.scarletShot[0].normalMask.rangeMax = 315;
		gunAbilityDials.scarletShot[0].normalMask.fillAmount = ((gunAbilityDials.scarletShot[0].normalMask.rangeMax -
			gunAbilityDials.scarletShot[0].normalMask.rangeMin)/360);
		#endregion
		

		#region DarkBullet
		gunAbilityDials.darkBullet[0].numOfTaps = 2;
		gunAbilityDials.darkBullet[1].numOfTaps = 2;
			//1
		gunAbilityDials.darkBullet[0].critMask.rangeMin = 226;
		gunAbilityDials.darkBullet[0].critMask.rangeMax = 240;
		gunAbilityDials.darkBullet[0].critMask.fillAmount = ((gunAbilityDials.darkBullet[0].critMask.rangeMax -
			gunAbilityDials.darkBullet[0].critMask.rangeMin)/360);
		
		gunAbilityDials.darkBullet[0].normalMask.rangeMin = 180;
		gunAbilityDials.darkBullet[0].normalMask.rangeMax = 225;
		gunAbilityDials.darkBullet[0].normalMask.fillAmount = ((gunAbilityDials.darkBullet[0].normalMask.rangeMax -
			gunAbilityDials.darkBullet[0].normalMask.rangeMin)/360);
			//2
		gunAbilityDials.darkBullet[1].critMask.rangeMin = 270;
		gunAbilityDials.darkBullet[1].critMask.rangeMax = 285;
		gunAbilityDials.darkBullet[1].critMask.fillAmount = ((gunAbilityDials.darkBullet[1].critMask.rangeMax -
			gunAbilityDials.darkBullet[1].critMask.rangeMin)/360);
		
		gunAbilityDials.darkBullet[1].normalMask.rangeMin = 286;
		gunAbilityDials.darkBullet[1].normalMask.rangeMax = 300;
		gunAbilityDials.darkBullet[1].normalMask.fillAmount = ((gunAbilityDials.darkBullet[1].normalMask.rangeMax -
			gunAbilityDials.darkBullet[1].normalMask.rangeMin)/360);
		#endregion
		
		#region PlagueBlast
		gunAbilityDials.plagueBlast[0].numOfTaps = 4;
		gunAbilityDials.plagueBlast[1].numOfTaps = 4;
		gunAbilityDials.plagueBlast[2].numOfTaps = 4;

			//1
		gunAbilityDials.plagueBlast[0].critMask.rangeMin = 20;
		gunAbilityDials.plagueBlast[0].critMask.rangeMax = 30;
		gunAbilityDials.plagueBlast[0].critMask.fillAmount = ((gunAbilityDials.plagueBlast[0].critMask.rangeMax -
			gunAbilityDials.plagueBlast[0].critMask.rangeMin)/360);
		
		gunAbilityDials.plagueBlast[0].normalMask.rangeMin = 31;
		gunAbilityDials.plagueBlast[0].normalMask.rangeMax = 80;
		gunAbilityDials.plagueBlast[0].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[0].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[0].normalMask.rangeMin)/360);
			//2
		gunAbilityDials.plagueBlast[1].critMask.rangeMin = 110;
		gunAbilityDials.plagueBlast[1].critMask.rangeMax = 120;
		gunAbilityDials.plagueBlast[1].critMask.fillAmount = ((gunAbilityDials.plagueBlast[1].critMask.rangeMax -
			gunAbilityDials.plagueBlast[1].critMask.rangeMin)/360);
		
		gunAbilityDials.plagueBlast[1].normalMask.rangeMin = 121;
		gunAbilityDials.plagueBlast[1].normalMask.rangeMax = 150;
		gunAbilityDials.plagueBlast[1].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[1].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[1].normalMask.rangeMin)/360);
			//3
		gunAbilityDials.plagueBlast[2].critMask.rangeMin = 210;
		gunAbilityDials.plagueBlast[2].critMask.rangeMax = 220;
		gunAbilityDials.plagueBlast[2].critMask.fillAmount = ((gunAbilityDials.plagueBlast[2].critMask.rangeMax -
			gunAbilityDials.plagueBlast[2].critMask.rangeMin)/360);
		
		gunAbilityDials.plagueBlast[2].normalMask.rangeMin = 221;
		gunAbilityDials.plagueBlast[2].normalMask.rangeMax = 260;
		gunAbilityDials.plagueBlast[2].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[2].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[2].normalMask.rangeMin)/360);
			//4
		gunAbilityDials.plagueBlast[3].critMask.rangeMin = 330;
		gunAbilityDials.plagueBlast[3].critMask.rangeMax = 340;
		gunAbilityDials.plagueBlast[3].critMask.fillAmount = ((gunAbilityDials.plagueBlast[3].critMask.rangeMax -
			gunAbilityDials.plagueBlast[3].critMask.rangeMin)/360);
		
		gunAbilityDials.plagueBlast[3].normalMask.rangeMin = 341;
		gunAbilityDials.plagueBlast[3].normalMask.rangeMax = 359;
		gunAbilityDials.plagueBlast[3].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[3].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[3].normalMask.rangeMin)/360);
		#endregion
		
		#region BlitzBarrage
		gunAbilityDials.blitzBarrage[0].numOfTaps = 5;
		gunAbilityDials.blitzBarrage[1].numOfTaps = 5;	
		gunAbilityDials.blitzBarrage[2].numOfTaps = 5;	
		gunAbilityDials.blitzBarrage[3].numOfTaps = 5;	
		gunAbilityDials.blitzBarrage[4].numOfTaps = 5;
		
		//1
		gunAbilityDials.blitzBarrage[0].critMask.rangeMin = 70;
		gunAbilityDials.blitzBarrage[0].critMask.rangeMax = 80;
		gunAbilityDials.blitzBarrage[0].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[0].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[0].critMask.rangeMin)/360);
		
		gunAbilityDials.blitzBarrage[0].normalMask.rangeMin = 60;
		gunAbilityDials.blitzBarrage[0].normalMask.rangeMax = 90;
		gunAbilityDials.blitzBarrage[0].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[0].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[0].normalMask.rangeMin)/360);
		//2
		gunAbilityDials.blitzBarrage[1].critMask.rangeMin = 130;
		gunAbilityDials.blitzBarrage[1].critMask.rangeMax = 140;
		gunAbilityDials.blitzBarrage[1].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[1].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[1].critMask.rangeMin)/360);
		
		gunAbilityDials.blitzBarrage[1].normalMask.rangeMin = 120;
		gunAbilityDials.blitzBarrage[1].normalMask.rangeMax = 150;
		gunAbilityDials.blitzBarrage[1].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[1].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[1].normalMask.rangeMin)/360);
		//3
		gunAbilityDials.blitzBarrage[2].critMask.rangeMin = 190;
		gunAbilityDials.blitzBarrage[2].critMask.rangeMax = 200;
		gunAbilityDials.blitzBarrage[2].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[2].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[2].critMask.rangeMin)/360);
		
		gunAbilityDials.blitzBarrage[2].normalMask.rangeMin = 180;
		gunAbilityDials.blitzBarrage[2].normalMask.rangeMax = 210;
		gunAbilityDials.blitzBarrage[2].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[2].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[2].normalMask.rangeMin)/360);
		//4
		gunAbilityDials.blitzBarrage[3].critMask.rangeMin = 250;
		gunAbilityDials.blitzBarrage[3].critMask.rangeMax = 260;
		gunAbilityDials.blitzBarrage[3].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[3].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[3].critMask.rangeMin)/360);
		
		gunAbilityDials.blitzBarrage[3].normalMask.rangeMin = 240;
		gunAbilityDials.blitzBarrage[3].normalMask.rangeMax = 270;
		gunAbilityDials.blitzBarrage[3].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[3].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[3].normalMask.rangeMin)/360);
		//5
		gunAbilityDials.blitzBarrage[4].critMask.rangeMin = 310;
		gunAbilityDials.blitzBarrage[4].critMask.rangeMax = 320;
		gunAbilityDials.blitzBarrage[4].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[4].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[4].critMask.rangeMin)/360);
		
		gunAbilityDials.blitzBarrage[4].normalMask.rangeMin = 300;
		gunAbilityDials.blitzBarrage[4].normalMask.rangeMax = 330;
		gunAbilityDials.blitzBarrage[4].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[4].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[4].normalMask.rangeMin)/360);
		#endregion
		
		#region ShadowFlame Shot
		gunAbilityDials.shadowFlameShot[0].numOfTaps = 6;
		gunAbilityDials.shadowFlameShot[1].numOfTaps = 6;
		gunAbilityDials.shadowFlameShot[2].numOfTaps = 6;
		gunAbilityDials.shadowFlameShot[3].numOfTaps = 6;
		gunAbilityDials.shadowFlameShot[4].numOfTaps = 6;
		gunAbilityDials.shadowFlameShot[5].numOfTaps = 6;
		
		//1
		gunAbilityDials.shadowFlameShot[0].critMask.rangeMin = 75;
		gunAbilityDials.shadowFlameShot[0].critMask.rangeMax = 85;
		gunAbilityDials.shadowFlameShot[0].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[0].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[0].critMask.rangeMin)/360);
		
		gunAbilityDials.shadowFlameShot[0].normalMask.rangeMin = 60;
		gunAbilityDials.shadowFlameShot[0].normalMask.rangeMax = 90;
		gunAbilityDials.shadowFlameShot[0].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[0].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[0].critMask.rangeMin)/360);
		//2
		gunAbilityDials.shadowFlameShot[1].critMask.rangeMin = 123;
		gunAbilityDials.shadowFlameShot[1].critMask.rangeMax = 133;
		gunAbilityDials.shadowFlameShot[1].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[1].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[1].critMask.rangeMin)/360);
		
		gunAbilityDials.shadowFlameShot[1].normalMask.rangeMin = 113;
		gunAbilityDials.shadowFlameShot[1].normalMask.rangeMax = 143;
		gunAbilityDials.shadowFlameShot[1].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[1].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[1].critMask.rangeMin)/360);
		//3
		gunAbilityDials.shadowFlameShot[2].critMask.rangeMin = 176;
		gunAbilityDials.shadowFlameShot[2].critMask.rangeMax = 186;
		gunAbilityDials.shadowFlameShot[2].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[2].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[2].critMask.rangeMin)/360);
		
		gunAbilityDials.shadowFlameShot[2].normalMask.rangeMin = 166;
		gunAbilityDials.shadowFlameShot[2].normalMask.rangeMax = 196;
		gunAbilityDials.shadowFlameShot[2].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[2].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[2].critMask.rangeMin)/360);
		//4
		gunAbilityDials.shadowFlameShot[3].critMask.rangeMin = 219;
		gunAbilityDials.shadowFlameShot[3].critMask.rangeMax = 229;
		gunAbilityDials.shadowFlameShot[3].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[3].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[3].critMask.rangeMin)/360);
		
		gunAbilityDials.shadowFlameShot[3].normalMask.rangeMin = 219;
		gunAbilityDials.shadowFlameShot[3].normalMask.rangeMax = 249;
		gunAbilityDials.shadowFlameShot[3].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[3].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[3].critMask.rangeMin)/360);
		//5
		gunAbilityDials.shadowFlameShot[4].critMask.rangeMin = 282;
		gunAbilityDials.shadowFlameShot[4].critMask.rangeMax = 292;
		gunAbilityDials.shadowFlameShot[4].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[4].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[4].critMask.rangeMin)/360);
		
		gunAbilityDials.shadowFlameShot[4].normalMask.rangeMin = 272;
		gunAbilityDials.shadowFlameShot[4].normalMask.rangeMax = 292;
		gunAbilityDials.shadowFlameShot[4].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[4].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[4].critMask.rangeMin)/360);
		//6
		gunAbilityDials.shadowFlameShot[5].critMask.rangeMin = 345;
		gunAbilityDials.shadowFlameShot[5].critMask.rangeMax = 355;
		gunAbilityDials.shadowFlameShot[5].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[5].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[5].critMask.rangeMin)/360);
		
		gunAbilityDials.shadowFlameShot[5].normalMask.rangeMin = 315;
		gunAbilityDials.shadowFlameShot[5].normalMask.rangeMax = 345;
		gunAbilityDials.shadowFlameShot[5].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[5].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[5].normalMask.rangeMin)/360);
		
		#endregion
		
	}
	
	
	void Start(){
		
		isRotating = true;
		
		ArrowSpeed = 15;
		
		StartingDial = 0;
		
		initialPosition = arrow.transform.localPosition;
		stopPosition = initialPosition;
		referenceRight = Vector3.Cross(Vector3.up, initialPosition);
		
		populateMasks();
	
		gunDialMaskCrit1.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskCrit2.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskCrit3.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskCrit4.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskCrit5.fillDirection = UIFilledSprite.FillDirection.Radial360;
		
		gunDialMaskNormal1.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal2.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal3.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal4.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal5.fillDirection = UIFilledSprite.FillDirection.Radial360;
		
	}
	
	public void setDial(int gunAbilityChosen){
		
		
			gunDialButton.isEnabled = true;
			gunDialButton.defaultColor = Color.white;
			
			arrow.color = Color.white;
	
		//Set to Apropriate dial
		#region Set to Appropriate dial
		switch(gunAbilityChosen){
			
			
		//Set to ScarletShot
		case 0:
			//Set player's max clicks
			player.clickMax = gunAbilityDials.scarletShot[0].numOfTaps;
			
			//Crit 1
			gunDialMaskCrit1.fillAmount = gunAbilityDials.scarletShot[0].critMask.fillAmount;
			gunDialMaskCrit1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.scarletShot[0].critMask.rangeMin);
			
			//Norm 1
			gunDialMaskNormal1.fillAmount = gunAbilityDials.scarletShot[0].normalMask.fillAmount;
			gunDialMaskNormal1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.scarletShot[0].normalMask.rangeMin);
		
			//Hide Other Dials
			gunDialMaskCrit2.fillAmount = 0;
			gunDialMaskCrit3.fillAmount = 0;
			gunDialMaskCrit4.fillAmount = 0;
			gunDialMaskCrit5.fillAmount = 0;
			gunDialMaskCrit6.fillAmount = 0;
		
			gunDialMaskNormal2.fillAmount = 0;
			gunDialMaskNormal3.fillAmount = 0;
			gunDialMaskNormal4.fillAmount = 0;
			gunDialMaskNormal5.fillAmount = 0;
			gunDialMaskNormal6.fillAmount = 0;
			break;
		//Set to Dark Bullet
		case 1:
			//Set player's max clicks
			player.clickMax = gunAbilityDials.darkBullet[0].numOfTaps;
			
			//Crit 1
			gunDialMaskCrit1.fillAmount = gunAbilityDials.darkBullet[0].critMask.fillAmount;
			gunDialMaskCrit1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.darkBullet[0].critMask.rangeMin);
			//Crit 2
			gunDialMaskCrit2.fillAmount = gunAbilityDials.darkBullet[1].critMask.fillAmount;
			gunDialMaskCrit2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.darkBullet[1].critMask.rangeMin);
			
			
			//Norm1
			gunDialMaskNormal1.fillAmount = gunAbilityDials.darkBullet[0].normalMask.fillAmount;
			gunDialMaskNormal1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.darkBullet[0].normalMask.rangeMin);
			//Norm2
			gunDialMaskNormal2.fillAmount = gunAbilityDials.darkBullet[1].normalMask.fillAmount;
			gunDialMaskNormal2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.darkBullet[1].normalMask.rangeMin);
			
			//Hide Other Dials
			gunDialMaskCrit3.fillAmount = 0;
			gunDialMaskCrit4.fillAmount = 0;
			gunDialMaskCrit5.fillAmount = 0;
			gunDialMaskCrit6.fillAmount = 0;
		
			gunDialMaskNormal3.fillAmount = 0;
			gunDialMaskNormal4.fillAmount = 0;
			gunDialMaskNormal5.fillAmount = 0;
			gunDialMaskNormal6.fillAmount = 0;
			break;

		//Set to PlagueBlast
		case 2:
			//Set player's max clicks
			player.clickMax = gunAbilityDials.plagueBlast[0].numOfTaps;
			
			//Crit 1
			gunDialMaskCrit1.fillAmount = gunAbilityDials.plagueBlast[0].critMask.fillAmount;
			gunDialMaskCrit1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[0].critMask.rangeMin);
			//Crit 2
			gunDialMaskCrit2.fillAmount = gunAbilityDials.plagueBlast[1].critMask.fillAmount;
			gunDialMaskCrit2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[1].critMask.rangeMin);
			//Crit 3
			gunDialMaskCrit3.fillAmount = gunAbilityDials.plagueBlast[2].critMask.fillAmount;
			gunDialMaskCrit3.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[2].critMask.rangeMin);
			//Crit 4
			gunDialMaskCrit4.fillAmount = gunAbilityDials.plagueBlast[3].critMask.fillAmount;
			gunDialMaskCrit4.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[3].critMask.rangeMin);
			
			//Norm1
			gunDialMaskNormal1.fillAmount = gunAbilityDials.plagueBlast[0].normalMask.fillAmount;
			gunDialMaskNormal1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[0].normalMask.rangeMin);
			//Norm2
			gunDialMaskNormal2.fillAmount = gunAbilityDials.plagueBlast[1].normalMask.fillAmount;
			gunDialMaskNormal2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[1].normalMask.rangeMin);
			//Norm3
			gunDialMaskNormal3.fillAmount = gunAbilityDials.plagueBlast[2].normalMask.fillAmount;
			gunDialMaskNormal3.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[2].normalMask.rangeMin);
			//Norm 4
			gunDialMaskNormal4.fillAmount = gunAbilityDials.plagueBlast[3].normalMask.fillAmount;
			gunDialMaskNormal4.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.plagueBlast[3].normalMask.rangeMin);
			
			
			//Hide other Dials
			gunDialMaskCrit5.fillAmount = 0;
			gunDialMaskCrit6.fillAmount = 0;
			gunDialMaskNormal5.fillAmount = 0;
			gunDialMaskNormal6.fillAmount = 0;
		
			break;
		
		//Set to BlitzBarrage
		case 3:
			//Set player's max clicks
			player.clickMax = gunAbilityDials.blitzBarrage[0].numOfTaps;
			
			//Crit 1
			gunDialMaskCrit1.fillAmount = gunAbilityDials.blitzBarrage[0].critMask.fillAmount;
			gunDialMaskCrit1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[0].critMask.rangeMin);
			//Crit 2
			gunDialMaskCrit2.fillAmount = gunAbilityDials.blitzBarrage[1].critMask.fillAmount;
			gunDialMaskCrit2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[1].critMask.rangeMin);
			//Crit 3
			gunDialMaskCrit3.fillAmount = gunAbilityDials.blitzBarrage[2].critMask.fillAmount;
			gunDialMaskCrit3.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[2].critMask.rangeMin);
			//Crit 4
			gunDialMaskCrit4.fillAmount = gunAbilityDials.blitzBarrage[3].critMask.fillAmount;
			gunDialMaskCrit4.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[3].critMask.rangeMin);
			//Crit 5
			gunDialMaskCrit5.fillAmount = gunAbilityDials.blitzBarrage[4].critMask.fillAmount;
			gunDialMaskCrit5.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[4].critMask.rangeMin);
			
			//Norm1
			gunDialMaskNormal1.fillAmount = gunAbilityDials.blitzBarrage[0].normalMask.fillAmount;
			gunDialMaskNormal1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[0].normalMask.rangeMin);
			//Norm2
			gunDialMaskNormal2.fillAmount = gunAbilityDials.blitzBarrage[1].normalMask.fillAmount;
			gunDialMaskNormal2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[1].normalMask.rangeMin);
			//Norm3
			gunDialMaskNormal3.fillAmount = gunAbilityDials.blitzBarrage[2].normalMask.fillAmount;
			gunDialMaskNormal3.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[2].normalMask.rangeMin);
			//Norm 4
			gunDialMaskNormal4.fillAmount = gunAbilityDials.blitzBarrage[3].normalMask.fillAmount;
			gunDialMaskNormal4.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[3].normalMask.rangeMin);
			//Norm 5
			gunDialMaskNormal5.fillAmount = gunAbilityDials.blitzBarrage[4].normalMask.fillAmount;
			gunDialMaskNormal5.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.blitzBarrage[4].normalMask.rangeMin);
			
			
			//Hide other Dials
			gunDialMaskCrit6.fillAmount = 0;
			gunDialMaskNormal6.fillAmount = 0;
			
			break;
		
		//Set to ShadowShot
		case 4:
			//Set player's max clicks
			player.clickMax = gunAbilityDials.shadowFlameShot[0].numOfTaps;
			
			//Crit 1
			gunDialMaskCrit1.fillAmount = gunAbilityDials.shadowFlameShot[0].critMask.fillAmount;
			gunDialMaskCrit1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[0].critMask.rangeMin);
			//Crit 2
			gunDialMaskCrit2.fillAmount = gunAbilityDials.shadowFlameShot[1].critMask.fillAmount;
			gunDialMaskCrit2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[1].critMask.rangeMin);
			//Crit 3
			gunDialMaskCrit3.fillAmount = gunAbilityDials.shadowFlameShot[2].critMask.fillAmount;
			gunDialMaskCrit3.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[2].critMask.rangeMin);
			//Crit 4
			gunDialMaskCrit4.fillAmount = gunAbilityDials.shadowFlameShot[3].critMask.fillAmount;
			gunDialMaskCrit4.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[3].critMask.rangeMin);
			//Crit 5
			gunDialMaskCrit5.fillAmount = gunAbilityDials.shadowFlameShot[4].critMask.fillAmount;
			gunDialMaskCrit5.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[4].critMask.rangeMin);
			//Crit 6
			gunDialMaskCrit6.fillAmount = gunAbilityDials.shadowFlameShot[5].critMask.fillAmount;
			gunDialMaskCrit6.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[5].critMask.rangeMin);
			
			//Norm1
			gunDialMaskNormal1.fillAmount = gunAbilityDials.shadowFlameShot[0].normalMask.fillAmount;
			gunDialMaskNormal1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[0].normalMask.rangeMin);
			//Norm2
			gunDialMaskNormal2.fillAmount = gunAbilityDials.shadowFlameShot[1].normalMask.fillAmount;
			gunDialMaskNormal2.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[1].normalMask.rangeMin);
			//Norm3
			gunDialMaskNormal3.fillAmount = gunAbilityDials.shadowFlameShot[2].normalMask.fillAmount;
			gunDialMaskNormal3.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[2].normalMask.rangeMin);
			//Norm 4
			gunDialMaskNormal4.fillAmount = gunAbilityDials.shadowFlameShot[3].normalMask.fillAmount;
			gunDialMaskNormal4.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[3].normalMask.rangeMin);
			//Norm 5
			gunDialMaskNormal5.fillAmount = gunAbilityDials.shadowFlameShot[4].normalMask.fillAmount;
			gunDialMaskNormal5.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[4].normalMask.rangeMin);
			//Norm 6
			gunDialMaskNormal6.fillAmount = gunAbilityDials.shadowFlameShot[5].normalMask.fillAmount;
			gunDialMaskNormal6.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.shadowFlameShot[5].normalMask.rangeMin);
			break;
		}
		#endregion
		
	}
	
	public Attack didLand(Attack currentAttack){
		float stoppedAngle = findAngle(initialPosition, stopPosition, referenceRight);
		
		
		switch(player.gunAbilityChosen){
		//Scarlet Shot
		case 1:
			//Check Crit
			if(stoppedAngle < gunAbilityDials.scarletShot[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.scarletShot[0].critMask.rangeMin)
				return Attack.Crit;
			
			//Check Normal hit
			else if(stoppedAngle < gunAbilityDials.scarletShot[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.scarletShot[0].normalMask.rangeMin)
				return Attack.Normal;
			
			//Miss
			else
				return Attack.Miss;

			
		//Dark Bullet
		case 2:
			//Check Crit hit
			if(stoppedAngle < gunAbilityDials.darkBullet[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[0].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.darkBullet[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[1].critMask.rangeMin)
				return Attack.Crit;
			
			//Check Normal hit
			else if(stoppedAngle < gunAbilityDials.darkBullet[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[0].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.darkBullet[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[1].normalMask.rangeMin)
				return Attack.Normal;
			
			//Miss
			else
				return Attack.Miss;

		
		//PlagueBlast
		case 3:
			//Check Crit Hit
			if(stoppedAngle < gunAbilityDials.plagueBlast[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[0].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.plagueBlast[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[1].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.plagueBlast[2].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[2].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.plagueBlast[3].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[3].critMask.rangeMin)
				return Attack.Crit;
			
			//Check Normal Hit
			else if(stoppedAngle < gunAbilityDials.plagueBlast[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[0].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.plagueBlast[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[1].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.plagueBlast[2].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[2].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.plagueBlast[3].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[3].normalMask.rangeMin)
				return Attack.Normal;
			
			//Miss
			else
				return Attack.Miss;
			

			
		//BlitzBarrage
		case 4:
			//Check Crit Hit
			if(stoppedAngle < gunAbilityDials.blitzBarrage[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[0].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[1].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[2].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[2].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[3].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[3].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[4].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[4].critMask.rangeMin)
				return Attack.Crit;
			
			//Check Normal Hit
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[0].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[1].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[2].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[2].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[3].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[3].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[4].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[4].normalMask.rangeMin)
				return Attack.Normal;
			
			//Miss
			else
				return Attack.Miss;

			
		//ShadowFlameShot
		case 5:
			//Check Crit Hit
			if(stoppedAngle < gunAbilityDials.shadowFlameShot[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[0].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[1].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[2].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[2].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[3].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[3].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[4].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[4].critMask.rangeMin)
				return Attack.Crit;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[5].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[5].critMask.rangeMin)
				return Attack.Crit;
			
			//Check Normal Hit
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[0].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[1].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[2].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[2].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[3].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[3].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[4].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[4].normalMask.rangeMin)
				return Attack.Normal;
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[5].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[5].normalMask.rangeMin)
				return Attack.Normal;
			
			//Miss
			else
				return Attack.Miss;

			
			
		default:
				return Attack.Miss;

		}
		
		
	}
	
	
	void OnClick(){
		
		isRotating = false;
		
		stopPosition = arrow.transform.localPosition;
		
		clickCounter++;
		player.clickCounter++;
		
		currentAttack = didLand(currentAttack);
		
		player.lastGunHit = (Player.LastGunHit) currentAttack;
	}
	
	
	// Update is called once per frame
	void Update () {
		gunDialButton.UpdateColor(true,true);
		
		if(player.TurnPhases == 5){
			
			
			setDial((player.gunAbilityChosen - 1));
			
			//Move Arrow
			arrow.transform.RotateAround(gunDialButton.transform.position,
				Vector3.forward, ArrowSpeed * Time.deltaTime);
		
		
		
			currentPosition = arrow.transform.localPosition;
		
		
			distanceFromCenter = findAngle(initialPosition, currentPosition, referenceRight);
			attackDistanceFromCenter = findAngle(initialPosition, stopPosition, referenceRight);
		}
		else{
			//Hide Everything
			gunDialButton.isEnabled = false;
			gunDialButton.defaultColor = Color.clear;
			
			arrow.color = Color.clear;
			//arrow.transform.localPosition = initialPosition;
			
			//Hide Other Dials
			gunDialMaskCrit1.fillAmount = 0;
			gunDialMaskCrit2.fillAmount = 0;
			gunDialMaskCrit3.fillAmount = 0;
			gunDialMaskCrit4.fillAmount = 0;
			gunDialMaskCrit5.fillAmount = 0;
			gunDialMaskCrit6.fillAmount = 0;
		
			gunDialMaskNormal1.fillAmount = 0;
			gunDialMaskNormal2.fillAmount = 0;
			gunDialMaskNormal3.fillAmount = 0;
			gunDialMaskNormal4.fillAmount = 0;
			gunDialMaskNormal5.fillAmount = 0;
			gunDialMaskNormal6.fillAmount = 0;
		}
		
	}
	
	
	float findAngle(Vector3 initial, Vector3 current, Vector3 middle){
		
		float tempAngle = Vector3.Angle(initial, current);
		
		 if(AngleDir(initial, current, middle) == -1) {

        	return 360 - tempAngle;

		}
		else
			return tempAngle;
		
	}
	//From Forums
	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}

	
}
