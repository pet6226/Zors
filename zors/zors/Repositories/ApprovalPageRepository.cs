using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace zors.Repositories
{
    public class ApprovalPageRepository
    {
        protected void ButtonODOBRI_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewRN1.Rows)
            {
                Label idTxt = (Label)row.FindControl("ID") as Label;
                RadioButton check = (RadioButton)row.FindControl("check") as RadioButton;
                bool CheckTrue = check.Checked;

                if (CheckTrue == true)
                {
                    int id = int.Parse(idTxt.Text);
                    string cekiranizors1 = idTxt.Text;
                    korak1(cekiranizors1);

                }

            }

        }
    }
}