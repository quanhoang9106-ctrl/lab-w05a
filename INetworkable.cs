
/****************/
// Mã sinh viên: 202418971
// Họ tên: Hoàng Văn Quân
/****************/

public interface INetworkable
{
    string IpAddress { get; }

    void Connect(string ipAddress);

    void Disconnect();

    bool IsConnected { get; }
}
