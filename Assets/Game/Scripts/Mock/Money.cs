namespace Game.Core
{
	using UnityEngine;

	public interface IMoney
	{
		bool TrySpend(int money);
	}
	
	public class Money: IMoney
	{
		int _value = int.MaxValue;
		
		public bool TrySpend(int amount)
		{
			_value -= amount;
			Debug.Log( $"Spend {amount}, total: {_value}");
			
			return true;
		}
	}
}