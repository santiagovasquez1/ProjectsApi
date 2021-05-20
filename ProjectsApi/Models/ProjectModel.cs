using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsApi.Models
{
    public class ProjectModel
    {
        private string fId;

        public string Id
        {
            get { return fId; }
            set { fId = value; }
        }

        private string fprojectName;

        public string ProjectName
        {
            get { return fprojectName; }
            set { fprojectName = value; }
        }

        private int fyear;

        public int Year
        {
            get { return fyear; }
            set { fyear = value; }
        }
        private string fimage;

        public string Image
        {
            get { return fimage; }
            set { fimage = value; }
        }

        private List<string> flanguajes;

        public List<string> Languajes
        {
            get { return flanguajes; }
            set { flanguajes = value; }
        }

        public ProjectModel()
        {
            this.Id = new Guid().ToString();
        }

    }
}
