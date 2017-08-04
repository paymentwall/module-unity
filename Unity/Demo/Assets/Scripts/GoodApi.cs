using System;
using ApiPW;
using Paymentwall;
using UnityEngine;

public class GoodApi: MonoBehaviour, ApiObserver
{
	private int status = Paymentwall_Base.API_GOODS;
	public Main main;

	public GoodApi (){
		
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

