using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpForTB
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookies = GetCookies("","","");
            Console.WriteLine(cookies);
            Console.ReadKey();
        }
        /// <summary>
        /// 获取cookies
        /// login_username和login_password根据页面定义的名称而定
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static string GetCookies(string url,string username,string password)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(url);
            client.Authenticator = new SimpleAuthenticator("login_username", username, "login_password", password);
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            var ck = response.Cookies.SingleOrDefault(n => n.Name.Equals("JSESSIONID"));
            return ck.Value;
        }
    }
}
