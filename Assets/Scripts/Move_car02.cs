using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_car02 : MonoBehaviour {
	public float fSpeed = 5.0f;
	float fdt_Idle = 0.0f;
	public float Speed_Idle = 1.0f;
	
	// Update is called once per frame
	void Update () {
		Anim_Move();
		Anim_Idle();
	}

	void Anim_Move()
	{
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - fSpeed * Time.deltaTime,
														 gameObject.transform.localPosition.y,
														 gameObject.transform.localPosition.z);
		if (gameObject.transform.localPosition.x < -6.0f)
		{
			gameObject.transform.localPosition = new Vector3(15.0f, gameObject.transform.localPosition.y,
																	gameObject.transform.localPosition.z);
		}
	}

	void Anim_Idle()
    {
        fdt_Idle += Time.deltaTime;
        if (fdt_Idle < 0.1)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
            gameObject.transform.localPosition.y + Speed_Idle * Time.deltaTime,
            gameObject.transform.localPosition.z);
        }
        else
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
            gameObject.transform.localPosition.y - Speed_Idle * Time.deltaTime,
            gameObject.transform.localPosition.z);    
        }
        if (fdt_Idle > 0.2)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 0.0f,
                                                             gameObject.transform.localPosition.z);
            fdt_Idle = 0.0f;
        }
    }
}
