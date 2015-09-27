using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// These are the using's needed for Revit.
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;

[TransactionAttribute(TransactionMode.Manual)]
[RegenerationAttribute(RegenerationOption.Manual)]
public class Lab1PlaceGroup : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        Tracelog("Addin Start");

        //Get application and document objects
        UIApplication UIApp = commandData.Application;
        UIDocument UIDoc = UIApp.ActiveUIDocument;
        Application app = UIApp.Application;
        Document doc = UIDoc.Document;

        // Get all doors.
        FilteredElementCollector collectorForDoors = new FilteredElementCollector(doc);
        collectorForDoors.OfCategory(BuiltInCategory.OST_Doors).OfClass(typeof(FamilyInstance));

        // Iterate the collector and show the information
        if ( collectorForDoors.Count<Element>() > 0 )
        {
            // I have a valid collection to iterate
            foreach(Element ele in collectorForDoors)
            {
                TaskDialog.Show(ele.Category.Name, ele.Name);
            }
        }
        else
        {
            // No collection found.
            Tracelog("No collection found");
        }

        return (Result.Succeeded);
    }

    public void Tracelog(string msg)
    {
        TaskDialog.Show("Debug Message", msg);

    }
}
