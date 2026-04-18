using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace ClassLibrary1
{
  // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.

  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class ServiceChat : IServiceChat
  {
    List<ServerUser> users = new List<ServerUser>();
    int nextId = 1;
    public int Connect(string name)
    {
      var user = new ServerUser()
      {
        Id = nextId,
        Name = name,
        operationContext = OperationContext.Current
      };
      nextId++;

      SendMsg(": " + user.Name + " подключился к чату!", 0);
      users.Add(user);
      return user.Id;
    }

    public void Disconnect(int id)
    {
      var user = users.FirstOrDefault(u => u.Id == id);
      if (user != null)
      {
        users.Remove(user);
        SendMsg(": " + user.Name + " отключился от чата!", 0);
      }
    }

    public void SendMsg(string msg, int id)
    {
      foreach (var item in users) 
      {
        string answer = DateTime.Now.ToShortTimeString() + " ";
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
          answer += ": " + user.Name+" ";
        }
        answer += msg;

        item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallBack(answer);
      }
    }
  }
}
