public enum BagItemType
{
	All = 0,
	Common_Card = 100,
	Normal_Card = 101,
	Rare_Card = 102,
}

public interface IBagItem
{
	BagItemType ItemType { get; set; }
}
