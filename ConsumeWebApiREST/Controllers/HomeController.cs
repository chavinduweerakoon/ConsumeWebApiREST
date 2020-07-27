using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumeWebApiREST.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

using System.Threading.Tasks;

namespace ConsumeWebApiREST.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "https://5f1d237d39d95a0016953bb2.mockapi.io/WebApi/Model/";
        public async Task<ActionResult> Index()
        {
            List<Post> PostInfo = new List<Post>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource getposts using HttpClient  
                HttpResponseMessage RequestMain = await client.GetAsync("/Post");

                //Checking the response is successful or not which is sent using HttpClient  
                if (RequestMain.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var PostResponse = RequestMain.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Post list  
                    PostInfo = JsonConvert.DeserializeObject<List<Post>>(PostResponse);

                }
                //returning the post list to view  
                return View(PostInfo);
            }
        }
    }
}