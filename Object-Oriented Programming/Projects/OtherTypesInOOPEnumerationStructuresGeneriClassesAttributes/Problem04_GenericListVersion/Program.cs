using System;
using System.Collections.Generic;



    class Program
    {
        static void Main()
        {
           GenericList<dynamic> list = new GenericList<dynamic>();
          
           
            Console.WriteLine("Please choose the type of variables you want to put into the Generic:");
            Console.WriteLine("1 - int");
            Console.WriteLine("2 - double");
            Console.WriteLine("3 - string");
            Console.WriteLine("4 - date and time");
            int type = int.Parse(Console.ReadLine());
            if(type<1|| type>4)
            {
                throw new ArgumentException ("Invalid type");
            }
            while(true)
            {
                Console.WriteLine("Please enter the next variable to add:");
                
                var element = Convert(type);
                list.Add(element);
                Console.WriteLine("Would you like to add another element? Y/N");
                string checker = Console.ReadLine();
                if(checker=="N"||checker=="n") break;
            }
            Console.WriteLine("Current list: " + list.ToString());
            Console.WriteLine("You can check an element at a current position. Please enter the position of the element you want to see:");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine("The element on position {0} is {1}", position, list[position]);
            Console.WriteLine("Now we are going to replace an element on a current position. Please enter the position you want to replace:");
            position = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the new element you want to add:");
            var element2 = Convert(type);
            list[position] = element2;
            Console.WriteLine("The element on position {0} is now {1}", position, list[position]);
            Console.WriteLine("You can remove an element from a position. Please choose a position to remove");
            position = int.Parse(Console.ReadLine());
            list.RemoveAt(position);
            Console.WriteLine("Current list: " + list.ToString());
            Console.WriteLine("Now we are going to insert an element. Please enter the value");
            element2 = Convert(type);
            Console.WriteLine("Now please enter the position you want to add this item in:");
            position = int.Parse(Console.ReadLine());
            list.Insert(position, element2);
            Console.WriteLine("Current list: " + list.ToString());
            Console.WriteLine("Now we are checking the position of a value. Please enter the element which position we are looking for:");
            element2 = Convert(type);
            Console.WriteLine("You can add a starting position to search from. Press enter if you want to search from the begining of the list:");
            int startingPosition = 0;
            string input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input))
            {
                startingPosition = int.Parse(input);
            }
            Console.WriteLine("You can add the length of the search. Please press enter if you want to search till the end of the list:");
            int lenght = list.Count - startingPosition;
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                lenght = int.Parse(input);
            }
            Console.WriteLine("The position of the element you are searching is:" + list.IndexOf(element2, startingPosition, lenght));
            Console.WriteLine("Please enter an element and check whether the list contains it:");
            element2 = Convert(type);
            Console.WriteLine(list.Contains(element2));
            Console.Write("The smallest element is: ");
            switch (type)
            {
                case (1): IntMinMax(0, list); break;
                case (2): DoubleMinMax(0, list); break;
                case (3): StringMinMax(0, list); break;
                case (4): StringMinMax(0, list); break;

            }
            Console.Write("The largest element is: ");
            switch (type)
            {
                case (1): IntMinMax(1, list); break;
                case (2): DoubleMinMax(1, list); break;
                case (3): StringMinMax(1, list); break;
                case (4): StringMinMax(1, list); break;

            }
            object[] versionAttributes = typeof(GenericList<int>).GetCustomAttributes(false);
            Console.WriteLine("Version: {0}", versionAttributes[1]);
            
        }
        public static dynamic Convert (int type)
        {
            string input = Console.ReadLine();
            dynamic result = null; ;
            switch(type)
            {
                case(1): result = int.Parse(input); break;
                case (2): result = double.Parse(input); break;
                case (3): result = input; break;
                case (4): result = DateTime.Parse(input); break;

            }
            return result;
        }
        public static void IntMinMax(int a, GenericList<dynamic> list)
        {
            GenericList<int> listTemp = new GenericList<int>();
            for (int i = 0; i < list.Count; i++)
            {
                listTemp.Add(list[i]);
                
            }
            if (a==0) Console.WriteLine(GenericList<int>.Min<int>(listTemp));
            else Console.WriteLine(GenericList<int>.Max<int>(listTemp));
        }
        public static void DoubleMinMax(int a, GenericList<dynamic> list)
        {
            GenericList<double> listTemp = new GenericList<double>();
            for (int i = 0; i < list.Count; i++)
            {
                listTemp.Add(list[i]);

            }
            if (a == 0) Console.WriteLine(GenericList<double>.Min<double>(listTemp));
            else Console.WriteLine(GenericList<double>.Max<double>(listTemp));
        }
        public static void StringMinMax(int a, GenericList<dynamic> list)
        {
            GenericList<string> listTemp = new GenericList<string>();
            for (int i = 0; i < list.Count; i++)
            {
                listTemp.Add(list[i]);

            }
            if (a == 0) Console.WriteLine(GenericList<string>.Min<string>(listTemp));
            else Console.WriteLine(GenericList<string>.Max<string>(listTemp));
        }
        public static void DateTimeMinMax(int a, GenericList<dynamic> list)
        {
            GenericList<DateTime> listTemp = new GenericList<DateTime>();
            for (int i = 0; i < list.Count; i++)
            {
                listTemp.Add(list[i]);

            }
            if (a == 0) Console.WriteLine(GenericList<DateTime>.Min<DateTime>(listTemp));
            else Console.WriteLine(GenericList<DateTime>.Max<DateTime>(listTemp));
        }
        
    }

