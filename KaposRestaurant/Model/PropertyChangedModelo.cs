using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaposRestaurant.Model
{
    public partial class CATEGORIA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public partial class ELEMENTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public partial class FACTURA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public partial class COMANDA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
