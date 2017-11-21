using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingame_mng : MonoBehaviour {
	public bool mng_isover = false;
	public Sprite[] PF_font = new Sprite[10];
	public Sprite[] PF_Bfont = new Sprite[10];


	public GameObject num1, num10, num100;
	SpriteRenderer snum1, snum10, snum100;


	public GameObject nowNum1, nowNum10, nowNum100;
	SpriteRenderer snowNum1, snowNum10, snowNum100;

	public GameObject bstNum1, bstNum10, bstNum100;
	SpriteRenderer sbstNum1, sbstNum10, sbstNum100;


	public GameObject Act_obj;
	Act_ingame fade_ingame;

	public float fLevel = 100.0f;
	public float fLevelUpsize = 0.1f;
	public int nScore = 0;
	float fdt = 0f;

	float Dx, Dy, Ux, Uy;
	bool ismouseover = false;

	void Start () {
			// 아이폰 빌드
		 	Screen.SetResolution(Screen.width, (Screen.width * 16) / 9 , false);
			// 데스크탑 빌드
			//Screen.SetResolution(450, 800, false);
			Camera.main.fieldOfView = 60f;

			snum1 = num1.GetComponent<SpriteRenderer>();
			snum10 = num10.GetComponent<SpriteRenderer>();
			snum100 = num100.GetComponent<SpriteRenderer>();

			snowNum1 = nowNum1.GetComponent<SpriteRenderer>();
			snowNum10 = nowNum10.GetComponent<SpriteRenderer>();
			snowNum100 = nowNum100.GetComponent<SpriteRenderer>();

			sbstNum1 = bstNum1.GetComponent<SpriteRenderer>();
			sbstNum10 = bstNum10.GetComponent<SpriteRenderer>();
			sbstNum100 = bstNum100.GetComponent<SpriteRenderer>();

			fade_ingame = Act_obj.GetComponent<Act_ingame>();
	}
	void FixedUpdate ()
	{
		fdt += Time.deltaTime;

		if(mng_isover.Equals(false))
			Scoring();
		else
			StartCoroutine(BestScore());
	}

	void Scoring()
	{
		if (fdt > 0.5f)
		{
			nScore += (int)fLevel / 100;

			snum1.sprite = PF_font[nScore % 10];
			snum10.sprite = PF_font[(nScore % 100 ) / 10];
			snum100.sprite = PF_font[nScore / 100];

			fLevel += fLevelUpsize;

			fdt = 0f;
		}
	}

	void Input_mp()
	{

		if (Input.GetMouseButtonDown(0))
		{
			Dx = Input.mousePosition.x;
			Dy = Input.mousePosition.y;
		}

		if (Input.GetMouseButtonUp(0))
		{
			Ux = Input.mousePosition.x;
			Uy = Input.mousePosition.y;

			if (Uy - Dy > 40 || Dy - Uy > 40 || Ux - Dx > 40 || Dx - Ux > 40)
				StartCoroutine(fade_ingame.Fadeout_toMenu());
			else
				StartCoroutine(fade_ingame.Fadeout_toRestart());

		}
	}

	IEnumerator BestScore()
	{
		yield return null;
		int Best = PlayerPrefs.GetInt("BestScore");
		if (Best < nScore)
			PlayerPrefs.SetInt("BestScore", nScore);

		Best = PlayerPrefs.GetInt("BestScore");
		
		snowNum1.sprite = PF_Bfont[nScore % 10];
		snowNum10.sprite = PF_Bfont[(nScore % 100 ) / 10];
		snowNum100.sprite = PF_Bfont[nScore / 100];

		sbstNum1.sprite = PF_Bfont[Best % 10];
		sbstNum10.sprite = PF_Bfont[(Best % 100 ) / 10];
		sbstNum100.sprite = PF_Bfont[Best / 100];

		StartCoroutine(GoFade());
	}

	IEnumerator GoFade()
	{
			if (ismouseover)
			{
				if (Input.GetMouseButtonDown(0))
				{
					Dx = Input.mousePosition.x;
					Dy = Input.mousePosition.y;
				}

				if (Input.GetMouseButtonUp(0))
				{
					Ux = Input.mousePosition.x;
					Uy = Input.mousePosition.y;

					if (Uy - Dy > 40 || Dy - Uy > 40 || Ux - Dx > 40 || Dx - Ux > 40)
						StartCoroutine(fade_ingame.Fadeout_toMenu());
					else
						StartCoroutine(fade_ingame.Fadeout_toRestart());
				}
			}

			if (Input.GetMouseButtonUp(0) && ismouseover.Equals(false))
				ismouseover = true;
			
			yield return null;
	}
}
