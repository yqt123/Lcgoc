
namespace Lcgoc.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class GridViewColumn
    {
        public string ColumnName { get; set; }
        public string Caption { get; set; }
        public int? Width { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? Visible { get; set; }
        public bool? IsNew { get; set; }
        public object RepositoryItemButtonEdit { get; set; }
    }
}
