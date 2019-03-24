using UnityEngine;

public class BigCircle : MonoBehaviour {
    public float Speed = 1;

	void Update () {
        transform.Rotate(new Vector3(0,0,Speed));
	}
}
