#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
#endregion

namespace EntityLayer
{
    [DataContract]
	public class LoggedInUserDetailsEntity
	{
		#region Fields
		/// <summary>
		/// Description : Database table field
		/// </summary>
		public static class Fields
		{
			public const string LOGGEDINUSERID = "LoggedInUserID";
			public const string USERNAME = "UserName";
			public const string ISLOGGEDINNOW = "IsLoggedInNow";
			public const string LOGGEDINFROMDOMAIN = "LoggedInFromDomain";
			public const string LOGGEDINAT = "LoggedInAt";
			public const string LOGGEDINFROMIP = "LoggedInFromIP";
			public const string LOGGEDINUSERAGENT = "LoggedInUserAgent";
		}
		#endregion

		#region Database Table and Type
		/// <summary>
		/// Description: Database Table and Type
		/// </summary>
		public static class DBTableAndType
		{
			#region Database Tables

			/// <summary>
			/// [dbo].[LoggedInUserDetails]
			/// </summary>
			public const string TABLE_LoggedInUserDetails = "[dbo].[LoggedInUserDetails]"; 

			/// <summary>
			/// [dbo].[LoggedInUserDetails_CommonSearch] (this is not actual table in DB)
			/// </summary>
			public const string TABLE_LoggedInUserDetails_CommonSearch = "[dbo].[LoggedInUserDetails_CommonSearch]"; 

			#endregion

			#region Database Type Tables

			/// <summary>
			/// [dbo].[TypeLoggedInUserDetails]
			/// </summary>
			public const string TYPE_TABLE_LoggedInUserDetails = "[dbo].[TypeLoggedInUserDetails]"; 

			/// <summary>
			/// [dbo].[TypeLoggedInUserDetails_CommonSearch] (this will be User Define Type Table)
			/// </summary>
			public const string TYPE_TABLE_LoggedInUserDetails_CommonSearch = "[dbo].[TypeLoggedInUserDetails_CommonSearch]"; 

			#endregion
		}
		#endregion

		#region Database StoredProcedures
		/// <summary>
		/// Holds the Stored Procedure names in the database
		/// </summary>
		public static class StoredProcedures
		{
			public const string CRUD = "[dbo].[uspCRUDLoggedInUserDetails]";
		}
		#endregion

		#region Database Parameters
		/// <summary>
		/// Holds the Stored Procedure parameter names in the database
		/// </summary>
		public static class Parameters
		{
			public const string Param_LoggedInUserID = "@LoggedInUserID";
			public const string Param_TypeTable_LoggedInUserDetails = "@TBL_LoggedInUserDetails";
			public const string Param_TypeTable_LoggedInUserDetails_CommonSearch = "@TBL_LoggedInUserDetails_CommonSearch";
		}
		#endregion

		#region DataTable Name
		/// <summary>
		/// Holds DataTable names while Fill the data from Adapter
		/// </summary>
		public static class DataTableName
		{
			//retrieve
			public const string DTData = "dtData";
		}
		#endregion

		#region Method
		/// <summary>
		/// Description : method will return table structure of Data tables which passes to StoreProcedure
		/// [dbo].[TypeLoggedInUserDetails]
		/// </summary>
		/// <returns>Dataset</returns>
		public DataSet GetTablesStructure()
		{
			DataSet ds = new DataSet();

			DataTable dbTable = new DataTable(DBTableAndType.TABLE_LoggedInUserDetails);
			dbTable.Columns.Add(Fields.LOGGEDINUSERID, Type.GetType("System.Int32"));
			dbTable.Columns.Add(Fields.USERNAME, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.ISLOGGEDINNOW, Type.GetType("System.Boolean"));
			dbTable.Columns.Add(Fields.LOGGEDINFROMDOMAIN, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.LOGGEDINAT, Type.GetType("System.DateTime"));
			dbTable.Columns.Add(Fields.LOGGEDINFROMIP, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.LOGGEDINUSERAGENT, Type.GetType("System.String"));
			ds.Tables.Add(dbTable);

			dbTable = new DataTable(DBTableAndType.TABLE_LoggedInUserDetails_CommonSearch);
			dbTable.Columns.Add(LoggedInUserDetails_CommonSearch.Fields.USERNAME, Type.GetType("System.String"));
			dbTable.Columns.Add(LoggedInUserDetails_CommonSearch.Fields.LOGGEDINFROMDOMAIN, Type.GetType("System.String"));
			ds.Tables.Add(dbTable);

			return ds;
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Holds all public properties of LoggedInUserDetails 
		/// </summary>
		/// 
		[DataMember]
		public Int32? LoggedInUserID { get; set; }

		[DataMember]
		public String UserName { get; set; }

		[DataMember]
		public Boolean? IsLoggedInNow { get; set; }

		[DataMember]
		public String LoggedInFromDomain { get; set; }

		[DataMember]
		public DateTime? LoggedInAt { get; set; }

		[DataMember]
		public String LoggedInFromIP { get; set; }

		[DataMember]
		public String LoggedInUserAgent { get; set; }

		[DataMember]
		public List<LoggedInUserDetails_CommonSearch> LoggedInUserDetails_CommonSearchList { get; set; }

		#endregion

		#region Auto search / Global Search Class Entity
		/// <summary>
		/// Auto search / Global Search Class Entity LoggedInUserDetails_CommonSearch
		/// </summary>
		public class LoggedInUserDetails_CommonSearch
		{
			#region Fields
			/// <summary>
			/// Description : Database table field
			/// </summary>
			public static class Fields
			{
				public const string USERNAME = "UserName";
				public const string LOGGEDINFROMDOMAIN = "LoggedInFromDomain";
			}
 			#endregion

			[DataMember]
			public String UserName { get; set; }

			[DataMember]
			public String LoggedInFromDomain { get; set; }

		}
 		#endregion

	}
}
