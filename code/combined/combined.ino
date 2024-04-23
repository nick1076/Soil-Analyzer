#include <dht.h>

bool serialMonitor = false;

dht DHT;

#define tempHumSensor 9
#define soilMoistureSensor A0

#include <SoftwareSerial.h>
#include <Wire.h>

#define RE 8
#define DE 7
 
//const byte code[]= {0x01, 0x03, 0x00, 0x1e, 0x00, 0x03, 0x65, 0xCD};
const byte nitro[] = {0x01,0x03, 0x00, 0x1e, 0x00, 0x01, 0xe4, 0x0c};
const byte phos[] = {0x01,0x03, 0x00, 0x1f, 0x00, 0x01, 0xb5, 0xcc};
const byte pota[] = {0x01,0x03, 0x00, 0x20, 0x00, 0x01, 0x85, 0xc0};
 
byte values[11];
SoftwareSerial mod(2,3);

void setup() {
  Serial.begin(9600);
  mod.begin(9600);
  pinMode(RE, OUTPUT);
  pinMode(DE, OUTPUT);
  delay(500);
  delay(3000);
}

void loop() {
  byte val1,val2,val3;
  val1 = nitrogen();
  delay(250);
  val2 = phosphorous();
  delay(250);
  val3 = potassium();
  delay(250);
  delay(500);
  int readData = DHT.read11(tempHumSensor);
  float t = DHT.temperature;
  float h = DHT.humidity;
  int soilMoisture = analogRead(soilMoistureSensor);

  if (serialMonitor){
    Serial.print("Temperature: ");
    Serial.print((t*9.0)/5.0+32.0);
    Serial.print("°F | ");
    Serial.print("Humidity: ");
    Serial.print(h);
    Serial.print("% | ");
    
    Serial.print("Soil Moisture: ");
    Serial.println(soilMoisture);
    
    Serial.print("Nitrogen: ");
    Serial.print(val1);
    Serial.println(" mg/kg");
    Serial.print("Phosphorous: ");
    Serial.print(val2);
    Serial.println(" mg/kg");
    Serial.print("Potassium: ");
    Serial.print(val3);
    Serial.println(" mg/kg");
    delay(2000);
    
    Serial.println();
  }
  else{
    Serial.print("&");
    Serial.print((t*9.0)/5.0+32.0);
    Serial.print("&");
    Serial.print(h);
    Serial.print("&");
    Serial.print(soilMoisture);
    Serial.print("&");
    Serial.print(val1);
    Serial.print("&");
    Serial.print(val2);
    Serial.print("&");
    Serial.print(val3);
    Serial.println("&");
    delay(2000);
  }
}

 
byte nitrogen(){
  digitalWrite(DE,HIGH);
  digitalWrite(RE,HIGH);
  delay(10);
  if(mod.write(nitro,sizeof(nitro))==8){
    digitalWrite(DE,LOW);
    digitalWrite(RE,LOW);
    for(byte i=0;i<7;i++){
    //Serial.print(mod.read(),HEX);
    values[i] = mod.read();
    //Serial.print(values[i],HEX);
    }
    //Serial.println();
  }
  return values[4];
}
 
byte phosphorous(){
  digitalWrite(DE,HIGH);
  digitalWrite(RE,HIGH);
  delay(10);
  if(mod.write(phos,sizeof(phos))==8){
    digitalWrite(DE,LOW);
    digitalWrite(RE,LOW);
    for(byte i=0;i<7;i++){
    //Serial.print(mod.read(),HEX);
    values[i] = mod.read();
    //Serial.print(values[i],HEX);
    }
    //Serial.println();
  }
  return values[4];
}
 
byte potassium(){
  digitalWrite(DE,HIGH);
  digitalWrite(RE,HIGH);
  delay(10);
  if(mod.write(pota,sizeof(pota))==8){
    digitalWrite(DE,LOW);
    digitalWrite(RE,LOW);
    for(byte i=0;i<7;i++){
    //Serial.print(mod.read(),HEX);
    values[i] = mod.read();
    //Serial.print(values[i],HEX);
    }
    //Serial.println();
  }
  return values[4];
}
