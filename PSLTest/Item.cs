using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PSLTest
{
    [Serializable]
    [XmlRoot("request")]

    public class ItemRequest
    {
        [XmlElement("item")]
        public List<Item> Item { get; set; }
    }
    public class Item
    {
        [XmlAttribute("itemid")]
        public string ItemId { get; set; }

        [XmlAttribute("entityid")]
        public string EntityId { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("resourceentityid")]
        public string ResourceEntityId { get; set; }
        
        [XmlAttribute("actualentityid")]
        public string ActualEntityId { get; set; }

        [XmlAttribute("creationdate")]
        public string CreationDate { get; set; }

        [XmlAttribute("creationby")]
        public string CreationBy { get; set; }

        [XmlAttribute("modifieddate")]
        public string ModifiedDate { get; set; }

        [XmlAttribute("modifiedby")]
        public string ModifiedBy { get; set; }

        [XmlAttribute("origindepth")]
        public string OriginDepth { get; set; }

        [XmlAttribute("derivativedepth")]
        public string DerivativeDepth { get; set; }

        [XmlElement("data")]
        public Data Data { get; set; }        
    }

    public class Data
    {
        [XmlElement("link")]
        public Link Link { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("parent")]
        public string Parent { get; set; }

        [XmlElement("sequence")]
        public string Sequence { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("folder")]
        public string Folder { get; set; }

        [XmlElement("href")]
        public Href Href { get; set; }

        [XmlElement("timetocomplete")]
        public string TimeToComplete { get; set; }

        [XmlElement("category")]
        public int Category { get; set; }

        [XmlElement("categorysequence")]
        public string CategorySequence { get; set; }

        [XmlElement("period")]
        public Period Period { get; set; }

        [XmlElement("groupsetid")]
        public int GroupSetId { get; set; }

        [XmlElement("projectgroupsetid")]
        public int ProjectGroupSetId { get; set; }

        [XmlElement("duedate")]
        public DateTime DueDate { get; set; }

        [XmlElement("gradereleasedate")]
        public DateTime GradeReleaseDate { get; set; }

        [XmlElement("weight")]
        public int Weight { get; set; }

        [XmlElement("gradeentry")]
        public int GradeEntry { get; set; }

        [XmlElement("inputtable")]
        public InputTable InputTable { get; set; }

        [XmlElement("completiontrigger")]
        public int CompletionTrigger { get; set; }

        [XmlElement("submissiongradeaction")]
        public int SubmissionGradeAction { get; set; }

        [XmlElement("securitylevel")]
        public string SecurityLevel { get; set; }

        [XmlElement("bfw_type")]
        public string BfwType { get; set; }

        [XmlElement("bfw_subtype")]
        public string BfwSubType { get; set; }

        [XmlArray("bfw_meta"), XmlArrayItem("bfw_metadata")]
        public List<BfwMetadata> Metadata { get; set; }

        [XmlArray("bfw_properties"), XmlArrayItem("bfw_property")]
        public List<BfwProperty> Property { get; set; }

        [XmlElement("AssignmentSettings")]
        public AssignmentSettings AssignmentSettings { get; set; }

        [XmlElement("IsMarkAsCompleteChecked")]
        public bool IsMarkAsCompleteChecked { get; set; }

        [XmlElement("meta-bfw_assigned")]
        public bool MetaBfwAssigned { get; set; }

        [XmlElement("proxyConfig")]
        public ProxyConfig ProxyConfig { get; set; }

        [XmlElement("creationby")]
        public int CreationBy { get; set; }

        [XmlElement("meta-px-source")]
        public string MetaPxSource { get; set; }

        [XmlElement("meta-px-updated")]
        public string MetaPxUpdated { get; set; }

        [XmlElement("meta-px-user")]
        public string MetaPxUser { get; set; }

        [XmlElement("bfw_tocs")]
        public BfwTocs BfwTocs { get; set; }

        [XmlArray("meta-topics"), XmlArrayItem("meta-topic")]
        public List<MetaTopic> MetaTopic { get; set; }

        [XmlElement("meta-content-type")]
        public MetaContentType MetaContentType { get; set; }
    }
    public class Link
    {
        [XmlAttribute("courseid")]
        public string CourseId { get; set; }

        [XmlAttribute("itemid")]
        public string ItemId { get; set; }
    }

    public class Href
    {
        [XmlAttribute("entityid")]
        public string EntityId { get; set; }

        [XmlText]
        public string Name { get; set; }
    }

    public class Period
    {
        [XmlAttribute("inherit")]
        public string Inherit { get; set; }
    }

    public class InputTable
    {
        [XmlAttribute("inherit")]
        public string Inherit { get; set; }
    }

    public class BfwMetadata
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlText]
        public string MetDatavalue { get; set; }
    }

    public class BfwProperty
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }
    }

    public class AssignmentSettings
    {
        [XmlElement("AvailableCompletionTriggers")]
        public string AvailableCompletionTriggers { get; set; }

        [XmlElement("DefaultCompletionTrigger")]
        public int DefaultCompletionTrigger { get; set; }

        [XmlElement("AvailableSubmissionGradeActions")]
        public int AvailableSubmissionGradeActions { get; set; }

        [XmlElement("DefaultSubmissionGradeAction")]
        public int DefaultSubmissionGradeAction { get; set; }
    }

    public class ProxyConfig
    {
        [XmlElement("useProxyPage")]
        public bool UseProxyPage { get; set; }

        [XmlElement("stripJS")]
        public bool StripJS { get; set; }

        [XmlElement("allowComments")]
        public bool AllowComments { get; set; }
    }

    public class BfwTocs
    {
        [XmlElement("bfw_toc_contents")]
        public BfwTocContents BfwTocContents { get; set; }
    }

    public class BfwTocContents
    {
        [XmlAttribute("parentid")]
        public string ParentId { get; set; }

        [XmlAttribute("sequence")]
        public string Sequence { get; set; }
    }

    public class MetaTopic
    {
        [XmlAttribute("dlaptype")]
        public string DlapType { get; set; }
    }

    public class MetaContentType
    {
        [XmlAttribute("dlaptype")]
        public string DlapType { get; set; }
    }
}