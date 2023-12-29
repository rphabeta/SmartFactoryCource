#include <ESP8266WiFi.h>
#include <PubSubClient.h>

// #include <Wire.h>
#include <BH1750.h>
BH1750 lightMeter;

#include "DHT.h"
#define DHTPIN D4
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);

const char* ssid = "RiatechB2G";
const char* password = "12345678";

const char* userId = "mqtt_subean";
const char* userPw = "1234";
const char* clientId = userId;

// char* topic_t = "Sensors/MyOffice/Outdoor/temp";
// char* topic_h = "Sensors/MyOffice/Outdoor/humi";
// char* topic_l = "Sensors/MyOffice/Outdoor/Lux";
char* topic = "Sensors/MyOffice/Outdoor/SensorValue";

char* server = "192.168.2.35";

WiFiClient wifiClient;
PubSubClient client(server, 1883, wifiClient);


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  Serial.print("\nConnecting to ");
  Serial.println(ssid);

  Wire.begin();
  lightMeter.begin();

  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.println("\nWiFi Connected");

  Serial.println("Connecting to broker");
  while (!client.connect(clientId, userId, userPw)) {
    Serial.print("*");
    delay(500);
  }
  Serial.println("\nConnecting to broker");
  dht.begin();
}

// unsigned long int preTime = 0, currentTime;

void loop() {
  // put your main code here, to run repeatedly:
  char payload[80];
  float h = dht.readHumidity();
  float t = dht.readTemperature();
  float l = lightMeter.readLightLevel();
  
  if (isnan(h) || isnan(t)) {
    Serial.println("Failed to read from DHT sensor!");
    return;
  }

  String sPayload = "{'Temp':"
                +String(t, 1)   // 소수점 한 자리만 붙여서 생성
                +",'Humi':"
                +String(h, 1)
                +", 'Lux' :"
                +String(l, 1)
                +"}"; 

  sPayload.toCharArray(payload, 80);
  client.publish(topic, payload);
  Serial.print(String(topic) + " ");  Serial.println(payload);
  delay(2000);

  // String str = String(h);
  // str.toCharArray(buf, str.length());
  // client.publish(topic_h, buf);
  // Serial.println(String(topic_h) + " : " + buf);

  // str = String(t);
  // str.toCharArray(buf, str.length());
  // client.publish(topic_t, buf);
  // Serial.println(String(topic_t) + " : " + buf);
  // delay(2000);


  // // char buf[20];
  // str = String(l);
  // str.toCharArray(buf, str.length());
  // client.publish(topic_l, buf);
  // Serial.println(String(topic_l) + " : " + buf);
}