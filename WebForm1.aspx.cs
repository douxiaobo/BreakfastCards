using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Excel= Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Xml;
using Microsoft.Office.Interop.Excel;

namespace Breakfast_Cards_Manage_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string ThisMonth = DateTime.Now.ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("en-US"));
        string NextMonth = DateTime.Now.AddMonths(1).ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("en-US"));
        protected void Page_Load(object sender, EventArgs e)
        {
            // Github Test...


            Label_ThisMonth.Text = ThisMonth;
            Label_ThisMonth.Text += "    /" + DateTime.Now.ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("zh-CN"));
            Label_ThisMonth.Text += "    /" + DateTime.Now.ToString("yyyy-MM", CultureInfo.GetCultureInfo("en-US"));

            Label_NextMonth.Text = NextMonth;
            Label_NextMonth.Text += "    /" + DateTime.Now.AddMonths(1).ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("zh-CN"));

            DataSet myds=new DataSet();
            String dir = ThisMonth + ".xml";
            myds.ReadXml(Server.MapPath(dir));
            GridView1.DataSource = myds;
            GridView1.DataBind();

            if(!File.Exists(NextMonth+".xml"))
            {
                Label_NextMonth.Text = "Never Created";
            }
        }

        protected void Comfirm_Click(object sender, EventArgs e)
        {
            if(!File.Exists(NextMonth+".xml"))
            {
                CreateXMLFile();
            }
            else
            {
                UpdateXML();
            }
        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            if (!File.Exists(NextMonth + ".xml"))
            {
                CreateXMLFile();
            }
            else
            {
                UpdateXML();
            }
        }
        public void CreateXMLFile()
        {
            XmlDocument XMLDoc = new XmlDocument();
            //创建类型声明节点
            XmlNode node = XMLDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            XMLDoc.AppendChild(node);
            //创建XML根节点
            XmlNode root = XMLDoc.CreateElement("Cards");
            XMLDoc.AppendChild(root);

            XmlNode root1 = XMLDoc.CreateElement("Card");
            root1.AppendChild(root1);

            CreateNode(XMLDoc, root1, DropDownList1.SelectedItem.Text, TextBox1.Text);

            XMLDoc.Save(NextMonth + ".xml");
        }

        public void CreateNode(XmlDocument XMLDoc,XmlNode parentNode,string name, string value)
        {
            //创建对应XML
            XmlNode node = XMLDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }

        public void UpdateXML()
        {
            XmlDocument XMLDoc=new XmlDocument();
            XMLDoc.Load(NextMonth + ".xml");
            XmlNode xns = XMLDoc.SelectSingleNode("Cards/Card");
            XmlNodeList xmlNodeList = xns.ChildNodes;
            foreach(XmlNode xmlNode in xmlNodeList)
            {
                XmlElement xmlElement=(XmlElement)xmlNode;
                
            }
            XMLDoc.Save(NextMonth + ".xml");
        }
    }
}