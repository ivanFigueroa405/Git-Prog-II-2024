//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Facturacion.Domain;
using Facturacion.Servicios;
using Facturacion.Datos;




Client_Service client_Service = new Client_Service();

var oClient = new Client()
{
    Name = "Ivan",
    Surname = "Figueroa",
    Shet_up = "Publica",
    Height = "200"
};

if (client_Service.SaveClient(oClient))
    Console.WriteLine("SE CARGO EXITOSAMENTE EL CLIENTE...");
else
    Console.WriteLine("No se pudo cargar correctamente");

//List<Client> lClient = client_Service.GetALlClient();
//if (lClient.Count > 0)
//{
//    foreach (var client in lClient)
//    {
//        Console.WriteLine("EL CLIENTE ES:  " + client);
//    }

//}
//else if (lClient.Count == 0)
//{
//    Console.WriteLine("no hay Clientes cargados");

//}
////if (client_Service.DeletClient(1))
////    Console.WriteLine("borrado exitoso");


//ArticleService ArticleManager = new ArticleService();

//var oArticle = new Article()
//{
//    Name = "Tornillos",
//    Price_Unitary = 200
//};

//if (ArticleManager.SaveArticle(oArticle))
//{
//    Console.WriteLine("Guardado con exito...");
//}
//else
//{
//    Console.WriteLine("tuki");
//}
//List<Article> lArticles = ArticleManager.GetArticle();
//if (lArticles.Count == 0)
//{
//    Console.WriteLine("No hay Articulos cargados...");
//}
//else
//    foreach (var art in lArticles)
//    {
//        Console.WriteLine(art);
//    }

//PaymentMethods_Service service = new PaymentMethods_Service();
//List<Payment_Methods> lMethods = service.GetAllMethods();
//if (lMethods.Count == 0)
//{
//    Console.WriteLine("No hay Formas de pago cargdas...");
//}
//else
//    foreach (var fr in lMethods)
//    {
//        Console.WriteLine("LAS FORMAS DE PAGO SON:  " + fr);
//    }
//InvoiceService ServiInvoice = new InvoiceService();



//var method = new Payment_Methods
//{
//    Id_Methods = 1,
//    Name = "EFECTIVO"
//};
//var invoice = new Invoice()
//{

//    Payment = method,
//    Client = lClient[0]
//};
//var details = new Details_Invoice()
//{
//    Id_detail = 1,
//    Nbr_Inovice = invoice,
//    Article = lArticles[0],
//    Quantity = 20
//};
//invoice.Details.Add(details);
//if (ServiInvoice.Save(invoice))
//{
//    Console.WriteLine("se cargo");
//}
//List<Invoice> LFAC = ServiInvoice.GetAll();
//if (LFAC.Count == 0)
//{
//    Console.WriteLine("NO SE ENCONTRARON FACTURAS");
//}
//else
//    foreach (var lvar in LFAC)
//    {
//        Console.WriteLine("Las facturas son:" + lvar);
//    }

//List<Details_Invoice> Di = ServiInvoice.Get();
//if (Di.Count == 0)
//{

//}
//else
//    foreach (var li in Di)
//    {
//        Console.WriteLine("los detalles: " + li);
//    }
