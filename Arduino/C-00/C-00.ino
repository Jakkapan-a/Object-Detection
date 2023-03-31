#include <TcBUTTON.h>
#include <TcPINOUT.h>

// Create button start and reset
#define BUTTON_START 11
#define BUTTON_RESET 12

void btStartPressed();
void btStartRepassed();

void btResetPressed();
void btResetRepassed();

TcBUTTON btStart(BUTTON_START, btStartPressed, btStartRepassed);
TcBUTTON btReset(BUTTON_RESET, btResetPressed, btResetRepassed);


// Create LED NG and OK
#define LED_NG 8
#define LED_OK 9

void ledIsOk(bool);
void ledIsNg(bool);

TcPINOUT ledOk(LED_OK, ledIsOk);
TcPINOUT ledNg(LED_NG, ledIsNg);


void serialEvent();
// Variable
String inputString = "";
bool stringComplete = false;


void setup() {
 Serial.begin(115200);
}

void loop() { 
    btStart.update();
    btReset.update();
    
    if(stringComplete) {
      if(inputString == "ok") {
        ledOk.on();
        ledNg.off();
      } else if(inputString == "ng") {
        ledOk.off();
        ledNg.on();
      } else if(inputString == "rs") {
        ledOk.off();
        ledNg.off();
      }
      inputString = "";
      stringComplete = false;
    }
}

void btStartPressed() {
  Serial.println("Start pressed");
  serialCommand("st");
}
void btStartRepassed() {
  Serial.println("Start repressed");
}

void btResetPressed() {
  Serial.println("Reset pressed");
  serialCommand("rs");
}

void btResetRepassed() {
  Serial.println("Reset repressed");

  ledIsOk.off();
  ledIsNg.off();
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
     if (inChar == '#') {
      stringComplete = true;  // Set state complete to true
      inputString.trim();     // Remove space
      break;
    }
    if (inChar == '>' || inChar == '<' || inChar == '\n' || inChar == '\r' || inChar == '\t' || inChar == ' ' || inChar == '?') {
      continue;
    }
    inputString += inChar;
  }
}

void serialCommand(String command) {
  Serial.println(">"+command+"<#");
}

void ledIsOk(bool state) {
  Serial.println("LED OK: "+String(state));
}

void ledIsNg(bool state) {
  Serial.println("LED NG: "+String(state));
}