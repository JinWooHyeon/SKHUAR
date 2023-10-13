using UnityEngine;
using System.Collections;

public class Building06Ctrl : MonoBehaviour {
    Rigidbody rigdbody;
    Vector3 movement;
    Vector2[] touchPos = new Vector2[5];

    private float fMoveSpeed = 50.0f;
    private float x = 0.0f;
    private float y = 0.0f;
    private float z = 0.0f;
    private int cnt;

    void Awake () {
        rigdbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        cnt = Input.touchCount;

        if (cnt > 0) {
            for (int i = 0; i < cnt; ++i) {
                Touch touch = Input.GetTouch(i);
                Vector2 beganPos = touch.position;
                //Vector2 pos = touch.position;

                switch (touch.phase) {
                    case TouchPhase.Began:
                        Debug.Log("Touch began");
                        Debug.Log("beganPos(" + i + ") : x = " + beganPos.x + ", y = " + beganPos.y);
                        break;
                    case TouchPhase.Moved:
                        //Debug.Log("Touch Moving");
                        break;
                    case TouchPhase.Ended:
                        Debug.Log("Touch Ended");
                        break;
                }
                //Debug.Log("touch(" + i + ") : x = " + pos.x + ", y = " + pos.y);
            }
        }

        //if (x != 0 || y != 0 || z != 0) {
        //    Debug.Log("X = " + x.ToString());
        //    Debug.Log("Y = " + y.ToString());
        //    Debug.Log("Z = " + z.ToString());
        //}

    }

    //void Move (float x, float y, float z) {
    //    movement.Set(x, y, z);
    //    movement = movement.normalized * fMoveSpeed * Time.smoothDeltaTime;

    //    rigdbody.MovePosition(transform.position + movement);
    //}

    //public void OnGUI()
    //{
    //    GUI.Box(new Rect(1, Screen.height - 300, Screen.width / 2, Screen.height - 1), "Move");

    //    // Make the buttons. If it is pressed, Application.Loadlevel (1) will be executed
    //    if (GUI.RepeatButton(new Rect(10, Screen.height - 165, 100, 100), "Left")) {
    //        x = -1;
    //        y = 0;
    //        z = 0;
    //        Move(x, y, z);
    //    }

    //    if (GUI.RepeatButton(new Rect(230, Screen.height - 165, 100, 100), "Right")) {
    //        x = 1;
    //        y = 0;
    //        z = 0;
    //        Move(x, y, z);
    //    }

    //    if (GUI.RepeatButton(new Rect(120, Screen.height - 220, 100, 100), "Up")) {
    //        x = 0;
    //        y = 1;
    //        z = 0;
    //        Move(x, y, z);
    //    }

    //    if (GUI.RepeatButton(new Rect(120, Screen.height - 110, 100, 100), "Down")) {
    //        x = 0;
    //        y = -1;
    //        z = 0;
    //        Move(x, y, z);
    //    }

    //    if (GUI.RepeatButton(new Rect(10, Screen.height - 275, 100, 100), "ZoomOut")) {
    //        x = 0;
    //        y = 0;
    //        z = 1;
    //        Move(x, y, z);
    //    }

    //    if (GUI.RepeatButton(new Rect(230, Screen.height - 275, 100, 100), "ZoomIn")) {
    //        x = 0;
    //        y = 0;
    //        z = -1;
    //        Move(x, y, z);
    //    }

    //    GUI.Box(new Rect(Screen.width / 2 + 1, Screen.height - 300, Screen.width / 2, Screen.height - 1), "Rotate");

    //    if (GUI.RepeatButton(new Rect(Screen.width - 330, Screen.height - 165, 100, 100), "RotLeft")) {
    //        transform.Rotate(new Vector3(0, 1, 0), Space.World);
    //    }

    //    if (GUI.RepeatButton(new Rect(Screen.width - 110, Screen.height - 165, 100, 100), "RotRight")) {
    //        transform.Rotate(new Vector3(0, -1, 0), Space.World);
    //    }

    //    if (GUI.RepeatButton(new Rect(Screen.width - 220, Screen.height - 220, 100, 100), "RotUp")) {
    //        transform.Rotate(new Vector3(1, 0, 0), Space.World);
    //    }

    //    if (GUI.RepeatButton(new Rect(Screen.width - 220, Screen.height - 110, 100, 100), "RotDown")) {
    //        transform.Rotate(new Vector3(-1, 0, 0), Space.World);
    //    }
    //}
}
