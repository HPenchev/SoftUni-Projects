using System;
using System.Numerics;


    class BitArray
    {

        private int numberOfBits;
        private int[] numbers;
        
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= this.NumberOfBits - 1)
                {
                   
                    int positionInArray = index / 32;
                    int number = this.numbers[positionInArray];
                    return (number >> index & 1);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
            }
            set
            {
                if (index < 0 || index > this.NumberOfBits - 1)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                if(value<0||value>1)  throw new ArgumentOutOfRangeException("Index value is out of range");

                int positionInArray = index / 32;
                int positionOfBit = index % 32;
                int number = this.numbers[positionInArray];
                if(value==0)
                {
                    value = number & (~(1 << positionOfBit));
                }
                else
                {
                    value = number | 1 << positionOfBit;
                }
                this.numbers[positionInArray] = value;
            }
        }

        public int NumberOfBits
        {
            get
            {
                return this.numberOfBits;
            }
            set
            {
                if (value < 1 || value > 100000) throw new ArgumentOutOfRangeException("Number of bits has to be between 1 and 100 000");
                this.numberOfBits = value;
            }
        }
        public int[] Numbers
        {
            get
            {
                return this.numbers;
            }
            set
            {
                
                this.numbers = value;
            }
        }
        


        public BitArray(int numberOfBits)
        {
            this.NumberOfBits = numberOfBits;
            int size = numberOfBits / 32;
            if (numberOfBits % 32 != 0) size++;
            this.Numbers = new int[size];
        }
        public override string ToString()
        {
            BigInteger endNumber = 0;
            for (int i = 0; i < this.NumberOfBits; i++)
            {
                int positionInArray = i / 32;
                int number = this.Numbers[positionInArray];
                int positionOfBit = i % 32;
                int mask = 1 << positionOfBit;
                mask = mask & number;
                if(mask!=0)
                {
                    BigInteger numberToAdd = 1;
                    for (int j = 1; j <=i; j++)
                    {
                        numberToAdd *= 2;
                    }
                    endNumber += numberToAdd;
                }

            }
            return string.Format(endNumber.ToString());
        }
    }

