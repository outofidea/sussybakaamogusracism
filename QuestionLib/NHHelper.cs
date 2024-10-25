using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace QuestionLib
{
	// Token: 0x02000003 RID: 3
	public class NHHelper
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020E0 File Offset: 0x000010E0
		public void Configure()
		{
			Configuration configuration = new Configuration().Configure();
			configuration.AddAssembly("QuestionLib");
			configuration.Properties["hibernate.connection.connection_string"] = NHHelper.ConnectionString;
			configuration.Properties["connection.connection_string"] = NHHelper.ConnectionString;
			this.SessionFactory = configuration.BuildSessionFactory();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002140 File Offset: 0x00001140
		public void ExportTables()
		{
			Configuration configuration = new Configuration().Configure();
			configuration.AddAssembly("QuestionLib");
			new SchemaExport(configuration).Create(true, true);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002174 File Offset: 0x00001174
		public static ISessionFactory GetSessionFactory()
		{
			NHHelper nhhelper = new NHHelper();
			nhhelper.Configure();
			return nhhelper.SessionFactory;
		}

		// Token: 0x04000001 RID: 1
		public static string ConnectionString = "";

		// Token: 0x04000002 RID: 2
		public ISessionFactory SessionFactory;
	}
}
