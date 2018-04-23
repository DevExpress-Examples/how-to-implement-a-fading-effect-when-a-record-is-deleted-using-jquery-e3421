using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            grid.DataBind();
    }

    protected void grid_DataBinding(object sender, EventArgs e) {
        grid.DataSource = TempData;
    }

    protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e) {
        Int32 key = Convert.ToInt32(e.Keys[0]);

        // emulate accident exceptions
        if (key % 2 == 0)
            throw new Exception("This record is readonly :(");

        TempData.RemoveAll(i => i.Id == key);

        e.Cancel = true;
    }

    /* Fake data source */

    List<GridDataItem> TempData {
        get {
            const String key = "(some key)";
            if (Session[key] == null) {

                List<GridDataItem> lst = new List<GridDataItem>();

                /* Initialization with some values */

                for (Int32 i = 0; i < 12; i++)
                    lst.Add(new GridDataItem() {
                        Id = i,
                        Name = (i % 2 == 0 ? "Exception!" : "Delete me!"),
                        CurrentDate = new DateTime(2008 + i, i + 1, 17 + i)
                    });

                Session[key] = lst;
            }
            return (List<GridDataItem>)Session[key];
        }
    }
}