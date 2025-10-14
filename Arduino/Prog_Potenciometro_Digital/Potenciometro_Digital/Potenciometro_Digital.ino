 
//A visualização do grafico é realizada em "Ferramentas>Plotter Serial" na IDE do arduino

/*                                                                                                                                 
 * Para este exemplo, conecte seu X9C103P (ou similar) da seguinte maneira:
 * 1 - INC - Arduino pin 2
 * 2 - U/D - Arduino pin 3
 * 3 - VH  - 5V
 * 4 - VSS - GND
 * 5 - VW  - Output: Arduino pin A0 for analogRead
 * 6 - VL  - GND
 * 7 - CS  - Arduino pin 4
 * 8 - VCC - 5V
 */


#include <DigiPotX9Cxxx.h>

DigiPot pot(2,3,4);

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.println("Starting");  

  for (int i=0; i<100; i++) {
    pot.increase(1);
    Serial.println(analogRead(A0));
    delay(20);
  }
  
  
  for (int i=0; i<100; i++) {
    pot.decrease(1);
    Serial.println(analogRead(A0));
    delay(20);
  }

}
