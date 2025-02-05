namespace CafePulse.QA
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestGetAllGenero()
        {
           CafePulse.ModelClass.Result response = CafePulse.BusinessClass.Genero.GetAll();
            Assert.IsTrue(response.Success);

        }

        [TestMethod]
        public void TestGetAllRol()
        {
            CafePulse.ModelClass.Result response = CafePulse.BusinessClass.Rol.GetAll();
            Assert.IsTrue(response.Success);
        }
        
        [TestMethod]
        public void TesLoginSP()
        {
            string Usuario = "reyesoa";
            string Contrasena = "WELCOME001";

            CafePulse.ModelClass.Result response = CafePulse.BusinessClass.Usuario.GetAuthenticationLog(Usuario,Contrasena);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void InsertNewUser()
        {
            ModelClass.Usuario use = new ModelClass.Usuario();
            use.Genero = new ModelClass.Genero();
            use.Rol = new ModelClass.Rol();

            use.Nombre = "Juan";
            use.Apellido = "Zamorano";
            use.FechaNacimiento = "01/01/2001";
            use.Genero.IdGenero = 2;
            use.Rol.IdRol = 3;
            use.Telefono = "5534681234";
            use.Email = "juanCz@BininixD.com";
            use.User = "caz002";
            use.Pass = "Welcome2001";

            CafePulse.ModelClass.Result response = CafePulse.BusinessClass.Usuario.InsertNewUser(use);
            Assert.IsTrue(response.Success);
        }
    }
}
