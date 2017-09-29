using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data.Entity;

namespace WcfServer {
    [ServiceContract]
    public interface IFieldTanks {

        [OperationContract]
        List<TankDetail> SelectTankDetails(bool delete);

        [OperationContract]
        List<Tank> InitTanks(int tanksCount, int tankVisible);

        [OperationContract]
        int[] FillField(List<Tank> tanks);

        [OperationContract]
        List<Tank> ApplyStrategy(List<Tank> tanks, FieldTanks.TankColor tankColor, string player, bool attack);

    }

    [DataContract]
    public class TankDetail {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Orient { get; set; }
        [DataMember]
        public string Player { get; set; }
        [DataMember]
        public string Strategy { get; set; }
    }

    class TankContext : DbContext {
        public TankContext()
            : base("DbConnection") { }

        public DbSet<TankDetail> TankDetails { get; set; }
    }
}
