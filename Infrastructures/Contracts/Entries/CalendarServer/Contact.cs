using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class Contact
{
    #region Property

    /// <summary>
    /// Etag
    /// http实体标记
    /// </summary>
    [DataMember]
    public string Etag { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [DataMember]
    public string AssistantName { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    [DataMember]
    public string Birthday { get; set; }

    /// <summary>
    /// 商业地址
    /// </summary>
    [DataMember]
    public Address BusinessAddress { get; set; }

    /// <summary>
    /// 商业主页（待完善）
    /// </summary>
    [DataMember]
    public string BusinessHomePage { get; set; }

    /// <summary>
    /// 工作电话
    /// </summary>
    [DataMember]
    public List<string> BusinessHomePhone { get; set; }

    /// <summary>
    /// 类别
    /// </summary>
    [DataMember]
    public List<string> Categories { get; set; }
    /// <summary>
    /// 版本应用
    /// </summary>
    [DataMember]
    public string ChangeKey { get; set; }

    /// <summary>
    /// 孩子姓名
    /// </summary>
    [DataMember]
    public List<string> Children { get; set; }

    /// <summary>
    /// 公司名
    /// </summary>
    [DataMember]
    public string CompanyName { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    [DataMember]
    public string CreatedDateTime { get; set; }

    /// <summary>
    /// 公司部门
    /// </summary>
    [DataMember]
    public string Department { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [DataMember]
    public string DisplayName { get; set; }

    /// <summary>
    /// 邮件地址
    /// </summary>
    [DataMember]
    public List<EmailAddress> EmailAddresses { get; set; }

    /// <summary>
    /// 姓名归档
    /// </summary>
    [DataMember]
    public string FileAs { get; set; }

    /// <summary>
    /// 亲属
    /// </summary>
    [DataMember]
    public string Generation { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    [DataMember]
    public string GivenName { get; set; }

    /// <summary>
    /// 家庭住址
    /// </summary>
    [DataMember]
    public Address HomeAddress { get; set; }

    /// <summary>
    /// 家庭电话
    /// </summary>
    [DataMember]
    public List<string> HomePhones { get; set; }

    /// <summary>
    /// 身份唯一标识
    /// </summary>
    [DataMember]
    public string Id { get; set; }

    /// <summary>
    /// 紧急联系地址
    /// </summary>
    [DataMember]
    public List<string> ImAddresses { get; set; }

    /// <summary>
    /// 姓名缩写
    /// </summary>
    [DataMember]
    public string Initials { get; set; }
    /// <summary>
    /// 工作主题
    /// </summary>
    [DataMember]
    public string JobTitle { get; set; }

    /// <summary>
    /// 修改的日期
    /// </summary>
    [DataMember]
    public string LastModifiedDateTime { get; set; }

    /// <summary>
    /// 经理的姓名
    /// </summary>
    [DataMember]
    public string Manager { get; set; }

    /// <summary>
    /// 中间名
    /// </summary>
    [DataMember]
    public string MiddleName { get; set; }

    /// <summary>
    /// 移动电话
    /// </summary>
    public string MobilePhone { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [DataMember]
    public string NickName { get; set; }

    /// <summary>
    /// 办公地点
    /// </summary>
    [DataMember]
    public string OfficeLocation { get; set; }

    /// <summary>
    /// 其他地址
    /// </summary>
    public Address OtherAddress { get; set; }

    /// <summary>
    /// 父母id
    /// </summary>
    [DataMember]
    public string ParentFolderId { get; set; }

    /// <summary>
    /// 用户说明
    /// </summary>
    [DataMember]
    public string PersonalNotes { get; set; }

    /// <summary>
    /// 个人照片
    /// </summary>
    [DataMember]
    public List<Photo> Photos { get; set; }

    /// <summary>
    /// 电话号码
    /// </summary>
    [DataMember]
    public List<Phone> PhoneNumbers { get; set; }

    /// <summary>
    /// 职业
    /// </summary>
    [DataMember]
    public string Profession { get; set; }

    /// <summary>
    /// 资源名称
    /// </summary>
    [DataMember]
    public string ResourceName { get; set; }

    /// <summary>
    /// 配偶姓名
    /// </summary>
    [DataMember]
    public string SpouseName { get; set; }
    /// <summary>
    /// 姓氏
    /// </summary>
    [DataMember]
    public string Surname { get; set; }
    /// <summary>
    /// 主题
    /// </summary>
    [DataMember]
    public string Title { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    [DataMember]
    public string Type { get; set; }

    /// <summary>
    /// 公司日语名
    /// </summary>
    [DataMember]
    public string YomiCompanyName { get; set; }

    /// <summary>
    /// 日本名字
    /// </summary>
    [DataMember]
    public string YomiGivenName { get; set; }

    /// <summary>
    /// 日本姓氏
    /// </summary>
    [DataMember]
    public string YomiSurname { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [DataMember]
    public string OriginalData { get; set; }

    /// <summary>
    /// 个人的只读元数据.
    /// </summary>
    [DataMember]
    public PersonMetadata Metadata { get; set; }

    /// <summary>
    /// 语言.
    /// </summary>
    [DataMember]
    public Item Locales { get; set; }

    /// <summary>
    /// 昵称.
    /// </summary>        
    [DataMember]
    public Item Nicknames { get; set; }

    /// <summary>
    /// 只读，封面照片
    /// </summary>
    [DataMember]
    public Photo CoverPhotos { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [DataMember]
    public ItemFormatted Genders { get; set; }

    /// <summary>
    /// 年龄范围
    /// </summary>
    [DataMember]
    public AgeRange AgeRanges { get; set; }
    /// <summary>
    /// 生日
    /// </summary>
    [DataMember]
    public Birthday Birthdays { get; set; }

    /// <summary>
    /// 个人事件
    /// </summary>
    [DataMember]
    public ContactEvent Events { get; set; }

    /// <summary>
    ///个人地址
    /// </summary>
    [DataMember]
    public Address Addresses { get; set; }

    /// <summary>
    /// 家庭住宅
    /// </summary>
    [DataMember]
    public Residence Residences { get; set; }

    /// <summary>
    /// 即时消息客户端
    /// </summary>
    [DataMember]
    public ImClient ImClients { get; set; }

    /// <summary>
    /// 口号
    /// </summary>
    [DataMember]
    public Item Taglines { get; set; }

    /// <summary>
    /// 传记
    /// </summary>
    [DataMember]
    public Biographie Biographies { get; set; }

    /// <summary>
    /// 相关联人的Url      
    /// </summary>
    [DataMember]
    public Url Urls { get; set; }

    /// <summary>
    /// 过去或者现在的组织
    /// </summary>
    [DataMember]
    public Organization Organizations { get; set; }

    /// <summary>
    /// 职业.
    /// </summary>
    [DataMember]
    public Item Occupations { get; set; }

    /// <summary>
    /// 爱好.
    /// </summary>
    [DataMember]
    public Item Interests { get; set; }

    /// <summary>
    /// 技能
    /// </summary>
    [DataMember]
    public Item Skills { get; set; }

    /// <summary>
    /// 荣誉
    /// </summary>
    [DataMember]
    public Item BraggingRights { get; set; }

    /// <summary>
    /// 关系网
    /// </summary>
    [DataMember]
    public Relation Relations { get; set; }

    /// <summary>
    /// 只读，关系兴趣.
    /// </summary>
    [DataMember]
    public ItemFormatted RelationshipInterests { get; set; }

    /// <summary>
    ///只读关系状态
    /// </summary>
    [DataMember]
    public ItemFormatted RelationshipStatuses { get; set; }

    /// <summary>
    /// 只读组成员.
    /// </summary>
    [DataMember]
    public Membership Memberships { get; set; }

    /// <summary>
    /// 用户定义的数据
    /// </summary>
    [DataMember]
    public UserDefined UserDefineds { get; set; }

    #endregion

    /// <summary>
    /// 构造函数
    /// </summary>
    public Contact()
    {

    }
}
