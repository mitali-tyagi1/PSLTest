using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using AutoMapper;
using PSLTest.Helper;

namespace PSLTest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*var serializer = new XmlSerializer(typeof(Item));
            Item pubreq = new Item();
            var serializer = new XmlSerializer(typeof(pubrequest));
            using (var reader = XmlReader.Create(@"D:\Work\PSL\PSLTest\PSLTest\pub.xml"))
            {
                pubrequest info = (pubrequest)serializer.Deserialize(reader);
            }*/


            /*var serializer = new XmlSerializer(typeof(pubrequest));
            pubrequest pubreq = new pubrequest();
            using (var reader = XmlReader.Create(@"D:\Work\PSL\PSLTest\PSLTest\pub.xml"))
            {
                pubreq = (pubrequest)serializer.Deserialize(reader);
            }
             Mapper.CreateMap<pubrequest, Item>().ForMember(it => it.ItemId, map => map.MapFrom(pb => pb.RequestId ));

            var item = Mapper.Map<pubrequest, Item>(pubreq);*/

            //loadRequestItemXML();
            loadPubRequestXML();
        }

        public void loadRequestItemXML()
        {
            var serializer = new XmlSerializer(typeof(pubrequest));
            using (var reader = XmlReader.Create("D:\\Work\\PSL\\PSLTest_dev\\PSLTest\\PSLTest\\pub.xml"))
            {
                pubrequest info = (pubrequest)serializer.Deserialize(reader);
                // do whatever you wanted to do with those locations
                Mapper.CreateMap<request, Item>().ForMember(s => s.ActualEntityId, opt => opt.MapFrom(c => c.Action));
                var item = Mapper.Map<List<request>, List<Item>>(info.Request);
            }
        }


        public void loadPubRequestXML()
        {
            ItemHelper itHelp = new ItemHelper();
            XDocument xDoc = XDocument.Load("D:\\Work\\PSL\\PSLTest_dev\\PSLTest\\PSLTest\\pub.xml");
            string entityid = getEntityId(xDoc);
            string strDLAPTier=getDLAPTier(xDoc);
            var itemXML = from itXML in xDoc.Descendants("pubrequest").Elements("request") select itXML;
            ItemRequest itemReq = new ItemRequest();
            itemReq.Item = new List<Item>();
            foreach (var item in itemXML)
            {
                Item newItem = new Item();
                newItem.ItemId = item.Attribute("rsuiteid").Value;
                newItem.EntityId = entityid;
                Data itemdata = new Data();
                itemdata.Parent = itHelp.GetParentId(item);
                itemdata.Sequence = itHelp.GetSequecneId(item);
                itemdata.Type = itHelp.GetType(item);
                itemdata.Title = itHelp.GetTitle(item);
                itemdata.Href= itHelp.GetHref(item,itemdata.Type,"","",strDLAPTier,entityid);
                //itemdata.Metadata = itHelp.GetbfwMetadata(item);

                newItem.Data = itemdata;
                itemReq.Item.Add(newItem);
            }
            XmlSerializer xmlSerializer = new XmlSerializer(itemReq.GetType());
            TextWriter textWriter = new StreamWriter("D:\\Work\\PSL\\PSLTest_dev\\PSLTest\\PSLTest\\mohit.xml");
            xmlSerializer.Serialize(textWriter, itemReq);
            textWriter.Close();
        }

        public string getEntityId(XDocument pubrequest)
        {
            string strEntityId = string.Empty;
            strEntityId = pubrequest.Element("pubrequest").Attribute("entityid").Value;
            if (strEntityId == "")
                strEntityId = "PRODUCT_MASTER_COURSE_ID";
            return strEntityId;
        }
        public string getDLAPTier(XDocument pubrequest)
        {
            string strEntityId = string.Empty;
            strEntityId = pubrequest.Element("pubrequest").Attribute("tier").Value;
            if (strEntityId == "")
                strEntityId = "dev";
            return strEntityId;
        }
    }
}