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
        void InitTanks(FieldTanks.TankColor tankColor);

        [OperationContract]
        int[] FillField();
        
        [OperationContract]
        void InitField(int cellCount, int tanksCount, int tankVisible);

        [OperationContract]
        void ApplyStrategy(FieldTanks.TankColor tankColor, bool attack = false);

    }

    
   
}
