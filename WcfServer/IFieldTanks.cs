using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServer {
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IFieldTanks {

        [OperationContract]
        List<Tank> InitTanks(int tanksCount, int tankVisible);

        [OperationContract]
        int[] FillField(List<Tank> tanks);
        

        [OperationContract]
        List<Tank>  ApplyStrategy(List<Tank> tanks, FieldTanks.TankColor tankColor, bool attack);
    

    }

    
   
}
