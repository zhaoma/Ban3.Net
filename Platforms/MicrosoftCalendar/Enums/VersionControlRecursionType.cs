using System;
namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Enums
{

	public enum VersionControlRecursionType
	{
		/// <summary>
		/// Return specified item and all descendants
		/// </summary>
		Full,
		/// <summary>
		/// Only return the specified item.
		/// </summary>
		None,
		/// <summary>
		/// Return the specified item and its direct children.
		/// </summary>
		OneLevel,
		/// <summary>
		/// Return the specified item and its direct children, 
		/// as well as recursive chains of nested child folders 
		/// that only contain a single folder.
		/// </summary>
		OneLevelPlusNestedEmptyFolders

	}
}

