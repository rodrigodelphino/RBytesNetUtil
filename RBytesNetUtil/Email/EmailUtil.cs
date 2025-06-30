using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;

namespace RBytesNetUtil
{
    
    public static class RBytesEmailUtil
    {
       
        /// <summary>
        /// Classe que envia email do tipo noreply, caso tenha erro devolve a exception, caso não tenha devolve ""
        /// </summary>
        /// <param name="emailDe"></param>
        /// <param name="emailPara"></param>
        /// <param name="emailDeNome"></param>
        /// <param name="emailParaNome"></param>
        /// <param name="emailResponder"></param>
        /// <param name="emailResponderNome"></param>
        /// <param name="mensagem"></param>
        /// <param name="titulo"></param>
        /// <param name="dominio"></param>
        /// <param name="HOST"></param>
        /// <param name="PASS"></param>
        /// <param name="PORTA"></param>
        /// <param name="TIMEOUT"></param>
        /// <returns></returns>
        public static string EnviarEmailNoReply(string emailDe,
                                    string emailPara,
                                    string emailDeNome,
                                    string emailParaNome,
                                    string emailResponder,
                                    string emailResponderNome,
                                    string mensagem,
                                    string titulo,
                                    string dominio,
                                    string HOST,
                                    string PASS,
                                    int PORTA,
                                    int TIMEOUT = 120)
        {

            string retorno = "";
            string usuario = "noreply@" + dominio;
            string senha = PASS;
            bool SSL = true;

            try
            {
                using (MailMessage emailMessage = new())
                {
                    emailMessage.From = new MailAddress(emailDe, emailDeNome);
                    emailMessage.To.Add(new MailAddress(emailPara, emailParaNome));
                    emailMessage.ReplyToList.Add(new MailAddress(emailResponder, emailResponderNome));
                    emailMessage.Subject = titulo;
                    emailMessage.Body = mensagem;
                    emailMessage.Priority = MailPriority.Normal;
                    emailMessage.IsBodyHtml = true;

                    SmtpClient client = new();
                    client.Host = HOST;
                    client.Port = PORTA;
                    client.EnableSsl = SSL;
                    client.Timeout = TIMEOUT;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(usuario, senha);
                    client.Send(emailMessage);
                }
            }
            catch (Exception ex)
            {
                retorno = ex.Message.ToString();
            }

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailMessage">Objeto mailmessage</param>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <param name="HOST"></param>
        /// <param name="PORTA"></param>
        /// <param name="TIMEOUT"></param>
        /// <returns></returns>
        public static string EnviarEmailCompleto(System.Net.Mail.MailMessage emailMessage,
                                            string usuario, string senha,
                                            string HOST,
                                            int PORTA, 
                                            int TIMEOUT = 120, 
                                            bool SSL = true)
        {
            string retorno = "";
            try
            {
                    SmtpClient client = new();
                    client.Host = HOST;
                    client.Port = PORTA;
                    client.EnableSsl = (PORTA == 25) ? false : SSL;
                    client.Timeout = TIMEOUT;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(usuario, senha);
                    client.Send(emailMessage);
            }
            catch (Exception ex)
            {
                retorno = ex.Message.ToString();
            }

            return retorno;
        }

        public static bool IsValidEmail(string email, string nomeValidacao, ref List<string> validacao)
        {
            try
            {
                MailAddress m = new(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                //Erro generico não esperado.
                return false;
            }
        }        
    }
}

