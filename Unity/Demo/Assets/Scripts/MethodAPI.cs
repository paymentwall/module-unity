using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Paymentwall;
using ApiPW;
public class MethodAPI : MonoBehaviour {
	
	public GameObject buttonBuyCoin;
	public GameObject buttonBuyItem;
	public Dropdown dropDown;
	private ApiPayment ap;
	public GoodApi goodApi;
	public VCApi vcApi;
	// Use this for initialization
	void Start () {
		ap = new ApiPayment ();
		ap.SetStatusApi (Paymentwall_Base.API_GOODS);
		ap.Attach (goodApi);
		ap.Attach (vcApi);
		ap.Notify ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnChangeDropDown(){
		if (dropDown.value == 0) {
			ap.SetStatusApi (Paymentwall_Base.API_GOODS);
		} else if (dropDown.value == 1) {
			ap.SetStatusApi (Paymentwall_Base.API_VC);
		}

		ap.Notify ();
	}
}
