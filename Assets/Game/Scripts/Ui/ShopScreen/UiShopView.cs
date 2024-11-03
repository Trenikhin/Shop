namespace Game.Ui
{
	using System;
	using Configs;
	using UniRx;
	using UnityEngine;
	using UnityEngine.UI;
	using TMPro;
	using Zenject;

	public interface iUiShopView
	{
		IObservable<Unit> OnCloseClicked { get; }
		
		void ShowHide(bool show);
		void SetName(string screenName);
		
		IUiShopBundleView Create( ShopBundleConfig config );
		void DestroyObj(UiShopBundleView obj);
	}
	
	public class UiShopView : MonoBehaviour, iUiShopView
	{
		[SerializeField] Button _closeButton;
		[SerializeField] TextMeshProUGUI _name;
		
		[SerializeField] UiShopBundleView _cardTemplate;
		[SerializeField] Transform _content;
		
		[Inject] UiShopBundleView.Factory _bundleFactory;
		
		public IObservable<Unit> OnCloseClicked => _closeButton.OnClickAsObservable();
		
		public void ShowHide( bool show ) => gameObject.SetActive(show);
		
		public void SetName( string screenName ) => _name.text = screenName;
		
		public IUiShopBundleView Create( ShopBundleConfig cfg ) => _bundleFactory.Create(cfg, _content);
		public void DestroyObj( UiShopBundleView obj ) => Destroy( obj.gameObject );
	}
}