int LED = 13;

void setup() {
  Serial.begin(9600);
  pinMode(LED, OUTPUT);
}

void loop() {
  if (Serial && Serial.available() && Serial.read() == '1'){
    digitalWrite(LED, HIGH);                   
                  delay(1000);
                  digitalWrite(LED, LOW);
  }
}
