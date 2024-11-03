namespace Game.Installers
{
	using System.Collections.Generic;
	using Configs;
	using UnityEngine;
	using Zenject;

	public class ConfigInstaller : MonoInstaller
	{
		[SerializeField] PrefabsConfig _prefabsConfig;
		[SerializeField] ShopConfig _shopConfig;
		
		public override void InstallBindings()
		{
			// Core
			Container.BindInstance(_prefabsConfig);
			
			// Ui
			Container.BindInstance(_shopConfig);
		}
	}
}