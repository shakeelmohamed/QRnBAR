using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

namespace CodeDayWcf
{
	[ServiceContract]
	public interface ICodeDaySvc
	{
		[OperationContract]
        [WebGet(UriTemplate = "GetScoreboard/", ResponseFormat=WebMessageFormat.Json)]
		List<ScoreboardItem> GetScoreboard();

        [OperationContract]
        [WebGet(UriTemplate = "Scan/?imei={imei}&code={code}&points={points}", ResponseFormat = WebMessageFormat.Json)]
        bool Scan(string imei, string code, string points);

        [OperationContract]
        [WebGet(UriTemplate = "SetupPlayer/?imei={imei}&nickname={nickname}", ResponseFormat = WebMessageFormat.Json)]
        bool SetupPlayer(string imei, string nickname);

        [OperationContract]
        [WebGet(UriTemplate = "GetPlayer/{imei}", ResponseFormat = WebMessageFormat.Json)]
        string GetPlayer(string imei);

        [OperationContract]
        [WebGet(UriTemplate = "DeletePlayer/?imei={imei}&deleteCodesFlag={deleteCodesFlag}", ResponseFormat = WebMessageFormat.Json)]
        bool DeletePlayer(string imei, string deleteCodesFlag);
	}
}
