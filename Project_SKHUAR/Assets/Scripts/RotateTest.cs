using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {
    Vector2 position, com_position;
    Vector3 first_position;
    Quaternion first_rotation;

    public GameObject MainCamera;
    public GameObject Char;

	// Use this for initialization
	void Start () {
        position = com_position = Vector2.zero;
        first_position = MainCamera.GetComponent<Transform>().position;
        first_rotation = MainCamera.GetComponent<Transform>().rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Down() {
        first_position = MainCamera.transform.position;
        first_rotation = MainCamera.transform.rotation;

        position = Input.mousePosition;
    }

    void Moved(Vector2 touchPosition) {
        com_position = touchPosition;

        MainCamera.transform.RotateAround(Char.GetComponent<Transform>().position, Vector3.up, (position.x - com_position.x) / 10);

        float angle = (position.y - com_position.y) / 10;

        //MainCamera.transform.Rotate(Vector3.left, angle);

        //Char.transform.Rotate(Vector3.up, (position.x - com_position.x) / 10);

        position = com_position;
    }

    void Up() {

    }

    void LateUpdate() {
        int count = Input.touchCount;

        for (int i = 0; i < count; i++) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                Down();
            } else if (Input.GetTouch(i).phase == TouchPhase.Moved) {
                Moved(Input.mousePosition);
            } else if (Input.GetTouch(i).phase == TouchPhase.Ended) {
                Up();
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            Down();
        } else if (Input.GetMouseButton(0)) {
            Moved(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0)) {
            Up();
        }
    }
}
