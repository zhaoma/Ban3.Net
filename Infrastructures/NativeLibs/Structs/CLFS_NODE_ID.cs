using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Represents a node identifier.
    /// https://learn.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-clfs_node_id
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_NODE_ID
    {
        /// <summary>
        /// The CLFS node type.
        /// </summary>
        public uint cType;

        /// <summary>
        /// The size of the CLFS node, in bytes.
        /// </summary>
        public uint cbNode;
    }
}
