#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
#endregion

namespace EntityLayer
{
    [DataContract]
	public class UserProfileEntity
	{
		#region Fields
		/// <summary>
		/// Description : Database table field
		/// </summary>
		public static class Fields
		{
			public const string USERID = "UserID";
			public const string FIRSTNAME = "FirstName";
			public const string LASTNAME = "LastName";
            public const string PASSWORD = "Password";
            public const string DOB = "DOB";
			public const string PHONE = "Phone";
			public const string ADDRESS = "Address";
			public const string USERNAME = "UserName";
			public const string REMARK = "Remark";
			public const string VALIDFROM = "ValidFrom";
			public const string VALIDTO = "ValidTo";
			public const string CREATEDBY = "CreatedBy";
			public const string CREATEDON = "CreatedOn";
			public const string CREATEDIP = "CreatedIP";
			public const string MODIFIEDBY = "ModifiedBy";
			public const string MODIFIEDON = "ModifiedOn";
			public const string MODIFIEDIP = "ModifiedIP";
			public const string ISACTIVE = "IsActive";
			public const string ISDELETED = "IsDeleted";
            
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
			/// [dbo].[UserProfile]
			/// </summary>
			public const string TABLE_UserProfile = "[dbo].[UserProfile]"; 

			/// <summary>
			/// [dbo].[UserProfile_CommonSearch] (this is not actual table in DB)
			/// </summary>
			public const string TABLE_UserProfile_CommonSearch = "[dbo].[UserProfile_CommonSearch]"; 

			#endregion

			#region Database Type Tables

			/// <summary>
			/// [dbo].[TypeUserProfile]
			/// </summary>
			public const string TYPE_TABLE_UserProfile = "[dbo].[TypeUserProfile]"; 

			/// <summary>
			/// [dbo].[TypeUserProfile_CommonSearch] (this will be User Define Type Table)
			/// </summary>
			public const string TYPE_TABLE_UserProfile_CommonSearch = "[dbo].[TypeUserProfile_CommonSearch]"; 

			#endregion
		}
		#endregion

		#region Database StoredProcedures
		/// <summary>
		/// Holds the Stored Procedure names in the database
		/// </summary>
		public static class StoredProcedures
		{
			public const string CRUD = "[dbo].[uspCRUDUserProfile]";
		}
		#endregion

		#region Database Parameters
		/// <summary>
		/// Holds the Stored Procedure parameter names in the database
		/// </summary>
		public static class Parameters
		{
			public const string Param_UserID = "@UserID";
			public const string Param_TypeTable_UserProfile = "@TBL_UserProfile";
			public const string Param_TypeTable_UserProfile_CommonSearch = "@TBL_UserProfile_CommonSearch";
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
		/// [dbo].[TypeUserProfile]
		/// </summary>
		/// <returns>Dataset</returns>
		public DataSet GetTablesStructure()
		{
			DataSet ds = new DataSet();

			DataTable dbTable = new DataTable(DBTableAndType.TABLE_UserProfile);
			dbTable.Columns.Add(Fields.USERID, Type.GetType("System.Int32"));
			dbTable.Columns.Add(Fields.FIRSTNAME, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.LASTNAME, Type.GetType("System.String"));
            dbTable.Columns.Add(Fields.DOB, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.PHONE, Type.GetType("System.Int32"));
			dbTable.Columns.Add(Fields.ADDRESS, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.USERNAME, Type.GetType("System.String"));
            dbTable.Columns.Add(Fields.PASSWORD, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.REMARK, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.VALIDFROM, Type.GetType("System.DateTime"));
			dbTable.Columns.Add(Fields.VALIDTO, Type.GetType("System.DateTime"));
			dbTable.Columns.Add(Fields.CREATEDBY, Type.GetType("System.Int32"));
			dbTable.Columns.Add(Fields.CREATEDON, Type.GetType("System.DateTime"));
			dbTable.Columns.Add(Fields.CREATEDIP, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.MODIFIEDBY, Type.GetType("System.Int32"));
			dbTable.Columns.Add(Fields.MODIFIEDON, Type.GetType("System.DateTime"));
			dbTable.Columns.Add(Fields.MODIFIEDIP, Type.GetType("System.String"));
			dbTable.Columns.Add(Fields.ISACTIVE, Type.GetType("System.Boolean"));
			dbTable.Columns.Add(Fields.ISDELETED, Type.GetType("System.Boolean"));
			ds.Tables.Add(dbTable);

			dbTable = new DataTable(DBTableAndType.TABLE_UserProfile_CommonSearch);
			dbTable.Columns.Add(UserProfile_CommonSearch.Fields.FIRSTNAME, Type.GetType("System.String"));
            dbTable.Columns.Add(UserProfile_CommonSearch.Fields.LASTNAME, Type.GetType("System.String"));
            dbTable.Columns.Add(UserProfile_CommonSearch.Fields.DOB, Type.GetType("System.String"));
            dbTable.Columns.Add(UserProfile_CommonSearch.Fields.USERNAME, Type.GetType("System.String"));
            dbTable.Columns.Add(UserProfile_CommonSearch.Fields.PASSWORD, Type.GetType("System.String"));
            dbTable.Columns.Add(UserProfile_CommonSearch.Fields.SITEID, Type.GetType("System.Int32"));

            ds.Tables.Add(dbTable);

			return ds;
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Holds all public properties of UserProfile 
		/// </summary>
		/// 
		[DataMember]
		public Int32? UserID { get; set; }

		[DataMember]
		public String FirstName { get; set; }

        [DataMember]
        public String Password { get; set; }

        [DataMember]
		public String LastName { get; set; }

		[DataMember]
		public String DOB { get; set; }

		[DataMember]
		public Int32? Phone { get; set; }

		[DataMember]
		public String Address { get; set; }

		[DataMember]
		public String UserName { get; set; }

		[DataMember]
		public String Remark { get; set; }

		[DataMember]
		public DateTime? ValidFrom { get; set; }

		[DataMember]
		public DateTime? ValidTo { get; set; }

		[DataMember]
		public Int32? CreatedBy { get; set; }

		[DataMember]
		public DateTime? CreatedOn { get; set; }

		[DataMember]
		public String CreatedIP { get; set; }

		[DataMember]
		public Int32? ModifiedBy { get; set; }

		[DataMember]
		public DateTime? ModifiedOn { get; set; }

		[DataMember]
		public String ModifiedIP { get; set; }

		[DataMember]
		public Boolean? IsActive { get; set; }

		[DataMember]
		public Boolean? IsDeleted { get; set; }

		[DataMember]
		public List<UserProfile_CommonSearch> UserProfile_CommonSearchList { get; set; }

		#endregion

		#region Auto search / Global Search Class Entity
		/// <summary>
		/// Auto search / Global Search Class Entity UserProfile_CommonSearch
		/// </summary>
		public class UserProfile_CommonSearch
		{
			#region Fields
			/// <summary>
			/// Description : Database table field
			/// </summary>
			public static class Fields
			{
				public const string FIRSTNAME = "FirstName";
				public const string LASTNAME = "LastName";
				public const string DOB = "DOB";
				public const string USERNAME = "UserName";
                public const string PASSWORD = "Password";
                public const string SITEID = "SiteId";
            }
 			#endregion

			[DataMember]
			public String FirstName { get; set; }

			[DataMember]
			public String LastName { get; set; }

			[DataMember]
			public String DOB { get; set; }

			[DataMember]
			public String UserName { get; set; }

            [DataMember]
            public String Password { get; set; }

            [DataMember]
            public int? SiteId { get; set; }

        }
 		#endregion

	}
}
