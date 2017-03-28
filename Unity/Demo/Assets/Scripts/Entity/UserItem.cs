using UnityEngine;
using System.Collections.Generic;

public class UserItem {
	
	public string id;

	public string name;

	public string orderStatus;

	public UserItem(string id, string name, string statusItem){
		this.id = id;
		this.name = name;
		this.orderStatus = statusItem;
	}
}
