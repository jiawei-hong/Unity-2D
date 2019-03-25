using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Needle needlePrefab = null;

    Needle _needle = null;
    // Use this for initialization
    void Start () {
        needlePrefab.gameObject.SetActive(true);
        _needle = Instantiate(needlePrefab);
        _needle.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            _needle.IsFired = true;

            _needle = Instantiate(needlePrefab);
            _needle.gameObject.SetActive(true);
        }
    }
}
