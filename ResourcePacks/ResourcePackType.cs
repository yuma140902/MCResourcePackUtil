using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCResourcePackUtil.ResourcePacks
{
	/// <summary>
	/// <see cref="EnumResourcePackType"/>のヘルパー
	/// </summary>
	public class ResourcePackType
	{
		public static readonly ResourcePackType Zip = new ResourcePackType(EnumResourcePackType.Zip);
		public static readonly ResourcePackType Folder = new ResourcePackType(EnumResourcePackType.Folder);
		public static readonly ResourcePackType Mod = new ResourcePackType(EnumResourcePackType.Mod);
		public static readonly ResourcePackType PlainFolder = new ResourcePackType(EnumResourcePackType.PlainFolder);
		private static readonly ResourcePackType[] _values = new ResourcePackType[] { 
			Zip, Folder, Mod, PlainFolder
		};

		public readonly EnumResourcePackType value;

		private ResourcePackType(EnumResourcePackType value) => this.value = value;

		public bool IsFolderStyle => this == EnumResourcePackType.Folder || this == EnumResourcePackType.PlainFolder;

		public override string ToString()
		{
			switch (this.value) {
				case EnumResourcePackType.Zip:
					return "Zip型リソースパック";
				case EnumResourcePackType.Folder:
					return "フォルダ型リソースパック";
				case EnumResourcePackType.Mod:
					return "MODファイル";
				case EnumResourcePackType.PlainFolder:
					return "フォルダ";
				default:
					return "(不明)";
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is ResourcePackType type) return this.value == type.value;
			else if (obj is EnumResourcePackType value) return this.value == value;
			else return false;
		}

		public override int GetHashCode() => this.value.GetHashCode();

		public static implicit operator EnumResourcePackType(ResourcePackType type) => type.value;
		public static implicit operator ResourcePackType(EnumResourcePackType value)
		{
			switch (value) {
				case EnumResourcePackType.Zip:
					return Zip;
				case EnumResourcePackType.Folder:
					return Folder;
				case EnumResourcePackType.Mod:
					return Mod;
				default:
					return PlainFolder;
			}
		}

		public static ResourcePackType[] GetValues() => _values;
	}
}
