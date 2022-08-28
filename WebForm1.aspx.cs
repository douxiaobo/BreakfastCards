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
using MySql.Data.MySqlClient;

namespace Breakfast_Cards_Manage_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string ThisYearMonth = DateTime.Now.ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("en-US"));
        string NextYearMonth = DateTime.Now.AddMonths(1).ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("en-US"));

        string ThisYear = DateTime.Now.ToString("yyyy");
        string ThisMonth = DateTime.Now.ToString("MMMM",CultureInfo.GetCultureInfo("en-US"));
                
        protected void Page_Load(object sender, EventArgs e)
        {
            // Github Test...
            
            if(!IsPostBack)
            {
                GridView2.DataBind();
            }

            Label_ThisYearMonth.Text = ThisYearMonth;
            Label_ThisYearMonth.Text += "    /" + DateTime.Now.ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("zh-CN"));
            Label_ThisYearMonth.Text += "    /" + DateTime.Now.ToString("yyyy-MM", CultureInfo.GetCultureInfo("en-US"));

            Label_NextYearMonth.Text = NextYearMonth;
            Label_NextYearMonth.Text += "    /" + DateTime.Now.AddMonths(1).ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("zh-CN"));

            DataSet myds=new DataSet();
            String dir = ThisYearMonth + ".xml";
            myds.ReadXml(Server.MapPath(dir));
            GridView1.DataSource = myds;
            GridView1.DataBind();

            if(!File.Exists(NextYearMonth+".xml"))
            {
                Label_NextYearMonth.Text = "Never Created";
            }
            int ThisYearInt = Convert.ToInt16(ThisYear);
            if (ThisMonth == "December")
                ThisYearInt++;
            for (int i = ThisYearInt; i >= 1997; i--)
            {
                DropDownList_Add_Year.Items.Add(i.ToString());
                DropDownList_Delete_Year.Items.Add(i.ToString());
                DropDownList_Revise_Year.Items.Add(i.ToString());
                DropDownList_Inquiry_Year.Items.Add(i.ToString());
            }

            Dictionary<int, string> Month_DigitToEng = new Dictionary<int, string>();
            Month_DigitToEng.Add(1,"January");
            Month_DigitToEng.Add(2,"February");
            Month_DigitToEng.Add(3,"March");
            Month_DigitToEng.Add(4,"April");
            Month_DigitToEng.Add(5,"May");
            Month_DigitToEng.Add(6,"June");
            Month_DigitToEng.Add(7,"July");
            Month_DigitToEng.Add(8,"August");
            Month_DigitToEng.Add(9,"September");
            Month_DigitToEng.Add(10,"October");
            Month_DigitToEng.Add(11,"November");
            Month_DigitToEng.Add(12,"December");

            Dictionary<int,string>.ValueCollection MonthCol=Month_DigitToEng.Values;
            foreach(string value in MonthCol)
            {
                DropDownList_Add_Month.Items.Add(value.ToString());
                DropDownList_Delete_Month.Items.Add(value.ToString());
                DropDownList_Revise_Month.Items.Add(value.ToString());
                DropDownList_Inquiry_Month.Items.Add(value.ToString());
            }

            Dictionary<int,string> GroupName_Dic=new Dictionary<int,string>();
            GroupName_Dic.Add(1,"Intune");
            GroupName_Dic.Add(2,"Office");
            GroupName_Dic.Add(3,"SCCM");
            GroupName_Dic.Add(4,"Teams");
            GroupName_Dic.Add(5,"POD1");
            GroupName_Dic.Add(6,"POD2");
            GroupName_Dic.Add(7,"S500_1");
            GroupName_Dic.Add(8,"S500_2");
            GroupName_Dic.Add(9,"SharePoint");

            Dictionary<int,string>.ValueCollection GroupNameCol=GroupName_Dic.Values;
            foreach(string value in GroupNameCol)
            {
                DropDownList_Add_GroupName.Items.Add(value.ToString());
                DropDownList_Delete_GroupName.Items.Add(value.ToString());
                DropDownList_Revise_GroupName.Items.Add(value.ToString());
                DropDownList_Inquiry_GroupName.Items.Add(value.ToString());
            }
        }

        protected void Comfirm_Click(object sender, EventArgs e)
        {
            if(!File.Exists(NextYearMonth+".xml"))
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
            if (!File.Exists(NextYearMonth + ".xml"))
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

            XMLDoc.Save(NextYearMonth + ".xml");
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
            XMLDoc.Load(NextYearMonth + ".xml");
            XmlNode xns = XMLDoc.SelectSingleNode("Cards/Card");
            XmlNodeList xmlNodeList = xns.ChildNodes;
            foreach(XmlNode xmlNode in xmlNodeList)
            {
                XmlElement xmlElement=(XmlElement)xmlNode;
                
            }
            XMLDoc.Save(NextYearMonth + ".xml");
        }

        protected void Button_Add_Comfirm_Click(object sender, EventArgs e)
        {
            Cards Cards_Add=new Cards();
            Cards_Add.YearMonth = DropDownList_Add_Year.Text + DropDownList_Add_Month.Text;
            if(DropDownList_Add_GroupName.Text=="Intune")
            {
                Cards_Add.Intune = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if(DropDownList_Add_GroupName.Text=="Office")
            {
                Cards_Add.Office = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if(DropDownList_Add_GroupName.Text=="SCCM")
            {
                Cards_Add.SCCM = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if(DropDownList_Add_GroupName.Text=="Teams")
            {
                Cards_Add.Teams= Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if(DropDownList_Add_GroupName.Text=="POD1")
            {
                Cards_Add.POD1 = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if (DropDownList_Add_GroupName.Text == "POD2")
            {
                Cards_Add.POD2 = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if(DropDownList_Add_GroupName.Text=="S500_1")
            {
                Cards_Add.S500_1 = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if (DropDownList_Add_GroupName.Text == "S500_2")
            {
                Cards_Add.S500_2 = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            else if(DropDownList_Add_GroupName.Text=="SharePoint")
            {
                Cards_Add.SharePoint = Convert.ToInt16(TextBox_Add_Quantity.Text);
            }
            BreakfastCardsEntities Breakfast_AddData=new BreakfastCardsEntities();
            Breakfast_AddData.Cards.Add(Cards_Add);
            Breakfast_AddData.SaveChanges();
        }

        protected void Button_Detele_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities Breakfast_Delete = new BreakfastCardsEntities();
            Cards Cards_Delete=new Cards();
            Cards_Delete.YearMonth= DropDownList_Delete_Year.Text + DropDownList_Delete_Month.Text;            
        }
    }
}