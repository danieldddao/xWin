using System;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace xWin.Forms
{
    public partial class EmailError : Form
    {
        private string username = "swep.team4.sp2017@gmail.com";
        private string password = "Xwin2017";
        private String[] devEmails = { "swep.team4.sp2017@gmail.com" }; // developers' email

        public EmailError()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextBox.Text == "")
                {
                    MessageBox.Show("Please enter your name!");
                }
                else if (emailTextBox.Text == "")
                {
                    MessageBox.Show("Please enter your email!");
                }
                else if (emailMsgTextBox.Text == "")
                {
                    MessageBox.Show("Please enter your message!");
                }
                else
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress(emailTextBox.Text);
                    foreach (string devEmail in devEmails)
                    { mail.To.Add(devEmail); }
                    mail.Subject = "Error Report from " + nameTextBox.Text;
                    mail.Body = emailMsgTextBox.Text;
                    // Attach log file
                    var rollingFileAppender = ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.Appenders.OfType<log4net.Appender.RollingFileAppender>().FirstOrDefault();
                    string logFile = rollingFileAppender != null ? rollingFileAppender.File : string.Empty;
                    mail.Attachments.Add(new Attachment(logFile));

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);

                    MessageBox.Show("Email sent to the developers!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
