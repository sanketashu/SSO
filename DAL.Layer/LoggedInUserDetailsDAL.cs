#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyCommonEntity = EntityLayer.CommonEntity;
using MyCommonFunctions = EntityLayer.CommonFunctions;
using MasterEntity = EntityLayer.LoggedInUserDetailsEntity;
using MasterEntityFields = EntityLayer.LoggedInUserDetailsEntity.Fields;
using MasterParameters = EntityLayer.LoggedInUserDetailsEntity.Parameters;
using ChildLoggedInUserDetails_CommonSearchEntity = EntityLayer.LoggedInUserDetailsEntity.LoggedInUserDetails_CommonSearch;
using ChildLoggedInUserDetails_CommonSearchEntityFields = EntityLayer.LoggedInUserDetailsEntity.LoggedInUserDetails_CommonSearch.Fields;
#endregion

namespace DataAccessLayer
{
	public class LoggedInUserDetailsDAL : DalcBase
	{
		/// <summary>
		///THIS METHOD IS USED TO CREATES DALC OBJECT
		/// </summary>
		/// </param>
		public LoggedInUserDetailsDAL() : base() { }

		/// <summary>
		///THIS METHOD IS USED TO CREATES DALC OBJECT
		/// </summary>
		/// <param name="connectionString"></param>
		public LoggedInUserDetailsDAL(string connectionString) : base(connectionString) { }

		/// <summary>
		/// This method is used to get Initial data in dataset
		/// </summary>
		/// <param name="DataSet"></param>
		/// <param name="Hashtable"></param>
		/// <returns></returns>
		public DataSet GetInitDataSet(DataSet DTSet, Hashtable ht)
		{
			DataSet ds = new DataSet();
			try
			{
				//if DTSet is null then pass blank DBStructure to SP
				if(DTSet == null)
					DTSet = new MasterEntity().GetTablesStructure();

				using (SqlConnection con = base.GetConnection())
				{
					using (SqlCommand cmd = new SqlCommand(MasterEntity.StoredProcedures.CRUD, con))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						SqlParameter parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails;
						cmd.Parameters.Add(parameter);

						// SQL TypeTable Parameter for Auto Search or Global Search (Common Search) Table
						parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails_CommonSearch, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails_CommonSearch]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails_CommonSearch;
						cmd.Parameters.Add(parameter);

						if (ht != null)
						{
							// Operation mode
							if (ht[MyCommonEntity.Fields.OPERATIONMODE] != null)
								cmd.Parameters.Add(MyCommonEntity.Parameters.OperationMode, SqlDbType.VarChar, 10).Value = ht[MyCommonEntity.Fields.OPERATIONMODE];

							#region Output parameter
							// this represent Output parameter
							if (ht[MasterEntityFields.LOGGEDINUSERID] != null)
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = ht[MasterEntityFields.LOGGEDINUSERID];
							else
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = 0;

							cmd.Parameters[MasterEntity.Parameters.Param_LoggedInUserID].Direction = ParameterDirection.InputOutput;
							#endregion
						}

						SqlDataAdapter AdapterObj = new SqlDataAdapter(cmd);
						AdapterObj.TableMappings.Add("Table", MasterEntity.DataTableName.DTData);
						AdapterObj.Fill(ds);
					}
				}
			}
			catch (SqlException sqlException)
			{
				throw sqlException;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;
		}
		
		/// <summary>
		/// This method is used to get List data in dataset
		/// </summary>
		/// <param name="DataSet"></param>
		/// <param name="Hashtable"></param>
		/// <returns></returns>
		public DataSet GetViewDataSet(DataSet DTSet, Hashtable ht)
		{
			DataSet ds = new DataSet();
			try
			{
				//if DTSet is null then pass blank DBStructure to SP
				if(DTSet == null)
					DTSet = new MasterEntity().GetTablesStructure();

				using (SqlConnection con = base.GetConnection())
				{
					using (SqlCommand cmd = new SqlCommand(MasterEntity.StoredProcedures.CRUD, con))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						SqlParameter parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails;
						cmd.Parameters.Add(parameter);

						// SQL TypeTable Parameter for Auto Search or Global Search (Common Search) Table
						parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails_CommonSearch, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails_CommonSearch]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails_CommonSearch;
						cmd.Parameters.Add(parameter);

						if (ht != null)
						{
							// Operation mode
							if (ht[MyCommonEntity.Fields.OPERATIONMODE] != null)
								cmd.Parameters.Add(MyCommonEntity.Parameters.OperationMode, SqlDbType.VarChar, 10).Value = ht[MyCommonEntity.Fields.OPERATIONMODE];

							#region Output parameter
							// this represent Output parameter
							if (ht[MasterEntityFields.LOGGEDINUSERID] != null)
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = ht[MasterEntityFields.LOGGEDINUSERID];
							else
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = 0;

							cmd.Parameters[MasterEntity.Parameters.Param_LoggedInUserID].Direction = ParameterDirection.InputOutput;
							#endregion
						}

						SqlDataAdapter AdapterObj = new SqlDataAdapter(cmd);
						AdapterObj.TableMappings.Add("Table", MasterEntity.DataTableName.DTData);
						AdapterObj.Fill(ds);
					}
				}
			}
			catch (SqlException sqlException)
			{
				throw sqlException;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;
		}
		
		/// <summary>
		/// This method is used to get Auto Complete data in dataset
		/// </summary>
		/// <param name="DataSet"></param>
		/// <param name="Hashtable"></param>
		/// <returns></returns>
		public DataSet GetAutoDataSet(DataSet DTSet, Hashtable ht)
		{
			DataSet ds = new DataSet();
			try
			{
				//if DTSet is null then pass blank DBStructure to SP
				if(DTSet == null)
					DTSet = new MasterEntity().GetTablesStructure();

				using (SqlConnection con = base.GetConnection())
				{
					using (SqlCommand cmd = new SqlCommand(MasterEntity.StoredProcedures.CRUD, con))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						SqlParameter parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails;
						cmd.Parameters.Add(parameter);

						// SQL TypeTable Parameter for Auto Search or Global Search (Common Search) Table
						parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails_CommonSearch, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails_CommonSearch]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails_CommonSearch;
						cmd.Parameters.Add(parameter);

						if (ht != null)
						{
							// Operation mode
							if (ht[MyCommonEntity.Fields.OPERATIONMODE] != null)
								cmd.Parameters.Add(MyCommonEntity.Parameters.OperationMode, SqlDbType.VarChar, 10).Value = ht[MyCommonEntity.Fields.OPERATIONMODE];

							#region Output parameter
							// this represent Output parameter
							if (ht[MasterEntityFields.LOGGEDINUSERID] != null)
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = ht[MasterEntityFields.LOGGEDINUSERID];
							else
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = 0;

							cmd.Parameters[MasterEntity.Parameters.Param_LoggedInUserID].Direction = ParameterDirection.InputOutput;
							#endregion
						}

						SqlDataAdapter AdapterObj = new SqlDataAdapter(cmd);
						AdapterObj.TableMappings.Add("Table", MasterEntity.DataTableName.DTData);
						AdapterObj.Fill(ds);
					}
				}
			}
			catch (SqlException sqlException)
			{
				throw sqlException;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;
		}
		
		/// <summary>
		/// Description: Perform Add/Update/deleted operation
		/// </summary>
		/// <param name="DataSet"></param>
		/// <param name="Hashtable"></param>
		/// <returns></returns>
		public bool CRUD(DataSet DTSet, Hashtable ht)
		{
			bool flag = false;
			try
			{
				//if DTSet is null then pass blank DBStructure to SP
				if(DTSet == null)
					DTSet = new MasterEntity().GetTablesStructure();

				using (SqlConnection con = base.GetConnection())
				{
					using (SqlCommand cmd = new SqlCommand(MasterEntity.StoredProcedures.CRUD, con))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						SqlParameter parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails;
						cmd.Parameters.Add(parameter);

						// SQL TypeTable Parameter for Auto Search or Global Search (Common Search) Table
						parameter = new SqlParameter(MasterEntity.Parameters.Param_TypeTable_LoggedInUserDetails_CommonSearch, DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails_CommonSearch]);
						parameter.SqlDbType = SqlDbType.Structured;
						parameter.TypeName = MasterEntity.DBTableAndType.TYPE_TABLE_LoggedInUserDetails_CommonSearch;
						cmd.Parameters.Add(parameter);

						if (ht != null)
						{
							// Operation mode
							if (ht[MyCommonEntity.Fields.OPERATIONMODE] != null)
								cmd.Parameters.Add(MyCommonEntity.Parameters.OperationMode, SqlDbType.VarChar, 10).Value = ht[MyCommonEntity.Fields.OPERATIONMODE];

							#region Output parameter
							// this represent Output parameter
							if (ht[MasterEntityFields.LOGGEDINUSERID] != null)
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = ht[MasterEntityFields.LOGGEDINUSERID];
							else
								cmd.Parameters.Add(MasterEntity.Parameters.Param_LoggedInUserID, SqlDbType.Int).Value = 0;

							cmd.Parameters[MasterEntity.Parameters.Param_LoggedInUserID].Direction = ParameterDirection.InputOutput;
							#endregion
						}

						cmd.Connection.Open();
						flag = cmd.ExecuteNonQuery() > 0;

						if (flag)
							ht[MasterEntityFields.LOGGEDINUSERID] = Convert.ToInt32(cmd.Parameters[MasterEntity.Parameters.Param_LoggedInUserID].Value);
					}
				}
			}
			catch (SqlException sqlException)
			{
				throw sqlException;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return flag;
		}
	}
}
