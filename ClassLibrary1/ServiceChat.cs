using System;

namespace ClassLibrary1
{
  // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.
  public class ServiceChat : IServiceChat
  {
    public int Connect()
    {
      throw new NotImplementedException();
    }

    public void Disconnect(int id)
    {
      throw new NotImplementedException();
    }

    public void DoWork()
    {
    }

    public void SendMsg(string msg)
    {
      throw new NotImplementedException();
    }
  }
}
