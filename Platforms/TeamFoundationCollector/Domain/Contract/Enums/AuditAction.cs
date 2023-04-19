namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The change type (add, edit, delete).
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/get-definition-revisions?view=azure-devops-rest-7.0#auditaction
/// </summary>
public enum AuditAction
{
    Add,

    Delete,

    Update
}