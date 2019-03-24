using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Neddle neddle;
    public GameObject pinPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //CreatePin();
            neddle.isFired = true;
        }
	}

    void CreatePin()
    {
        Instantiate(pinPrefab, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
    }
}
