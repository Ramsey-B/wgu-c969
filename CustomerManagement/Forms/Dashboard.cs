using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagement.Forms
{
    public partial class Dashboard : Form
    {
        private readonly UserContext _userContext;

        public Dashboard(UserContext userContext)
        {
            InitializeComponent();

            _userContext = userContext;
            var test = _userContext.CurrentUser;
        }
    }
}
