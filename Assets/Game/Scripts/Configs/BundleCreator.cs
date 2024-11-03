namespace Game.Configs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using UnityEngine.UI;
	using TMPro;

	[System.Serializable]
	public class SpriteData
	{
		public string Name;
		public Sprite Sprite;
	}
	
	public class BundleCreator : MonoBehaviour
	{
		[SerializeField] ShopConfig _shopConfig;
		[SerializeField] Button _createButton;
		
		[SerializeField] TMP_InputField _title;
		[SerializeField] TMP_InputField _description;
		[SerializeField] TMP_Dropdown _itemNameDropdown;
		[SerializeField] TMP_Dropdown _itemCountDropdown;
		[SerializeField] TMP_InputField _price;
		[SerializeField] TMP_InputField _discount;
		[SerializeField] TMP_Dropdown _spriteDropdown;
		
		[SerializeField] List<ItemConfig> _itemConfigs;
		[SerializeField] List<SpriteData> _sprites;
		
		int _itemCount;
		string _name;
		Sprite _sprite;
		
		void Start()
		{
			_discount.text = 0.ToString();
			
			_itemConfigs.ForEach(i =>
			{
				_itemNameDropdown.options.Add(new TMP_Dropdown.OptionData() { text = i.Name });
			} );
			_sprites.ForEach(i =>
			{
				_spriteDropdown.options.Add(new TMP_Dropdown.OptionData() { text = i.Name });
			} );
			_itemCountDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "3" });
			_itemCountDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "4" });
			_itemCountDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "5" });
			_itemCountDropdown.options.Add(new TMP_Dropdown.OptionData() { text = "6" });
			
			_itemNameDropdown.onValueChanged.AddListener( i =>
			{
				_name = _itemNameDropdown.options[i].text;
			});
			_itemCountDropdown.onValueChanged.AddListener( i =>
			{
				int.TryParse( _itemCountDropdown.options[ i ].text, out _itemCount );
			});
			_spriteDropdown.onValueChanged.AddListener( i =>
			{
				_sprite = _sprites.FirstOrDefault( s => s.Name == _spriteDropdown.options[ i ].text )?.Sprite;
			});
			
			_createButton.onClick.AddListener( CreateBundle );
		}

		void Update()
		{
			_createButton.interactable = _itemCount != 0 &&
			                             !string.IsNullOrEmpty(_name) &&
			                             !string.IsNullOrEmpty(_title.text) &&
			                             !string.IsNullOrEmpty(_price.text) &&
			                             int.TryParse(_price.text, out _) &&
			                             !_shopConfig.Cards.Select(n => n.Title).Contains(_title.text) &&
			                             int.TryParse(_discount.text, out int value) && value >= 0 && value <= 100;
		}

		void CreateBundle()
		{
			ShopBundleConfig newData = ScriptableObject.CreateInstance<ShopBundleConfig>();
			
			string path = $"Assets/Game/Data/[Bundle] {_title.text}.asset";
			UnityEditor.AssetDatabase.CreateAsset(newData, path);
			UnityEditor.AssetDatabase.SaveAssets();
			
			newData.Title = _title.text;
			newData.Description = _description.text;
			newData.Icon = _sprite;
			newData.Price = int.Parse(_price.text);
			newData.Discount = int.Parse(_discount.text);
			newData.Items = new List<StackConfig>();
			
			for (int i = 0; i < _itemCount; i++)
			{
				var stack = new StackConfig()
				{
					Item = _itemConfigs.FirstOrDefault(c => c.Name == _name),
					Amount = 40,
				};
				
				newData.Items.Add( stack );
			}
			
			_shopConfig.Cards.Add(newData);
		}
	}
}