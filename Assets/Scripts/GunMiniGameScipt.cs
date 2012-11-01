using UnityEngine;
using System.Collections;

public class GunMiniGameScipt : MonoBehaviour {

	//public GUITexture clickScreen;
	public UIButton clickScreenButton;
	
	public UIFilledSprite gunBar;
	
	//Icons for bar
	[System.Serializable]
	public class GunBarIcons{
	
		public UIFilledSprite gunIcon1;
		public UIFilledSprite gunIcon2;
		public UIFilledSprite gunIcon3;
		public UIFilledSprite gunIcon4;
		public UIFilledSprite gunIcon5;
		
	}
	
	public GunBarIcons gunBarIcons = new GunBarIcons();
	
	public UIFilledSprite gunBarMaskCrit1;
	public UIFilledSprite gunBarMaskCrit2;
	public UIFilledSprite gunBarMaskCrit3;
	public UIFilledSprite gunBarMaskCrit4;
	public UIFilledSprite gunBarMaskCrit5;
	public UIFilledSprite gunBarMaskCrit6;
	
	public UIFilledSprite gunBarMaskNormal1;
	public UIFilledSprite gunBarMaskNormal2;
	public UIFilledSprite gunBarMaskNormal3;
	public UIFilledSprite gunBarMaskNormal4;
	public UIFilledSprite gunBarMaskNormal5;
	public UIFilledSprite gunBarMaskNormal6;
	
	public UIFilledSprite critLabel1;
	public UIFilledSprite critLabel2;
	public UIFilledSprite critLabel3;
	public UIFilledSprite critLabel4;
	public UIFilledSprite critLabel5;
	public UIFilledSprite critLabel6;
	
	public UIFilledSprite normalLabel1;
	public UIFilledSprite normalLabel2;
	public UIFilledSprite normalLabel3;
	public UIFilledSprite normalLabel4;
	public UIFilledSprite normalLabel5;
	public UIFilledSprite normalLabel6;
	
	public UIFilledSprite missLabel;

	
	public UIFilledSprite arrow;
	
	public int ArrowSpeed;
	
	public int StartingBar = 1;
	
	public Player player;
	
	public Vector3 stopPosition;
	public float attackDistanceFromStart;
	
	[System.Serializable]
	public class Mask{
		//public float fillAmount;
		public Vector3 initialScale;
		//public Vector3 currentScale;
		
		public Vector3 initialPosition;
		//public Vector3 currentPosition;
		
		public float scaleMultiplier;
		
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
	public class GunAbilityBars{
	
		public GunAbilityMaskGroup[] scarletShot = new GunAbilityMaskGroup[1];
		
		public GunAbilityMaskGroup[] darkBullet = new GunAbilityMaskGroup[2];
		
		public GunAbilityMaskGroup[] plagueBlast = new GunAbilityMaskGroup[4];
		
		public GunAbilityMaskGroup[] blitzBarrage = new GunAbilityMaskGroup[5];
		
		public GunAbilityMaskGroup[] shadowFlameShot = new GunAbilityMaskGroup[6];
		
	}
	
	public GunAbilityBars gunAbilityBars = new GunAbilityBars();
	
	
	public float clickCounter = 0;
	
	public float distanceFromStart;
	
	
	public Vector3 arrowInitialPosition;
	public Vector3 arrowCurrentPosition;
	
	public enum Attack{NoHit,Normal,Crit, Miss, BeenClicked};
	public Attack currentAttack = Attack.NoHit;
	
	public float startTimer = 0;
	
	public float arrowColorTimer = 0;
	
	public void populateMasks(){
		
		
		#region Scarlet Shot
		gunAbilityBars.scarletShot[0].numOfTaps = 1;
		//1
		gunAbilityBars.scarletShot[0].normalMask.initialScale = new Vector3((gunBarMaskNormal1.transform.localScale.x * 3),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.scarletShot[0].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.scarletShot[0].normalMask.rangeMin = gunAbilityBars.scarletShot[0].normalMask.initialPosition.x + 125;
		gunAbilityBars.scarletShot[0].normalMask.rangeMax = gunAbilityBars.scarletShot[0].normalMask.rangeMin +
			gunAbilityBars.scarletShot[0].normalMask.initialScale.x;
		gunAbilityBars.scarletShot[0].normalMask.isClicked = false;
		
		gunAbilityBars.scarletShot[0].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.scarletShot[0].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.scarletShot[0].critMask.rangeMin = gunAbilityBars.scarletShot[0].normalMask.rangeMax -
			gunAbilityBars.scarletShot[0].critMask.initialScale.x;
		gunAbilityBars.scarletShot[0].critMask.rangeMax = gunAbilityBars.scarletShot[0].critMask.rangeMin +
			gunAbilityBars.scarletShot[0].critMask.initialScale.x;
		gunAbilityBars.scarletShot[0].critMask.isClicked = false;	
		
		/*gunAbilityBars.scarletShot[0].normalMask.initialScale = new Vector3((gunBarMaskNormal1.transform.localScale.x * 3),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.scarletShot[0].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.scarletShot[0].normalMask.rangeMin = gunAbilityBars.scarletShot[0].normalMask.initialPosition.x;
		gunAbilityBars.scarletShot[0].normalMask.rangeMax = gunAbilityBars.scarletShot[0].normalMask.rangeMin +
			gunAbilityBars.scarletShot[0].normalMask.initialScale.x;
		gunAbilityBars.scarletShot[0].normalMask.isClicked = false;*/
		#endregion
		
		#region DarkBullet
		gunAbilityBars.darkBullet[0].numOfTaps = 2;
		gunAbilityBars.darkBullet[1].numOfTaps = 2;
			//1
		gunAbilityBars.darkBullet[0].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 2.5),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.darkBullet[0].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.darkBullet[0].normalMask.rangeMin = gunAbilityBars.darkBullet[0].normalMask.initialPosition.x + 30;
		gunAbilityBars.darkBullet[0].normalMask.rangeMax = gunAbilityBars.darkBullet[0].normalMask.rangeMin +
			gunAbilityBars.darkBullet[0].normalMask.initialScale.x;
		gunAbilityBars.darkBullet[0].normalMask.isClicked = false;
		
		gunAbilityBars.darkBullet[0].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.darkBullet[0].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.darkBullet[0].critMask.rangeMin = gunAbilityBars.darkBullet[0].normalMask.rangeMin;
		gunAbilityBars.darkBullet[0].critMask.rangeMax = gunAbilityBars.darkBullet[0].critMask.rangeMin +
			gunAbilityBars.darkBullet[0].critMask.initialScale.x;
		gunAbilityBars.darkBullet[0].critMask.isClicked = false;
		
			//2
		gunAbilityBars.darkBullet[1].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 2.5),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.darkBullet[1].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.darkBullet[1].normalMask.rangeMin = gunAbilityBars.darkBullet[1].normalMask.initialPosition.x + 250;
		gunAbilityBars.darkBullet[1].normalMask.rangeMax = gunAbilityBars.darkBullet[1].normalMask.rangeMin +
			gunAbilityBars.darkBullet[1].normalMask.initialScale.x;
		gunAbilityBars.darkBullet[1].normalMask.isClicked = false;
		
		gunAbilityBars.darkBullet[1].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.darkBullet[1].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.darkBullet[1].critMask.rangeMin = gunAbilityBars.darkBullet[1].normalMask.rangeMax -
			gunAbilityBars.darkBullet[1].critMask.initialScale.x;
		gunAbilityBars.darkBullet[1].critMask.rangeMax = gunAbilityBars.darkBullet[1].critMask.rangeMin +
			gunAbilityBars.darkBullet[1].critMask.initialScale.x;
		gunAbilityBars.darkBullet[1].critMask.isClicked = false;
		#endregion
		
		#region PlagueBlast
		gunAbilityBars.plagueBlast[0].numOfTaps = 4;
		gunAbilityBars.plagueBlast[1].numOfTaps = 4;
		gunAbilityBars.plagueBlast[2].numOfTaps = 4;
		gunAbilityBars.plagueBlast[3].numOfTaps = 4;

			//1
		gunAbilityBars.plagueBlast[0].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.25),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.plagueBlast[0].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.plagueBlast[0].normalMask.rangeMin = gunAbilityBars.plagueBlast[0].normalMask.initialPosition.x + 80;
		gunAbilityBars.plagueBlast[0].normalMask.rangeMax = gunAbilityBars.plagueBlast[0].normalMask.rangeMin +
			gunAbilityBars.plagueBlast[0].normalMask.initialScale.x;
		gunAbilityBars.plagueBlast[0].normalMask.isClicked = false;
		
		gunAbilityBars.plagueBlast[0].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.plagueBlast[0].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.plagueBlast[0].critMask.rangeMin = gunAbilityBars.plagueBlast[0].normalMask.rangeMin +
			(gunAbilityBars.plagueBlast[0].normalMask.initialScale.x/2) -
			(gunAbilityBars.plagueBlast[0].critMask.initialScale.x/2);
		gunAbilityBars.plagueBlast[0].critMask.rangeMax = gunAbilityBars.plagueBlast[0].critMask.rangeMin +
			gunAbilityBars.plagueBlast[0].critMask.initialScale.x;
		gunAbilityBars.plagueBlast[0].critMask.isClicked = false;
			//2
		gunAbilityBars.plagueBlast[1].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.25),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.plagueBlast[1].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.plagueBlast[1].normalMask.rangeMin = gunAbilityBars.plagueBlast[1].normalMask.initialPosition.x + 170;
		gunAbilityBars.plagueBlast[1].normalMask.rangeMax = gunAbilityBars.plagueBlast[1].normalMask.rangeMin +
			gunAbilityBars.plagueBlast[1].normalMask.initialScale.x;
		gunAbilityBars.plagueBlast[1].normalMask.isClicked = false;
		
		gunAbilityBars.plagueBlast[1].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.plagueBlast[1].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.plagueBlast[1].critMask.rangeMin = gunAbilityBars.plagueBlast[1].normalMask.rangeMin +
			(gunAbilityBars.plagueBlast[1].normalMask.initialScale.x/2) -
			(gunAbilityBars.plagueBlast[1].critMask.initialScale.x/2);
		gunAbilityBars.plagueBlast[1].critMask.rangeMax = gunAbilityBars.plagueBlast[1].critMask.rangeMin +
			gunAbilityBars.plagueBlast[1].critMask.initialScale.x;
		gunAbilityBars.plagueBlast[1].critMask.isClicked = false;
			//3
		gunAbilityBars.plagueBlast[2].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.25),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.plagueBlast[2].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.plagueBlast[2].normalMask.rangeMin = gunAbilityBars.plagueBlast[2].normalMask.initialPosition.x + 260;
		gunAbilityBars.plagueBlast[2].normalMask.rangeMax = gunAbilityBars.plagueBlast[2].normalMask.rangeMin +
			gunAbilityBars.plagueBlast[2].normalMask.initialScale.x;
		gunAbilityBars.plagueBlast[2].normalMask.isClicked = false;
		
		gunAbilityBars.plagueBlast[2].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.plagueBlast[2].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.plagueBlast[2].critMask.rangeMin = gunAbilityBars.plagueBlast[2].normalMask.rangeMin +
			(gunAbilityBars.plagueBlast[2].normalMask.initialScale.x/2) -
			(gunAbilityBars.plagueBlast[2].critMask.initialScale.x/2);
		gunAbilityBars.plagueBlast[2].critMask.rangeMax = gunAbilityBars.plagueBlast[2].critMask.rangeMin +
			gunAbilityBars.plagueBlast[2].critMask.initialScale.x;
		gunAbilityBars.plagueBlast[2].critMask.isClicked = false;
			//4
		gunAbilityBars.plagueBlast[3].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.25),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.plagueBlast[3].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.plagueBlast[3].normalMask.rangeMin = gunAbilityBars.plagueBlast[3].normalMask.initialPosition.x + 350;
		gunAbilityBars.plagueBlast[3].normalMask.rangeMax = gunAbilityBars.plagueBlast[3].normalMask.rangeMin +
			gunAbilityBars.plagueBlast[3].normalMask.initialScale.x;
		gunAbilityBars.plagueBlast[3].normalMask.isClicked = false;
		
		gunAbilityBars.plagueBlast[3].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.plagueBlast[3].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.plagueBlast[3].critMask.rangeMin = gunAbilityBars.plagueBlast[3].normalMask.rangeMin +
			(gunAbilityBars.plagueBlast[3].normalMask.initialScale.x/2) -
			(gunAbilityBars.plagueBlast[3].critMask.initialScale.x/2);
		gunAbilityBars.plagueBlast[3].critMask.rangeMax = gunAbilityBars.plagueBlast[3].critMask.rangeMin +
			gunAbilityBars.plagueBlast[3].critMask.initialScale.x;
		gunAbilityBars.plagueBlast[3].critMask.isClicked = false;
		#endregion
		
		#region BlitzBarrage
		gunAbilityBars.blitzBarrage[0].numOfTaps = 5;
		gunAbilityBars.blitzBarrage[1].numOfTaps = 5;	
		gunAbilityBars.blitzBarrage[2].numOfTaps = 5;	
		gunAbilityBars.blitzBarrage[3].numOfTaps = 5;	
		gunAbilityBars.blitzBarrage[4].numOfTaps = 5;
		
		//1
		gunAbilityBars.blitzBarrage[0].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.75),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.blitzBarrage[0].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.blitzBarrage[0].normalMask.rangeMin = gunAbilityBars.blitzBarrage[0].normalMask.initialPosition.x;
		gunAbilityBars.blitzBarrage[0].normalMask.rangeMax = gunAbilityBars.blitzBarrage[0].normalMask.rangeMin + 
			gunAbilityBars.blitzBarrage[0].normalMask.initialScale.x;
		gunAbilityBars.blitzBarrage[0].normalMask.isClicked = false;
		
		gunAbilityBars.blitzBarrage[0].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.blitzBarrage[0].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.blitzBarrage[0].critMask.rangeMin = gunAbilityBars.blitzBarrage[0].normalMask.rangeMax -
			gunAbilityBars.blitzBarrage[0].critMask.initialScale.x;
		gunAbilityBars.blitzBarrage[0].critMask.rangeMax = gunAbilityBars.blitzBarrage[0].critMask.rangeMin +
			gunAbilityBars.blitzBarrage[0].critMask.initialScale.x;
		gunAbilityBars.blitzBarrage[0].critMask.isClicked = false;
		//2
		gunAbilityBars.blitzBarrage[1].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.75),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.blitzBarrage[1].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.blitzBarrage[1].normalMask.rangeMin = gunAbilityBars.blitzBarrage[1].normalMask.initialPosition.x + 80;
		gunAbilityBars.blitzBarrage[1].normalMask.rangeMax = gunAbilityBars.blitzBarrage[1].normalMask.rangeMin +
			gunAbilityBars.blitzBarrage[1].normalMask.initialScale.x;
		gunAbilityBars.blitzBarrage[1].normalMask.isClicked = false;
		
		gunAbilityBars.blitzBarrage[1].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.blitzBarrage[1].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.blitzBarrage[1].critMask.rangeMin = gunAbilityBars.blitzBarrage[1].normalMask.rangeMin +
			(gunAbilityBars.blitzBarrage[1].normalMask.initialScale.x/2) -
			(gunAbilityBars.blitzBarrage[1].critMask.initialScale.x/2);
		gunAbilityBars.blitzBarrage[1].critMask.rangeMax = gunAbilityBars.blitzBarrage[1].critMask.rangeMin +
			gunAbilityBars.blitzBarrage[1].critMask.initialScale.x;
		gunAbilityBars.blitzBarrage[1].critMask.isClicked = false;
		//3
		gunAbilityBars.blitzBarrage[2].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.75),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.blitzBarrage[2].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.blitzBarrage[2].normalMask.rangeMin = gunAbilityBars.blitzBarrage[2].normalMask.initialPosition.x + 160;
		gunAbilityBars.blitzBarrage[2].normalMask.rangeMax = gunAbilityBars.blitzBarrage[2].normalMask.rangeMin +
			gunAbilityBars.blitzBarrage[2].normalMask.initialScale.x;
		gunAbilityBars.blitzBarrage[2].normalMask.isClicked = false;
		
		gunAbilityBars.blitzBarrage[2].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.blitzBarrage[2].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.blitzBarrage[2].critMask.rangeMin = gunAbilityBars.blitzBarrage[2].normalMask.rangeMin;;
		gunAbilityBars.blitzBarrage[2].critMask.rangeMax = gunAbilityBars.blitzBarrage[2].critMask.rangeMin +
			gunAbilityBars.blitzBarrage[2].critMask.initialScale.x;
		gunAbilityBars.blitzBarrage[2].critMask.isClicked = false;
		//4
		gunAbilityBars.blitzBarrage[3].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.75),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.blitzBarrage[3].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.blitzBarrage[3].normalMask.rangeMin = gunAbilityBars.blitzBarrage[3].normalMask.initialPosition.x + 240;
		gunAbilityBars.blitzBarrage[3].normalMask.rangeMax = gunAbilityBars.blitzBarrage[3].normalMask.rangeMin +
			gunAbilityBars.blitzBarrage[3].normalMask.initialScale.x;
		gunAbilityBars.blitzBarrage[3].normalMask.isClicked = false;
		
		gunAbilityBars.blitzBarrage[3].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.blitzBarrage[3].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.blitzBarrage[3].critMask.rangeMin = gunAbilityBars.blitzBarrage[3].normalMask.rangeMin +
			(gunAbilityBars.blitzBarrage[3].normalMask.initialScale.x/2) -
			(gunAbilityBars.blitzBarrage[3].critMask.initialScale.x/2);
		gunAbilityBars.blitzBarrage[3].critMask.rangeMax = gunAbilityBars.blitzBarrage[3].critMask.rangeMin +
			gunAbilityBars.blitzBarrage[3].critMask.initialScale.x;
		gunAbilityBars.blitzBarrage[3].critMask.isClicked = false;
		//5
		gunAbilityBars.blitzBarrage[4].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.75),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.blitzBarrage[4].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.blitzBarrage[4].normalMask.rangeMin = gunAbilityBars.blitzBarrage[4].normalMask.initialPosition.x + 320;
		gunAbilityBars.blitzBarrage[4].normalMask.rangeMax = gunAbilityBars.blitzBarrage[4].normalMask.rangeMin +
			gunAbilityBars.blitzBarrage[4].normalMask.initialScale.x;
		gunAbilityBars.blitzBarrage[4].normalMask.isClicked = false;
		
		gunAbilityBars.blitzBarrage[4].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.blitzBarrage[4].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.blitzBarrage[4].critMask.rangeMin = gunAbilityBars.blitzBarrage[4].normalMask.rangeMax -
			gunAbilityBars.blitzBarrage[4].critMask.initialScale.x;
		gunAbilityBars.blitzBarrage[4].critMask.rangeMax = gunAbilityBars.blitzBarrage[4].critMask.rangeMin +
			gunAbilityBars.blitzBarrage[4].critMask.initialScale.x;
		gunAbilityBars.blitzBarrage[4].critMask.isClicked = false;
		#endregion
		
		#region ShadowFlame Shot
		gunAbilityBars.shadowFlameShot[0].numOfTaps = 6;
		gunAbilityBars.shadowFlameShot[1].numOfTaps = 6;
		gunAbilityBars.shadowFlameShot[2].numOfTaps = 6;
		gunAbilityBars.shadowFlameShot[3].numOfTaps = 6;
		gunAbilityBars.shadowFlameShot[4].numOfTaps = 6;
		gunAbilityBars.shadowFlameShot[5].numOfTaps = 6;
		
		//1
		gunAbilityBars.shadowFlameShot[0].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.25),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.shadowFlameShot[0].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[0].normalMask.rangeMin = gunAbilityBars.shadowFlameShot[0].normalMask.initialPosition.x + 25;
		gunAbilityBars.shadowFlameShot[0].normalMask.rangeMax = gunAbilityBars.shadowFlameShot[0].normalMask.rangeMin + 
			gunAbilityBars.shadowFlameShot[0].normalMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[0].normalMask.isClicked = false;
		
		gunAbilityBars.shadowFlameShot[0].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.shadowFlameShot[0].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[0].critMask.rangeMin = gunAbilityBars.shadowFlameShot[0].normalMask.rangeMax -
			gunAbilityBars.shadowFlameShot[0].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[0].critMask.rangeMax = gunAbilityBars.shadowFlameShot[0].critMask.rangeMin +
			gunAbilityBars.shadowFlameShot[0].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[0].critMask.isClicked = false;
		//2
		gunAbilityBars.shadowFlameShot[1].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.25),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.shadowFlameShot[1].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[1].normalMask.rangeMin = gunAbilityBars.shadowFlameShot[1].normalMask.initialPosition.x + 95;
		gunAbilityBars.shadowFlameShot[1].normalMask.rangeMax = gunAbilityBars.shadowFlameShot[1].normalMask.rangeMin + 
			gunAbilityBars.shadowFlameShot[1].normalMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[1].normalMask.isClicked = false;
		
		gunAbilityBars.shadowFlameShot[1].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.shadowFlameShot[1].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[1].critMask.rangeMin = gunAbilityBars.shadowFlameShot[1].normalMask.rangeMin;
		gunAbilityBars.shadowFlameShot[1].critMask.rangeMax = gunAbilityBars.shadowFlameShot[1].normalMask.rangeMin +
			gunAbilityBars.shadowFlameShot[1].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[1].critMask.isClicked = false;
		//3
		gunAbilityBars.shadowFlameShot[2].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x * 1.25),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.shadowFlameShot[2].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[2].normalMask.rangeMin = gunAbilityBars.shadowFlameShot[2].normalMask.initialPosition.x + 160;
		gunAbilityBars.shadowFlameShot[2].normalMask.rangeMax = gunAbilityBars.shadowFlameShot[2].normalMask.rangeMin + 
			gunAbilityBars.shadowFlameShot[2].normalMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[2].normalMask.isClicked = false;
		
		gunAbilityBars.shadowFlameShot[2].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.shadowFlameShot[2].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[2].critMask.rangeMin = gunAbilityBars.shadowFlameShot[2].normalMask.rangeMin +
			(gunAbilityBars.shadowFlameShot[2].normalMask.initialScale.x/2) -
			(gunAbilityBars.shadowFlameShot[2].critMask.initialScale.x/2);
		gunAbilityBars.shadowFlameShot[2].critMask.rangeMax = gunAbilityBars.shadowFlameShot[2].critMask.rangeMin +
			gunAbilityBars.shadowFlameShot[2].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[2].critMask.isClicked = false;
		//4
		gunAbilityBars.shadowFlameShot[3].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.shadowFlameShot[3].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[3].normalMask.rangeMin = gunAbilityBars.shadowFlameShot[3].normalMask.initialPosition.x + 230;
		gunAbilityBars.shadowFlameShot[3].normalMask.rangeMax = gunAbilityBars.shadowFlameShot[3].normalMask.rangeMin + 
			gunAbilityBars.shadowFlameShot[3].normalMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[3].normalMask.isClicked = false;
		
		gunAbilityBars.shadowFlameShot[3].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.shadowFlameShot[3].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[3].critMask.rangeMin = gunAbilityBars.shadowFlameShot[3].normalMask.rangeMin;
		gunAbilityBars.shadowFlameShot[3].critMask.rangeMax = gunAbilityBars.shadowFlameShot[3].normalMask.rangeMin +
			gunAbilityBars.shadowFlameShot[3].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[3].critMask.isClicked = false;
		//5
		gunAbilityBars.shadowFlameShot[4].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.shadowFlameShot[4].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[4].normalMask.rangeMin = gunAbilityBars.shadowFlameShot[4].normalMask.initialPosition.x + 295;
		gunAbilityBars.shadowFlameShot[4].normalMask.rangeMax = gunAbilityBars.shadowFlameShot[4].normalMask.rangeMin + 
			gunAbilityBars.shadowFlameShot[4].normalMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[4].normalMask.isClicked = false;
		
		gunAbilityBars.shadowFlameShot[4].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.shadowFlameShot[4].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[4].critMask.rangeMin = gunAbilityBars.shadowFlameShot[4].normalMask.rangeMin + 
			gunAbilityBars.shadowFlameShot[4].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[4].critMask.rangeMax = gunAbilityBars.shadowFlameShot[4].critMask.rangeMin +
			gunAbilityBars.shadowFlameShot[4].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[4].critMask.isClicked = false;
		//6
		gunAbilityBars.shadowFlameShot[5].normalMask.initialScale = new Vector3((float)(gunBarMaskNormal1.transform.localScale.x),
			gunBarMaskNormal1.transform.localScale.y,
			gunBarMaskNormal1.transform.localScale.z);
		gunAbilityBars.shadowFlameShot[5].normalMask.initialPosition = gunBarMaskNormal1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[5].normalMask.rangeMin = gunAbilityBars.shadowFlameShot[5].normalMask.initialPosition.x + 360;
		gunAbilityBars.shadowFlameShot[5].normalMask.rangeMax = gunAbilityBars.shadowFlameShot[5].normalMask.rangeMin + 
			gunAbilityBars.shadowFlameShot[5].normalMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[5].normalMask.isClicked = false;
		
		gunAbilityBars.shadowFlameShot[5].critMask.initialScale = gunBarMaskCrit1.transform.localScale;
		gunAbilityBars.shadowFlameShot[5].critMask.initialPosition = gunBarMaskCrit1.transform.localPosition;
		gunAbilityBars.shadowFlameShot[5].critMask.rangeMin = gunAbilityBars.shadowFlameShot[5].normalMask.rangeMin +
			gunAbilityBars.shadowFlameShot[5].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[5].critMask.rangeMax = gunAbilityBars.shadowFlameShot[5].critMask.rangeMin +
			gunAbilityBars.shadowFlameShot[5].critMask.initialScale.x;
		gunAbilityBars.shadowFlameShot[5].critMask.isClicked = false;
		
		#endregion
		
	}
	
	
	void Start(){

		//ArrowSpeed = 150;
		
		StartingBar = 0;
		
		arrowInitialPosition = arrow.transform.localPosition;
		arrowInitialPosition = new Vector3(-153,-90,0);
		stopPosition = arrowInitialPosition;
		
		populateMasks();
	
		
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
		
		if(normalLabel1 != null)
			normalLabel1.fillAmount = 0;
		if(normalLabel2 != null)
			normalLabel2.fillAmount = 0;
		if(normalLabel3 != null)
			normalLabel3.fillAmount = 0;
		if(normalLabel4 != null)
			normalLabel4.fillAmount = 0;
		if(normalLabel5 != null)
			normalLabel5.fillAmount = 0;
		if(normalLabel6 != null)
			normalLabel6.fillAmount = 0;
		
		if(missLabel != null)
			missLabel.fillAmount = 0;
		
	}
	
	public void setBar(int gunAbilityChosen){
			
		arrow.color = Color.white;
		arrow.transform.localPosition = arrowInitialPosition;
		gunBar.fillAmount = 1;
	
		//Set to Apropriate dial
		//Also set CritLabels
		#region Set to Appropriate dial
		switch(gunAbilityChosen){
			
			
		//Set to ScarletShot
		case 0:
			//Set player's max clicks
			player.clickMax = gunAbilityBars.scarletShot[0].numOfTaps;
			
			
			//Crit 1
			gunBarMaskCrit1.transform.localPosition = new Vector3( (gunAbilityBars.scarletShot[0].critMask.rangeMin),
				gunAbilityBars.scarletShot[0].critMask.initialPosition.y,
				gunAbilityBars.scarletShot[0].critMask.initialPosition.z);
			

			
			//Norm 1
			gunBarMaskNormal1.transform.localPosition = new Vector3( (gunAbilityBars.scarletShot[0].normalMask.rangeMin),
				gunAbilityBars.scarletShot[0].normalMask.initialPosition.y,
				gunAbilityBars.scarletShot[0].normalMask.initialPosition.z);
			gunBarMaskNormal1.transform.localScale = gunAbilityBars.scarletShot[0].normalMask.initialScale;

		
			//Hide Other Bars
			gunBarMaskCrit1.fillAmount = 1;
			gunBarMaskCrit2.fillAmount = 0;
			gunBarMaskCrit3.fillAmount = 0;
			gunBarMaskCrit4.fillAmount = 0;
			gunBarMaskCrit5.fillAmount = 0;
			gunBarMaskCrit6.fillAmount = 0;
		
			gunBarMaskNormal1.fillAmount = 1;
			gunBarMaskNormal2.fillAmount = 0;
			gunBarMaskNormal3.fillAmount = 0;
			gunBarMaskNormal4.fillAmount = 0;
			gunBarMaskNormal5.fillAmount = 0;
			gunBarMaskNormal6.fillAmount = 0;
			
			gunBarIcons.gunIcon1.fillAmount = 1;
			gunBarIcons.gunIcon2.fillAmount = 0;
			gunBarIcons.gunIcon3.fillAmount = 0;
			gunBarIcons.gunIcon4.fillAmount = 0;
			gunBarIcons.gunIcon5.fillAmount = 0;
			break;
		//Set to Dark Bullet
		case 1:
			//Set player's max clicks
			player.clickMax = gunAbilityBars.darkBullet[0].numOfTaps;
			
			//Crit 1
			gunBarMaskCrit1.transform.localPosition = new Vector3( (gunAbilityBars.darkBullet[0].critMask.rangeMin),
				gunAbilityBars.darkBullet[0].critMask.initialPosition.y,
				gunAbilityBars.darkBullet[0].critMask.initialPosition.z);
			//Crit 2
			gunBarMaskCrit2.transform.localPosition = new Vector3( (gunAbilityBars.darkBullet[1].critMask.rangeMin),
				gunAbilityBars.darkBullet[1].critMask.initialPosition.y,
				gunAbilityBars.darkBullet[1].critMask.initialPosition.z);
			
			
			//Norm1
			gunBarMaskNormal1.transform.localPosition = new Vector3( (gunAbilityBars.darkBullet[0].normalMask.rangeMin),
				gunAbilityBars.darkBullet[0].normalMask.initialPosition.y,
				gunAbilityBars.darkBullet[0].normalMask.initialPosition.z);
			gunBarMaskNormal1.transform.localScale = gunAbilityBars.darkBullet[0].normalMask.initialScale;
			//Norm2
			gunBarMaskNormal2.transform.localPosition = new Vector3( (gunAbilityBars.darkBullet[1].normalMask.rangeMin),
				gunAbilityBars.darkBullet[1].normalMask.initialPosition.y,
				gunAbilityBars.darkBullet[1].normalMask.initialPosition.z);
			gunBarMaskNormal2.transform.localScale = gunAbilityBars.darkBullet[1].normalMask.initialScale;
			
			//Hide Other Bars
			gunBarMaskCrit1.fillAmount = 1;
			gunBarMaskCrit2.fillAmount = 1;
			gunBarMaskCrit3.fillAmount = 0;
			gunBarMaskCrit4.fillAmount = 0;
			gunBarMaskCrit5.fillAmount = 0;
			gunBarMaskCrit6.fillAmount = 0;
		
			gunBarMaskNormal1.fillAmount = 1;
			gunBarMaskNormal2.fillAmount = 1;
			gunBarMaskNormal3.fillAmount = 0;
			gunBarMaskNormal4.fillAmount = 0;
			gunBarMaskNormal5.fillAmount = 0;
			gunBarMaskNormal6.fillAmount = 0;
			
			gunBarIcons.gunIcon1.fillAmount = 0;
			gunBarIcons.gunIcon2.fillAmount = 1;
			gunBarIcons.gunIcon3.fillAmount = 0;
			gunBarIcons.gunIcon4.fillAmount = 0;
			gunBarIcons.gunIcon5.fillAmount = 0;
			break;

		//Set to PlagueBlast
		case 2:
			//Set player's max clicks
			player.clickMax = gunAbilityBars.plagueBlast[0].numOfTaps;
			
			//Crit 1
			gunBarMaskCrit1.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[0].critMask.rangeMin),
				gunAbilityBars.plagueBlast[0].critMask.initialPosition.y,
				gunAbilityBars.plagueBlast[0].critMask.initialPosition.z);
			//Crit 2
			gunBarMaskCrit2.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[1].critMask.rangeMin),
				gunAbilityBars.plagueBlast[1].critMask.initialPosition.y,
				gunAbilityBars.plagueBlast[1].critMask.initialPosition.z);
			//Crit 3
			gunBarMaskCrit3.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[2].critMask.rangeMin),
				gunAbilityBars.plagueBlast[2].critMask.initialPosition.y,
				gunAbilityBars.plagueBlast[2].critMask.initialPosition.z);
			//Crit 4
			gunBarMaskCrit4.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[3].critMask.rangeMin),
				gunAbilityBars.plagueBlast[3].critMask.initialPosition.y,
				gunAbilityBars.plagueBlast[3].critMask.initialPosition.z);
			
			//Norm1
			gunBarMaskNormal1.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[0].normalMask.rangeMin),
				gunAbilityBars.plagueBlast[0].normalMask.initialPosition.y,
				gunAbilityBars.plagueBlast[0].normalMask.initialPosition.z);
			gunBarMaskNormal1.transform.localScale = gunAbilityBars.plagueBlast[0].normalMask.initialScale;
			//Norm2
			gunBarMaskNormal2.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[1].normalMask.rangeMin),
				gunAbilityBars.plagueBlast[1].normalMask.initialPosition.y,
				gunAbilityBars.plagueBlast[1].normalMask.initialPosition.z);
			gunBarMaskNormal2.transform.localScale = gunAbilityBars.plagueBlast[1].normalMask.initialScale;
			//Norm3
			gunBarMaskNormal3.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[2].normalMask.rangeMin),
				gunAbilityBars.plagueBlast[2].normalMask.initialPosition.y,
				gunAbilityBars.plagueBlast[2].normalMask.initialPosition.z);
			gunBarMaskNormal3.transform.localScale = gunAbilityBars.plagueBlast[2].normalMask.initialScale;
			//Norm 4
			gunBarMaskNormal4.transform.localPosition = new Vector3( (gunAbilityBars.plagueBlast[3].normalMask.rangeMin),
				gunAbilityBars.plagueBlast[3].normalMask.initialPosition.y,
				gunAbilityBars.plagueBlast[3].normalMask.initialPosition.z);
			gunBarMaskNormal4.transform.localScale = gunAbilityBars.plagueBlast[3].normalMask.initialScale;
			
			
			//Hide other Bars
			gunBarMaskCrit1.fillAmount = 1;
			gunBarMaskCrit2.fillAmount = 1;
			gunBarMaskCrit3.fillAmount = 1;
			gunBarMaskCrit4.fillAmount = 1;
			gunBarMaskCrit5.fillAmount = 0;
			gunBarMaskCrit6.fillAmount = 0;
		
			gunBarMaskNormal1.fillAmount = 1;
			gunBarMaskNormal2.fillAmount = 1;
			gunBarMaskNormal3.fillAmount = 1;
			gunBarMaskNormal4.fillAmount = 1;
			gunBarMaskNormal5.fillAmount = 0;
			gunBarMaskNormal6.fillAmount = 0;
		
			gunBarIcons.gunIcon1.fillAmount = 0;
			gunBarIcons.gunIcon2.fillAmount = 0;
			gunBarIcons.gunIcon3.fillAmount = 1;
			gunBarIcons.gunIcon4.fillAmount = 0;
			gunBarIcons.gunIcon5.fillAmount = 0;
			break;
		
		//Set to BlitzBarrage
		case 3:
			//Set player's max clicks
			player.clickMax = gunAbilityBars.blitzBarrage[0].numOfTaps;
			
			//Crit 1
			gunBarMaskCrit1.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[0].critMask.rangeMin),
				gunAbilityBars.blitzBarrage[0].critMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[0].critMask.initialPosition.z);
			//Crit 2
			gunBarMaskCrit2.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[1].critMask.rangeMin),
				gunAbilityBars.blitzBarrage[1].critMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[1].critMask.initialPosition.z);
			//Crit 3
			gunBarMaskCrit3.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[2].critMask.rangeMin),
				gunAbilityBars.blitzBarrage[2].critMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[2].critMask.initialPosition.z);
			//Crit 4
			gunBarMaskCrit4.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[3].critMask.rangeMin),
				gunAbilityBars.blitzBarrage[3].critMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[3].critMask.initialPosition.z);
			//Crit 5
			gunBarMaskCrit5.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[4].critMask.rangeMin),
				gunAbilityBars.blitzBarrage[4].critMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[4].critMask.initialPosition.z);
			
			//Norm1
			gunBarMaskNormal1.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[0].normalMask.rangeMin),
				gunAbilityBars.blitzBarrage[0].normalMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[0].normalMask.initialPosition.z);
			gunBarMaskNormal1.transform.localScale = gunAbilityBars.blitzBarrage[0].normalMask.initialScale;
			//Norm2
			gunBarMaskNormal2.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[1].normalMask.rangeMin),
				gunAbilityBars.blitzBarrage[1].normalMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[1].normalMask.initialPosition.z);
			gunBarMaskNormal2.transform.localScale = gunAbilityBars.blitzBarrage[1].normalMask.initialScale;
			//Norm3
			gunBarMaskNormal3.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[2].normalMask.rangeMin),
				gunAbilityBars.blitzBarrage[2].normalMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[2].normalMask.initialPosition.z);
			gunBarMaskNormal3.transform.localScale = gunAbilityBars.blitzBarrage[2].normalMask.initialScale;
			//Norm 4
			gunBarMaskNormal4.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[3].normalMask.rangeMin),
				gunAbilityBars.blitzBarrage[3].normalMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[3].normalMask.initialPosition.z);
			gunBarMaskNormal4.transform.localScale = gunAbilityBars.blitzBarrage[3].normalMask.initialScale;
			//Norm 5
			gunBarMaskNormal5.transform.localPosition = new Vector3( (gunAbilityBars.blitzBarrage[4].normalMask.rangeMin),
				gunAbilityBars.blitzBarrage[4].normalMask.initialPosition.y,
				gunAbilityBars.blitzBarrage[4].normalMask.initialPosition.z);
			gunBarMaskNormal5.transform.localScale = gunAbilityBars.blitzBarrage[4].normalMask.initialScale;
			
			
			//Hide other Bars
			gunBarMaskCrit1.fillAmount = 1;
			gunBarMaskCrit2.fillAmount = 1;
			gunBarMaskCrit3.fillAmount = 1;
			gunBarMaskCrit4.fillAmount = 1;
			gunBarMaskCrit5.fillAmount = 1;
			gunBarMaskCrit6.fillAmount = 0;
		
			gunBarMaskNormal1.fillAmount = 1;
			gunBarMaskNormal2.fillAmount = 1;
			gunBarMaskNormal3.fillAmount = 1;
			gunBarMaskNormal4.fillAmount = 1;
			gunBarMaskNormal5.fillAmount = 1;
			gunBarMaskNormal6.fillAmount = 0;
			
			gunBarIcons.gunIcon1.fillAmount = 0;
			gunBarIcons.gunIcon2.fillAmount = 0;
			gunBarIcons.gunIcon3.fillAmount = 0;
			gunBarIcons.gunIcon4.fillAmount = 1;
			gunBarIcons.gunIcon5.fillAmount = 0;
			
			break;
		
		//Set to ShadowShot
		case 4:
			//Set player's max clicks
			player.clickMax = gunAbilityBars.shadowFlameShot[0].numOfTaps;
			
			//Crit 1
			gunBarMaskCrit1.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[0].critMask.rangeMin),
				gunAbilityBars.shadowFlameShot[0].critMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[0].critMask.initialPosition.z);
			//Crit 2
			gunBarMaskCrit2.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[1].critMask.rangeMin),
				gunAbilityBars.shadowFlameShot[1].critMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[1].critMask.initialPosition.z);
			//Crit 3
			gunBarMaskCrit3.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[2].critMask.rangeMin),
				gunAbilityBars.shadowFlameShot[2].critMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[2].critMask.initialPosition.z);
			//Crit 4
			gunBarMaskCrit4.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[3].critMask.rangeMin),
				gunAbilityBars.shadowFlameShot[3].critMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[3].critMask.initialPosition.z);
			//Crit 5
			gunBarMaskCrit5.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[4].critMask.rangeMin),
				gunAbilityBars.shadowFlameShot[4].critMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[4].critMask.initialPosition.z);
			//Crit 6
			gunBarMaskCrit6.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[5].critMask.rangeMin),
				gunAbilityBars.shadowFlameShot[5].critMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[5].critMask.initialPosition.z);
			
			//Norm1
			gunBarMaskNormal1.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[0].normalMask.rangeMin),
				gunAbilityBars.shadowFlameShot[0].normalMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[0].normalMask.initialPosition.z);
			gunBarMaskNormal1.transform.localScale = gunAbilityBars.shadowFlameShot[0].normalMask.initialScale;
			//Norm2
			gunBarMaskNormal2.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[1].normalMask.rangeMin),
				gunAbilityBars.shadowFlameShot[1].normalMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[1].normalMask.initialPosition.z);
			gunBarMaskNormal2.transform.localScale = gunAbilityBars.shadowFlameShot[1].normalMask.initialScale;
			//Norm3
			gunBarMaskNormal3.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[2].normalMask.rangeMin),
				gunAbilityBars.shadowFlameShot[2].normalMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[2].normalMask.initialPosition.z);
			gunBarMaskNormal3.transform.localScale = gunAbilityBars.shadowFlameShot[2].normalMask.initialScale;
			//Norm 4
			gunBarMaskNormal4.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[3].normalMask.rangeMin),
				gunAbilityBars.shadowFlameShot[3].normalMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[3].normalMask.initialPosition.z);
			gunBarMaskNormal4.transform.localScale = gunAbilityBars.shadowFlameShot[3].normalMask.initialScale;
			//Norm 5
			gunBarMaskNormal5.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[4].normalMask.rangeMin),
				gunAbilityBars.shadowFlameShot[4].normalMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[4].normalMask.initialPosition.z);
			gunBarMaskNormal5.transform.localScale = gunAbilityBars.shadowFlameShot[4].normalMask.initialScale;
			//Norm 6
			gunBarMaskNormal6.transform.localPosition = new Vector3( (gunAbilityBars.shadowFlameShot[5].normalMask.rangeMin),
				gunAbilityBars.shadowFlameShot[5].normalMask.initialPosition.y,
				gunAbilityBars.shadowFlameShot[5].normalMask.initialPosition.z);
			gunBarMaskNormal6.transform.localScale = gunAbilityBars.shadowFlameShot[5].normalMask.initialScale;
			
			//Unhide other bars
			gunBarMaskCrit1.fillAmount = 1;
			gunBarMaskCrit2.fillAmount = 1;
			gunBarMaskCrit3.fillAmount = 1;
			gunBarMaskCrit4.fillAmount = 1;
			gunBarMaskCrit5.fillAmount = 1;
			gunBarMaskCrit6.fillAmount = 1;
		
			gunBarMaskNormal1.fillAmount = 1;
			gunBarMaskNormal2.fillAmount = 1;
			gunBarMaskNormal3.fillAmount = 1;
			gunBarMaskNormal4.fillAmount = 1;
			gunBarMaskNormal5.fillAmount = 1;
			gunBarMaskNormal6.fillAmount = 1;
			
			gunBarIcons.gunIcon1.fillAmount = 0;
			gunBarIcons.gunIcon2.fillAmount = 0;
			gunBarIcons.gunIcon3.fillAmount = 0;
			gunBarIcons.gunIcon4.fillAmount = 0;
			gunBarIcons.gunIcon5.fillAmount = 1;
			break;
		}
		#endregion
		
	}
	
	public Attack didLand(Attack currentAttack){
		//float stoppedAngle = findAngle(arrowInitialPosition, stopPosition, referenceRight);
		float stoppedArrowSpot = stopPosition.x;
		
		switch(player.gunAbilityChosen){
		//Scarlet Shot
		case 1:
			//Check Crit
			if(stoppedArrowSpot < gunAbilityBars.scarletShot[0].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.scarletShot[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				
				if(gunAbilityBars.scarletShot[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.scarletShot[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal hit
			else if(stoppedArrowSpot < gunAbilityBars.scarletShot[0].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.scarletShot[0].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel1 != null){
					normalLabel1.transform.localPosition = stopPosition;
					normalLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.scarletShot[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.scarletShot[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else{
				//Move NormalLabel
				if(missLabel != null){
					missLabel.transform.localPosition = stopPosition;
					missLabel.fillAmount = 1;
				}
				
				return Attack.Miss;
			}

			
		//Dark Bullet
		case 2:
			//Check Crit hit
			if(stoppedArrowSpot < gunAbilityBars.darkBullet[0].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.darkBullet[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.darkBullet[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.darkBullet[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.darkBullet[1].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.darkBullet[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				
				if(gunAbilityBars.darkBullet[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.darkBullet[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal hit
			else if(stoppedArrowSpot < gunAbilityBars.darkBullet[0].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.darkBullet[0].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel1 != null){
					normalLabel1.transform.localPosition = stopPosition;
					normalLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.darkBullet[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.darkBullet[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.darkBullet[1].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.darkBullet[1].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel2 != null){
					normalLabel2.transform.localPosition = stopPosition;
					normalLabel2.fillAmount = 1;
				}
				
				if(gunAbilityBars.darkBullet[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.darkBullet[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else{
				//Move NormalLabel
				if(missLabel != null){
					missLabel.transform.localPosition = stopPosition;
					missLabel.fillAmount = 1;
				}
				
				return Attack.Miss;
			}

		
		//PlagueBlast
		case 3:
			//Check Crit Hit
			if(stoppedArrowSpot < gunAbilityBars.plagueBlast[0].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.plagueBlast[1].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.plagueBlast[2].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[2].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel3 != null){
					critLabel3.transform.localPosition = stopPosition;
					critLabel3.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[2].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[2].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.plagueBlast[3].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[3].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel4 != null){
					critLabel4.transform.localPosition = stopPosition;
					critLabel4.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[3].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[3].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal Hit
			else if(stoppedArrowSpot < gunAbilityBars.plagueBlast[0].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[0].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel1 != null){
					normalLabel1.transform.localPosition = stopPosition;
					normalLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.plagueBlast[1].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[1].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel2 != null){
					normalLabel2.transform.localPosition = stopPosition;
					normalLabel2.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.plagueBlast[2].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[2].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel3 != null){
					normalLabel3.transform.localPosition = stopPosition;
					normalLabel3.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[2].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[2].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.plagueBlast[3].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.plagueBlast[3].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel4 != null){
					normalLabel4.transform.localPosition = stopPosition;
					normalLabel4.fillAmount = 1;
				}
				
				if(gunAbilityBars.plagueBlast[3].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.plagueBlast[3].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else{
				//Move NormalLabel
				if(missLabel != null){
					missLabel.transform.localPosition = stopPosition;
					missLabel.fillAmount = 1;
				}
				
				return Attack.Miss;
			}

			
		//BlitzBarrage
		case 4:
			//Check Crit Hit
			if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[0].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[1].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[2].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[2].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel3 != null){
					critLabel3.transform.localPosition = stopPosition;
					critLabel3.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[2].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[2].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[3].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[3].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel4 != null){
					critLabel4.transform.localPosition = stopPosition;
					critLabel4.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[3].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[3].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[4].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[4].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel5 != null){
					critLabel5.transform.localPosition = stopPosition;
					critLabel5.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[4].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[4].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal Hit
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[0].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[0].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel1 != null){
					normalLabel1.transform.localPosition = stopPosition;
					normalLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[1].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[1].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel2 != null){
					normalLabel2.transform.localPosition = stopPosition;
					normalLabel2.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[2].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[2].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel3 != null){
					normalLabel3.transform.localPosition = stopPosition;
					normalLabel3.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[2].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[2].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[3].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[3].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel4 != null){
					normalLabel4.transform.localPosition = stopPosition;
					normalLabel4.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[3].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[3].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.blitzBarrage[4].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.blitzBarrage[4].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel5 != null){
					normalLabel5.transform.localPosition = stopPosition;
					normalLabel5.fillAmount = 1;
				}
				
				if(gunAbilityBars.blitzBarrage[4].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.blitzBarrage[4].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else{
				//Move NormalLabel
				if(missLabel != null){
					missLabel.transform.localPosition = stopPosition;
					missLabel.fillAmount = 1;
				}
				
				return Attack.Miss;
			}

			
		//ShadowFlameShot
		case 5:
			//Check Crit Hit
			if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[0].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[0].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel1 != null){
					critLabel1.transform.localPosition = stopPosition;
					critLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[0].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[0].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[1].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[1].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel2 != null){
					critLabel2.transform.localPosition = stopPosition;
					critLabel2.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[1].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[1].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[2].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[2].critMask.rangeMin){
				
				
				//Move CritLabel
				if(critLabel3 != null){
					critLabel3.transform.localPosition = stopPosition;
					critLabel3.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[2].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[2].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[3].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[3].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel4 != null){
					critLabel4.transform.localPosition = stopPosition;
					critLabel4.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[3].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[3].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[4].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[4].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel5 != null){
					critLabel5.transform.localPosition = stopPosition;
					critLabel5.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[4].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[4].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[5].critMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[5].critMask.rangeMin){
				
				//Move CritLabel
				if(critLabel6 != null){
					critLabel6.transform.localPosition = stopPosition;
					critLabel6.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[5].critMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[5].critMask.isClicked = true;
					return Attack.Crit;
				}
			}
			
			//Check Normal Hit
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[0].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[0].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel1 != null){
					normalLabel1.transform.localPosition = stopPosition;
					normalLabel1.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[0].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[0].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[1].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[1].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel2 != null){
					normalLabel2.transform.localPosition = stopPosition;
					normalLabel2.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[1].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[1].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[2].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[2].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel3 != null){
					normalLabel3.transform.localPosition = stopPosition;
					normalLabel3.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[2].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[2].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[3].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[3].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel4 != null){
					normalLabel4.transform.localPosition = stopPosition;
					normalLabel4.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[3].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[3].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[4].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[4].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel5 != null){
					normalLabel5.transform.localPosition = stopPosition;
					normalLabel5.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[4].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[4].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			else if(stoppedArrowSpot < gunAbilityBars.shadowFlameShot[5].normalMask.rangeMax &&
				stoppedArrowSpot > gunAbilityBars.shadowFlameShot[5].normalMask.rangeMin){
				
				//Move NormalLabel
				if(normalLabel6 != null){
					normalLabel6.transform.localPosition = stopPosition;
					normalLabel6.fillAmount = 1;
				}
				
				if(gunAbilityBars.shadowFlameShot[5].normalMask.isClicked == true)
					return Attack.BeenClicked;
				else{
					gunAbilityBars.shadowFlameShot[5].normalMask.isClicked = true;
					return Attack.Normal;
				}
			}
			
			//Miss
			else{
				//Move NormalLabel
				if(missLabel != null){
					missLabel.transform.localPosition = stopPosition;
					missLabel.fillAmount = 1;
				}
				
				return Attack.Miss;
			}

			
			
		default:
				return Attack.Miss;

		}
		
		
	}

	
	
	public void OnClick(){
		
		if(player.TurnPhases == 5){
			
			//Reset time for arrowColorChange
			arrowColorTimer =(float)(Time.time + .20);
		
			
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
		
		if(player.TurnPhases == 5){
			
			if(clickScreenButton != null)
				clickScreenButton.isEnabled = true;
			
			
			if(player.isGunSet == false){
				startTimer = Time.time + 1;
				
				setBar((player.gunAbilityChosen - 1));
				player.isGunSet = true;	
			}
			
			//Move Arrow
			arrow.transform.localPosition = new Vector3((arrow.transform.localPosition.x + (ArrowSpeed * Time.deltaTime)),
				arrowInitialPosition.y,arrowInitialPosition.y);
			
			//Adjust Arrow Color if need be
			if(Time.time <= arrowColorTimer){
				
				switch(currentAttack){
				
				case (Attack.Normal):
					arrow.color = Color.green;
					break;
				case (Attack.Crit):
					arrow.color = Color.red;
					break;				
				}
			}
			else
				arrow.color = Color.white;
		
		
			arrowCurrentPosition = arrow.transform.localPosition;
		
		
			distanceFromStart = (arrowCurrentPosition.x - arrowInitialPosition.x);
			attackDistanceFromStart = (arrowInitialPosition.x - stopPosition.x);
			
			//Stop Minigame if Arrow makes the distance once
			if(startTimer != 0){
				if(Time.time >= startTimer){
					if(distanceFromStart >= 390){
						
						player.clickCounter = player.clickMax;
					
					}
				}
			}
		}
		else{
			//Hide Everything
			gunBar.fillAmount = 0;
			
			arrow.color = Color.clear;
			arrow.transform.localPosition = arrowInitialPosition;
			arrow.transform.localRotation = new Quaternion(0,0,0,0);
			
			//Hide Bar Icons
			gunBarIcons.gunIcon1.fillAmount = 0;
			gunBarIcons.gunIcon2.fillAmount = 0;
			gunBarIcons.gunIcon3.fillAmount = 0;
			gunBarIcons.gunIcon4.fillAmount = 0;
			gunBarIcons.gunIcon5.fillAmount = 0;
			
			//Hide Other Bars
			gunBarMaskCrit1.fillAmount = 0;
			gunBarMaskCrit2.fillAmount = 0;
			gunBarMaskCrit3.fillAmount = 0;
			gunBarMaskCrit4.fillAmount = 0;
			gunBarMaskCrit5.fillAmount = 0;
			gunBarMaskCrit6.fillAmount = 0;
		
			gunBarMaskNormal1.fillAmount = 0;
			gunBarMaskNormal2.fillAmount = 0;
			gunBarMaskNormal3.fillAmount = 0;
			gunBarMaskNormal4.fillAmount = 0;
			gunBarMaskNormal5.fillAmount = 0;
			gunBarMaskNormal6.fillAmount = 0;
			
			//Hide CritLabels
			//AlsoReset CritLabels
			critLabel1.fillAmount = 0;
			critLabel2.fillAmount = 0;
			critLabel3.fillAmount = 0;
			critLabel4.fillAmount = 0;
			critLabel5.fillAmount = 0;
			critLabel6.fillAmount = 0;
			
			normalLabel1.fillAmount = 0;
			normalLabel2.fillAmount = 0;
			normalLabel3.fillAmount = 0;
			normalLabel4.fillAmount = 0;
			normalLabel5.fillAmount = 0;
			normalLabel6.fillAmount = 0;
			
			missLabel.fillAmount = 0;
			
			//Reset all Bar's isClicked
			resetBarIsClicked();
			
			if(clickScreenButton != null)
				clickScreenButton.isEnabled = false;
			
		}
		
	}
	
	void resetBarIsClicked(){
	
		//Scarlet Shot
		for(int i = 0; i < 1; i++){
			gunAbilityBars.scarletShot[i].critMask.isClicked = false;
			gunAbilityBars.scarletShot[i].normalMask.isClicked = false;	
		}
		//Dark Shot
		for(int j = 0; j < gunAbilityBars.darkBullet.Length; j++){
			gunAbilityBars.darkBullet[j].critMask.isClicked = false;
			gunAbilityBars.darkBullet[j].normalMask.isClicked = false;
		}
		//Plague Blast
		for(int k = 0; k < gunAbilityBars.plagueBlast.Length; k++){
			gunAbilityBars.plagueBlast[k].critMask.isClicked = false;
			gunAbilityBars.plagueBlast[k].normalMask.isClicked = false;
		}
		//Blitz Barrage
		for(int l = 0; l < gunAbilityBars.blitzBarrage.Length; l++){
			gunAbilityBars.blitzBarrage[l].critMask.isClicked = false;
			gunAbilityBars.blitzBarrage[l].normalMask.isClicked = false;
		}
		//ShadowFlame Shot
		for(int m = 0; m < gunAbilityBars.blitzBarrage.Length; m++){
			gunAbilityBars.shadowFlameShot[m].critMask.isClicked = false;
			gunAbilityBars.shadowFlameShot[m].normalMask.isClicked = false;
		}
		
	}
	
	
	/*
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
	}*/

	
}
