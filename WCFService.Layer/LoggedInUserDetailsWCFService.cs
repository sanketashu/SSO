#region Namespaces
using EntityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using MasterBalc = BussinessAccessLayer.LoggedInUserDetailsBAL;
using MasterEntity = EntityLayer.LoggedInUserDetailsEntity;
using MasterInterface = WCFContractLayer.LoggedInUserDetailsWCFContract;
using MyCommonEntity = EntityLayer.CommonEntity;
using MyConstantEntity = EntityLayer.ConstantEntity;
#endregion

namespace WCFServiceLayer
{
    [ServiceBehavior(Namespace = "LoggedInUserDetails_WCFContract", Name = "LoggedInUserDetails_WCFService", InstanceContextMode = InstanceContextMode.PerCall)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class LoggedInUserDetailsWCFService : MasterInterface
	{
		static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

		#region WCF Auto Service 
		[OperationBehavior]
		[WebInvoke(Method = MyConstantEntity.ServiceCallMethod.POST, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = MyConstantEntity.UriTemplateMethodName.AUTO)]
		public OperationResult Auto(MasterEntity oEntity)
		{
			OperationResult obj = new OperationResult();
			try
			{
				//if oEntity is null then initialize it with blank entity
				if (oEntity == null)
					oEntity = new MasterEntity();

				Hashtable ht = new Hashtable();
				ht[MyCommonEntity.Fields.OPERATIONMODE] = MyConstantEntity.OperationModes.AUTO;
				List<object> ol = new MasterBalc(ConnectionString).GetInitData(oEntity, ht);
				if (ol.Count > 0)
				{
					obj.Data = ol;
					obj.Result = ol.Count > 0;
				}
				obj.Message = (obj.Result) ? MyConstantEntity.MessageConstants.RECORD_AUTO_SUCCEEDED : MyConstantEntity.MessageConstants.RECORD_AUTO_FAILED;
			}
			catch (Exception ex)
			{
				obj.Message = ex.Message;
			}
			return obj;
		}
		#endregion

		#region WCF Init Service 
		[OperationBehavior]
		[WebInvoke(Method = MyConstantEntity.ServiceCallMethod.POST, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = MyConstantEntity.UriTemplateMethodName.INIT)]
		public OperationResult Init(MasterEntity oEntity)
		{
			OperationResult obj = new OperationResult();
			try
			{
				//if oEntity is null then initialize it with blank entity
				if (oEntity == null)
					oEntity = new MasterEntity();

				Hashtable ht = new Hashtable();
				ht[MyCommonEntity.Fields.OPERATIONMODE] = MyConstantEntity.OperationModes.INIT;
				List<object> ol = new MasterBalc(ConnectionString).GetInitData(oEntity, ht);
				if (ol.Count > 0)
				{
					obj.Data = ol;
					obj.Result = ol.Count > 0;
				}
				obj.Message = (obj.Result) ? MyConstantEntity.MessageConstants.RECORD_INIT_SUCCEEDED : MyConstantEntity.MessageConstants.RECORD_INIT_FAILED;
			}
			catch (Exception ex)
			{
				obj.Message = ex.Message;
			}
			return obj;
		}
		#endregion

		#region WCF Retrieve Service 
		[OperationBehavior]
		[WebInvoke(Method = MyConstantEntity.ServiceCallMethod.POST, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = MyConstantEntity.UriTemplateMethodName.RETRIEVE)]
		public OperationResult Retrieve(MasterEntity oEntity)
		{
			OperationResult obj = new OperationResult();
			try
			{
				//if oEntity is null then initialize it with blank entity
				if (oEntity == null)
					oEntity = new MasterEntity();

				Hashtable ht = new Hashtable();
				ht[MyCommonEntity.Fields.OPERATIONMODE] = MyConstantEntity.OperationModes.RETRIEVE;
				List<object> ol = new MasterBalc(ConnectionString).GetInitData(oEntity, ht);
				if (ol.Count > 0)
				{
					obj.Data = ol;
					obj.Result = ol.Count > 0;
				}
				obj.Message = (obj.Result) ? MyConstantEntity.MessageConstants.RECORD_RETRIEVE_SUCCEEDED : MyConstantEntity.MessageConstants.RECORD_RETRIEVE_FAILED;
			}
			catch (Exception ex)
			{
				obj.Message = ex.Message;
			}
			return obj;
		}
		#endregion

		#region WCF Insert Service 
		[OperationBehavior]
		[WebInvoke(Method = MyConstantEntity.ServiceCallMethod.POST, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = MyConstantEntity.UriTemplateMethodName.INSERT)]
		public OperationResult Insert(MasterEntity oEntity)
		{
			OperationResult obj = new OperationResult();
			try
			{
				//if oEntity is null then initialize it with blank entity
				if (oEntity == null)
					oEntity = new MasterEntity();

				Hashtable ht = new Hashtable();
				ht[MyCommonEntity.Fields.OPERATIONMODE] = MyConstantEntity.OperationModes.INSERT;
				obj.Result = new MasterBalc(ConnectionString).Insert(oEntity, ht);
				obj.Message = (obj.Result) ? MyConstantEntity.MessageConstants.RECORD_INSERT_SUCCEEDED : MyConstantEntity.MessageConstants.RECORD_INSERT_FAILED;
				obj.Data = new List<object>();
				obj.Data.Add((obj.Result) ? ht[MasterEntity.Fields.LOGGEDINUSERID] : -1);
			}
			catch (Exception ex)
			{
				obj.Message = ex.Message;
			}
			return obj;
		}
		#endregion

		#region WCF Update Service 
		[OperationBehavior]
		[WebInvoke(Method = MyConstantEntity.ServiceCallMethod.POST, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = MyConstantEntity.UriTemplateMethodName.UPDATE)]
		public OperationResult Update(MasterEntity oEntity)
		{
			OperationResult obj = new OperationResult();
			try
			{
				//if oEntity is null then initialize it with blank entity
				if (oEntity == null)
					oEntity = new MasterEntity();

				Hashtable ht = new Hashtable();
				ht[MyCommonEntity.Fields.OPERATIONMODE] = MyConstantEntity.OperationModes.UPDATE;
				obj.Result = new MasterBalc(ConnectionString).Update(oEntity, ht);
				obj.Message = (obj.Result) ? MyConstantEntity.MessageConstants.RECORD_UPDATE_SUCCEEDED : MyConstantEntity.MessageConstants.RECORD_UPDATE_FAILED;
				obj.Data = new List<object>();
				obj.Data.Add((obj.Result) ? ht[MasterEntity.Fields.LOGGEDINUSERID] : -1);
			}
			catch (Exception ex)
			{
				obj.Message = ex.Message;
			}
			return obj;
		}
		#endregion

		#region WCF Delete Service 
		[OperationBehavior]
		[WebInvoke(Method = MyConstantEntity.ServiceCallMethod.POST, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = MyConstantEntity.UriTemplateMethodName.DELETE)]
		public OperationResult Delete(MasterEntity oEntity)
		{
			OperationResult obj = new OperationResult();
			try
			{
				//if oEntity is null then initialize it with blank entity
				if (oEntity == null)
					oEntity = new MasterEntity();

				Hashtable ht = new Hashtable();
				ht[MyCommonEntity.Fields.OPERATIONMODE] = MyConstantEntity.OperationModes.DELETE;
				obj.Result = new MasterBalc(ConnectionString).Delete(oEntity, ht);
				obj.Message = (obj.Result) ? MyConstantEntity.MessageConstants.RECORD_DELETE_SUCCEEDED : MyConstantEntity.MessageConstants.RECORD_DELETE_FAILED;
				obj.Data = new List<object>();
				obj.Data.Add((obj.Result) ? ht[MasterEntity.Fields.LOGGEDINUSERID] : -1);
			}
			catch (Exception ex)
			{
				obj.Message = ex.Message;
			}
			return obj;
		}
		#endregion

	}
}
