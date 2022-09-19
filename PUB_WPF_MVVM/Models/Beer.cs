using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PUB_WPF_MVVM.Models
{
    public class Beer:Entity
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public double Price { get; set; }

        public string ImagePath { get; set; }

        public Beer()
        {
            Guid = new Guid();
        }
    }
}
