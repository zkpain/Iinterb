using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;

namespace Transferencias_interbancarias
{


    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            int randomico = 0;
            string[] datos = File.ReadAllLines(@"D:\csv grabaciones\interbanc.csv");
            //int c = 0;

            foreach (var d in datos)
            {
                var valores = d.Split(',');

                string usuario = valores[0];
                string captcha = valores[1];
                string password = valores[2];
                string nomEquipo = valores[3];
                string respuesta1 = valores[4];
                string respuesta2 = valores[5];
                string respuesta3 = valores[6];
                string listaCliente = valores[7];
                string cajaAhorro = valores[8];
                string bancoAch = valores[9];
                string grupoAbono = valores[10];
                string selecAbono = valores[11];
                string monto = valores[12];
                string facturaNit = valores[13];
                string facturaNombre = valores[14];
                
                                
                Console.Write("-----------------prueba start---------------");
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://10.16.22.88/BNBNet/es/IniciarSesion/IniciarIdentificador");
                driver.FindElement(By.Id("IdentificadorEncriptado")).Click();
                driver.FindElement(By.Id("IdentificadorEncriptado")).Clear();
                driver.FindElement(By.Id("IdentificadorEncriptado")).SendKeys(usuario);
                driver.FindElement(By.Id("RespuestaCapchaEncriptado")).Click();
                driver.FindElement(By.Id("RespuestaCapchaEncriptado")).Clear();
                driver.FindElement(By.Id("RespuestaCapchaEncriptado")).SendKeys(captcha);
                driver.FindElement(By.Id("submitEnviar")).Click();
                driver.FindElement(By.Id("Clave")).Clear();
                driver.FindElement(By.Id("Clave")).SendKeys(password);
                driver.FindElement(By.Id("submitEnviar")).Click();

                Random rand = new Random();
                randomico = rand.Next(10000000);

                Console.WriteLine(randomico);

                driver.FindElement(By.Id("NombreEquipo")).SendKeys(nomEquipo+randomico);

                if (IsElementPresent(By.Id("FactoresAutenticacion.FactoresTransaccion.DesafioPregunta.Respuesta1"), driver))
                {
                    driver.FindElement(By.Id("FactoresAutenticacion.FactoresTransaccion.DesafioPregunta.Respuesta1")).SendKeys(respuesta1);
                }
                if (IsElementPresent(By.Id("FactoresAutenticacion.FactoresTransaccion.DesafioPregunta.Respuesta2"), driver))
                {
                    driver.FindElement(By.Id("FactoresAutenticacion.FactoresTransaccion.DesafioPregunta.Respuesta2")).SendKeys(respuesta2);
                }
                if (IsElementPresent(By.Id("FactoresAutenticacion.FactoresTransaccion.DesafioPregunta.Respuesta3"), driver))
                {
                    driver.FindElement(By.Id("FactoresAutenticacion.FactoresTransaccion.DesafioPregunta.Respuesta3")).SendKeys(respuesta3);
                }

                driver.FindElement(By.Id("submitEnviar")).Click();

                driver.FindElement(By.Id(listaCliente)).Click();
                driver.FindElement(By.Id("submitEnviar")).Click();
                driver.FindElement(By.LinkText("Operaciones")).Click();
                driver.FindElement(By.LinkText("Transferencias")).Click();
                driver.FindElement(By.XPath("//button[@onclick=\"location.href='/BNBNet/es/cuentas/RegistrarTransferenciasInterbancarias'\"]")).Click();
                driver.FindElement(By.Id("ProductoOrigenSeleccionado")).Click();
                new SelectElement(driver.FindElement(By.Id("ProductoOrigenSeleccionado"))).SelectByText("Caja De Ahorro Bs. 1000090553 | Saldo Bs. 99999678,06");
                driver.FindElement(By.Id("ProductoOrigenSeleccionado")).Click();
                driver.FindElement(By.Id("BancoACHSeleccionado")).Click();

                new SelectElement(driver.FindElement(By.Id("BancoACHSeleccionado"))).SelectByText("Banco De Credito");
               // new SelectElement(driver.FindElement(By.Id("//BancoACHSeleccionado"))).SelectByText("Banco De Credito");

                driver.FindElement(By.Id("BancoACHSeleccionado")).Click();
                driver.FindElement(By.Id("GrupoAbonoSeleccionado")).Click();
                new SelectElement(driver.FindElement(By.Id("GrupoAbonoSeleccionado"))).SelectByText("Bnb");
                driver.FindElement(By.Id("GrupoAbonoSeleccionado")).Click();
                driver.FindElement(By.Id("AbonadoSeleccionado")).Click();
                new SelectElement(driver.FindElement(By.Id("AbonadoSeleccionado"))).SelectByText("Diego Auza - Caja De Ahorro (2150808885)");
                driver.FindElement(By.Id("AbonadoSeleccionado")).Click();
                driver.FindElement(By.Id("EnviarNotificacion")).Click();
                driver.FindElement(By.Id("Monto")).Click();
                driver.FindElement(By.Id("Monto")).Clear();
                driver.FindElement(By.Id("Monto")).SendKeys(monto);
                driver.FindElement(By.Id("FacturaNit")).Click();
                driver.FindElement(By.Id("FacturaNit")).Clear();
                driver.FindElement(By.Id("FacturaNit")).SendKeys(facturaNit);
                driver.FindElement(By.Id("FacturaNombre")).Click();
                driver.FindElement(By.Id("FacturaNombre")).Click();
                driver.FindElement(By.Id("FacturaNombre")).Clear();
                driver.FindElement(By.Id("FacturaNombre")).SendKeys(facturaNombre);
                driver.FindElement(By.XPath("//section")).Click();
                driver.FindElement(By.Id("submitTransferir")).Click();
                //driver.FindElement(By.Id("btnAceptar")).Click();
                driver.FindElement(By.Id("Cerrar")).Click();
            }

        }

        private bool IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
            
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
