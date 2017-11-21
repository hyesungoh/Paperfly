using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_bestscore : MonoBehaviour {

	public Sprite[] PF_Bfont = new Sprite[10];
	public GameObject m_bstNum1, m_bstNum10, m_bstNum100;
	SpriteRenderer m_sbstNum1, m_sbstNum10, m_sbstNum100;
	int Best = 0;

	void Start ()
	{
		Best = PlayerPrefs.GetInt("BestScore");

		m_sbstNum1 = m_bstNum1.GetComponent<SpriteRenderer>();
		m_sbstNum10 = m_bstNum10.GetComponent<SpriteRenderer>();
		m_sbstNum100 = m_bstNum100.GetComponent<SpriteRenderer>();

		m_sbstNum1.sprite = PF_Bfont[Best % 10];
		m_sbstNum10.sprite = PF_Bfont[(Best % 100 ) / 10];
		m_sbstNum100.sprite = PF_Bfont[Best / 100];
	}
}
