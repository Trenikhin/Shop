namespace Game.Ui
{
	using System;
	using Configs;
	using TMPro;
	using UniRx;
	using UnityEngine;
	using UnityEngine.UI;
	using Zenject;

	public interface IUiShopBundleView
	{
		IObservable<Unit> OnBuyClicked { get; }
		
		void SetTitle(string title);
		void SetIcon(Sprite image);
		void SetDescription(string description);
		void SetPrice(string price);
		void SetOldPrice(string price);
		void SetDiscountLabel(string price);
		
		UiItemView CreateItem();
	}
	
	public class UiShopBundleView : MonoBehaviour, IUiShopBundleView
	{
		[Header( "Buttons" )]
		[SerializeField] Button _buyButton;
		[SerializeField] Image _icon;
		
		[Header( "Header" )]
		[SerializeField] TextMeshProUGUI _titleText;
		[SerializeField] TextMeshProUGUI _descriptionText;
		
		[Header("PriceTexts")]
		[SerializeField] TextMeshProUGUI _priceText;
		[SerializeField] TextMeshProUGUI _oldPriceText;
		[SerializeField] TextMeshProUGUI _discountLabelText;
		
		[Header("Items")]
		[SerializeField] UiItemView _item;
		[SerializeField] Transform _content;
 		
		public IObservable<Unit> OnBuyClicked => _buyButton.OnClickAsObservable();
		
		
		public void SetTitle( string title ) => _titleText.text = title;
		public void SetIcon( Sprite image ) => _icon.sprite = image;
		
		public void SetDescription( string description ) => _descriptionText.text = description;
		
		public void SetPrice( string price ) => _priceText.text = price;
		
		public void SetOldPrice( string price ) => _oldPriceText.text = price;
		
		public void SetDiscountLabel( string price ) => _discountLabelText.text = price;
		
		public UiItemView CreateItem() => Instantiate(_item, _content);

		public class Factory : PlaceholderFactory< ShopBundleConfig, Transform, IUiShopBundleView > {}
	}
}