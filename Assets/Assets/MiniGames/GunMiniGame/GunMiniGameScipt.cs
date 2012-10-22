using UnityEngine;
using System.Collections;

public class GunMiniGameScipt : MonoBehaviour {

	//public GUITexture clickScreen;
	public UIButton clickScreenButton;
	
	public UIButton gunDialButton;
	
	public UIFilledSprite gunDialMaskCrit1;
	public Vector3 gunDialMaskCrit1InitialPosition;
	public UIFilledSprite gunDialMaskCrit2;
	public Vector3 gunDialMaskCrit2InitialPosition;
	public UIFilledSprite gunDialMaskCrit3;
	public Vector3 gunDialMaskCrit3InitialPosition;
	public UIFilledSprite gunDialMaskCrit4;
	public Vector3 gunDialMaskCrit4InitialPosition;
	public UIFilledSprite gunDialMaskCrit5;
	public Vector3 gunDialMaskCrit5InitialPosition;
	public UIFilledSprite gunDialMaskCrit6;
	public Vector3 gunDialMaskCrit6InitialPosition;
	
	public UIFilledSprite gunDialMaskNormal1;
	public Vector3 gunDialMaskNormal1InitialPosition;
	public UIFilledSprite gunDialMaskNormal2;
	public Vector3 gunDialMaskNormal2InitialPosition;
	public UIFilledSprite gunDialMaskNormal3;
	public Vector3 gunDialMaskNormal3InitialPosition;
	public UIFilledSprite gunDialMaskNormal4;
	public Vector3 gunDialMaskNormal4InitialPosition;
	public UIFilledSprite gunDialMaskNormal5;
	public Vector3 gunDialMaskNormal5InitialPosition;
	public UIFilledSprite gunDialMaskNormal6;
	public Vector3 gunDialMaskNormal6InitialPosition;
	
	public UIFilledSprite critLabel1;
	public UIFilledSprite critLabel2;
	public UIFilledSprite critLabel3;
	public UIFilledSprite critLabel4;
	public UIFilledSprite critLabel5;
	public UIFilledSprite critLabel6;

	
	public UIFilledSprite arrow;
	
	public int ArrowSpeed = 5;
	
	public int StartingDial = 1;
	
	public Player player;
	
	public Vector3 stopPosition;
	public float attackDistanceFromCenter;
	
	[System.Serializable]
	public class Mask{
		public float fillAmount;
		
		public float rangeMin;
		public float rangeMax;
		
		public bool isClicked;
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
	
	public enum Attack{NoHit,Normal,Crit, Miss, BeenClicked};
	public Attack currentAttack = Attack.NoHit;
	
	public float startTimer = 0;
	
	public void populateMasks(){
		
		
		#region Scarlet Shot
		gunAbilityDials.scarletShot[0].numOfTaps = 1;
		//1
		gunAbilityDials.scarletShot[0].critMask.rangeMin = 316;
		gunAbilityDials.scarletShot[0].critMask.rangeMax = 330;
		gunAbilityDials.scarletShot[0].critMask.fillAmount = ((gunAbilityDials.scarletShot[0].critMask.rangeMax -
			gunAbilityDials.scarletShot[0].critMask.rangeMin)/360);
		gunAbilityDials.scarletShot[0].critMask.isClicked = false;
			
		gunAbilityDials.scarletShot[0].normalMask.rangeMin = 240;
		gunAbilityDials.scarletShot[0].normalMask.rangeMax = 315;
		gunAbilityDials.scarletShot[0].normalMask.fillAmount = ((gunAbilityDials.scarletShot[0].normalMask.rangeMax -
			gunAbilityDials.scarletShot[0].normalMask.rangeMin)/360);
		gunAbilityDials.scarletShot[0].normalMask.isClicked = false;
		#endregion
		
		#region DarkBullet
		gunAbilityDials.darkBullet[0].numOfTaps = 2;
		gunAbilityDials.darkBullet[1].numOfTaps = 2;
			//1
		gunAbilityDials.darkBullet[0].critMask.rangeMin = 226;
		gunAbilityDials.darkBullet[0].critMask.rangeMax = 240;
		gunAbilityDials.darkBullet[0].critMask.fillAmount = ((gunAbilityDials.darkBullet[0].critMask.rangeMax -
			gunAbilityDials.darkBullet[0].critMask.rangeMin)/360);
		gunAbilityDials.darkBullet[0].critMask.isClicked = false;
		
		gunAbilityDials.darkBullet[0].normalMask.rangeMin = 180;
		gunAbilityDials.darkBullet[0].normalMask.rangeMax = 225;
		gunAbilityDials.darkBullet[0].normalMask.fillAmount = ((gunAbilityDials.darkBullet[0].normalMask.rangeMax -
			gunAbilityDials.darkBullet[0].normalMask.rangeMin)/360);
		gunAbilityDials.darkBullet[0].normalMask.isClicked = false;
			//2
		gunAbilityDials.darkBullet[1].critMask.rangeMin = 270;
		gunAbilityDials.darkBullet[1].critMask.rangeMax = 285;
		gunAbilityDials.darkBullet[1].critMask.fillAmount = ((gunAbilityDials.darkBullet[1].critMask.rangeMax -
			gunAbilityDials.darkBullet[1].critMask.rangeMin)/360);
		gunAbilityDials.darkBullet[1].normalMask.isClicked = false;
		
		gunAbilityDials.darkBullet[1].normalMask.rangeMin = 286;
		gunAbilityDials.darkBullet[1].normalMask.rangeMax = 300;
		gunAbilityDials.darkBullet[1].normalMask.fillAmount = ((gunAbilityDials.darkBullet[1].normalMask.rangeMax -
			gunAbilityDials.darkBullet[1].normalMask.rangeMin)/360);
		gunAbilityDials.darkBullet[1].normalMask.isClicked = false;
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
		gunAbilityDials.plagueBlast[0].critMask.isClicked = false;
		
		gunAbilityDials.plagueBlast[0].normalMask.rangeMin = 31;
		gunAbilityDials.plagueBlast[0].normalMask.rangeMax = 80;
		gunAbilityDials.plagueBlast[0].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[0].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[0].normalMask.rangeMin)/360);
		gunAbilityDials.plagueBlast[0].normalMask.isClicked = false;
			//2
		gunAbilityDials.plagueBlast[1].critMask.rangeMin = 110;
		gunAbilityDials.plagueBlast[1].critMask.rangeMax = 120;
		gunAbilityDials.plagueBlast[1].critMask.fillAmount = ((gunAbilityDials.plagueBlast[1].critMask.rangeMax -
			gunAbilityDials.plagueBlast[1].critMask.rangeMin)/360);
		gunAbilityDials.plagueBlast[1].critMask.isClicked = false;
		
		gunAbilityDials.plagueBlast[1].normalMask.rangeMin = 121;
		gunAbilityDials.plagueBlast[1].normalMask.rangeMax = 150;
		gunAbilityDials.plagueBlast[1].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[1].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[1].normalMask.rangeMin)/360);
		gunAbilityDials.plagueBlast[1].normalMask.isClicked = false;
			//3
		gunAbilityDials.plagueBlast[2].critMask.rangeMin = 210;
		gunAbilityDials.plagueBlast[2].critMask.rangeMax = 220;
		gunAbilityDials.plagueBlast[2].critMask.fillAmount = ((gunAbilityDials.plagueBlast[2].critMask.rangeMax -
			gunAbilityDials.plagueBlast[2].critMask.rangeMin)/360);
		gunAbilityDials.plagueBlast[2].critMask.isClicked = false;
		
		gunAbilityDials.plagueBlast[2].normalMask.rangeMin = 221;
		gunAbilityDials.plagueBlast[2].normalMask.rangeMax = 260;
		gunAbilityDials.plagueBlast[2].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[2].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[2].normalMask.rangeMin)/360);
		gunAbilityDials.plagueBlast[2].normalMask.isClicked = false;
			//4
		gunAbilityDials.plagueBlast[3].critMask.rangeMin = 330;
		gunAbilityDials.plagueBlast[3].critMask.rangeMax = 340;
		gunAbilityDials.plagueBlast[3].critMask.fillAmount = ((gunAbilityDials.plagueBlast[3].critMask.rangeMax -
			gunAbilityDials.plagueBlast[3].critMask.rangeMin)/360);
		gunAbilityDials.plagueBlast[3].critMask.isClicked = false;
		
		gunAbilityDials.plagueBlast[3].normalMask.rangeMin = 341;
		gunAbilityDials.plagueBlast[3].normalMask.rangeMax = 359;
		gunAbilityDials.plagueBlast[3].normalMask.fillAmount = ((gunAbilityDials.plagueBlast[3].normalMask.rangeMax -
			gunAbilityDials.plagueBlast[3].normalMask.rangeMin)/360);
		gunAbilityDials.plagueBlast[3].normalMask.isClicked = false;
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
		gunAbilityDials.blitzBarrage[0].critMask.isClicked = false;
		
		gunAbilityDials.blitzBarrage[0].normalMask.rangeMin = 60;
		gunAbilityDials.blitzBarrage[0].normalMask.rangeMax = 90;
		gunAbilityDials.blitzBarrage[0].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[0].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[0].normalMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[0].normalMask.isClicked = false;
		//2
		gunAbilityDials.blitzBarrage[1].critMask.rangeMin = 130;
		gunAbilityDials.blitzBarrage[1].critMask.rangeMax = 140;
		gunAbilityDials.blitzBarrage[1].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[1].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[1].critMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[1].critMask.isClicked = false;
		
		gunAbilityDials.blitzBarrage[1].normalMask.rangeMin = 120;
		gunAbilityDials.blitzBarrage[1].normalMask.rangeMax = 150;
		gunAbilityDials.blitzBarrage[1].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[1].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[1].normalMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[1].normalMask.isClicked = false;
		//3
		gunAbilityDials.blitzBarrage[2].critMask.rangeMin = 190;
		gunAbilityDials.blitzBarrage[2].critMask.rangeMax = 200;
		gunAbilityDials.blitzBarrage[2].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[2].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[2].critMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[2].critMask.isClicked = false;
		
		gunAbilityDials.blitzBarrage[2].normalMask.rangeMin = 180;
		gunAbilityDials.blitzBarrage[2].normalMask.rangeMax = 210;
		gunAbilityDials.blitzBarrage[2].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[2].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[2].normalMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[2].normalMask.isClicked = false;
		//4
		gunAbilityDials.blitzBarrage[3].critMask.rangeMin = 250;
		gunAbilityDials.blitzBarrage[3].critMask.rangeMax = 260;
		gunAbilityDials.blitzBarrage[3].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[3].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[3].critMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[3].critMask.isClicked = false;
		
		gunAbilityDials.blitzBarrage[3].normalMask.rangeMin = 240;
		gunAbilityDials.blitzBarrage[3].normalMask.rangeMax = 270;
		gunAbilityDials.blitzBarrage[3].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[3].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[3].normalMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[3].normalMask.isClicked = false;
		//5
		gunAbilityDials.blitzBarrage[4].critMask.rangeMin = 310;
		gunAbilityDials.blitzBarrage[4].critMask.rangeMax = 320;
		gunAbilityDials.blitzBarrage[4].critMask.fillAmount = ((gunAbilityDials.blitzBarrage[4].critMask.rangeMax -
			gunAbilityDials.blitzBarrage[4].critMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[4].critMask.isClicked = false;
		
		gunAbilityDials.blitzBarrage[4].normalMask.rangeMin = 300;
		gunAbilityDials.blitzBarrage[4].normalMask.rangeMax = 330;
		gunAbilityDials.blitzBarrage[4].normalMask.fillAmount = ((gunAbilityDials.blitzBarrage[4].normalMask.rangeMax -
			gunAbilityDials.blitzBarrage[4].normalMask.rangeMin)/360);
		gunAbilityDials.blitzBarrage[4].normalMask.isClicked = false;
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
		gunAbilityDials.shadowFlameShot[0].critMask.isClicked = false;
		
		gunAbilityDials.shadowFlameShot[0].normalMask.rangeMin = 60;
		gunAbilityDials.shadowFlameShot[0].normalMask.rangeMax = 90;
		gunAbilityDials.shadowFlameShot[0].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[0].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[0].normalMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[0].normalMask.isClicked = false;
		//2
		gunAbilityDials.shadowFlameShot[1].critMask.rangeMin = 123;
		gunAbilityDials.shadowFlameShot[1].critMask.rangeMax = 133;
		gunAbilityDials.shadowFlameShot[1].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[1].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[1].critMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[1].critMask.isClicked = false;
		
		gunAbilityDials.shadowFlameShot[1].normalMask.rangeMin = 113;
		gunAbilityDials.shadowFlameShot[1].normalMask.rangeMax = 143;
		gunAbilityDials.shadowFlameShot[1].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[1].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[1].normalMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[1].normalMask.isClicked = false;
		//3
		gunAbilityDials.shadowFlameShot[2].critMask.rangeMin = 176;
		gunAbilityDials.shadowFlameShot[2].critMask.rangeMax = 186;
		gunAbilityDials.shadowFlameShot[2].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[2].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[2].critMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[2].critMask.isClicked = false;
		
		gunAbilityDials.shadowFlameShot[2].normalMask.rangeMin = 166;
		gunAbilityDials.shadowFlameShot[2].normalMask.rangeMax = 196;
		gunAbilityDials.shadowFlameShot[2].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[2].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[2].normalMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[2].normalMask.isClicked = false;
		//4
		gunAbilityDials.shadowFlameShot[3].critMask.rangeMin = 219;
		gunAbilityDials.shadowFlameShot[3].critMask.rangeMax = 229;
		gunAbilityDials.shadowFlameShot[3].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[3].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[3].critMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[3].critMask.isClicked = false;
		
		gunAbilityDials.shadowFlameShot[3].normalMask.rangeMin = 219;
		gunAbilityDials.shadowFlameShot[3].normalMask.rangeMax = 249;
		gunAbilityDials.shadowFlameShot[3].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[3].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[3].normalMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[3].normalMask.isClicked = false;
		//5
		gunAbilityDials.shadowFlameShot[4].critMask.rangeMin = 282;
		gunAbilityDials.shadowFlameShot[4].critMask.rangeMax = 292;
		gunAbilityDials.shadowFlameShot[4].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[4].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[4].critMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[4].critMask.isClicked = false;
		
		gunAbilityDials.shadowFlameShot[4].normalMask.rangeMin = 272;
		gunAbilityDials.shadowFlameShot[4].normalMask.rangeMax = 292;
		gunAbilityDials.shadowFlameShot[4].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[4].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[4].normalMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[4].normalMask.isClicked = false;
		//6
		gunAbilityDials.shadowFlameShot[5].critMask.rangeMin = 345;
		gunAbilityDials.shadowFlameShot[5].critMask.rangeMax = 355;
		gunAbilityDials.shadowFlameShot[5].critMask.fillAmount = ((gunAbilityDials.shadowFlameShot[5].critMask.rangeMax -
			gunAbilityDials.shadowFlameShot[5].critMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[5].critMask.isClicked = false;
		
		gunAbilityDials.shadowFlameShot[5].normalMask.rangeMin = 315;
		gunAbilityDials.shadowFlameShot[5].normalMask.rangeMax = 345;
		gunAbilityDials.shadowFlameShot[5].normalMask.fillAmount = ((gunAbilityDials.shadowFlameShot[5].normalMask.rangeMax -
			gunAbilityDials.shadowFlameShot[5].normalMask.rangeMin)/360);
		gunAbilityDials.shadowFlameShot[5].normalMask.isClicked = false;
		
		#endregion
		
	}
	
	
	void Start(){

		ArrowSpeed = 5;
		
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
		gunDialMaskCrit6.fillDirection = UIFilledSprite.FillDirection.Radial360;
		
		gunDialMaskNormal1.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal2.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal3.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal4.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal5.fillDirection = UIFilledSprite.FillDirection.Radial360;
		gunDialMaskNormal6.fillDirection = UIFilledSprite.FillDirection.Radial360;
		
		gunDialMaskCrit1InitialPosition = gunDialMaskCrit1.transform.localPosition;
		gunDialMaskCrit2InitialPosition = gunDialMaskCrit2.transform.localPosition;
		gunDialMaskCrit3InitialPosition = gunDialMaskCrit3.transform.localPosition;
		gunDialMaskCrit4InitialPosition = gunDialMaskCrit4.transform.localPosition;
		gunDialMaskCrit5InitialPosition = gunDialMaskCrit5.transform.localPosition;
		gunDialMaskCrit6InitialPosition = gunDialMaskCrit6.transform.localPosition;
		
		gunDialMaskNormal1InitialPosition = gunDialMaskNormal1.transform.localPosition;
		gunDialMaskNormal2InitialPosition = gunDialMaskNormal2.transform.localPosition;
		gunDialMaskNormal3InitialPosition = gunDialMaskNormal3.transform.localPosition;
		gunDialMaskNormal4InitialPosition = gunDialMaskNormal4.transform.localPosition;
		gunDialMaskNormal5InitialPosition = gunDialMaskNormal5.transform.localPosition;
		gunDialMaskNormal6InitialPosition = gunDialMaskNormal6.transform.localPosition;
		
		if(critLabel1 != null)
			critLabel1.fillAmount = 0;
		if(critLabel2 != null)
			critLabel2.fillAmount = 0;
		if(critLabel3 != null)
			critLabel3.fillAmount = 0;
		if(critLabel4 != null)
			critLabel4.fillAmount = 0;
		if(critLabel5 != null)
			critLabel5.fillAmount = 0;
		if(critLabel6 != null)
			critLabel6.fillAmount = 0;
		
	}
	
	public void setDial(int gunAbilityChosen){
		
		
			gunDialButton.isEnabled = true;
			gunDialButton.defaultColor = Color.white;
			
			arrow.color = Color.white;
	
		//Set to Apropriate dial
		//Also set CritLabels
		#region Set to Appropriate dial
		switch(gunAbilityChosen){
			
			
		//Set to ScarletShot
		case 0:
			//Set player's max clicks
			player.clickMax = gunAbilityDials.scarletShot[0].numOfTaps;
			
			/*Vector3 newCritPosition1 = gunDialMaskCrit1.transform.position;
			newCritPosition1.x = gunDialMaskCrit1.sprite.inner.center.x + (gunDialMaskCrit1.sprite.inner.height/2)*Mathf.Cos(gunAbilityDials.scarletShot[0].critMask.rangeMin);

			newCritPosition1.z= gunDialMaskCrit1.transform.localPosition.z + (gunDialMaskCrit1.sprite.inner.height/2)*Mathf.Sin(gunAbilityDials.scarletShot[0].critMask.rangeMin);
			float yRotation = 0 * Mathf.Deg2Rad - (gunAbilityDials.scarletShot[0].critMask.rangeMin); 
  			gunDialMaskCrit1.transform.rotation = Quaternion.EulerAngles(0,yRotation,0);
  			gunDialMaskCrit1.transform.position = newCritPosition1;
			
			Vector3 newNormalPosition1 = gunDialMaskNormal1.transform.position;
			newNormalPosition1.x = gunDialMaskNormal1.sprite.inner.center.x + (gunDialMaskNormal1.sprite.inner.height/2)*Mathf.Cos(gunAbilityDials.scarletShot[0].normalMask.rangeMin);

			newNormalPosition1.z= gunDialMaskNormal1.transform.localPosition.z + (gunDialMaskNormal1.sprite.inner.height/2)*Mathf.Sin(gunAbilityDials.scarletShot[0].normalMask.rangeMin);
			float yRotation2 = 0 * Mathf.Deg2Rad - (gunAbilityDials.scarletShot[0].normalMask.rangeMin);
  			gunDialMaskNormal1.transform.rotation = Quaternion.EulerAngles(0,yRotation2,0);
  			gunDialMaskNormal1.transform.position = newNormalPosition1;*/
			
			
			//Crit 1
			gunDialMaskCrit1.fillAmount = gunAbilityDials.scarletShot[0].critMask.fillAmount;
			gunDialMaskCrit1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.scarletShot[0].critMask.rangeMin);
			//gunDialMaskCrit1.transform.RotateAroundLocal(Vector3.forward,gunAbilityDials.scarletShot[0].critMask.rangeMin);
			//gunDialMaskCrit1.transform.RotateAroundLocal(Vector3.forward,gunAbilityDials.scarletShot[0].critMask.rangeMin);
			//gunDialMaskCrit1.transform.position = Quaternion.FromToRotation(gunDialMaskCrit1InitialPosition,
			
			//Norm 1
			gunDialMaskNormal1.fillAmount = gunAbilityDials.scarletShot[0].normalMask.fillAmount;
			gunDialMaskNormal1.transform.eulerAngles = new Vector3(0,0,gunAbilityDials.scarletShot[0].normalMask.rangeMin);
			//gunDialMaskNormal1.transform.RotateAroundLocal(Vector3.forward,gunAbilityDials.scarletShot[0].normalMask.rangeMin);
			//gunDialMaskNormal1.transform.position = Quaternion.FromToRotation(gunDialMaskNormal1InitialPosition,
				//new Vector3(0,0,gunAbilityDials.scarletShot[0].normalMask.rangeMin));
		
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
				stoppedAngle > gunAbilityDials.scarletShot[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				
				if(gunAbilityDials.scarletShot[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.scarletShot[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal hit
			else if(stoppedAngle < gunAbilityDials.scarletShot[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.scarletShot[0].normalMask.rangeMin){
				
				if(gunAbilityDials.scarletShot[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.scarletShot[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else
				return Attack.Miss;

			
		//Dark Bullet
		case 2:
			//Check Crit hit
			if(stoppedAngle < gunAbilityDials.darkBullet[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityDials.darkBullet[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.darkBullet[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.darkBullet[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				
				if(gunAbilityDials.darkBullet[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.darkBullet[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal hit
			else if(stoppedAngle < gunAbilityDials.darkBullet[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[0].normalMask.rangeMin){
				
				if(gunAbilityDials.darkBullet[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.darkBullet[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.darkBullet[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.darkBullet[1].normalMask.rangeMin){
				
				if(gunAbilityDials.darkBullet[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.darkBullet[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else
				return Attack.Miss;

		
		//PlagueBlast
		case 3:
			//Check Crit Hit
			if(stoppedAngle < gunAbilityDials.plagueBlast[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityDials.plagueBlast[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.plagueBlast[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				if(gunAbilityDials.plagueBlast[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.plagueBlast[2].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[2].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel3 != null){
					critLabel3.transform.localPosition = stopPosition;
					critLabel3.fillAmount = 1;
				}
				
				if(gunAbilityDials.plagueBlast[2].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[2].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.plagueBlast[3].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[3].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel4 != null){
					critLabel4.transform.localPosition = stopPosition;
					critLabel4.fillAmount = 1;
				}
				
				if(gunAbilityDials.plagueBlast[3].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[3].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal Hit
			else if(stoppedAngle < gunAbilityDials.plagueBlast[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[0].normalMask.rangeMin){
				
				if(gunAbilityDials.plagueBlast[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.plagueBlast[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[1].normalMask.rangeMin){
				
				if(gunAbilityDials.plagueBlast[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.plagueBlast[2].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[2].normalMask.rangeMin){
				
				if(gunAbilityDials.plagueBlast[2].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[2].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.plagueBlast[3].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.plagueBlast[3].normalMask.rangeMin){
				
				if(gunAbilityDials.plagueBlast[3].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.plagueBlast[3].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else
				return Attack.Miss;
			

			
		//BlitzBarrage
		case 4:
			//Check Crit Hit
			if(stoppedAngle < gunAbilityDials.blitzBarrage[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityDials.blitzBarrage[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				if(gunAbilityDials.blitzBarrage[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[2].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[2].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel3 != null){
					critLabel3.transform.localPosition = stopPosition;
					critLabel3.fillAmount = 1;
				}
				
				if(gunAbilityDials.blitzBarrage[2].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[2].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[3].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[3].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel4 != null){
					critLabel4.transform.localPosition = stopPosition;
					critLabel4.fillAmount = 1;
				}
				
				if(gunAbilityDials.blitzBarrage[3].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[3].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[4].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[4].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel5 != null){
					critLabel5.transform.localPosition = stopPosition;
					critLabel5.fillAmount = 1;
				}
				
				if(gunAbilityDials.blitzBarrage[4].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[4].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal Hit
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[0].normalMask.rangeMin){
				
				
				if(gunAbilityDials.blitzBarrage[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[1].normalMask.rangeMin){
				
				if(gunAbilityDials.blitzBarrage[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[2].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[2].normalMask.rangeMin){
				
				if(gunAbilityDials.blitzBarrage[2].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[2].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[3].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[3].normalMask.rangeMin){
				
				if(gunAbilityDials.blitzBarrage[3].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[3].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.blitzBarrage[4].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.blitzBarrage[4].normalMask.rangeMin){
				
				if(gunAbilityDials.blitzBarrage[4].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.blitzBarrage[4].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else
				return Attack.Miss;

			
		//ShadowFlameShot
		case 5:
			//Check Crit Hit
			if(stoppedAngle < gunAbilityDials.shadowFlameShot[0].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityDials.shadowFlameShot[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[1].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				if(gunAbilityDials.shadowFlameShot[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[2].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[2].critMask.rangeMin){
				
				
				//Move CritLabel
				if(critLabel3 != null){
					critLabel3.transform.localPosition = stopPosition;
					critLabel3.fillAmount = 1;
				}
				
				if(gunAbilityDials.shadowFlameShot[2].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[2].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[3].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[3].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel4 != null){
					critLabel4.transform.localPosition = stopPosition;
					critLabel4.fillAmount = 1;
				}
				
				if(gunAbilityDials.shadowFlameShot[3].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[3].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[4].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[4].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel5 != null){
					critLabel5.transform.localPosition = stopPosition;
					critLabel5.fillAmount = 1;
				}
				
				if(gunAbilityDials.shadowFlameShot[4].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[4].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[5].critMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[5].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel6 != null){
					critLabel6.transform.localPosition = stopPosition;
					critLabel6.fillAmount = 1;
				}
				
				if(gunAbilityDials.shadowFlameShot[5].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[5].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal Hit
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[0].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[0].normalMask.rangeMin){
				
				
				if(gunAbilityDials.shadowFlameShot[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[1].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[1].normalMask.rangeMin){
				
				if(gunAbilityDials.shadowFlameShot[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[2].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[2].normalMask.rangeMin){
				
				if(gunAbilityDials.shadowFlameShot[2].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[2].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[3].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[3].normalMask.rangeMin){
				
				if(gunAbilityDials.shadowFlameShot[3].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[3].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[4].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[4].normalMask.rangeMin){
				
				if(gunAbilityDials.shadowFlameShot[4].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[4].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedAngle < gunAbilityDials.shadowFlameShot[5].normalMask.rangeMax &&
				stoppedAngle > gunAbilityDials.shadowFlameShot[5].normalMask.rangeMin){
				
				if(gunAbilityDials.shadowFlameShot[5].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityDials.shadowFlameShot[5].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else
				return Attack.Miss;

			
			
		default:
				return Attack.Miss;

		}
		
		
	}

	
	
	void OnClick(){
		
		if(player.TurnPhases == 5){
			//isRotating = false;
		
			stopPosition = arrow.transform.localPosition;
		
			currentAttack = didLand(currentAttack);
		
			if(currentAttack != Attack.BeenClicked){
				clickCounter++;
				player.clickCounter++;
			}
		
			player.lastGunHit = (Player.LastGunHit) currentAttack;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		gunDialButton.UpdateColor(true,true);
		
		if(player.TurnPhases == 5){
			
			if(clickScreenButton != null)
				clickScreenButton.isEnabled = true;
			
			
			if(player.isDialSet == false){
				startTimer = Time.time + 1;
				
				setDial((player.gunAbilityChosen - 1));
				player.isDialSet = true;	
			}
			
			//Move Arrow
			arrow.transform.RotateAround(gunDialButton.transform.position,
				Vector3.forward, ArrowSpeed * Time.deltaTime);
		
		
		
			currentPosition = arrow.transform.localPosition;
		
		
			distanceFromCenter = findAngle(initialPosition, currentPosition, referenceRight);
			attackDistanceFromCenter = findAngle(initialPosition, stopPosition, referenceRight);
			
			//Stop Minigame if Arrow makes OneRotation
			if(startTimer != 0){
				if(Time.time >= startTimer){
					if(distanceFromCenter <= 1 && distanceFromCenter >= 0){
						
						player.clickCounter = player.clickMax;
					
					}
				}
			}
		}
		else{
			//Hide Everything
			gunDialButton.isEnabled = false;
			gunDialButton.defaultColor = Color.clear;
			
			arrow.color = Color.clear;
			arrow.transform.localPosition = initialPosition;
			arrow.transform.localRotation = new Quaternion(0,0,0,0);
			
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
			
			//Hide CritLabels
			//AlsoReset CritLabels
			critLabel1.fillAmount = 0;
			critLabel2.fillAmount = 0;
			critLabel3.fillAmount = 0;
			critLabel4.fillAmount = 0;
			critLabel5.fillAmount = 0;
			critLabel6.fillAmount = 0;
			
			//Reset all Dial's isClicked
			resetDialIsClicked();
			
			if(clickScreenButton != null)
				clickScreenButton.isEnabled = false;
			
		}
		
	}
	
	void resetDialIsClicked(){
	
		//Scarlet Shot
		for(int i = 0; i < 1; i++){
			gunAbilityDials.scarletShot[i].critMask.isClicked = false;
			gunAbilityDials.scarletShot[i].normalMask.isClicked = false;	
		}
		//Dark Shot
		for(int j = 0; j < gunAbilityDials.darkBullet.Length; j++){
			gunAbilityDials.darkBullet[j].critMask.isClicked = false;
			gunAbilityDials.darkBullet[j].normalMask.isClicked = false;
		}
		//Plague Blast
		for(int k = 0; k < gunAbilityDials.plagueBlast.Length; k++){
			gunAbilityDials.plagueBlast[k].critMask.isClicked = false;
			gunAbilityDials.plagueBlast[k].normalMask.isClicked = false;
		}
		//Blitz Barrage
		for(int l = 0; l < gunAbilityDials.blitzBarrage.Length; l++){
			gunAbilityDials.blitzBarrage[l].critMask.isClicked = false;
			gunAbilityDials.blitzBarrage[l].normalMask.isClicked = false;
		}
		//ShadowFlame Shot
		for(int m = 0; m < gunAbilityDials.blitzBarrage.Length; m++){
			gunAbilityDials.shadowFlameShot[m].critMask.isClicked = false;
			gunAbilityDials.shadowFlameShot[m].normalMask.isClicked = false;
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
