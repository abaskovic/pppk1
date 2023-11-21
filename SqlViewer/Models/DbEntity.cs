﻿using SqlViewer.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlViewer.Models
{
    internal class DbEntity
    {
        private readonly Lazy<IEnumerable<Column>> columns;

        public DbEntity()
        {
            columns = new Lazy<IEnumerable<Column>>(
                ()=>RepositoryFactory.Repository.GetColumns(this)
                );
        }

        public IList<Column> Columns
        {
            get =>
                new List<Column>(columns.Value);
        }
        public string? Name { get; set; }
        public string? Schema { get; set; }
        public Database? Database { get; set; }
        public override string ToString() => $"{Schema}.{Name}"!;


    }
}
