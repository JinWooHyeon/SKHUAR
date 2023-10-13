using UnityEngine;
using System.Collections;

public class UICtrl : MonoBehaviour {
    Vector2 position, com_position;
    Vector3 first_position;
    Quaternion first_rotation;

    public GameObject MainCamera;
    public GameObject Char;

    public GameObject btTracking;

    public GameObject[] pn06BdF;
    public GameObject pn06Bd01F;
    public GameObject pn06Bd02F;
    public GameObject pn06Bd03F;
    public GameObject pn06Bd04F;
    public GameObject pn06Bd05F;
    public GameObject pn06Bd06F;

    public GameObject[] mb06BdF;
    public GameObject mb06Bd01F;
    public GameObject mb06Bd02F;
    public GameObject mb06Bd03F;
    public GameObject mb06Bd04F;
    public GameObject mb06Bd05F;
    public GameObject mb06Bd06F;

    public GameObject Text01F;
    public GameObject Text02F;

    public GameObject Axis;
    public GameObject mainCam;

    Transform AxisTrans;
    
    private float x = 0.0f;
    private float y = 0.0f;
    private float z = 0.0f;
    int arraySize;

    Renderer rend;
    Transform trans;
    Vector3 movement;
    public bool[] md = new bool[6];
    
    int Flag = -1;

    // Use this for initialization
    void Start() {
        position = com_position = Vector2.zero;
        first_position = MainCamera.GetComponent<Transform>().position;
        first_rotation = MainCamera.GetComponent<Transform>().rotation;

        //arraySize = 6;
        //pn06BdF = new GameObject[arraySize];
        for (int i = 0; i <= 5; i++) {
            md[i] = false;
        }

        mb06Bd01F.SetActive(true);
        mb06Bd02F.SetActive(true);
        mb06Bd03F.SetActive(true);
        mb06Bd04F.SetActive(true);
        mb06Bd05F.SetActive(true);
        mb06Bd06F.SetActive(true);

        Text01F.SetActive(false);
        Text02F.SetActive(false);

        trans = mainCam.GetComponent<Transform>();
        AxisTrans = Axis.GetComponent<Transform>();

        StartCoroutine("Rotate");
    }

    //// Update is called once per frame
    //void Update () {

    //   }

    void Down() {
        StopCoroutine("Rotate");

        first_position = MainCamera.transform.position;
        first_rotation = MainCamera.transform.rotation;

        position = Input.mousePosition;
    }

    void Moved(Vector2 touchPosition) {
        com_position = touchPosition;

        MainCamera.transform.RotateAround(Char.GetComponent<Transform>().position, Vector3.down, (position.x - com_position.x) / 10);

        float angle = (position.y - com_position.y) / 10;

        MainCamera.transform.Rotate(Vector3.right, angle);

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

    //public void OnGUI() {
    //    GUI.Box(new Rect(1, Screen.height - 300, Screen.width / 2, Screen.height - 1), "Move");

    //    // Make the buttons. If it is pressed, Application.Loadlevel (1) will be executed
    //    if (GUI.RepeatButton(new Rect(10, Screen.height - 165, 100, 100), "Left")) {
    //        trans.Translate(Vector3.right, Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(230, Screen.height - 165, 100, 100), "Right")) {
    //        trans.Translate(Vector3.left, Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(120, Screen.height - 220, 100, 100), "Up")) {
    //        trans.Translate(Vector3.down, Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(120, Screen.height - 110, 100, 100), "Down")) {
    //        trans.Translate(Vector3.up, Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(10, Screen.height - 275, 100, 100), "ZoomOut")) {
    //        trans.Translate(Vector3.back, Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(230, Screen.height - 275, 100, 100), "ZoomIn")) {
    //        trans.Translate(Vector3.forward, Space.Self);
    //    }

    //    GUI.Box(new Rect(Screen.width / 2 + 1, Screen.height - 300, Screen.width / 2, Screen.height - 1), "Rotate");

    //    if (GUI.RepeatButton(new Rect(Screen.width - 330, Screen.height - 165, 100, 100), "RotLeft")) {
    //        AxisTrans.Rotate(new Vector3(0, -1, 0), Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(Screen.width - 110, Screen.height - 165, 100, 100), "RotRight")) {
    //        AxisTrans.Rotate(new Vector3(0, 1, 0), Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(Screen.width - 220, Screen.height - 220, 100, 100), "RotUp")) {
    //        AxisTrans.Rotate(new Vector3(-1, 0, 0), Space.Self);
    //    }

    //    if (GUI.RepeatButton(new Rect(Screen.width - 220, Screen.height - 110, 100, 100), "RotDown")) {
    //        AxisTrans.Rotate(new Vector3(1, 0, 0), Space.Self);
    //    }
    //}

    public void ReturnTrackingScene() {
        //if (Vuforia.VuforiaBehaviour.Instance.enabled == true) {
        //    Vuforia.VuforiaBehaviour.Instance.enabled = false;
        //} else {
        //    Vuforia.VuforiaBehaviour.Instance.enabled = true;
        //}
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("ImageTracking");
    }

    public void TogglePn06Bd01F() {
        StopCoroutine("Rotate");

        pn06Bd01F.SetActive(!pn06Bd01F.active);
        pn06Bd02F.SetActive(false);
        pn06Bd03F.SetActive(false);
        pn06Bd04F.SetActive(false);
        pn06Bd05F.SetActive(false);
        pn06Bd06F.SetActive(false);

        if (mb06Bd01F.active == true) {
            Text01F.SetActive(true);
        } else {
            Text01F.SetActive(false);
        }

        Flag = 0;

        ToggleBd06Renderer(Flag);
    }

    public void TogglePn06Bd02F() {
        StopCoroutine("Rotate");

        pn06Bd01F.SetActive(false);
        pn06Bd02F.SetActive(!pn06Bd02F.active);
        pn06Bd03F.SetActive(false);
        pn06Bd04F.SetActive(false);
        pn06Bd05F.SetActive(false);
        pn06Bd06F.SetActive(false);

        Flag = 1;

        ToggleBd06Renderer(Flag);
    }

    public void TogglePn06Bd03F() {
        StopCoroutine("Rotate");

        pn06Bd01F.SetActive(false);
        pn06Bd02F.SetActive(false);
        pn06Bd03F.SetActive(!pn06Bd03F.active);
        pn06Bd04F.SetActive(false);
        pn06Bd05F.SetActive(false);
        pn06Bd06F.SetActive(false);

        Flag = 2;

        ToggleBd06Renderer(Flag);
    }

    public void TogglePn06Bd04F() {
        StopCoroutine("Rotate");

        pn06Bd01F.SetActive(false);
        pn06Bd02F.SetActive(false);
        pn06Bd03F.SetActive(false);
        pn06Bd04F.SetActive(!pn06Bd04F.active);
        pn06Bd05F.SetActive(false);
        pn06Bd06F.SetActive(false);

        Flag = 3;

        ToggleBd06Renderer(Flag);
    }

    public void TogglePn06Bd05F() {
        StopCoroutine("Rotate");

        pn06Bd01F.SetActive(false);
        pn06Bd02F.SetActive(false);
        pn06Bd03F.SetActive(false);
        pn06Bd04F.SetActive(false);
        pn06Bd05F.SetActive(!pn06Bd05F.active);
        pn06Bd06F.SetActive(false);

        Flag = 4;

        ToggleBd06Renderer(Flag);
    }

    public void TogglePn06Bd06F() {
        StopCoroutine("Rotate");

        pn06Bd01F.SetActive(false);
        pn06Bd02F.SetActive(false);
        pn06Bd03F.SetActive(false);
        pn06Bd04F.SetActive(false);
        pn06Bd05F.SetActive(false);
        pn06Bd06F.SetActive(!pn06Bd06F.active);

        Flag = 5;

        ToggleBd06Renderer(Flag);
    }

    public void ToggleBd06Renderer(int Flag) {
        switch (Flag) {
            case 0:
                if (pn06Bd01F.active == true) {
                    btTracking.SetActive(false);

                    mb06Bd01F.SetActive(true);
                    mb06Bd02F.SetActive(false);
                    mb06Bd03F.SetActive(false);
                    mb06Bd04F.SetActive(false);
                    mb06Bd05F.SetActive(false);
                    mb06Bd06F.SetActive(false);

                    if (md[Flag] == false) {
                        StartCoroutine("ZoomInSelectedFloor");
                    }
                } else {
                    btTracking.SetActive(true);
                }
                break;
            case 1:
                if (pn06Bd02F.active == true) {
                    btTracking.SetActive(false);

                    //mb06Bd01F.SetActive(false);
                    //mb06Bd02F.SetActive(true);
                    //mb06Bd03F.SetActive(false);
                    //mb06Bd04F.SetActive(false);
                    //mb06Bd05F.SetActive(false);
                    //mb06Bd06F.SetActive(false);

                    if (md[Flag] == false) {
                        StartCoroutine("ZoomInSelectedFloor");
                    }
                } else {
                    btTracking.SetActive(true);
                }
                break;
            case 2:
                if (pn06Bd03F.active == true) {
                    btTracking.SetActive(false);

                    mb06Bd01F.SetActive(false);
                    mb06Bd02F.SetActive(false);
                    mb06Bd03F.SetActive(true);
                    mb06Bd04F.SetActive(false);
                    mb06Bd05F.SetActive(false);
                    mb06Bd06F.SetActive(false);

                    if (md[Flag] == false) {
                        StartCoroutine("ZoomInSelectedFloor");
                    }
                } else {
                    btTracking.SetActive(true);
                }
                break;
            case 3:
                if (pn06Bd04F.active == true) {
                    btTracking.SetActive(false);

                    mb06Bd01F.SetActive(false);
                    mb06Bd02F.SetActive(false);
                    mb06Bd03F.SetActive(false);
                    mb06Bd04F.SetActive(true);
                    mb06Bd05F.SetActive(false);
                    mb06Bd06F.SetActive(false);

                    if (md[Flag] == false) {
                        StartCoroutine("ZoomInSelectedFloor");
                    }
                } else {
                    btTracking.SetActive(true);
                }
                break;
            case 4:
                if (pn06Bd05F.active == true) {
                    btTracking.SetActive(false);

                    mb06Bd01F.SetActive(false);
                    mb06Bd02F.SetActive(false);
                    mb06Bd03F.SetActive(false);
                    mb06Bd04F.SetActive(false);
                    mb06Bd05F.SetActive(true);
                    mb06Bd06F.SetActive(false);

                    if (md[Flag] == false) {
                        StartCoroutine("ZoomInSelectedFloor");
                    }
                } else {
                    btTracking.SetActive(true);
                }
                break;
            case 5:
                if (pn06Bd06F.active == true) {
                    btTracking.SetActive(false);

                    mb06Bd01F.SetActive(false);
                    mb06Bd02F.SetActive(false);
                    mb06Bd03F.SetActive(false);
                    mb06Bd04F.SetActive(false);
                    mb06Bd05F.SetActive(false);
                    mb06Bd06F.SetActive(true);

                    if (md[Flag] == false) {
                        StartCoroutine("ZoomInSelectedFloor");
                    }
                } else {
                    btTracking.SetActive(true);
                }
                break;
            case 10:
                rend = mb06Bd06F.GetComponent<Renderer>();
                //trans = parent06Bd.GetComponent<Transform>();

                if (pn06Bd06F.active == false) {
                    //rend.material = mat0;
                    //StartCoroutine("FadeIn");
                } else {
                    mb06Bd01F.SetActive(false);
                    mb06Bd02F.SetActive(false);
                    mb06Bd03F.SetActive(false);
                    mb06Bd04F.SetActive(false);
                    mb06Bd05F.SetActive(false);
                    mb06Bd06F.SetActive(true);

                    if (md[Flag] == false) {
                        StartCoroutine("ZoomInSelectedFloor");
                    }

                    //StartCoroutine("FadeOut");
                    //rend.material = mat1;
                }
                //if (rend.material.color.a >= 0.9)
                //{
                //    rend.material = mat1;
                //    Debug.Log(rend.material.color.a);
                //    Debug.Log("material change");
                //}
                break;
        }
    }

    IEnumerator FadeIn() {
        for (float i = 1f; i >= 0; i -= 0.1f) {
            Color color = new Color(1, 1, 1, i);
            rend.material.color = color;

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeOut() {
        for (float i = 0f; i <= 1; i += 0.1f) {
            Color color = new Color(1, 1, 1, i);
            rend.material.color = color;

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Rotate() {
        while (true) {
            AxisTrans.Rotate(new Vector3(0, 1, 0), Space.World);

            yield return new WaitForSeconds(0.03f);
        }
    }

    IEnumerator ZoomInSelectedFloor() {
        float tiltAngle = 90.0f;
        movement.Set(0, 0, -100);
        trans.position = movement;
        trans.rotation = Quaternion.Euler(0, 0, 0);
        //AxisTrans.rotation = Quaternion.Euler(0, 0, 0);
        md[Flag] = false;

        for (float x = 0.0f; x >= -3; x -= 0.1f) {
            movement.Set(x, 0, -100);
            trans.position = movement;

            yield return new WaitForSeconds(0.01f);
        }

        for (float z = -100.0f; z <= -65; z += 1f) {
            movement.Set(-3, 0, z);
            trans.position = movement;

            yield return new WaitForSeconds(0.01f);
        }
        
        for (float x = 0f; x <= tiltAngle; x += 1f) {
            AxisTrans.Rotate(new Vector3(1, 0, 0), Space.World);

            yield return new WaitForSeconds(0.01f);
        }
    }
    
}
