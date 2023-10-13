using UnityEngine;
using System.Collections;

public class ArrowCtrl : MonoBehaviour {
    public GameObject BankArrow;
    public GameObject P6109Arrow;
    public GameObject WCArrow;

    public GameObject P6109Light;
    public GameObject P6109Light_Copy;

    public GameObject BankLight;
    public GameObject BankLight_Copy;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ToggleBankArrow() {
        BankArrow.SetActive(!BankArrow.active);
        P6109Arrow.SetActive(false);
        WCArrow.SetActive(false);
        Destroy(P6109Light_Copy);

        StartCoroutine("MakeBankFlash");
    }

    public void ToggleP6109Arrow () {
        BankArrow.SetActive(false);
        P6109Arrow.SetActive(!P6109Arrow.active);
        WCArrow.SetActive(false);
        Destroy(BankLight_Copy);

        StartCoroutine("MakeP6109Flash");
    }

    public void ToggleWCArrow () {
        BankArrow.SetActive(false);
        P6109Arrow.SetActive(false);
        WCArrow.SetActive(!WCArrow.active);
        Destroy(P6109Light_Copy);
        Destroy(BankLight_Copy);
    }

    IEnumerator MakeBankFlash() {
        if (BankLight_Copy == null) {
            BankLight_Copy = (GameObject)Instantiate(BankLight, BankLight.transform.position, BankLight.transform.rotation);
            for (int i = 0; i < 6; i++) {
                BankLight_Copy.SetActive(!BankLight_Copy.active);
                yield return new WaitForSeconds(0.5f);
            }
        } else {
            Destroy(BankLight_Copy);
        }
    }

    IEnumerator MakeP6109Flash() {
        if (P6109Light_Copy == null) {
            P6109Light_Copy = (GameObject)Instantiate(P6109Light, P6109Light.transform.position, P6109Light.transform.rotation);
            for (int i = 0; i < 6; i++) {
                P6109Light_Copy.SetActive(!P6109Light_Copy.active);
                yield return new WaitForSeconds(0.5f);
            }
        } else {
            Destroy(P6109Light_Copy);
        }
    }

    

}
