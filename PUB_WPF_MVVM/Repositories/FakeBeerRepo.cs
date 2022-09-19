using PUB_WPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PUB_WPF_MVVM.Repositories
{
    public class FakeBeerRepo
    {
        public ObservableCollection<Beer> GetAll()
        {
            return new ObservableCollection<Beer>()
            {
                new Beer
                {
                    Name="Starapraga",
                     Price=3.5,
                      Volume=0.5,
                       ImagePath="/Images/starapraga.jpg"
                },

                new Beer
                {
                    Name="Efes",
                     Price=5.5,
                      Volume=0.4,
                       ImagePath="/Images/efes.jpg"
                },

                 new Beer
                {
                    Name="Edelweiss",
                     Price=6.5,
                      Volume=0.5,
                       ImagePath="/Images/edelweis.jpg"
                },
                  new Beer
                {
                    Name="Heineken",
                     Price=7.5,
                      Volume=0.5,
                       ImagePath="/Images/heineken.jpg"
                }

            };
         
        }
    }
}
