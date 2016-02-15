#Servo Client

A simple serial interface for a custom servo driver. The interface supports changing various parameters on the driver as well as charting performance data back from the driver.

The client displays the last 1,000 points of data from the driver.

## Packet structure
The packets are binary data, the first byte is the size of the packet, the second byte is the type of the packet and the remaining size - 2 bytes are the payload.

## Supported Commands
1. Get Config - retrieves the config from the device
1. Set Config - sends config to the device
1. Start/Stop Performance Data - Tells the device to start or stop sending performance data
