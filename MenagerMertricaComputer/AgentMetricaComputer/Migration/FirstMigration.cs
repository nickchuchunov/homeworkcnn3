using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace AgentMetricaComputer
{
    [Migration(1)]
    public class FirstMigration: Migration
    {

        public override void Up()
        {
          


            Create.Table("netmetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("networkmetrica")
              .WithColumn("Id").AsInt64().PrimaryKey().Identity()
              .WithColumn("Value").AsInt32()
              .WithColumn("Time").AsInt64();
            Create.Table("rammetrica")
              .WithColumn("Id").AsInt64().PrimaryKey().Identity()
              .WithColumn("Value").AsInt32()
              .WithColumn("Time").AsInt64();
            Create.Table("cpumetrica")
              .WithColumn("Id").AsInt64().PrimaryKey().Identity()
              .WithColumn("Value").AsInt32()
              .WithColumn("Time").AsInt64();
            Create.Table("harddrivemetrica")
              .WithColumn("Id").AsInt64().PrimaryKey().Identity()
              .WithColumn("Value").AsInt32()
              .WithColumn("Time").AsInt64();

        }


        public override void Down()
        {


            Delete.Table("netmetrics");
            Delete.Table("networkmetrica");
            Delete.Table("rammetrica");
            Delete.Table("cpumetrica");
            Delete.Table("harddrivemetrica");


        }



    }
}
