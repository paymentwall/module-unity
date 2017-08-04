using UnityEngine;


public class UserItemDto {
	
	public string id;

	public string name;

	public string order_status;


	public UserItem ConvertToUserItem(){
		return new UserItem(id, name, order_status);
	}
}
