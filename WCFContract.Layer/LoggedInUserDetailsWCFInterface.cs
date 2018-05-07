#region Namespaces
using EntityLayer;
using System.ServiceModel;
using MasterEntity = EntityLayer.LoggedInUserDetailsEntity;
#endregion

namespace WCFContractLayer
{
    [ServiceContract]
	public interface LoggedInUserDetailsWCFContract
	{
		[OperationContract]
		OperationResult Auto(MasterEntity oEntity);

		[OperationContract]
		OperationResult Init(MasterEntity oEntity);

		[OperationContract]
		OperationResult Retrieve(MasterEntity oEntity);

		[OperationContract]
		OperationResult Insert(MasterEntity oEntity);

		[OperationContract]
		OperationResult Update(MasterEntity oEntity);

		[OperationContract]
		OperationResult Delete(MasterEntity oEntity);
	}
}
