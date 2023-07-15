namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The LSA_FOREST_TRUST_RECORD_TYPE enumeration defines the type of a Local Security Authority forest trust record.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-lsa_forest_trust_record_type
    /// </summary>
    public enum LSA_FOREST_TRUST_RECORD_TYPE
    {
        /// <summary>
        /// Record contains an included top-level name.
        /// </summary>
        ForestTrustTopLevelName,

        /// <summary>
        /// Record contains an excluded top-level name.
        /// </summary>
        ForestTrustTopLevelNameEx,

        /// <summary>
        /// Record contains an LSA_FOREST_TRUST_DOMAIN_INFO structure.
        /// </summary>
        ForestTrustDomainInfo,
        ForestTrustBinaryInfo,
        ForestTrustScannerInfo,

        /// <summary>
        /// Marks the end of an enumeration.
        /// </summary>
        ForestTrustRecordTypeLast
    }
}