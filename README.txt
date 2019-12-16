This is a simple simulation program which checks whether the polynomial is primal or not. To do so the program uses Fibonacci linear shift register based on input polynomial.
LFSR seeded with any bit sequence excluding series of zeros will give a cycle of 2^n - 1 different sequences which can be used for pseudorandom number generation.
Example:

polynomial to check: 1+x^2+x^5
Input:  1   0   1   0   0   1
       x^0 x^1 x^2 x^3 x^4 x^5
	   
Corresponding LFSR:
----------------------+---------------------------------
|                     |                                |
|                     |                                |
|                     |                                |
| |------|   |------| | |------|   |------|   |------| |
>-|      |->-|      |->-|      |->-|      |->-|      |->-----
  |------|   |------|   |------|   |------|   |------| 
  
Output:
11111
01111
00111
10011
11001
01100
10110
01011
00101
10010
01001
00100
00010
00001
10000
01000
10100
01010
10101
11010
11101
01110
10111
11011
01101
00110
00011
10001
11000
11100
11110
