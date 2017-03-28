using System;
using System.Collections.Generic;
using ApiPW;
using UnityEngine;
public class ApiPayment: ApiSubject{
	private int statusApi;
	private List<ApiObserver> storage = new List<ApiObserver> ();

	public void Attach(ApiObserver observer){
		storage.Add (observer);
	}
	public void Detach(ApiObserver observer){
		storage.Remove (observer);
	}
	public void Notify(){
		for(int i = 0; i < storage.Count; i++){
			storage [i].Run (this);
		}
	}
	public void SetStatusApi(int status){
		this.statusApi = status;
	}
	public int GetStatusApi(){
		return statusApi;
	}
}


