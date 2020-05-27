using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace at03.Models
{
    public class Usuario
    {
        [ScaffoldColumn(false)]
        [Key]
        public int id {get;set;}
        
        [Display(Name = "Nome de Usuário")]
        [Required]
        public string usuario { get; set; }

        [Display(Name = "Senha")]
        [Required]
        public string senha { get; set; }

        public Usuario(String novo_usuario, String nova_senha)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] senha_utf8 = new UTF8Encoding().GetBytes(nova_senha);

                byte[] hash = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(senha_utf8);

                string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                usuario = novo_usuario;
                senha = encoded;
            }
        }

        public Usuario()
        {

        }
    }
}
