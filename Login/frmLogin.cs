using AutoMapper;
using PalcoNet.Business.Implementations;
using PalcoNet.Business.Interfaces;
using PalcoNet.Dtos;
using PalcoNet.Forms;
using PalcoNet.Infraestructure.Logging;
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

namespace PalcoNet.Login
{
    public partial class frmLogin : Form, IForm
    {
        private readonly ILogger _logger = null;
        private readonly IUsuarioBusiness _usuarioBusiness = null;
        public UsuarioDto UsuarioLoggin { set; get; }

        public frmLogin(IUsuarioBusiness usuarioBusiness, ILoggerFactory loggerFactory)
        {
            InitializeComponent();
            CenterToParent();
            ControlBox = false;
            AutoSize = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            _logger = loggerFactory.Get<frmLogin>();
            _usuarioBusiness = usuarioBusiness;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario, "Debe ingresar un usuario");
                isOk = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Debe ingresar una password");
                isOk = false;
            }

            if (isOk)
            {
                var response = _usuarioBusiness.GetByUserNamePassword(txtUsuario.Text, txtPassword.Text);
                if (response == null || response.Result.HasErrors)
                    MessageBox.Show(response.Result.GetMesseges());
                else
                {
                    //if (usuario.Roles.Where(q => q.Estado == true).Count() > 1)
                    //{
                    //    var frmRol = new frmRoles(usuario.Roles);
                    //    var result = frmRol.ShowDialog();
                    //    if (result == DialogResult.OK)
                    //        _rolSelected = frmRol.GetRolSelected();
                    //}
                    //else
                    //    _rolSelected = _usuarioLogged.Roles.FirstOrDefault();

                    //if (_rolSelected == null)
                    //    MessageBox.Show("El usuario no tiene roles asignados");
                    //else
                    {
                        DialogResult = DialogResult.OK;
                        UsuarioLoggin = response.Data;
                        Dispose();
                        Close();
                    }
                }
            }
        }
    }
}
