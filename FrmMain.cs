using AutoMapper;
using PalcoNet.Business.Implementations;
using PalcoNet.Business.Interfaces;
using PalcoNet.Forms;
using PalcoNet.Infraestructure.Logging;
using PalcoNet.Login;
using PalcoNet.Repositories;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class frmMain : Form, IForm
    {
        private string userLogged = null;
        private IForm _childForm = null;
        private readonly IUnitOfWork _uow = null;
        private readonly IMapper _mapper = null;
        private readonly ILogger _logger = null;
        private readonly IFormFactory _formsFactory = null;
        private readonly IUsuarioBusiness _usuarioBusines = null;

        public frmMain(IUnitOfWork uow, IMapper mapper, ILoggerFactory loggerFactory, IFormFactory formsFactory,
                       IUsuarioBusiness usuarioBusiness)
        {
            InitializeComponent();
            _uow = uow;
            _mapper = mapper;
            _logger = loggerFactory.Get<frmMain>();
            _formsFactory = formsFactory;
            _usuarioBusines = usuarioBusiness;
        }

        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);
            if (userLogged == null)
            {
                _childForm = _formsFactory.GetForm<frmLogin>();
                if (_childForm.ShowDialog() != DialogResult.OK)
                    Close();
            }
        }
    }
}
