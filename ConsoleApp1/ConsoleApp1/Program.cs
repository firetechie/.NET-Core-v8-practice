using System;
using CommonLogic;
//using Maths;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    //Interfaces & Abstract Class :-
        // Interfaces : 
        //It's a first phase/step to planning abstract class, it's contract.
        //It enforces things to abstract class, it is implemented.
        //It has only signatures.
        //Everything is abstract, have to implement all the methods, support multiple inheritance
        //Ex:- 
       public interface ICustomerBasicInfo {
            string Name { get; set; }

            void enquiry();
         }

        public interface ICustomerPurchaseInfo {

            decimal discount();
        }

    // Abstract Class :
        //It is partially defined parent class, share common logic to child class
        //It is inherited
        //Some of the methods are defined and some are abstract, doesn't support multiple inheritance
    public abstract class CustomerBasicInfo
    {
        public string Name { get; set; }

        public void enquiry()
        {
            throw new NotImplementedException();
        }

        public decimal discount()
        {
            return 0;
        }
    }

    // Concrete Class : (child class)
    //It has full implementation of methods.
    public class visitor : ICustomerBasicInfo, ICustomerPurchaseInfo // Multiple inheritance
    {
            public string Name { get; set; }

            public decimal discount()
            {
                return 0;
            }

            public void enquiry()
            {
                throw new NotImplementedException();
            }
        } 




        class Program
    {
        //Features of .NET :-
        // CLR : it converts IL code to Machine readable language and basically it's virtual machine component that provides the service like type safety, exception handling, garbage collection, memory mngt. and thread mngt.
        // CTS : if i write any objects in different language it can interact each other, .ddl file will create with same structure.
        // CLS : if i write the variable name in capital/small case letter it may give us compile time exception. CLS Compliant,  It defines a set of rules and restrictions.

        //        static void Main(string[] args)
        //        {
        //            int i = 1000;
        //            double d = 100.10;
        //            string str = "123";
        //            bool b = true;

        //            //Console.WriteLine(i = (int) d);
        //            //Console.WriteLine(i = Convert.ToInt32(str));

        //            AO ao = new AO();
        //            int add = ao.add(10, 20);
        //            Console.WriteLine(add);

        //            AO ao1 = new AO();
        //            int sub = ao1.sub(10, 20);
        //            Console.WriteLine(sub);

        //            //Class1 c1 = new Class1();
        //            //Console.WriteLine("Hello World: " + c1.getCurrentDateAndTime());
        //            Console.ReadLine();
        //}

        //without using Yield keyword, it will wait for List to return list of values then pass to method invoke
        //static IEnumerable<int> GetEvenNumbers(int max)
        //{
        //    List<int> evenNos = new List<int>();
        //    for (int i = 0; i < max; i += 2)
        //    {
        //        evenNos.Add(i);

        //    }
        //    return evenNos;
        //}

        //using Yield keyword : for efficiency, it is an iterator blocker and return values.
        //static IEnumerable<int> GetEvenNos(int Max)
        //{
        //    for(int i=0; i< Max; i += 2)
        //    {
        //        yield return i;
        //    }
        //}

        //Foreground thread - even if main method exits the child thread will keeps executing until the whole block executes
        //     v/s
        //Background thread - once main method exits the child thread will stops executing.

        //static void fn()
        //{
        //    Console.WriteLine("Fn start executing");
        //    Thread.Sleep(5000);
        //    Console.WriteLine("Fn exit");
        //}

        //static Maths m = new Maths();

        //yield keyword :- 
        //        1-> It helps to implements the custom iteration without using temp collection.
        //        2-> stateful iteration
        static List<int> newList = new List<int>();
        static void PushData()
        {
            newList.Add(1);
            newList.Add(2);
            newList.Add(3);
            newList.Add(4);
            newList.Add(5);
        }

        //in list if value is greater than 3
        static IEnumerable<int> Filter()
        {
            //List<int> Temp = new List<int>();
            foreach (int i in newList)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }
        }

        //in the list we have elements i.e. 1,2,3,4,5 for each iteration it should add with current index value and display.
        // I/P : 1, 2, 3, 4, 5  
        // O/P : 1, 3, 6, 10, 15
        static IEnumerable<int> RunningTotal()
        {
            int runningTotal = 0;
            foreach (int i in newList)
            {
                runningTotal += i;
                yield return (runningTotal);
            }
        }

        //IEnumerable & IQueryable :- Both are interfaces in .net framework which is used to iterate the elements among
        //collection class using foreach loop.
        //Main difference between them is filtering logic. when we use IEnumerable, all the data which we requested send CancellationToken 
        //client side and filtering will happen in in-memory. (In-memory collections).
        //When we use IQueryable, filtering will happen in database itself (RDBMS/Sql Server) then pass the necessary data to client.
        //(Collection connected to DB via Entity framework/LINQ.)

        public static void Main(string[] args)
        {
            //Interfaces & Abstract Class ex:-
            visitor v = new visitor();
            v.enquiry();




        //Advantages of using Lambda Functions :-
        //1 -> Simplifying the  delegate code & using in LINQ
        //Generic Readymade delegate Functions are Func, Action and Predicate
        //Func :- Passing input in by specifying the type and expect the output with specific type
        //Func<double, double> pointer = (r) => 3.142 * r * r;
        //double result = pointer(5);
        //Console.WriteLine("Result is : " + result);

            //Action :- Passing input in any type and not expecting any output, will return void.
            //Action<string> message = (s) => Console.WriteLine(s);
            //message("Hello");

            //Predicate :- Passing input in in any type and output will be in boolean type
            //Predicate<string> num = (s) => s.Length > 3;
            //Console.WriteLine(num("Hello World"));

            //List<string> MyList = new List<string>();
            //MyList.Add("India");
            //MyList.Add("Hello");
            //MyList.Add("World");
            //List<string> res = MyList.FindAll(num);
            //Console.WriteLine(string.Join(", ", res));

            //2 -> Evaluating the expression trees
            //BinaryExpression b1 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(10), Expression.Constant(8));
            //BinaryExpression b2 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(3), Expression.Constant(4));
            //BinaryExpression b3 = Expression.MakeBinary(ExpressionType.Subtract, b1, b2);
            //int val = Expression.Lambda<Func<int>> (b3).Compile()();
            //Console.WriteLine(val);


            //yield keyword
            //PushData();
            //foreach (int i in RunningTotal())
            //{
            //    Console.WriteLine(i);
            //}
            //Console.ReadLine();

            //TPL: Task Parallel Library
            //Parallel.For(0, 1000000, str => RunMillionIterations());
            //Thread t1 = new Thread(RunMillionIterations);
            //t1.Start();
            //Console.Read();

            //Task.Factory.StartNew(NewMethod1);
            //Task.Factory.StartNew(NewMethod2);
            ////NewMethod1();
            ////NewMethod2();

            //Console.WriteLine("Enter your name :");
            //string str = Console.ReadLine();
            //Console.WriteLine(str);
            //Console.Read();





            //Concurrency:- Executing multiple threads at the same time in single core, if we want to make threds interacting each other it would be the good choice.
            //It intends to make the application usable. it's indetermistic and execution wise it may not sequentially and output will be proper.
            //Parallalism:- Executing multiple threads at the same time in multiple core/multiple hardware or machine so the threads will not interact each other.
            //intends to make the application very speed and efficient so it focus on performance. it's subset of concurrency concept. it's determistic and execution wise it will be sequentially and output will be proper. 
            //Based on what output should comes at the end based on that we can design and execute.

            //using (var m1 = new Mutex(false, "OneThreadAccess"))
            //{
            //    if (!m1.WaitOne(1000, false))
            //    {
            //        Console.WriteLine("another instance is running");
            //        Console.ReadKey();
            //        return;
            //    }
            //    Console.WriteLine("Main application is running");
            //    Console.ReadKey();
            //}

            //Thread t1 = new Thread(fn);
            //t1.IsBackground = true; // For background thread
            //t1.Start();
            //Console.WriteLine("Main thread exit");

            //Thread t1 = new Thread(m.Divide);
            //t1.Start(); // Child thread
            //m.Divide(); // Main thread
            //Console.ReadLine();







            //Exception handling, try catch block
            //int num1 = 0;
            //int num2 = 0;
            //Console.WriteLine("Enter first no. :");
            //num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter second no. :");
            //num2 = Convert.ToInt32(Console.ReadLine());

            //try
            //{
            //    int result = num1 / num2;
            //    Console.WriteLine(result);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error Occured: Execute the method again");
            //}


            //IEnumerable<int> getEvenNumbers = GetEvenNos(10);
            //foreach (int no in getEvenNumbers)
            //{
            //    Console.WriteLine("number: " + no);
            //}


            //int i = 10;
            //int j = i;
            //j = 30;

            //AO ao = new AO();
            //ao.title = "val-1";

            //AO ao1 = new AO();
            ////ao1 = ao;
            //ao1.title = "val-2";

            //Primitive types are stored in STACK - LIFO
            //Non-Primitive/Custom types are stored in HEAP - FIFO

            //Class is reference type -> once create the instance/object and assign to 
            //another instance/object it will copy only reference that's why if we changed in 2nd instance value it will effect to 1st one. - reference semantics

            //Struct is value/composite type so it will copy the value not reference. - value semantics

            //Moving from value type (stack) to reference type(heap) is called 'Boxing' and visa versa is called 'Unboxing'.
            //for ex:-
            //int x = 10; // value
            //int y = x;
            //object o = y; // reference
            //int z = (int)o;

            //Collection Types :-
            //int[] ary = new int[10]; // Array - performance and strict typing
            //ary[0] = 10;
            //ary[1] = 34;
            ////ary[0] = Convert.ToInt32("Hi");

            //ArrayList list = new ArrayList(); // flexibility and store different types of data
            //list.Add(1);
            //list.Add(true);

            ////combination of best of array and arraylist is List
            //List<int> il = new List<int>();
            //il.Add(1);

            //List<string> sl = new List<string>();
            //sl.Add("Test");

            //Yield keyword
            //Input: 10, Output: 0, 2, 4, 6, 8


            //Multithreading
            //Thread t1 = new Thread(new ThreadStart(fn1));
            //Thread t2 = new Thread(new ThreadStart(fn2));

            //t1.Start();
            //t2.Start();
            //Console.WriteLine("Main Function");

            // AutoResetEvent
            //new Thread(Method1).Start();
            //Console.ReadLine();
            //Obj1.Set(); //for 1

            //Console.ReadLine();
            //Obj1.Set(); //for 2

            // ManualResetEvent
            //new Thread(Method1).Start();
            //Console.ReadLine();
            //Obj2.Set(); //for multiple threads
        }

        //static AutoResetEvent Obj1 = new AutoResetEvent(false); // AutoResetEvent
        //static ManualResetEvent Obj2 = new ManualResetEvent(false); // ManualResetEvent

        // AutoResetEvent & ManualResetEvent both used to implement the synchronization concept in threads using signaling mechanism.
        // AutoResetEvent : For every WaitOne() need to Set() to release the threads.
        // ManualResetEvent : once we Set() that goes and allows all the threads to execute.

        //static void Method1()
        //{
        //    Console.WriteLine("Started: 1");
        //    Obj2.WaitOne();
        //    Console.WriteLine("Finished: 1");

        //    Console.WriteLine("Started: 2");
        //    Obj2.WaitOne();
        //    Console.WriteLine("Finished: 2");
        //}

        //concurrecny
        //private static async void NewMethod2()
        //{
        //    await Task.Delay(5000);
        //    Console.WriteLine("Task 2 executing");
        //}

        //private static async void NewMethod1()
        //{
        //    await Task.Delay(5000);
        //    Console.WriteLine("Task 1 executing");
        //}

        //paralallism
        //private static void NewMethod2()
        //{
        //    Task.Delay(10000);
        //    Console.WriteLine("Task 2 executing");
        //}

        //private static void NewMethod1()
        //{
        //    Task.Delay(10000);
        //    Console.WriteLine("Task 1 executing");
        //}

        //Multithreading
        //static void fn1()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Function 1 :" + i);
        //    }
        //}

        ////Multithreading
        //static void fn2()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Function 2 :" + i);
        //    }
        //}


        //TPL: Task Parallel Library : It will take all the tasks and distribute which processor is less loaded. 
        //It helps us to maximum utilization of the processor. It encapsulates the multi core execution.

        //private static void RunMillionIterations()
        //{
        //    string str = "";

        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        str = str + "s";
        //    }
        //}
    }

        //Lock/Monitor/Mutex : only one thread can run at a time
        //Semaphore/Semaphore slim : we can specify how many people can run how many thread

        //Thread safe objects using LOCK in multithreading. only one thread can execute the block which is inside LOCK scope.
        //class Maths
        //{
        //    public int num1;
        //    public int num2;
        //    Random r = new Random();
        //    private static object o = new object();

        //    public void Divide()
        //    {
        //        for (long i = 0; i < 1000; i++)
        //        {
        //            //lock (o)
        //            Monitor.Enter(o); // Old way of locking the code block to make the thread safe
        //            try
        //            {
        //                num1 = r.Next(1, 2);
        //                num2 = r.Next(1, 2);
        //                int result = num1 / num2;
        //                Console.WriteLine("result :" +result);  
        //                num1 = 0;
        //                num2 = 0;
        //                //throw new Exception();
        //                Console.WriteLine("Execution exited");
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e);
        //            }
        //            finally
        //            {
        //                Monitor.Exit(o);
        //            }
        //        }
        //    }
        //}

    }

//namespace Maths
//{
//    class AO
//    {
//        public string title = "Hello World";
//        public void getTitle()
//        {
//            Console.WriteLine(title);
//        }
//        public int add(int val1, int val2)
//        {
//            val1 = 5;
//            val2 = 3;
//            return val1 + val2;
//        }
//        public int sub(int val1, int val2)
//        {
//            return val1 - val2;
//        }
//    }
//}

//namespace DebugRelease
//{
//    class DR
//    {
//        public static void Main(String[] args)
//        {
//            M1();
//        }

//        static void M1()
//        {
//#if DEBUG
//            string str = "Hello World";
//            Console.WriteLine(str);
//#endif
//            M2();
//        }

//        static void M2()
//        {
//            M3();
//        }

//        static void M3()
//        {
//            throw new Exception("Error Occured");
//        }
//    }
//}