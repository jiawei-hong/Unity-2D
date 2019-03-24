using UnityEngine;

public class Neddle : MonoBehaviour {
    public float Speed = 1;
    public bool isFired;

	void Update () {
        if (Input.GetMouseButtonDown(0)){
            isFired = true;
        }

        if (isFired) {
            transform.Translate(new Vector3(0, Speed, 0));
        }
	}
}
