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
using System.Diagnostics;
using System.Windows.Interop;

namespace RevitHello
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    //此处的TransactionMode比如由Automatic改为Manual，不然在调试时会出现“revit无法运行外部程序”
    public class RVTCMD : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document Doc = uiDoc.Document;
            MainForm frm = new MainForm();
            frm.Show();
            return Result.Succeeded;
        }
    }
}
