#include "DHT.h"
#include <stdio.h>

#define DHTPIN 2
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);


void setup() {
    Serial.begin(9600);
}

void loop() {
  
  int t = dht.readTemperature();
  int h = dht.readHumidity();
  Serial.print(t);
  Serial.print(",");
  Serial.println(h);
  
  delay(1000);
}
