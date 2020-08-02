using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace DHRM.BusinessEntity
{
    public class Project
    {
        public int project_Id { get; set; }

        public string project_code { get; set; }

        public int client_id { get; set; }

        public int category_id { get; set; }

        public string project_name { get; set; }

        public string project_description { get; set; }

        public byte[] project_banner { get; set; }

        public DateTime project_start_date { get; set; }

        public DateTime project_end_date { get; set; }

        public string project_remarks { get; set; }

        public DateTime Trans_Date { get; set; }

        public int User_Id { get; set; }

        public string ImagePath { get; set; }

    }
}
