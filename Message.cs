using System;
using System.Collections.Generic;
using System.Text;
using MessagePack;

namespace BleGatewayTest
{
    [MessagePackObject]
    public class Message
    {
        [Key(0)]
        public string v { get; set; }
        [Key(1)]
        public int mid { get; set; }
        [Key(2)]
        public int time { get; set; }
        [Key(3)]
        public string ip { get; set; }
        [Key(4)]
        public string mac { get; set; }
        [Key(5)]
        public ICollection<Device> devices { get; set; }
    }

    [MessagePackObject]
    public class Device
    {
        [Key(0)]
        public string type { get; set; }
        [Key(1)]
        public int[] data { get; set; }
    }
}
