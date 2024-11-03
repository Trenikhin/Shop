namespace Game.Ui
{
	using System.Collections.Generic;
	using Core;
	using UniRx;
	using Zenject;

	public interface IShopPurchaser
	{
		ReactiveCommand OnBuySucceed { get; }
		ReactiveCommand OnBuyFailed { get; }
		
		bool TryPurchase(int price, List< (Item, int) > stacks);
	}
	
	public class ShopPurchaser : IShopPurchaser
	{
		[Inject] IMoney _money;
		[Inject] IInventory _inventory;
		
		public ReactiveCommand OnBuySucceed {get;} = new ReactiveCommand();
		public ReactiveCommand OnBuyFailed {get;} = new ReactiveCommand();
		
		public bool TryPurchase( int price, List< (Item, int) > stacks )
		{
			if (!_money.TrySpend(price))
			{
				OnBuyFailed.Execute();
				return false;
			}
			
			stacks.ForEach( s => _inventory.AddItem( s.Item1, s.Item2 ) );
			
			OnBuySucceed?.Execute();

			return true;
		}
	}
}