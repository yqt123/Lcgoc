using Lcgoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Common
{
    public class XtraGridHelper
    {
        public static void SetGridColumns(DevExpress.XtraGrid.Views.Grid.GridView gv, List<GridViewColumn> columnArgs = null, int? RowHeight = null)
        {
            gv.BestFitColumns();
            if (columnArgs != null)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn item in gv.Columns)
                {
                    var col = columnArgs.Where(n => n.ColumnName == item.FieldName).FirstOrDefault();
                    if (col != null)
                    {
                        item.Width = col.Width == null ? item.Width : (int)col.Width;
                        item.Caption = col.Caption == null ? item.Caption : col.Caption;
                        item.OptionsColumn.AllowEdit = col.AllowEdit == null ? item.OptionsColumn.AllowEdit : (bool)col.AllowEdit;
                        item.Visible = col.Visible == null ? item.OptionsColumn.ShowCaption : (bool)col.Visible;
                        if (item.ColumnType == typeof(DateTime))
                        {
                            item.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            item.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
                foreach (GridViewColumn item in columnArgs)
                {
                    if (item.IsNew == true)
                    {
                        var col = gv.Columns.ColumnByFieldName(item.ColumnName);
                        if (col == null)
                        {
                            var colNew = new DevExpress.XtraGrid.Columns.GridColumn()
                            {
                                FieldName = item.ColumnName,
                                Caption = item.Caption,
                                Width = item.Width == null ? 50 : (int)item.Width,
                            };
                            if (item.RepositoryItemButtonEdit != null)
                            {
                                var btnEdit = item.RepositoryItemButtonEdit as DevExpress.XtraEditors.Repository.RepositoryItem;
                                gv.GridControl.RepositoryItems.Add(btnEdit);
                                colNew.ColumnEdit = btnEdit;
                            }
                            gv.Columns.Add(colNew);
                        }
                    }
                }
            }
            if (RowHeight != null) gv.RowHeight = (int)RowHeight;
        }
    }
}
