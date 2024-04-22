#include <dht.h>

dht DHT;

#define tempHumSensor 8
#define soilMoistureSensor A0

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.println();
  delay(500);
  int readData = DHT.read11(tempHumSensor);
  float t = DHT.temperature;
  float h = DHT.humidity;
  Serial.print("Temperature: ");
  Serial.print((t*9.0)/5.0+32.0);
  Serial.print("°F | ");
  Serial.print("Humidity: ");
  Serial.print(h);
  Serial.print("% | ");
  
  int soilMoisture = analogRead(soilMoistureSensor);
  Serial.print("Soil Moisture: ");
  Serial.println(soilMoisture);
  
  Serial.println();
}
