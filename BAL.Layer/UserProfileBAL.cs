#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyCommonEntity = EntityLayer.CommonEntity;
using MyCommonFunctions = EntityLayer.CommonFunctions;
using MasterDalc = DataAccessLayer.UserProfileDAL;
using MasterEntity = EntityLayer.UserProfileEntity;
using MasterEntityFields = EntityLayer.UserProfileEntity.Fields;
using ChildUserProfile_CommonSearchEntity = EntityLayer.UserProfileEntity.UserProfile_CommonSearch;
using ChildUserProfile_CommonSearchEntityFields = EntityLayer.UserProfileEntity.UserProfile_CommonSearch.Fields;
#endregion

namespace BussinessAccessLayer
{
    public class UserProfileBAL
    {
        #region Private Data Members

        private MasterDalc oDalc = null;
        private string constr_ = null;

        #endregion

        /// <summary>
        /// Initializes a new instance of Service
        /// </summary>
        public UserProfileBAL()
        {
            this.oDalc = new MasterDalc();
        }

        /// <summary>
        /// Initializes a new instance of Service with connectionString
        /// </summary>
        /// <param name="connectionString">
        public UserProfileBAL(string connectionString)
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
            DataTable DTMasterTable = DTSet.Tables[MasterEntity.DBTableAndType.TABLE_UserProfile];
            DataTable DT_USERPROFILE_COMMONSEARCH = DTSet.Tables[MasterEntity.DBTableAndType.TABLE_UserProfile_CommonSearch];

            DataRow dr = DTMasterTable.NewRow();
            try
            {
                if (oEntity.UserID != null)
                    dr[MasterEntityFields.USERID] = oEntity.UserID;

                if (oEntity.FirstName != null)
                    dr[MasterEntityFields.FIRSTNAME] = oEntity.FirstName;

                if (oEntity.LastName != null)
                    dr[MasterEntityFields.LASTNAME] = oEntity.LastName;

                if (oEntity.DOB != null)
                    dr[MasterEntityFields.DOB] = oEntity.DOB;

                if (oEntity.Phone != null)
                    dr[MasterEntityFields.PHONE] = oEntity.Phone;

                if (oEntity.Address != null)
                    dr[MasterEntityFields.ADDRESS] = oEntity.Address;

                if (oEntity.Password != null)
                    dr[MasterEntityFields.PASSWORD] = oEntity.Password;

                if (oEntity.UserName != null)
                    dr[MasterEntityFields.USERNAME] = oEntity.UserName;

                if (oEntity.Remark != null)
                    dr[MasterEntityFields.REMARK] = oEntity.Remark;

                if (oEntity.ValidFrom != null)
                    dr[MasterEntityFields.VALIDFROM] = oEntity.ValidFrom;

                if (oEntity.ValidTo != null)
                    dr[MasterEntityFields.VALIDTO] = oEntity.ValidTo;

                if (oEntity.CreatedBy != null)
                    dr[MasterEntityFields.CREATEDBY] = oEntity.CreatedBy;

                if (oEntity.CreatedOn != null)
                    dr[MasterEntityFields.CREATEDON] = oEntity.CreatedOn;

                if (oEntity.CreatedIP != null)
                    dr[MasterEntityFields.CREATEDIP] = oEntity.CreatedIP;

                if (oEntity.ModifiedBy != null)
                    dr[MasterEntityFields.MODIFIEDBY] = oEntity.ModifiedBy;

                if (oEntity.ModifiedOn != null)
                    dr[MasterEntityFields.MODIFIEDON] = oEntity.ModifiedOn;

                if (oEntity.ModifiedIP != null)
                    dr[MasterEntityFields.MODIFIEDIP] = oEntity.ModifiedIP;

                if (oEntity.IsActive != null)
                    dr[MasterEntityFields.ISACTIVE] = oEntity.IsActive;

                if (oEntity.IsDeleted != null)
                    dr[MasterEntityFields.ISDELETED] = oEntity.IsDeleted;

                DTMasterTable.Rows.Add(dr);
                DTMasterTable.AcceptChanges();

                // Collect the information from oEntity UserProfile_CommonSearch and fill the data in DT_USERPROFILE_COMMONSEARCH DataTable
                if (oEntity.UserProfile_CommonSearchList != null)
                {
                    foreach (ChildUserProfile_CommonSearchEntity oEntity_ in oEntity.UserProfile_CommonSearchList)
                    {
                        //Initialize New row with DataTable
                        dr = DT_USERPROFILE_COMMONSEARCH.NewRow();

                        if (oEntity_.FirstName != null)
                            dr[ChildUserProfile_CommonSearchEntityFields.FIRSTNAME] = oEntity_.FirstName;

                        if (oEntity_.LastName != null)
                            dr[ChildUserProfile_CommonSearchEntityFields.LASTNAME] = oEntity_.LastName;

                        if (oEntity_.DOB != null)
                            dr[ChildUserProfile_CommonSearchEntityFields.DOB] = oEntity_.DOB;

                        if (oEntity_.UserName != null)
                            dr[ChildUserProfile_CommonSearchEntityFields.USERNAME] = oEntity_.UserName;

                        if (oEntity_.Password != null)
                            dr[ChildUserProfile_CommonSearchEntityFields.PASSWORD] = oEntity_.Password;

                        if (oEntity_.SiteId != null)
                            dr[ChildUserProfile_CommonSearchEntityFields.SITEID] = oEntity_.SiteId;

                        //Add Row into DataTable
                        DT_USERPROFILE_COMMONSEARCH.Rows.Add(dr);
                    }

                    // Save State of DataTable with Currently filled Data
                    DT_USERPROFILE_COMMONSEARCH.AcceptChanges();
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
