using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB = Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;

namespace RevitHello
{
    public partial class MainForm : System.Windows.Forms.Form
    {

        ExternalCommandData cmdDataForm;
        string msgForm;
        DB.ElementSet elementsForm = new DB.ElementSet();
        Autodesk.Revit.ApplicationServices.Application RevitApp;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(ExternalCommandData cmdData, string msg, DB.ElementSet elements)
        {
            InitializeComponent();
            cmdDataForm = cmdData;
            RevitApp = cmdDataForm.Application.Application;
            msgForm = msg;
            elementsForm = elements;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void GetVersionInfo(Autodesk.Revit.ApplicationServices.Application app)
        {
            if (app.VersionNumber == "2017")
            {
                TaskDialog.Show("Supported version",
                                "This application supported in this version.");
            }
            else
            {
                TaskDialog dialog = new TaskDialog("Unsupported version.");
                dialog.MainIcon = TaskDialogIcon.TaskDialogIconWarning;
                dialog.MainInstruction = "This application is only supported in Revit 2017.";
                dialog.Show();
            }
        }

        public void CreateInstance()
        {
            //============代码片段3-13 创建拉伸实体族============
            //创建族文档
            Document familyDoc = RevitApp.NewFamilyDocument(@"C:\ProgramData\Autodesk\RVT 2017\Family Templates\Chinese\公制常规模型.rft");
            using (Transaction transaction = new Transaction(familyDoc, "Create family"))
            {
                if (transaction.Start() == TransactionStatus.Started)
                {
                    CurveArray curveArray = new CurveArray();
                    curveArray.Append(Line.CreateBound(new XYZ(0, 0, 0), new XYZ(5, 0, 0)));
                    curveArray.Append(Line.CreateBound(new XYZ(5, 0, 0), new XYZ(5, 5, 0)));
                    curveArray.Append(Line.CreateBound(new XYZ(5, 5, 0), new XYZ(0, 5, 0)));
                    curveArray.Append(Line.CreateBound(new XYZ(0, 5, 0), new XYZ(0, 0, 0)));
                    CurveArrArray curveArrArray = new CurveArrArray();
                    curveArrArray.Append(curveArray);
                    //创建一个拉伸实体
                    familyDoc.FamilyCreate.NewExtrusion(true, curveArrArray, SketchPlane.Create(familyDoc, RevitApp.Create.NewPlane(new XYZ(0, 0, 1), XYZ.Zero)), 10);
                    //创建一个族类型
                    familyDoc.FamilyManager.NewType("MyNewType");
                    transaction.Commit();
                    familyDoc.SaveAs("MyNewFamily.rfa");
                    familyDoc.Close();
                }
            }

        }

        public void GetSelInfo()
        {
            UIDocument uidoc = cmdDataForm.Application.ActiveUIDocument;
            DB.Document doc = uidoc.Document;
            DB.ElementSet collection = new DB.ElementSet();
            ICollection<DB.ElementId> selectedIds = uidoc.Selection.GetElementIds();
            foreach (DB.ElementId id in selectedIds)
            {
                collection.Insert(uidoc.Document.GetElement(id));
            }

            if (0 == collection.Size)
            {
                // 如果在执行该例子之前没有选择任何元素，则会弹出提示.
                text_info.Text = "你没有选任何元素.";
                return;
            }
            else
            {
                String info = "所选元素类型为: ";
                foreach (DB.Element elem in collection)
                {
                    info += "\n\t" + elem.GetType().ToString();
                }

                text_info.Text = info;
                //TaskDialog.Show("Revit", info);
                return;
            }
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            this.CreateInstance();
            
            //this.GetVersionInfo(cmdDataForm.Application.Application);
        }
    }
}
