public interface ISerializable
{
    long InstanceId { get; }

    string Serialize();
    void Deserialize(string state);
}
