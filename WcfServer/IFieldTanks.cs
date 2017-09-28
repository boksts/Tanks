using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WcfServer {
    [ServiceContract]
    public interface IFieldTanks {

       /* [OperationContract]
        DataSet SelectGameDetails();*/

        [OperationContract]
        List<Tank> InitTanks(int tanksCount, int tankVisible);

        [OperationContract]
        int[] FillField(List<Tank> tanks);
 
        [OperationContract]
        List<Tank>  ApplyStrategy(List<Tank> tanks, FieldTanks.TankColor tankColor, bool attack);

    }
   /* 
    [DataContract]
    public class GameDetails
    {
        [DataMember]
        public int GameID { get; set; }
        [DataMember]
        public string PlayerName { get; set; }
        [DataMember]
        public string GameResult { get; set; }
        [DataMember]
        public string GameStrategy{ get; set; }

    
    }*/
}


