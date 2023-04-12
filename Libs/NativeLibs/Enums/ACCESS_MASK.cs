using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The ACCESS_MASK type is a bitmask that specifies a set of access rights in the access mask of an access control entry.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/kernel/access-mask
    /// 
    /// </summary>
    [Flags]
    public enum ACCESS_MASK : uint
    {
        /*
         
        32 bits
        The bits in this value are allocated as follows.

        Bits	Meaning
        0 15    Specific rights. Contains the access mask specific to the object type associated with the mask.
        16 23   Standard rights. Contains the object's standard access rights.
        24      Access system security (ACCESS_SYSTEM_SECURITY). It is used to indicate access to a system access control list (SACL). 
                This type of access requires the calling process to have the SE_SECURITY_NAME (Manage auditing and security log) privilege. 
                If this flag is set in the access mask of an audit access ACE (successful or unsuccessful access), 
                the SACL access will be audited.
        25      Maximum allowed (MAXIMUM_ALLOWED).
        26 27   Reserved.
        28      Generic all (GENERIC_ALL).
        29      Generic execute (GENERIC_EXECUTE).
        30      Generic write (GENERIC_WRITE).
        31      Generic read (GENERIC_READ).

        Standard rights bits, 16 to 23, contain the object's standard access rights and can be a combination of the following predefined flags.

        Bit	    Flag	        Meaning
        16      DELETE          Delete access.
        17      READ_CONTROL    Read access to the owner, group, and discretionary access control list (DACL) of the security descriptor.
        18      WRITE_DAC       Write access to the DACL.
        19      WRITE_OWNER     Write access to owner.
        20      SYNCHRONIZE     Synchronize access.
         
         */

        GENERIC_READ = 0x80000000,
        GENERIC_WRITE=0x40000000,
        GENERIC_EXECUTE=0x20000000,

        /// <summary>
        /// 
        /// </summary>
        GENERIC_ALL=0x10000000,

        /// <summary>
        /// When used in an Access Request operation: When requested, this bit grants the requestor the maximum permissions allowed to the object through the Access Check Algorithm.
        /// This bit can only be requested; it cannot be set in an ACE.
        /// When used to set the Security Descriptor on an object: Specifying the Maximum Allowed bit in the SECURITY_DESCRIPTOR has no meaning.
        /// The MA bit SHOULD NOT be set and SHOULD be ignored when part of a SECURITY_DESCRIPTOR structure.
        /// </summary>
        MAXIMUM_ALLOWED = 0x02000000,

        /// <summary>
        /// When used in an Access Request operation: When requested, this bit grants the requestor the right to change the SACL of an object.
        /// This bit MUST NOT be set in an ACE that is part of a DACL. When set in an ACE that is part of a SACL, this bit controls auditing of accesses to the SACL itself. 
        /// </summary>
        ACCESS_SYSTEM_SECURITY = 0x01000000,

        /// <summary>
        /// Specifies access to the object sufficient to synchronize or wait on the object.
        /// </summary>
        SYNCHRONIZE = 0x00100000,

        /// <summary>
        /// Specifies access to change the owner of the object as listed in the security descriptor.
        /// </summary>
        WRITE_OWNER = 0x00080000,

        /// <summary>
        /// Specifies access to change the discretionary access control list of the security descriptor of an object.
        /// </summary>
        WRITE_DAC = 0x00040000,

        /// <summary>
        /// Specifies access to read the security descriptor of an object.
        /// </summary>
        READ_CONTROL = 0x00020000,

        /// <summary>
        /// Specifies access to delete an object.
        /// </summary>
        DELETE = 0x00010000,

        STANDARD_RIGHTS_ALL = DELETE| READ_CONTROL| WRITE_DAC| WRITE_OWNER| SYNCHRONIZE,
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL,
        STANDARD_RIGHTS_READ = READ_CONTROL,
        STANDARD_RIGHTS_REQUIRED = DELETE | READ_CONTROL | WRITE_DAC | WRITE_OWNER,
        STANDARD_RIGHTS_WRITE = READ_CONTROL,

        /// <summary>
        /// Query information about the enlistment (see ZwQueryInformationEnlistment).
        /// </summary>
        ENLISTMENT_QUERY_INFORMATION,

        /// <summary>
        /// Set information for the enlistment (see ZwSetInformationEnlistment).
        /// </summary>
        ENLISTMENT_SET_INFORMATION,

        /// <summary>
        /// Recover the enlistment (see ZwRecoverEnlistment).
        /// </summary>
        ENLISTMENT_RECOVER,

        /// <summary>
        /// Perform operations that a resource manager that is not superior performs
        /// (see ZwRollbackEnlistment, ZwPrePrepareComplete, ZwPrepareComplete, ZwCommitComplete, ZwRollbackComplete, ZwSinglePhaseReject, ZwReadOnlyEnlistment).
        /// </summary>
        ENLISTMENT_SUBORDINATE_RIGHTS,

        /// <summary>
        /// Perform operations that a superior transaction manager must perform (see ZwPrepareEnlistment, ZwPrePrepareEnlistment, ZwCommitEnlistment).
        /// </summary>
        ENLISTMENT_SUPERIOR_RIGHTS,

        /// <summary>
        /// STANDARD_RIGHTS_READ and ENLISTMENT_QUERY_INFORMATION
        /// </summary>
        ENLISTMENT_GENERIC_READ = STANDARD_RIGHTS_READ| ENLISTMENT_QUERY_INFORMATION,

        /// <summary>
        /// STANDARD_RIGHTS_WRITE, ENLISTMENT_SET_INFORMATION, ENLISTMENT_RECOVER, ENLISTMENT_REFERENCE, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS
        /// </summary>
        ENLISTMENT_GENERIC_WRITE,

        /// <summary>
        /// STANDARD_RIGHTS_EXECUTE, ENLISTMENT_RECOVER, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS
        /// </summary>
        ENLISTMENT_GENERIC_EXECUTE,

        /// <summary>
        /// STANDARD_RIGHTS_REQUIRED, ENLISTMENT_GENERIC_READ, ENLISTMENT_GENERIC_WRITE, and ENLISTMENT_GENERIC_EXECUTE
        /// </summary>
        ENLISTMENT_ALL_ACCESS
    }
}
