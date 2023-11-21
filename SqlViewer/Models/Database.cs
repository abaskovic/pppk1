using SqlViewer.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlViewer.Models
{
    internal class Database
    {

        private readonly Lazy<IEnumerable<DbEntity>> tables;
        private readonly Lazy<IEnumerable<DbEntity>> views;
        private readonly Lazy<IEnumerable<Procedure>> procedures;

        public Database()
        {
            tables = new Lazy<IEnumerable<DbEntity>>(
                () =>Repository.GetDbEntityes(this, DbEntityType.Table));
            views = new Lazy<IEnumerable<DbEntity>>(
                () => Repository.GetDbEntityes(this, DbEntityType.View));
            procedures = new Lazy<IEnumerable<Procedure>>(
                () => Repository.GetProcedures(this));
        }

        public IList<DbEntity> Tables
        {
            get => new List<DbEntity>(tables.Value);
        }
        public IList<DbEntity> Views
        {
            get => new List<DbEntity>(views.Value);
        }
        public IList<Procedure> Procedures
        {
            get => new List<Procedure>(procedures.Value);
        }

        public string? Name { get; set; }
        public override string ToString() => Name!;

    }
}
