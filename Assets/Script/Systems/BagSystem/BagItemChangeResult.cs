public enum BagItemChangeResponse
{
	Success,
	AddFail_Full,
	AddFail_WrongType,
	RemoveFail,
	Fail_Exception
}


public interface IBagItemChangeResult
{
	BagItemChangeResponse response { get; set; }
	string description { get; set; }
}

public class BagItemChangeResult : IBagItemChangeResult
{
	public BagItemChangeResponse response { get; set; }
	public string description { get; set; }

	public BagItemChangeResult(BagItemChangeResponse response,string desc = "")
	{
		this.response = response;
		this.description = string.IsNullOrEmpty(desc) ? response.ToString() : desc;
	}
}