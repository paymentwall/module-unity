using System;
using ApiPW;
using Paymentwall;
using UnityEngine;
using System.Collections;

public class VCApi: MonoBehaviour, ApiObserver
{
	private int status = Paymentwall_Base.API_VC;
	public Main main;

	public VCApi (){

	}
	public void Run(ApiPayment apiSubject){
		if (status == apiSubject.GetStatusApi ()) {
			this.gameObject.SetActive (true);
		} else {
			this.gameObject.SetActive (false);
		}
	}
	public void ClickToBuy(){
		main.typePayment = status;
		main.ClickBuy ();
	}
}

