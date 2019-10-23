namespace SampleDataOper.Migrations
{
    using SG.Model.Sys;
    using SunginData.Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SunginData.SunginDataContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SampleDataOper.SampleContext";
        }

        protected override void Seed(SunginData.SunginDataContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            BuildHelper.BuildData(context);
            BuildHelper.ReBuildLendOutViews(context);
        }
    }
}
