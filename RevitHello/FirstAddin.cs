using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
//using Autodesk.Revit.Creation;
using Autodesk.Revit;

namespace RevitHello
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    //此处的TransactionMode比如由Automatic改为Manual，不然在调试时会出现“revit无法运行外部程序”
    public class FirstAddin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //TaskDialog.Show("this is title", "HERE IS THE INFO");
            //return Result.Succeeded;
            //Application uiapp = ;
            MainForm mainform= new MainForm(commandData, message, elements);
            mainform.Show();
            return Result.Succeeded;

            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            ElementSet collection = new ElementSet();
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            //Autodesk.Revit.Creation.Application app = ;
            //this.GetVersionInfo(commandData.Application.Application);
            foreach (ElementId id in selectedIds)
            {
                collection.Insert(uidoc.Document.GetElement(id));
            }

            if (0 == collection.Size)
            {
                // 如果在执行该例子之前没有选择任何元素，则会弹出提示.
                TaskDialog.Show("Revit", "你没有选任何元素.");
                return Result.Succeeded;
            }
            else
            {
                String info = "所选元素类型为: ";
                foreach (Element elem in collection)
                {
                    info += "\n\t" + elem.GetType().ToString();
                }

                TaskDialog.Show("Revit", info);
                return Result.Succeeded;
            }

        }
    }
}
