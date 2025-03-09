# Event Manager Unity Package
===

## Description
This package contains a utility that makes it possible to send and receive local events with any type of data in your Unity project.

## How to use
First, to fix Git Dependencies, copy the link below and add it to your project via Unity Package Manager: [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
```
https://github.com/sajadimn/noname-oneup-singleton.git
```
Then, copy the link below and add it to your project via Unity Package Manager: [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
```
https://github.com/sajadimn/noname-oneup-event-manager.git
```

## Benefits

### 1-Send and receive all types of data between your project scripts easily.
The sending class can create and send any data type. Then, the receiving class receives the data, converts it to the sent type, and uses it.

### 2-Removing dependencies between classes.
Send and receive data without needing to know who the receiving or sending class is and without needing to make classes dependent on each other.

### 3-Sync data across all classes that use it immediately as it changes.
Whenever data changes, you can send the data through the event manager, which then syncs the data of all classes that have registered to receive it.

### 4-No need to attach classes to each other to get data.

### 5-No need to make another class's function public and call it to get data.

### 6-No need to use the update function to sync data.

## Examples

✅️ Call the SendGlobalEvent function of the EventManager class to send data
```c#
  using Noname.OneUp.Packages.EventManager;

  public class MySenderClassName : MonoBehaviour {
    
    private void SendData()//Call this function whenever you need to send data
    {
        string data = "Test Data";//data can be anything(string, int, object of class, boolean, ...)
        EventManager.Instance.SendGlobalEvent("EventName", data);
    }
  }
```

✅️ Call the RegisterGlobalEvent function of the EventManager class to receive data
✅️ Call the RemoveGlobalEvent function of the EventManager class in the OnDestroy function and also wherever you want to remove the callback(this is necessary)
```c#
  using Noname.OneUp.Packages.EventManager;

  public class MyReceiverClassName : MonoBehaviour {
    
    private void Start()
    {
        EventManager.Instance.RegisterGlobalEvent("EventName", ReceiveData);
    }
    private void ReceiveData(object data)
    {
        if(data != null)
        {
            string receivedData = data as string;
            Debug.Log("Data Received: " + receivedData);
        }
    }
    private void MyRemoveEvent()//Optional
    {
        EventManager.Instance.RemoveGlobalEvent("EventName", ReceiveData);
    }
    private void OnDestroy()//Necessary
    {
        EventManager.Instance.RemoveGlobalEvent("EventName", ReceiveData);
    }
  }
```
## License

* MIT
* [Singleton](https://github.com/sajadimn/noname-oneup-event-manager) by Sajad Imani

## Author

[Sajad Imani](https://github.com/sajadimn)

## See Also

* GitHub Page : https://github.com/sajadimn

