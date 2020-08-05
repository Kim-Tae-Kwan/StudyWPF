using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdCaliburnApp.ViewModels
{
    public class DialogViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get ; set ; }

        public DialogViewModel()
        {

        }
    }
}
