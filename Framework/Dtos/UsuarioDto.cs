using System;

namespace Framework.Dtos
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        public long NroIdentificacion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Password { get; set; }

        public bool Activo { get; set; }
    }
}
