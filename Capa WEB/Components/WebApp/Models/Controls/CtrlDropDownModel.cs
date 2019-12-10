using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities_POJO;
using Newtonsoft.Json;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownModel : CtrlBaseModel
    {

        public string Label { get; set; }
        public string ListId { get; set; }

        private string URL_API_LISTs = "http://localhost:44341/api/List/";

        public string ListOptions
        {
            get
            {
                var htmlOptions = "";
                var lst = GetOptionsFromAPI();

                foreach (var option in lst)
                {
                    htmlOptions += "<option value='" + option.Value + "'>" + option.Description + "</option>";
                }
                return htmlOptions;
            }
            set
            {

            }
        }


        private List<OptionList> GetOptionsFromAPI()
        {
            var client = new System.Net.WebClient();
            var response = client.DownloadString(URL_API_LISTs + ListId);
            var options = JsonConvert.DeserializeObject<List<OptionList>>(response);
            return options;
        }



        public CtrlDropDownModel()
        {
            ViewName = "";
        }
    }

}