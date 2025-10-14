#include <LiquidCrystal_I2C.h>
#include <DallasTemperature.h>
#include <OneWire.h>

#define ONE_WIRE_BUS 2

int contador = 0;
bool medindo = false;
float t0 = 0;
int rele_1 = 7;
int rele_2 = 8;

LiquidCrystal_I2C lcd(0x27, 16, 2);
OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature sensors(&oneWire);



void medir() {
  sensors.requestTemperatures();
  lcd.setCursor(3, 0);
  lcd.print("Tempo.:");
  lcd.setCursor(10, 0);
  lcd.print(contador);
  lcd.setCursor(2, 1);
  lcd.print("Temp.:");
  lcd.setCursor(8, 1);
  lcd.print(sensors.getTempCByIndex(0));
  lcd.setCursor(13, 1);
  lcd.write(223);
  lcd.setCursor(14, 1);
  lcd.print("C");
}

void setup()
{
  lcd.init();
  lcd.clear();
  lcd.backlight();
  sensors.begin();
  Serial.begin(9600);
  pinMode(rele_1, OUTPUT);
  pinMode(rele_2, OUTPUT);

  digitalWrite(rele_1, LOW);
  digitalWrite(rele_2, LOW);

  medir();
}
void loop() {
  medir();
  if (Serial.available())  //verifica se tem dados diponível para leitura
  {
    if (Serial.read() == 'b') {
      medindo = true;
      t0 = sensors.getTempCByIndex(0);
    }
    while (medindo) {
      Serial.println((String)sensors.getTempCByIndex(0));
      medir();
      //delay(4200);
      delay(840);

      if(sensors.getTempCByIndex(0) >= (contador/60) + t0 + 1)
      {
        digitalWrite(rele_1, HIGH);
        digitalWrite(rele_2, HIGH);
      }

      if(sensors.getTempCByIndex(0) < (contador/60) + t0 - 1)
      {
        digitalWrite(rele_1, LOW);
        digitalWrite(rele_2, LOW);
      }

      //contador += 5;
        contador += 1;
      if (Serial.read() == 'd') {
        contador = 0;
        medindo = false;
        lcd.clear();
      }
    }
  }
}
