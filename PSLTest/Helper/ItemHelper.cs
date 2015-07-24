using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace PSLTest.Helper
{
    public class ItemHelper
    {
        public Dictionary<string, string> DictforType = new Dictionary<string, string>()
        {
            {"learningcurve","CustomActivity"},
            {"resource","Resource"},
            {"arga","CustomActivity"},
            {"dropbox","Assignment"},
            {"unit","Folder"},
            {"quiz","Assessment"},
            {"argaflashcard","Assignment"},
        };

        public Dictionary<string, string> DictforHref = new Dictionary<string, string>()
        {
            {"quiz","a"},
            {"external","ExternalLocation"},
            {"internal","Internallocation"},
        };
        
        public string GetParentId(XElement xItemElement)
        {
            string strParentId = string.Empty;
            strParentId = xItemElement.Element("toc").Element("structure").Element("parentid").Value;
            return strParentId;
        }

        public string GetType(XElement xItemElement)
        {
            string strType = string.Empty;
            strType = xItemElement.Attribute("type").Value;
            if (strType != "" && DictforType.Keys.Contains(strType))
                strType = DictforType[strType].ToString();
            else 
                strType = "NO_VALUE";
            return strType;
        }

        public string GetSequecneId(XElement xItemElement)
        {
            string strSequence = "NO_VALUE";
            CommonFunctions  cmf=new CommonFunctions();
            strSequence = xItemElement.Element("toc").Element("structure").Element("sequence").Value;
            strSequence = cmf.ConvertToAgilixBasedSequence(strSequence);
            return strSequence;
        }

        public string GetTitle(XElement xItemElement)
        {
            string strTitle = "NO_VALUE";
            strTitle = xItemElement.Element("contentmetadata").Element("title").Value;
            return strTitle;
        }

        public Href GetHref(XElement xItemElement, string type, string bfwtype, string subtype,string  DLAPtier,string EntityId)
        {
            Href itemHref = new Href();
            string strHREF = "NO_VALUE";
            string StrUrl = "ftp://" + DLAPtier + ".dlap.bfwpub.com/" + "Sitebuilder";

            if (DictforHref.ContainsKey(type))
                strHREF = "a";
            else
            {
                string strFileName = xItemElement.Element("contentmetadata").Element("defaultfile").Value;
                string fileType = xItemElement.Element("contentmetadata").Element("defaultfile").Attribute("type").Value;
                if (DictforHref.ContainsKey(fileType))
                    strHREF = DictforHref[fileType] + "/" + strFileName;
            }
            itemHref.EntityId = EntityId;
            itemHref.Name = strHREF;
            return itemHref;
        }


        public List<BfwMetadata> GetbfwMetadata(XElement xItemElement)
        {
            List<BfwMetadata> bfwMetadata = new List<BfwMetadata>();
            var itemMetadata = from metadata in xItemElement.Descendants("coursecontentmetadata") where metadata.Element("coursecontentmetadata").Element("allowComments")!=null select metadata;

            foreach (var meta in itemMetadata)
            {
                BfwMetadata bfwMeta = new BfwMetadata();

                bfwMeta.MetDatavalue = meta.Value;
                bfwMeta.Type = "Boolean";
                bfwMeta.Name = "bfw_allowcomments";

                bfwMetadata.Add(bfwMeta);
            }
            return bfwMetadata;
        }
        


       
    }
}