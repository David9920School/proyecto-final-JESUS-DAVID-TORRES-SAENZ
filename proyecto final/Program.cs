using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace proyecto_final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string numTarjeta = "", pin = "", numc = "";
            int  op = 0;
            double saldo = 35000, retir = 0, mon = 0, a, depos = 0;

            IClienteYBanco cliente1 = new Cajero();
            cliente1.nombreBanco();
            cliente1.Ubicacon();
            cliente1.nombreCliente();
            Console.WriteLine("**************************");
            Console.WriteLine("      Preciona ENTER....  ");
            Console.ReadLine();


            while (numTarjeta != "4152000021213344" || pin != "1234")

            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("***             CAJERO BBVA               ***");
                Console.WriteLine("---------------------------------------------");


                Console.Write("\nIngrese su número de tarjeta   : ");
                numTarjeta = Console.ReadLine();
                Console.Write("Ingrese el pin de su tarjeta : ");
                pin = Console.ReadLine();
                try
                {
                    if (numTarjeta.Equals("4152000021213344") && pin.Equals("1234"))
                    {
                        Console.WriteLine("BIENVENIDO");
                    }
                    else
                    {
                        throw new ErrorException("Numero de tarjeta o pin invalido");
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Mensaje excepcion: {0}", Ex.Message);
                    Console.WriteLine("\nVuelva a intentar.");
                    Console.WriteLine("retire su tarjeta.");
                    Console.WriteLine("---------------------------------");
                    return;
                }
                
                
                do
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("***             CAJERO BBVA               ***");
                        Console.WriteLine("---------------------------------------------");

                        Console.WriteLine("\nSeleccione la operación que desea realizar : ");

                        Console.WriteLine("1.- Transeferencia de saldo.");
                        Console.WriteLine("2.- Retirar saldo. ");
                        Console.WriteLine("3.- Consulta de saldo.");
                        Console.WriteLine("4.- Depósito de efectivo.");
                        Console.WriteLine("5.- Salir.");
                        Console.WriteLine("----------------------------------------------- - ");

                        Console.Write("Ingrese su opción : ");
                        op = int.Parse(Console.ReadLine());
                        try
                        {
                            if (op < 1 || op > 5)
                            {
                                throw new ErrorException("Ingresaste una opcion erronea");
                            }
                        }
                        catch(Exception Ex)
                        {
                            Console.WriteLine("Mensaje excepcion: {0}", Ex.Message);
                            goto fin;
                        }
                        
                    } 
                    while (op < 1 || op > 5);

                    switch (op)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("***             CAJERO BBVA               ***");
                            Console.WriteLine("---------------------------------------------");

                            Console.WriteLine("TRANSFERENCIA DE SALDO A TERCEROS.");
                            Console.Write("\nIngrese el número de cuenta : ");
                            numc = Console.ReadLine();
                            Console.Write("Ingrese el mónto a transeferir : ");
                            mon = int.Parse(Console.ReadLine());
                            a = (saldo - mon);
                            try
                            {
                                if (a > 0)
                                {
                                    Console.WriteLine("Se transfirió con éxito el mónto de S/.{0}", mon);
                                    saldo = (saldo - mon);
                                    StreamWriter Recibo;
                                    string nombreFichero = "C:\\Users\\El Prieto\\Desktop\\TAREAS DAVID TECNM\\Segundo semestre\\Trimestre 1\\POO\\ficheros\\ReciboTransferenciaBanco.txt";
                                    Recibo = File.AppendText(nombreFichero);
                                    Recibo.WriteLine("****************************************************");
                                    Recibo.WriteLine("-----                   VVBA                   -----");
                                    Recibo.WriteLine("****************************************************");
                                    Recibo.WriteLine("Se transfirió con éxito el monto:" + mon);
                                    Recibo.WriteLine("----------------------------------------------------");
                                    Recibo.WriteLine("A la cuenta: " + numc);
                                    Recibo.WriteLine("----------------------------------------------------");
                                    Recibo.WriteLine("Gracias por su visita");
                                    Recibo.Close();
                                }
                                else
                                {
                                    Console.WriteLine("------------------------------------------------------");
                                    throw new ErrorException("** ADVERTENCIA : La operación no se puede realizar porque el mónto ingresado excede su saldo actual. * *");
                                }
                            }
                            catch(Exception Ex)
                            {
                                Console.WriteLine("Mensaje excepcion: {0}", Ex.Message);  
                            }
                            Console.WriteLine("\n\n** Su saldo actual es S/ {0} **", saldo);
                            Console.WriteLine("\nPresione 1 para realizar otra operación.");
                            Console.WriteLine("Presione 2 para retirar su tarjeta.");
                            Console.WriteLine("-------------------------------------------------------");
                            Console.Write("Ingrese su opción : ");
                            op = int.Parse(Console.ReadLine());
                            if (op == 1)
                            {
                                break;
                            }
                            if (op == 2)
                            {
                                goto fin;
                            }
                            break;

                           
                        case 2:
                            Console.Clear();
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("***             CAJERO BBVA               ***");
                            Console.WriteLine("---------------------------------------------");

                            Console.WriteLine("\nSu saldo actual es : S/{0}", saldo);
                            Console.WriteLine("\n** No deberá superar los S/ 10000 por operación.");

                            Console.Write("\nIngrese la cantidad a retirar : ");
                            retir = int.Parse(Console.ReadLine());
                            try
                            {
                                if (retir > 0 && retir <= 10000)
                                {
                                    Console.WriteLine("Su retiro se realizo con exito de S/ {0}.", retir);
                                    saldo = (saldo - retir);
                                    StreamWriter Recibo;
                                    string nombreFichero = "C:\\Users\\El Prieto\\Desktop\\TAREAS DAVID TECNM\\Segundo semestre\\Trimestre 1\\POO\\ficheros\\ReciboRetiroBanco.txt";
                                    Recibo = File.AppendText(nombreFichero);
                                    Recibo.WriteLine("****************************************************");
                                    Recibo.WriteLine("-----                   VVBA                   -----");
                                    Recibo.WriteLine("****************************************************");
                                    Recibo.WriteLine("Se retiro con éxito el monto de:" + retir);
                                    Recibo.WriteLine("----------------------------------------------------");
                                    Recibo.WriteLine("De su cuenta : " + numTarjeta);
                                    Recibo.WriteLine("----------------------------------------------------");
                                    Recibo.WriteLine("Gracias por su visita");
                                    Recibo.Close();
                                }
                                else
                                {
                                    Console.WriteLine("-----------------------------------------");
                                    throw new ErrorException("** ADVERTENCIA : La operación no se pueder realizar porque el mónto ingresado excede el máximo permitido por operación. * *");
                                }
                            }
                            catch (Exception Ex)
                            {
                                Console.WriteLine("Mensaje excepcion: {0}", Ex.Message);
                            }
                            Console.WriteLine("\n\n** Su saldo actual es S/ {0} **", saldo);
                            Console.WriteLine("\nPresione 1 para realizar otra operación.");
                            Console.WriteLine("Presione 2 para retirar su tarjeta.");
                            Console.WriteLine("---------------------------------");
                            Console.Write("Ingrese su opción : ");
                            op = int.Parse(Console.ReadLine());
                            if (op == 1)
                            {
                                break;
                            }
                            if (op == 2)
                            {
                                goto fin;
                            }
                            break;

                        case 3:

                            Console.Clear();
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("***             CAJERO BBVA               ***");
                            Console.WriteLine("---------------------------------------------");

                            Console.WriteLine("CONSULTA DE SALDOS.");
                            Console.WriteLine("\nSu saldo actual es : S/{0}", saldo);
                            Console.WriteLine("-----------------------------------------------------------------");
                   

                            Console.WriteLine("\nPresione 1 para realizar otra operación.");
                            Console.WriteLine("Presione 2 para retirar su tarjeta.");
                            Console.WriteLine("---------------------------------------------------");
                            Console.Write("Ingrese su opción : ");
                            op = int.Parse(Console.ReadLine());
                            if (op == 1)
                            {
                                break;
                            }
                            if (op == 2)
                            {
                                goto fin;
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("***             CAJERO BBVA               ***");
                            Console.WriteLine("---------------------------------------------");

                            Console.WriteLine("DEPOSITO DE EFECTIVO.");
                            Console.WriteLine("\n** No deberá superar los S/ 10000 por operación.");

                            Console.Write("\nIngrese la cantidad a depositar : ");
                            depos = int.Parse(Console.ReadLine());
                            try
                            {
                                if (depos > 0 && depos <= 10000)
                                {
                                    Console.WriteLine("Se realizó con éxito el depósito de S/ {0} a su cuenta.", depos);
                                    saldo = (saldo + depos);
                                    StreamWriter Recibo;
                                    string nombreFichero = "C:\\Users\\El Prieto\\Desktop\\TAREAS DAVID TECNM\\Segundo semestre\\Trimestre 1\\POO\\ficheros\\ReciboDepositoBanco.txt";
                                    Recibo = File.AppendText(nombreFichero);
                                    Recibo.WriteLine("****************************************************");
                                    Recibo.WriteLine("-----                   VVBA                   -----");
                                    Recibo.WriteLine("****************************************************");
                                    Recibo.WriteLine("Se deposito con éxito el monto de:" + depos);
                                    Recibo.WriteLine("----------------------------------------------------");
                                    Recibo.WriteLine("A su cuenta:" + numTarjeta);
                                    Recibo.WriteLine("----------------------------------------------------");
                                    Recibo.WriteLine("Su nuevo saldo es de:" + saldo);
                                    Recibo.WriteLine("----------------------------------------------------");
                                    Recibo.WriteLine("Gracias por su visita");
                                    Recibo.Close();
                                }
                                else
                                {
                                    Console.WriteLine("-------------------------------------------------");
                                    throw new ErrorException("** ADVERTENCIA : La operación no se pueder realizar porque el mónto ingresado excede el máximo permitido por operación. * *");
                                }
                            }
                            catch (Exception Ex)
                            {
                                Console.WriteLine("Mensaje excepcion: {0}", Ex.Message);
                            }
                            Console.WriteLine("\n\n** Su saldo actual es S/ {0} **", saldo);
                            Console.WriteLine("\nPresione 1 para realizar otra operación.");
                            Console.WriteLine("Presione 2 para retirar su tarjeta.");
                            Console.WriteLine("-----------------------------------------------------");
                            Console.Write("Ingrese su opción : ");
                            op = int.Parse(Console.ReadLine());
                            if (op == 1)
                            {
                                break;
                            }
                            if (op == 2)
                            {
                                goto fin;
                            }
                            break;
                        case 5:
                            goto final;
                    }
                } while (op != 4);
            fin:
            
            final:
                Console.WriteLine("\n******************************************");
                Console.WriteLine("Puede retirar su tarjeta.");
                Console.Write("Gracias por su visita. Hasta pronto.....");
                Console.ReadLine();


            }
        }

    }
}
    

