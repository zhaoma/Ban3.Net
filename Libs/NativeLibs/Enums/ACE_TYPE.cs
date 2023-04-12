namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum ACE_TYPE:byte
    {
        ///Access-allowed ACE that uses the ACCESS_ALLOWED_ACE (section 2.4.4.2) structure.
        ACCESS_ALLOWED_ACE_TYPE = 0x00,

        ///Access-denied ACE that uses the ACCESS_DENIED_ACE (section 2.4.4.4) structure.
        ACCESS_DENIED_ACE_TYPE = 0x01,

        ///System-audit ACE that uses the SYSTEM_AUDIT_ACE (section 2.4.4.10) structure.
        SYSTEM_AUDIT_ACE_TYPE = 0x02,

        ///Reserved for future use.
        SYSTEM_ALARM_ACE_TYPE = 0x03,

        ///Reserved for future use.
        ACCESS_ALLOWED_COMPOUND_ACE_TYPE = 0x04,

        ///Object-specific access-allowed ACE that uses the ACCESS_ALLOWED_OBJECT_ACE (section 2.4.4.3) structure.
        ACCESS_ALLOWED_OBJECT_ACE_TYPE = 0x05,

        ///Object-specific access-denied ACE that uses the ACCESS_DENIED_OBJECT_ACE (section 2.4.4.5) structure.
        ACCESS_DENIED_OBJECT_ACE_TYPE = 0x06,

        ///Object-specific system-audit ACE that uses the SYSTEM_AUDIT_OBJECT_ACE (section 2.4.4.11) structure.
        SYSTEM_AUDIT_OBJECT_ACE_TYPE = 0x07,

        ///Reserved for future use.
        SYSTEM_ALARM_OBJECT_ACE_TYPE = 0x08,

        ///Access-allowed callback ACE that uses the ACCESS_ALLOWED_CALLBACK_ACE (section 2.4.4.6) structure.
        ACCESS_ALLOWED_CALLBACK_ACE_TYPE = 0x09,

        ///Access-denied callback ACE that uses the ACCESS_DENIED_CALLBACK_ACE (section 2.4.4.7) structure.
        ACCESS_DENIED_CALLBACK_ACE_TYPE = 0x0A,

        ///Object-specific access-allowed callback ACE that uses the ACCESS_ALLOWED_CALLBACK_OBJECT_ACE (section 2.4.4.8) structure.
        ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE = 0x0B,

        ///Object-specific access-denied callback ACE that uses the ACCESS_DENIED_CALLBACK_OBJECT_ACE (section 2.4.4.9) structure.
        ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE = 0x0C,

        ///System-audit callback ACE that uses the SYSTEM_AUDIT_CALLBACK_ACE (section 2.4.4.12) structure.
        SYSTEM_AUDIT_CALLBACK_ACE_TYPE = 0x0D,

        ///Reserved for future use.
        SYSTEM_ALARM_CALLBACK_ACE_TYPE = 0x0E,

        ///Object-specific system-audit callback ACE that uses the SYSTEM_AUDIT_CALLBACK_OBJECT_ACE (section 2.4.4.14) structure.
        SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE = 0x0F,

        ///Reserved for future use.
        SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE = 0x10,

        ///Mandatory label ACE that uses the SYSTEM_MANDATORY_LABEL_ACE (section 2.4.4.13) structure.
        SYSTEM_MANDATORY_LABEL_ACE_TYPE = 0x11,

        ///Resource attribute ACE that uses the SYSTEM_RESOURCE_ATTRIBUTE_ACE (section 2.4.4.15)
        SYSTEM_RESOURCE_ATTRIBUTE_ACE_TYPE = 0x12,

        ///	A central policy ID ACE that uses the SYSTEM_SCOPED_POLICY_ID_ACE (section 2.4.4.16)
        SYSTEM_SCOPED_POLICY_ID_ACE_TYPE = 0x13

    }
}