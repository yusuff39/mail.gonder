using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

using System.Windows.Forms;

namespace email_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Gonder(txt_Subject.Text, txt_Body.Text, txt_TO.Text.ToLower().Split(';'), txt_CS.Text.ToLower().Split(';'), txt_BCC.Text.ToLower().Split(';'));
        }
        public bool Gonder(string konu, string icerik, string[] ToGonderilen, string[] CcGönderilen, string[] BccGonderilen)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("sburaksg@outlook.com");
            

            for (int i = 0; i < ToGonderilen.Length; i++)
            {
                ePosta.To.Add(ToGonderilen[i]);
            }
            
            for (int i = 0; i < CcGönderilen.Length; i++)
            {
                ePosta.CC.Add(CcGönderilen[i]);
            }
            for (int i = 0; i < BccGonderilen.Length; i++)
            {
                ePosta.Bcc.Add(BccGonderilen[i]);
            }
            ePosta.Subject = konu;
            
            ePosta.Body = icerik;
            
            SmtpClient smtp = new SmtpClient();
           
            smtp.Credentials = new System.Net.NetworkCredential("odev.gonder.39@hotmail.com", "123*ysfF");
            smtp.Port = 587;
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;


        }
    }
}
