#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyCommonEntity = EntityLayer.CommonEntity;
using MyCommonFunctions = EntityLayer.CommonFunctions;
using MasterDalc = DataAccessLayer.LoggedInUserDetailsDAL;
using MasterEntity = EntityLayer.LoggedInUserDetailsEntity;
using MasterEntityFields = EntityLayer.LoggedInUserDetailsEntity.Fields;
using ChildLoggedInUserDetails_CommonSearchEntity = EntityLayer.LoggedInUserDetailsEntity.LoggedInUserDetails_CommonSearch;
using ChildLoggedInUserDetails_CommonSearchEntityFields = EntityLayer.LoggedInUserDetailsEntity.LoggedInUserDetails_CommonSearch.Fields;
#endregion

namespace BussinessAccessLayer
{
	public class LoggedInUserDetailsBAL
	{
		#region Private Data Members

		private MasterDalc oDalc = null;
		private string constr_ = null;

		#endregion

		/// <summary>
		/// Initializes a new instance of Service
		/// </summary>
		public LoggedInUserDetailsBAL()
		{
			this.oDalc = new MasterDalc();
		}
		
		/// <summary>
		/// Initializes a new instance of Service with connectionString
		/// </summary>
		/// <param name="connectionString">
		public LoggedInUserDetailsBAL(string connectionString)
		{
			constr_ = connectionString;
			this.oDalc = new MasterDalc(connectionString);
		}
		
		/// <summary>
		/// Description: add method 
		/// </summary>
		/// <param name="oEntity"></param>
		/// <param name="ht"></param>
		/// <returns>Boolean</returns>
		public bool Insert(MasterEntity oEntity, Hashtable ht)
		{
			bool flag = false;
			try
			{
				DataSet DTSet = FillEntityWithValues(oEntity);
				flag = this.oDalc.CRUD(DTSet, ht);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return flag;
		}
		
		/// <summary>
		/// Description: Update method
		/// </summary>
		/// <param name="oEntity"></param>
		/// <param name="ht"></param>
		/// <returns>Boolean</returns>
		public bool Update(MasterEntity oEntity, Hashtable ht)
		{
			bool flag = false;
			try
			{
				DataSet DTSet = FillEntityWithValues(oEntity);
				flag = this.oDalc.CRUD(DTSet, ht);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return flag;
		}
		
		/// <summary>
		/// Description: Delete method
		/// </summary>
		/// <param name="oEntity"></param>
		/// <param name="ht"></param>
		/// <returns>Boolean</returns>
		public bool Delete(MasterEntity oEntity, Hashtable ht)
		{
			bool flag = false;
			try
			{
				DataSet DTSet = FillEntityWithValues(oEntity);
				flag = this.oDalc.CRUD(DTSet, ht);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return flag;
		}
		
		/// <summary>
		/// Description: This method is used to get List data or complete detail
		/// </summary>
		/// <param name="PageCurrentMode"></param>
		/// <returns>List<object></returns>
		public List<object> GetViewData(MasterEntity oEntity, Hashtable ht)
		{
			List<object> ol = new List<object>();
			try
			{
				DataSet DTSet = FillEntityWithValues(oEntity);
				DataSet ds = this.oDalc.GetViewDataSet(DTSet, ht);
				if (ds != null && ds.Tables.Count >= 1)
				{
					ol.Add(MyCommonFunctions.DataSetToJSON(ds));
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ol;
		}
		
		/// <summary>
		/// Description: Get data which need to be fetch on page initialization e.g. Drop down values
		/// </summary>
		/// <param name="oEntity"></param>
		/// <param name="ht"></param>
		/// <returns>List<object></returns>
		public List<object> GetInitData(MasterEntity oEntity, Hashtable ht)
		{
			List<object> ol = new List<object>();
			try
			{
				DataSet DTSet = FillEntityWithValues(oEntity);
				DataSet ds = this.oDalc.GetInitDataSet(DTSet, ht);
				if (ds != null && ds.Tables.Count >= 1)
				{
					ol.Add(MyCommonFunctions.DataSetToJSON(ds));
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ol;
		}
		
		/// <summary>
		/// Description: Get data which need to be fetch on Auto Complete Dropdown's
		/// </summary>
		/// <param name="oEntity"></param>
		/// <param name="ht"></param>
		/// <returns>List<object></returns>
		public List<object> GetAutoData(MasterEntity oEntity, Hashtable ht)
		{
			List<object> ol = new List<object>();
			try
			{
				DataSet DTSet = FillEntityWithValues(oEntity);
				DataSet ds = this.oDalc.GetAutoDataSet(DTSet, ht);
				if (ds != null && ds.Tables.Count >= 1)
				{
					ol.Add(MyCommonFunctions.DataSetToJSON(ds));
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ol;
		}
		
		/// <summary>
		/// Description: Fill DataSet with Actual Values which needs to be send on DB
		/// </summary>
		/// <param name="oEntity"></param>
		/// <returns>Convert oEntity to DataSet which contains data in DataTable collection format</returns>
		public DataSet FillEntityWithValues(MasterEntity oEntity)
		{
			DataSet DTSet = new MasterEntity().GetTablesStructure();
			DataTable DTMasterTable = DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails];
			DataTable DT_LOGGEDINUSERDETAILS_COMMONSEARCH = DTSet.Tables[MasterEntity.DBTableAndType.TABLE_LoggedInUserDetails_CommonSearch];

			DataRow dr = DTMasterTable.NewRow();
			try
			{
				if (oEntity.LoggedInUserID != null)
					dr[MasterEntityFields.LOGGEDINUSERID] = oEntity.LoggedInUserID;

				if (oEntity.UserName != null)
					dr[MasterEntityFields.USERNAME] = oEntity.UserName;

				if (oEntity.IsLoggedInNow != null)
					dr[MasterEntityFields.ISLOGGEDINNOW] = oEntity.IsLoggedInNow;

				if (oEntity.LoggedInFromDomain != null)
					dr[MasterEntityFields.LOGGEDINFROMDOMAIN] = oEntity.LoggedInFromDomain;

				if (oEntity.LoggedInAt != null)
					dr[MasterEntityFields.LOGGEDINAT] = oEntity.LoggedInAt;

				if (oEntity.LoggedInFromIP != null)
					dr[MasterEntityFields.LOGGEDINFROMIP] = oEntity.LoggedInFromIP;

				if (oEntity.LoggedInUserAgent != null)
					dr[MasterEntityFields.LOGGEDINUSERAGENT] = oEntity.LoggedInUserAgent;

				DTMasterTable.Rows.Add(dr);
				DTMasterTable.AcceptChanges();

				// Collect the information from oEntity LoggedInUserDetails_CommonSearch and fill the data in DT_LOGGEDINUSERDETAILS_COMMONSEARCH DataTable
				if (oEntity.LoggedInUserDetails_CommonSearchList != null)
				{
					foreach (ChildLoggedInUserDetails_CommonSearchEntity oEntity_ in oEntity.LoggedInUserDetails_CommonSearchList)
					{
						//Initialize New row with DataTable
						dr = DT_LOGGEDINUSERDETAILS_COMMONSEARCH.NewRow();

						if (oEntity_.UserName != null)
							dr[ChildLoggedInUserDetails_CommonSearchEntityFields.USERNAME] = oEntity_.UserName;

						if (oEntity_.LoggedInFromDomain != null)
							dr[ChildLoggedInUserDetails_CommonSearchEntityFields.LOGGEDINFROMDOMAIN] = oEntity_.LoggedInFromDomain;

						//Add Row into DataTable
						DT_LOGGEDINUSERDETAILS_COMMONSEARCH.Rows.Add(dr);
					}

					// Save State of DataTable with Currently filled Data
					DT_LOGGEDINUSERDETAILS_COMMONSEARCH.AcceptChanges();
				}

			}
			catch (Exception exe)
			{
				throw exe;
			}
			return DTSet;
		}
	}
}
