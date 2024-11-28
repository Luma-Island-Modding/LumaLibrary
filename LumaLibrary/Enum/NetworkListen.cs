namespace LumaLibrary.Enum
{
    public enum NetworkHostEvent
    {
        OnPlayerJoinedGame,
        OnPlayerLeftGame
    }

    public enum NetworkClientEvent
    {
        OnConnectedToServer,
        OnFailedToConnectToHost,
        OnDisconnectedFromHost
    }
}
