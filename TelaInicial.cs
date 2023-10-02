using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestGoogle.Fixtures;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

namespace TestGoogle
{
    [Collection("Chrome Driver")]
    public class TelaInicial
    {
        private IWebDriver driver;
        public TelaInicial(TestFixtures fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void Search()
        {
            //Navegando para a URL "https://google.com.br"
            driver.Navigate().GoToUrl("https://google.com.br");
            //Certificando que o titulo do navegador contenha "Google"
            Assert.Contains("Google", driver.Title);
            // Criando variavel que aguarda 10 segundos antes de dar TimeOut
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Identificando a barra de pesquisar e preenchendo com o valor "Teste Pesquisar"
            driver.FindElement(By.XPath("//textarea[@id='APjFqb']")).SendKeys("TestSearch");
            //Clicando fora da barra de pesquisa
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")).Click();
            // Certificando que a pesquisa foi feita com sucesso
            Assert.Contains("TestSearch - Pesquisa Google", driver.Title);
            // Voltando para a tela anterior
            driver.Navigate().Back();

        }

        [Fact]
        public void RedirectLinks()
        {
            // Criando variavel que aguarda 10 segundos antes de dar TimeOut
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Navegando para a URL "https://google.com.br"
            driver.Navigate().GoToUrl("https://google.com.br");
            //Certificando que o titulo do navegador contenha "Google"
            Assert.Contains("Google", driver.Title);

            //Aguardando 0.8 segundos
            System.Threading.Thread.Sleep(0800);

            //Identificando o primeiro link redirecionador que leva para o Gmail
            driver.FindElement(By.XPath("//a[contains(text(), 'Gmail')]")).Click();
            // Certificando que o titulo do navegador contenha "Gmail"
            Assert.Contains("Gmail", driver.Title);
            // Voltando para a tela anterior
            driver.Navigate().Back();

            //Aguardando 0.8 segundos
            System.Threading.Thread.Sleep(0800);

            //Identificando o segundo link redirecionador que leva para o Google Imagens
            driver.FindElement(By.XPath("//a[contains(text(), 'Imagens')]")).Click();
            // Certificando que o titulo do navegador contenha "Imagens do Google"
            Assert.Contains("Imagens do Google", driver.Title);
            // Aguardando o <span> que tem o texto "Imagens" ficar visivel
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Imagens')]")));
            // Voltando para a tela anterior
            driver.Navigate().Back();

        }

        [Fact]
        public void GoogleApps()
        {

            //Navegando para a URL "https://google.com.br"
            driver.Navigate().GoToUrl("https://google.com.br");
            //Certificando que o titulo do navegador contenha "Google"
            Assert.Contains("Google", driver.Title);
            // Criando variavel que aguarda 10 segundos antes de dar TimeOut
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Aguardando 1 segundo
            System.Threading.Thread.Sleep(1000);

            //Identificando o botão para acessar a ferramenta de inserção de texto e clicando nela
            driver.FindElement(By.XPath("//*[@id='gbwa']/div/a")).Click();
            // Certificando que a ferramenta foi aberta
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("app")));

            

        }

    }
}