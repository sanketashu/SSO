using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EntityLayer
{
    public class CommonEntity
    {
        #region Field
        /// <summary>
        /// Description : Database table field
        /// </summary>
        public static class Fields
        {
            public const string OPERATIONMODE = "OperationMode";

        }
        #endregion

        #region Database Parameters
        /// <summary>
        /// Holds the Stored Procedure parameter names in the database
        /// </summary>
        public static class Parameters
        {
            public const string OperationMode = "@OperationMode";
        }
        #endregion

        public class ErrorLog
        {
            public string FunctionName { get; set; }
            public string Source { get; set; }
            public string TargetSite { get; set; }
            public string ExceptionType { get; set; }
            public string Message { get; set; }
            public string Stacktrace { get; set; }
            public string Timestamp { get; set; }
            public string MSDN_HelpLink { get; set; }
            public int ErrorCode { get; set; }
            public InnerException_ InnerException { get; set; }
            public class InnerException_
            {
                public string Inner_Source { get; set; }
                public string Inner_TargetSite { get; set; }
                public string Inner_ExceptionType { get; set; }
                public string Inner_Message { get; set; }
                public string Inner_Stacktrace { get; set; }
                public string Inner_Timestamp { get; set; }
                public string Inner_MSDN_HelpLink { get; set; }
                public int Inner_ErrorCode { get; set; }
            }
        }
    }

    public class ConstantEntity
    {
        public class OperationModes
        {
            public const string INIT = "INIT";
            public const string SAVE = "SAVE";
            public const string INSERT = "INSERT";
            public const string UPDATE = "UPDATE";
            public const string DELETE = "DELETE";
            public const string RETRIEVE = "RETRIEVE";
            public const string AUTO = "AUTO";
        }
        public class MessageConstants
        {
            public const string RECORD_AUTO_SUCCEEDED = "Records auto successfully !...";
            public const string RECORD_AUTO_FAILED = "Records auto failed !...";

            public const string RECORD_INIT_SUCCEEDED = "Records init successfully !...";
            public const string RECORD_INIT_FAILED = "Records init failed !...";

            public const string RECORD_SAVE_SUCCEEDED = "Record saved successfully !...";
            public const string RECORD_SAVE_FAILED = "Record save failed !...";

            public const string RECORD_INSERT_SUCCEEDED = "Record inserted successfully !...";
            public const string RECORD_INSERT_FAILED = "Record insert failed !...";

            public const string RECORD_UPDATE_SUCCEEDED = "Record updated successfully !...";
            public const string RECORD_UPDATE_FAILED = "Record update failed !...";

            public const string RECORD_DELETE_SUCCEEDED = "Record deleted successfully !...";
            public const string RECORD_DELETE_FAILED = "Record delete failed !...";

            public const string RECORD_RETRIEVE_SUCCEEDED = "Records retrieved successfully !...";
            public const string RECORD_RETRIEVE_FAILED = "Records retrieve failed !...";

            public const string RECORD_VIEW_SUCCEEDED = "Records fetch successfully !...";
            public const string RECORD_VIEW_FAILED = "Records fetch failed !...";
        }
        public class ServiceCallMethod
        {
            public const string POST = "POST";
            public const string GET = "GET";
            public const string PUT = "PUT";
            public const string DELETE = "DELETE";
        }
        public class UriTemplateMethodName
        {
            public const string AUTO = "Auto";
            public const string INIT = "Init";
            public const string RETRIEVE = "Retrieve";
            public const string INSERT = "Insert";
            public const string UPDATE = "Update";
            public const string DELETE = "Delete";
        }
    }

    public class OperationResult
    {
        public List<object> Data { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }
        public int ResponseCode { get; set; }
    }

    public class CommonFunctions
    {
        #region Local Variables
        private static List<CommonEntity.ErrorLog> ErrorLogEntity = new List<CommonEntity.ErrorLog>();
        private static string Sep = Path.DirectorySeparatorChar.ToString();
        #endregion

        /// <summary>
        /// This method will convert a JSOn Serialize to object
        /// </summary>
        /// <param name="lstObject">List of Objects</param>
        /// <returns>Dataset</returns>
        public static string DataSetToJSON(DataSet ds)
        {
            JsonSerializerSettings jsfs = new JsonSerializerSettings();
            jsfs.Formatting = Newtonsoft.Json.Formatting.Indented;
            return JsonConvert.SerializeObject(ds, jsfs);
        }

        /// <summary>
        /// This method will convert a JSOn Serialize to object
        /// </summary>
        /// <param name="lstObject">List of Objects</param>
        /// <returns>DataTable</returns>
        public static string DataTableToJSON(DataTable DT)
        {
            JsonSerializerSettings jsfs = new JsonSerializerSettings();
            jsfs.Formatting = Newtonsoft.Json.Formatting.Indented;
            return JsonConvert.SerializeObject(DT, jsfs);

        }

        /// <summary>
        /// This method will return IPAddress of requested PC
        /// </summary>
        /// <param name="lstObject"></param>
        /// <returns>String</returns>
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}