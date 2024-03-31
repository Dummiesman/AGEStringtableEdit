using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEStringtableEdit.Extensions
{
    public static class ListViewExtensions
    {
        public static void ClearSelection(this ListView listView)
        {
            if (listView.SelectedIndices.Count > 0)
                for (int i = 0; i < listView.SelectedIndices.Count; i++)
                {
                    listView.Items[listView.SelectedIndices[i]].Selected = false;
                }
        }

        public static void SelectAndFocus(this ListViewItem item)
        {
            item.Focused = true;
            item.Selected = true;
            item.EnsureVisible();
        }
    }
}
