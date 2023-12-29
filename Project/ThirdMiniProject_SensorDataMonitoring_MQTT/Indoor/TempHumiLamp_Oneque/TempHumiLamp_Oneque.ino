// Phi_Publish_DHT11.ino
#include <ESP8266WiFi.h>
#include <PubSubClient.h>
// --- BH1750 ------------------------
#include <BH1750.h>
BH1750 lightMeter;
// ----- DHT11 ------------------------
#include "DHT.h"
#define DHTPIN D4     
#define DHTTYPE DHT11  
DHT dht(DHTPIN, DHTTYPE);
// -------------------------------------

const char* ssid = "RiatechB2G";
const char* password = "12345678";

const char* userId = "mqtt_woo";
const char* clientId = userId;
const char* userPw = "1234";
// 원큐
const char* topic = "Sensors/MyOffice/Indoor/SensorValue";

char* server = "192.168.2.35"; 

WiFiClient wifiClient; 
PubSubClient client(server, 1883, wifiClient);


void setup() {
  Serial.begin(9600);
  Wire.begin();
  lightMeter.begin();

  
  Serial.print("\nConnecting to ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.println("\nWiFi Connected");
  
  Serial.println("Connecting to broker");
  while ( !client.connect(clientId, userId, userPw) ){ 
    Serial.print("*");
    delay(1000);
  }
  Serial.println("\nConnected to broker");
  dht.begin();
}


void loop() {
  char payload[80];
  float h = dht.readHumidity();
  float t = dht.readTemperature();
  float l = lightMeter.readLightLevel();
  if (isnan(h) || isnan(t) ) {
    Serial.println("Failed to read from DHT sensor!");
    return;
  }


  String sPayload = "{'Temp':"
                +String(t, 1)	// 소수점 한 자리만 붙여서 생성
                +",'Humi':"
                +String(h, 1)
                +", 'Lux' :"
                +String(l, 1)
                +"}"; 

  sPayload.toCharArray(payload, 80);
  client.publish(topic, payload);
  Serial.print(String(topic) + " ");  Serial.println(payload);
  delay(2000);
}
