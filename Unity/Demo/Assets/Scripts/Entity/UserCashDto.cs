using System;


public class UserCashDto
{
	public int cash;

	public string order_status;


	public UserCash ConvertToUserItem(){
		return new UserCash(this.cash, this.order_status);
	}
}


