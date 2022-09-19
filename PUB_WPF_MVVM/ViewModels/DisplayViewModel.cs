using PUB_WPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUB_WPF_MVVM.ViewModels
{
    public class DisplayViewModel:BaseViewModel
    {
        public List<string> DisplayList { get; set; }
    }
}
