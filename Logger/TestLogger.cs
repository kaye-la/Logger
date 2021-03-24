using System;

namespace Logger
{
    public class TestLogger
    {
        public static void testDebug()
        {
            Logger logger = new Logger();
            int x = 100;

            Console.WriteLine("Введите делитель:");
            int y = Convert.ToInt32(Console.ReadLine());
            
            logger.Debug("debug log with msg");
            try
            {
                Console.WriteLine(x/y);
            }
            catch (DivideByZeroException e)
            {
                logger.Debug("debug log with msg & exception", e);
            }
        }

        public static void testError()
        {
            Logger logger = new Logger();
            int x = 100;

            Console.WriteLine("Введите делитель:");
            int y = Convert.ToInt32(Console.ReadLine());

            logger.Error("error log with msg");
            try
            {
                Console.WriteLine(x / y);
            }
            catch (DivideByZeroException e)
            {
                logger.Error("error log with msg & exception", e);
            }
        }

        public static void testErrorUnique()
        {
            Logger logger = new Logger();

            logger.ErrorUnique("unique error log with msg", new Exception("check"));
            logger.ErrorUnique("unique error log with msg & exception", new DivideByZeroException());
            logger.ErrorUnique("unique error log with msg & exception", new DivideByZeroException());
        }

        public static void testFatal()
        {
            Logger logger = new Logger();
            int x = 100;

            Console.WriteLine("Введите делитель:");
            int y = Convert.ToInt32(Console.ReadLine());

            logger.Fatal("fatal log with msg");
            try
            {
                Console.WriteLine(x / y);
            }
            catch (DivideByZeroException e)
            {
                logger.Fatal("fatal log with msg & exception", e);
            }
        }

        public static void testInfo()
        {
            Logger logger = new Logger();
            int x = 100;

            Console.WriteLine("Введите делитель:");
            int y = Convert.ToInt32(Console.ReadLine());

            logger.Info("info log with msg");
            try
            {
                Console.WriteLine(x / y);
            }
            catch (DivideByZeroException e)
            {
                logger.Info("info log with msg & exception", e);
            }
            logger.Info("info log with msg & params: {0} {1}", 1, 2);
        }

        public static void testWarning()
        {
            Logger logger = new Logger();
            int x = 100;

            Console.WriteLine("Введите делитель:");
            int y = Convert.ToInt32(Console.ReadLine());

            logger.Warning("warning log with msg");
            try
            {
                Console.WriteLine(x / y);
            }
            catch (DivideByZeroException e)
            {
                logger.Warning("warning log with msg & exception", e);
            }
        }

        public static void testWarningUnique()
        {
            Logger logger = new Logger();
            logger.WarningUnique("warning log with msg");
            logger.WarningUnique("warning log with msg");
        }
    }
}
