using Grpc.Net.Client;
using gRoom.gRPC.Messages;
using Google.Protobuf.WellKnownTypes;

using var channel = GrpcChannel.ForAddress("http://localhost:5282");
var client = new Groom.GroomClient(channel);

Console.WriteLine("*** Admin Console started ***");
Console.WriteLine("Listening...");


using var call = client.StartMonitoring(new Empty());

var cts = new CancellationTokenSource();

while (await call.ResponseStream.MoveNext(cts.Token))
{
    var msg = call.ResponseStream.Current;
    Console.WriteLine($" New Message received : {msg.Contents}, user: {msg.User}, at:{msg.MsgTime}");

}