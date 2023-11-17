## Girleide Macario dos Santos
## Questão 2
<br/>

### Para números inteiros com sinal de 8 bits:
byte: números entre 0 e 255 <br/>
sbyte: números entre -128 e 127 <br/>
### Para números inteiros com sinal de 16 bits
short: números entre -32,768 e -32,767 <br/>
ushort: números entre 0 e 65,535<br/>
### Para números inteiros com sinal de 32 bits
int: números entre -2,147,483,648 e 2,147,483,647<br/>
uint: números entre 0 e 4,294,967,295<br/>
### Para números inteiros com sinal de 64 bits
long: números entre -9,223,372,036,854,775,808 e 9,223,372,036,854,775,807<br/>
ulong: números entre 0 e 18,446,744,073,709,551,615 <br/>

### Para números muito grandes, limitados pela memória disponível, utiliza-se: <br/>
using System.Numerics;

BigInteger A = BigInteger.Parse("1234567890123456789012345678901234567890");

