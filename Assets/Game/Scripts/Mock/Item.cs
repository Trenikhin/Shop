﻿namespace Game.Core
{
	public class Item
	{
		public string Name { get; private set; }

		public Item(string name)
		{
			Name = name;
		}
	}
}