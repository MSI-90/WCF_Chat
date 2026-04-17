using System.ServiceModel;

namespace ClassLibrary1
{
  // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceChat" в коде и файле конфигурации.
  [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
  public interface IServiceChat
  {
    [OperationContract]
    int Connect();

    [OperationContract]
    void Disconnect(int id);

    [OperationContract(IsOneWay = true)]
    void SendMsg(string msg);
  }

  public interface IServerChatCallback
  {
    [OperationContract]
    void MsgCallBack(string msg);
  }
}
