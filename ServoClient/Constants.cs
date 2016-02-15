using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoClient
{
    class Constants
    {
        public const int PACKET_TYPE_PERF_DATA = 1;
        public const int PACKET_SIZE_PERF_DATA = 20;
        public const int PACKET_TYPE_GET_CONFIG = 2;
        public const int PACKET_SIZE_GET_CONFIG = 2;
        public const int PACKET_TYPE_SET_CONFIG = 3;
        public const int PACKET_SIZE_SET_CONFIG = 14;
        public const int PACKET_TYPE_START_PERF_DATA = 4;
        public const int PACKET_SIZE_START_PERF_DATA = 2;
        public const int PACKET_TYPE_STOP_PERF_DATA = 5;
        public const int PACKET_SIZE_STOP_PERF_DATA = 2;
        public const int PACKET_TYPE_START_FAKE_STEP_COUNTER = 6;
        public const int PACKET_SIZE_START_FAKE_STEP_COUNTER = 2;
        public const int PACKET_TYPE_STOP_FAKE_STEP_COUNTER = 7;
        public const int PACKET_SIZE_STOP_FAKE_STEP_COUNTER = 2;
        public const int PACKET_TYPE_CONFIG = 8;
        public const int PACKET_SIZE_CONFIG = 14;
    }
}
