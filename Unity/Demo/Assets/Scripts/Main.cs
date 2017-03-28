using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Paymentwall;
using System.Collections.Specialized;
using SimpleJSON;
using ApiPW;

public class Main : MonoBehaviour {
	public Canvas canvas;
	private PWPingback pwb;
	Text messageView;
	public Dropdown dropDown;
	string server = "https://pw2.herokuapp.com/"; //ex: 
	public ApiObserver apiObserver;
	public int typePayment = Paymentwall_Base.API_GOODS;
	public Text textCash;
	private string new_item_id = "-1";
	private string user_id = "1";

	private int cash = 22;

	IEnumerator Start() {
		textCash.text = "Cash: " + cash;
		GameObject tem = GameObject.FindGameObjectWithTag ("messageview");
		messageView = tem.GetComponent<Text> ();
		StartCoroutine (GetNewItem());
		while (true) {			
			yield return new WaitForSeconds(1.0f);
			StartCoroutine (GetNewItem());
		}

	}
	/// <summary>
	/// handle item from server, if item paid or cancel
	/// </summary>
	IEnumerator GetNewItem(){
		WWW www = new WWW(server + "ClientGoodApi.php" + "?user_id=" + user_id);
		yield return www;
		List<UserItem> listItemUpdated = this.ConvertJsonToUserItem(www.text);
		this.ShowMessage (listItemUpdated);

		www = new WWW(server + "ClientVCApi.php" + "?user_id=" + user_id);
		yield return www;
		List<UserCash> listCashUpdated = this.ConvertJsonToUserCash(www.text);
		this.ShowCash (listCashUpdated);
	}

	public void ClickBuy(){
		StartCoroutine(updateBuyItem ());
	}
	/// <summary>
	/// send item info to server when player buy item
	/// call method Payment to create webview
	/// </summary>
	IEnumerator updateBuyItem(){
		WWWForm form = new WWWForm();
		form.AddField("uid", user_id);
		form.AddField("item_id", 1);

		WWW w = new WWW(server, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.error);
		}
		else {
			new_item_id = w.text;
			this.Payment (new_item_id);
		}
	}

	IEnumerator updateBuyCash(){
		WWWForm form = new WWWForm();
		form.AddField("uid", user_id);
		//form.AddField("cash", 2000);

		WWW w = new WWW(server, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.error);
		}
		else {
			new_item_id = w.text;
			this.Payment (new_item_id);
		}
	}

	/// <summary>
	///<param name="product_id">id of product for payment</param>
	/// setup product
	/// call webview for payment
	/// </summary>
	public void Payment(string product_id){
		
		PWBase.SetApiType(typePayment);
		PWBase.SetAppKey("8ec04f96a62ec4c7a0f13ceccee638ac"); // available in your Paymentwall merchant area
		PWBase.SetSecretKey("adb7497cc888e5c1547dded7aa9ca0d7"); // available in your Paymentwall merchant area

		List<PWProduct> productList = new List<PWProduct>();
		if(typePayment == Paymentwall_Base.API_GOODS){
			productList = this.CreateProduct (product_id);
		}

		PWWidget widget = new PWWidget(
			"1", // id of the end-user who's making the payment
			"p1_1", // widget code, e.g. p1; can be picked inside of your merchant account
			productList,
			new Dictionary<string, string>() {{"email", "cuongbui.203@gmail.com"}} // additional parameters
		);
		PWUnityWidget unity = new PWUnityWidget (widget);
		StartCoroutine (unity.callWidgetWebView (gameObject, canvas)); // call this function to display widget
	}

	public List<PWProduct> CreateProduct(string product_id){
		List<PWProduct> productList = new List<PWProduct>();
		PWProduct product = new PWProduct(
			product_id, // id of the product in your system
			9.99f, // price
			"USD", // currency code
			"M4a1", // product name
			PWProduct.TYPE_SUBSCRIPTION, // this is a time-based product; for one-time products, use Paymentwall_Product.TYPE_FIXED and omit the following 3 parameters
			1, // time duration
			PWProduct.PERIOD_TYPE_YEAR, // year
			true // recurring
		);
		productList.Add(product);
		return productList;
	}


	void ShowCash(List<UserCash> listItemUpdated){
		string itemBought = "";
		string itemCancel = "";

		if(listItemUpdated.Count > 0){
			for(int i = 0; i < listItemUpdated.Count; i++){
				switch(listItemUpdated[i].orderStatus){
				case "Paid":
					this.cash += listItemUpdated [i].cash;
					this.textCash.text = "Cash: " + this.cash;
	
					if (itemBought == "") {
						itemBought = listItemUpdated [i].cash + " cash";
					}else {
						itemBought = " - " + listItemUpdated [i].cash + " cash";
					}
					break;
				case "Cancel":
					if (itemCancel == "") {
						itemCancel = listItemUpdated [i].cash + " cash";
					}else {
						itemCancel = " - " + listItemUpdated [i].cash + " cash";
					}
					break;
				}
			}
			string message = "";
			if (itemBought != "") {
				message = "bought: " + itemBought+ "\n";
			}
			if (itemCancel != "") {
				message += "canceled: " + itemCancel;
			}
			messageView.text = message;
		}
	}

	/// <summary>
	///<param name="listItemUpdated">List of item paid</param>
	/// show message to user when sys update new item
	/// </summary>
	void ShowMessage(List<UserItem> listItemUpdated){
		string itemBought = "";
		string itemCancel = "";

		if(listItemUpdated.Count > 0){
			for(int i = 0; i < listItemUpdated.Count; i++){
				switch(listItemUpdated[i].orderStatus){
				case "Paid":
					if (itemBought == "") {
						itemBought = listItemUpdated [i].name;
					}else {
						itemBought = " - " + listItemUpdated [i].name;
					}

					break;
				case "Cancel":
					if (itemCancel == "") {
						itemCancel = listItemUpdated [i].name;
					}else {
						itemCancel = " - " + listItemUpdated [i].name;
					}
					break;
				}
			}
			string message = "";
			if (itemBought != "") {
				message = "bought: " + itemBought+ "\n";
			}
			if (itemCancel != "") {
				message += "canceled: " + itemCancel;
			}
			messageView.text = message;
		}
	}

	/// <summary>
	///<param name="json">json from server</param>
	/// conver json order from server to data format of client
	/// </summary>
	List<UserItem> ConvertJsonToUserItem(string json){
		List<UserItem> listUserItem = new List<UserItem> ();
		if(json != "null" && json != ""){
			JSONNode packet;
			packet = JSON.Parse (json);
			for(int i = 0; i < packet.Count; i++){
				UserItemDto tem;
				tem = JsonUtility.FromJson<UserItemDto>(packet[i].ToString());
				listUserItem.Add (tem.ConvertToUserItem());
			}
		}

		return listUserItem;
	}
	/// <summary>
	///<param name="json">json from server</param>
	/// conver json order from server to data format of client
	/// </summary>
	List<UserCash> ConvertJsonToUserCash(string json){
		List<UserCash> listUserCash = new List<UserCash> ();
		if(json != "null" && json != ""){
			JSONNode packet;
			packet = JSON.Parse (json);
			for(int i = 0; i < packet.Count; i++){
				UserCashDto tem;
				tem = JsonUtility.FromJson<UserCashDto>(packet[i].ToString());
				listUserCash.Add (tem.ConvertToUserItem());
			}
		}

		return listUserCash;
	}
}
