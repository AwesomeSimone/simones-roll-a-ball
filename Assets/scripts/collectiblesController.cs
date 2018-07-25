using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblesController : MonoBehaviour {

	public bool isCollected;

	// Use this for initialization
	void Start () {
		isCollected = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isCollected)
		{
			Destroy(this.gameObject, 1f);
            disappear();
		}
	}


	void disappear () {
		this.transform.Rotate(Vector3.forward, 720 * Time.deltaTime);
		this.transform.localScale += new Vector3(.25f,.25f,.25f) * Time.deltaTime;
	}
    
}
