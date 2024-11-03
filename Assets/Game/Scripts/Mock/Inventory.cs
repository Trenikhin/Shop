namespace Game.Core
{
	using System.Collections.Generic;
	using UnityEngine;

	public interface IInventory
	{
		bool AddItem(Item item, int count);
	}
	
	public class Inventory: IInventory
	{
		public bool AddItem(Item item, int count)
		{
			Debug.Log( $"add to inventory: {item.Name}, count: {count}" );

			return true;
		}
	}
}