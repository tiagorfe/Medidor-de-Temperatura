
#include <DigiPotX9Cxxx.h>

DigiPot pot(23,24,22);

void setTemp(double temp) {
  Serial.println("Setting Temperature to: " + (String)temp);
  double maxTemp = 100 ; // valor para 500 graus
  int value = (temp / 500 * maxTemp);
  //pot.decrease(100);
  Serial.println(value);
  pot.set(value);
}

void setup() {
  Serial.begin(9600);
  Serial.println("Starting");
  setTemp(100);
}

void loop() {
  delay(1000);
}