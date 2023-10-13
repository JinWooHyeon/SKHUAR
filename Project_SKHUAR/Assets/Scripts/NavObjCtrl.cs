using UnityEngine;
using System.Collections;

public class NavObjCtrl : MonoBehaviour {
    public GameObject mb06Bd01F;
    public GameObject mb06Bd02F;

    public GameObject Text01F;
    public GameObject Text02F;

    private Transform NavObjTrans;
    private Transform ArrivalPointTrans;
    private NavMeshAgent nvAgent;
    
	// Use this for initialization
	void Start () {
        NavObjTrans = this.gameObject.GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToBd06_F01_P6109RL() {
        ArrivalPointTrans = GameObject.FindWithTag("Bd06F01_P6109RL").GetComponent<Transform>();
        nvAgent.destination = ArrivalPointTrans.position;
    }

    public void GoToBd06_F02_WcWomen() {
        ArrivalPointTrans = GameObject.FindWithTag("Bd06F02_WcWomen").GetComponent<Transform>();
        nvAgent.destination = ArrivalPointTrans.position;
    }

    public void GoToBd06_F01_Bank() {
        ArrivalPointTrans = GameObject.FindWithTag("Bank").GetComponent<Transform>();
        nvAgent.destination = ArrivalPointTrans.position;
    }

    void OnTriggerEnter (Collider other) {
        if (other.transform.tag == "Bd06F01ToF02") {
            mb06Bd01F.SetActive(false);
            mb06Bd02F.SetActive(true);

            Text01F.SetActive(false);
            Text02F.SetActive(true);
        } else if (other.transform.tag == "Bd06F02To01") {
            mb06Bd01F.SetActive(true);
            mb06Bd02F.SetActive(false);

            Text01F.SetActive(true);
            Text02F.SetActive(false);
        }
    }

}
