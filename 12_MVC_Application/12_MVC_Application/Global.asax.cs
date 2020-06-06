using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

namespace _12_MVC_Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Application => Anahtar - deger ikilisi mantigiyla calisan bir koleksiyon olarak karsimiza cikmaktadir. Bu koleksiyon icerisinde uygulamaniza ozgu anahtarlari ve o anahtarlarin tasimis oldugu degerleri muhafaza edebilirsiniz...
            Application.Add("onlineUser", 0);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Eger Session_Start eventi tetiklenmis ise, kullanici siteye bir istekte bulunmus demektir. Bu istek durumunda, online kullanici sayisini bir arttirmaliyiz...

            Application.Lock();
            Application["onlineUser"] = ((int)Application["onlineUser"]) + 1;
            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Eger Session_End eventi tetiklenmis ise, bir kullanicin oturumunun sunucu tarafta sonlandigi anlamina gelir. Dogal olarak o kullaniciya ait veriler silinecegi icin, kullanici sayisini bir azaltabiliriz...

            Application.Lock();
            Application["onlineUser"] = ((int)Application["onlineUser"]) - 1;
            Application.UnLock();
        }

        //uygulamadaki herhangi bir dosyaya talep(request) geldiğinde tetiklenir. 
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        //FormsAuthentication kullanıldığında kullanıcının sisteme başarılı bir şekilde giriş yapması durumunda tetiklenecek olaydır. 
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        //Uygulamanın her hangi bir noktasında bir hata meydana geldiği zaman, hatanın işlenmesi için tetiklenen event'tır...
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception hata = Server.GetLastError();

            string hataMesaji = hata.InnerException != null ? hata.InnerException.Message : hata.Message;

            DateTime hataZamani = DateTime.Now;

            //NOT : Server değişkenlerini https://www.w3schools.com/asp/coll_servervariables.asp adresinden temin edebilirsiniz.  
            string kullaniciIP = Request.ServerVariables["REMOTE_ADDR"];

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/ErrorLog.xml"));

            XmlElement eleman = doc.CreateElement("Hata");

            XmlNode node_mesaj = doc.CreateNode(XmlNodeType.Element, "HataMesaji", null);
            node_mesaj.InnerText = hataMesaji;

            XmlNode node_tarih = doc.CreateNode(XmlNodeType.Element, "HataTarihi", null);
            node_tarih.InnerText = hataZamani.ToString();

            XmlNode node_IP = doc.CreateNode(XmlNodeType.Element, "MakineIP", null);
            node_IP.InnerText = kullaniciIP;

            eleman.AppendChild(node_mesaj);
            eleman.AppendChild(node_tarih);
            eleman.AppendChild(node_IP);

            doc.DocumentElement.AppendChild(eleman);

            doc.Save(Server.MapPath("~/App_Data/ErrorLog.xml"));


        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
