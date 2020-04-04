using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClienteWcfService
{   
    //>>CONFIGURAÇÃO DO SERVIÇO NA APLICAÇÃO QUE VAI RECEBER OS DADOS

    //1 - Apos já ter configuarado todo seu serviço que vai oferecer os dados pela internet
    //agora você precisa configurar a aplicação que vai consumir este serviço
    
    //2 - Vá até a aplicação que vai consumir o serviço, e clique com o direito em Refences
    //2.2 - Ao clicar em Add Service Refences será aberta uma tela com o campo Address para
    //que você coloque o endereço do serviço, apos colocar o endereço clique em GO
    //2.3 Na tela a esquerda você podera ver os metodos disponibilizados pelo serviço
    //2.4 Adicione o Serviço o serviço cliando em OK

    //3 - Abaixo você visualiza a estancia do serviço na aplicação MVC que foi configurado
    //3.3 - o Serviço teve o nome dado como ServiceRefence e na a aplicação foi 
    //atribuido um nome padrão como "Service"(mas pode ser alterado) e concatenado com "Client" formando 
    //Service1Client identificando que é o cliente service.
    
    //4 - Logo a baixo da estancia é possivel ver as chamadas dos metodos do serviço conforme
    //foi configurado dentro do WCF com as interfaces e classes. 

    //5 - Apos ter feito as devidas configurações basta executar seu MVC que está fazendo 
    //refencia a este serviço.

    //ServiceReference1.Service1Client wcf = new ServiceReference1.Service1Client();

    //var retornarTodosOsclientes = wcf.All();
    //var pegarDadosDoCliente = wcf.GetData(1);
    //var salvarDadosERetornarSeDeuCerto = wcf.Saved("Pedro", "44570695825");


    public class Service1 : IService1
    {
        public Clientes GetData(int value)
        {
            //Você estancia a classe Cliente
            Clientes cliente = new Clientes() { ID = 3, Nome = "Pedro", CPF = "44570695825" };

            return cliente;
        }

        public List<Clientes> All() 
        {
            List<Clientes> clienteList = new List<Clientes>();
            //var cliente = new Clientes() { ID = 3, Nome = "Pedro", CPF = "44570695825" };
            //clienteList.Add(cliente);
            clienteList.Add(new Clientes() { ID = 1, Nome = "Pedro", CPF = "44570695825" });
            clienteList.Add(new Clientes() { ID = 2, Nome = "Pedro", CPF = "44570695825" });
            clienteList.Add(new Clientes() { ID = 3, Nome = "Pedro", CPF = "44570695825" });
            return clienteList;
        }


        public bool Saved(String Nome, String CPF)
        {         
            try
            {
             bool saved = new Clientes () { Nome = Nome, CPF = CPF }.Saved();
                //Você poderia executar um Clientes.Save caso estivesse conectado ao banco
                return saved;
            }
            catch
            {
                return false;
            }         
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
