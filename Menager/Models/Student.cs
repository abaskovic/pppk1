using Menager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Menager.Models
{
    public class Student:User
    {
        public int IdStudent { get; set; }

        public byte[]? Picture { get; set; }

        public BitmapImage Image
        {

            get => ImageUtils.ByteArrayToBitmapIMage(Picture);

        }
    }
}
