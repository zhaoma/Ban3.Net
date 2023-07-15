using System;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    [Flags]
    public enum ACE_FLAGS:byte
    {

        ///Child objects that are containers, such as directories, inherit the ACE as an effective ACE. The inherited ACE is inheritable unless the NO_PROPAGATE_INHERIT_ACE bit flag is also set.
        CONTAINER_INHERIT_ACE = 0x02,

        ///Used with system-audit ACEs in a system access control list (SACL) to generate audit messages for failed access attempts.
        FAILED_ACCESS_ACE_FLAG = 0x80,

        ///Indicates an inherit-only ACE, which does not control access to the object to which it is attached. If this flag is not set, the ACE is an effective ACE that controls access to the object to which it is attached.
        ///Both effective and inherit-only ACEs can be inherited depending on the state of the other inheritance flags.
        INHERIT_ONLY_ACE = 0x08,

        ///Used to indicate that the ACE was inherited.<54> See section 2.5.3.5 for processing rules for setting this flag.
        INHERITED_ACE = 0x10,

        ///If the ACE is inherited by a child object, the system clears the OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE flags in the inherited ACE. This prevents the ACE from being inherited by subsequent generations of objects.
        NO_PROPAGATE_INHERIT_ACE = 0x04,

        ///Noncontainer child objects inherit the ACE as an effective ACE.
        ///For child objects that are containers, the ACE is inherited as an inherit-only ACE unless the NO_PROPAGATE_INHERIT_ACE bit flag is also set.
        OBJECT_INHERIT_ACE = 0x01,

        ///	Used with system-audit ACEs in a SACL to generate audit messages for successful access attempts.
        SUCCESSFUL_ACCESS_ACE_FLAG = 0x40

    }
}