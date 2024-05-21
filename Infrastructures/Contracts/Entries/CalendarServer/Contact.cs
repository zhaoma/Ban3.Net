//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class Contact : IZero
{
    #region Property

    /// <summary>
    /// Etag
    /// http实体标记
    /// </summary>
    public string Etag { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string AssistantName { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public string Birthday { get; set; }

    /// <summary>
    /// 商业地址
    /// </summary>
    public Address BusinessAddress { get; set; }

    /// <summary>
    /// 商业主页（待完善）
    /// </summary>
    public string BusinessHomePage { get; set; }

    /// <summary>
    /// 工作电话
    /// </summary>
    public List<string> BusinessHomePhone { get; set; }

    /// <summary>
    /// 类别
    /// </summary>
    public List<string> Categories { get; set; }

    /// <summary>
    /// 版本应用
    /// </summary>
    public string ChangeKey { get; set; }

    /// <summary>
    /// 孩子姓名
    /// </summary>
    public List<string> Children { get; set; }

    /// <summary>
    /// 公司名
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    public string CreatedDateTime { get; set; }

    /// <summary>
    /// 公司部门
    /// </summary>
    public string Department { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// 邮件地址
    /// </summary>
    public List<EmailAddress> EmailAddresses { get; set; }

    /// <summary>
    /// 姓名归档
    /// </summary>
    public string FileAs { get; set; }

    /// <summary>
    /// 亲属
    /// </summary>
    public string Generation { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    public string GivenName { get; set; }

    /// <summary>
    /// 家庭住址
    /// </summary>
    public Address HomeAddress { get; set; }

    /// <summary>
    /// 家庭电话
    /// </summary>
    public List<string> HomePhones { get; set; }

    /// <summary>
    /// 身份唯一标识
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 紧急联系地址
    /// </summary>
    public List<string> ImAddresses { get; set; }

    /// <summary>
    /// 姓名缩写
    /// </summary>
    public string Initials { get; set; }
    /// <summary>
    /// 工作主题
    /// </summary>
    public string JobTitle { get; set; }

    /// <summary>
    /// 修改的日期
    /// </summary>
    public string LastModifiedDateTime { get; set; }

    /// <summary>
    /// 经理的姓名
    /// </summary>
    public string Manager { get; set; }

    /// <summary>
    /// 中间名
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// 移动电话
    /// </summary>
    public string MobilePhone { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    /// 办公地点
    /// </summary>
    public string OfficeLocation { get; set; }

    /// <summary>
    /// 其他地址
    /// </summary>
    public Address OtherAddress { get; set; }

    /// <summary>
    /// 父母id
    /// </summary>
    public string ParentFolderId { get; set; }

    /// <summary>
    /// 用户说明
    /// </summary>
    public string PersonalNotes { get; set; }

    /// <summary>
    /// 个人照片
    /// </summary>
    public List<Photo> Photos { get; set; }

    /// <summary>
    /// 电话号码
    /// </summary>
    public List<Phone> PhoneNumbers { get; set; }

    /// <summary>
    /// 职业
    /// </summary>
    public string Profession { get; set; }

    /// <summary>
    /// 资源名称
    /// </summary>
    public string ResourceName { get; set; }

    /// <summary>
    /// 配偶姓名
    /// </summary>
    public string SpouseName { get; set; }
    /// <summary>
    /// 姓氏
    /// </summary>
    public string Surname { get; set; }
    /// <summary>
    /// 主题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// 公司日语名
    /// </summary>
    public string YomiCompanyName { get; set; }

    /// <summary>
    /// 日本名字
    /// </summary>
    public string YomiGivenName { get; set; }

    /// <summary>
    /// 日本姓氏
    /// </summary>
    public string YomiSurname { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    public string OriginalData { get; set; }

    /// <summary>
    /// 个人的只读元数据.
    /// </summary>
    public PersonMetadata Metadata { get; set; }

    /// <summary>
    /// 语言.
    /// </summary>
    public MetaValue Locales { get; set; }

    /// <summary>
    /// 昵称.
    /// </summary>
    public MetaValue Nicknames { get; set; }

    /// <summary>
    /// 只读，封面照片
    /// </summary>
    public Photo CoverPhotos { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public ItemFormatted Genders { get; set; }

    /// <summary>
    /// 年龄范围
    /// </summary>
    public AgeRange AgeRanges { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public Birthday Birthdays { get; set; }

    /// <summary>
    /// 个人事件
    /// </summary>
    public ContactEvent Events { get; set; }

    /// <summary>
    ///个人地址
    /// </summary>
    public Address Addresses { get; set; }

    /// <summary>
    /// 家庭住宅
    /// </summary>
    public Residence Residences { get; set; }

    /// <summary>
    /// 即时消息客户端
    /// </summary>
    public ImClient ImClients { get; set; }

    /// <summary>
    /// 口号
    /// </summary>
    public MetaValue Taglines { get; set; }

    /// <summary>
    /// 传记
    /// </summary>
    public Biographie Biographies { get; set; }

    /// <summary>
    /// 相关联人的Url
    /// </summary>
    public Url Urls { get; set; }

    /// <summary>
    /// 过去或者现在的组织
    /// </summary>
    public Organization Organizations { get; set; }

    /// <summary>
    /// 职业.
    /// </summary>
    public MetaValue Occupations { get; set; }

    /// <summary>
    /// 爱好.
    /// </summary>
    public MetaValue Interests { get; set; }

    /// <summary>
    /// 技能
    /// </summary>
    public MetaValue Skills { get; set; }

    /// <summary>
    /// 荣誉
    /// </summary>
    public MetaValue BraggingRights { get; set; }

    /// <summary>
    /// 关系网
    /// </summary>
    public Relation Relations { get; set; }

    /// <summary>
    /// 只读，关系兴趣.
    /// </summary>
    public ItemFormatted RelationshipInterests { get; set; }

    /// <summary>
    ///只读关系状态
    /// </summary>
    public ItemFormatted RelationshipStatuses { get; set; }

    /// <summary>
    /// 只读组成员.
    /// </summary>
    public Membership Memberships { get; set; }

    /// <summary>
    /// 用户定义的数据
    /// </summary>
    public UserDefined UserDefineds { get; set; }

    #endregion

    /// <summary>
    /// 构造函数
    /// </summary>
    public Contact()
    {

    }
}
