using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppAEM
{
    /// <summary>
    /// Interaction logic for RSAControl.xaml
    /// </summary>
    public partial class RSAControl : UserControl
    {
        public RSAControl()
        {
            InitializeComponent();
        }

        public byte[] EncryptM(string publicKeyXML, string dataToDycript)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKeyXML);

            return rsa.Encrypt(ASCIIEncoding.ASCII.GetBytes(dataToDycript), true);
        }

        public string DecryptM(string publicPrivateKeyXML, byte[] encryptedData)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicPrivateKeyXML);

            return ASCIIEncoding.ASCII.GetString(rsa.Decrypt(encryptedData, true));
        }


        public byte[] encrypted;

        public void EncryptCode()
        {
            string text = new TextRange(decryptedRichTextBox.Document.ContentStart, decryptedRichTextBox.Document.ContentEnd).Text;
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(publicKeyTextBox.Text);
            byte[] decrypted = System.Text.Encoding.Unicode.GetBytes(text);
            encrypted = RSA.Encrypt(decrypted, false);

            encryptedRichTextBox.Document.Blocks.Clear();
            encryptedRichTextBox.Document.Blocks.Add(new Paragraph(new Run(System.Convert.ToBase64String(encrypted))));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RSAParameters rsaKeyInfo = rsa.ExportParameters(false);
            string publicPrivateKeyXML = rsa.ToXmlString(true);
            privateKeyTextBox.Text = publicPrivateKeyXML;
            string publicOnlyKeyXML = rsa.ToXmlString(false);
            publicKeyTextBox.Text = publicOnlyKeyXML;

            string text = new TextRange(decryptedRichTextBox.Document.ContentStart, decryptedRichTextBox.Document.ContentEnd).Text;

            if (!string.IsNullOrEmpty(text))
            {
                EncryptCode();
                decryptedRichTextBox.Document.Blocks.Clear();


            }
            else
            {
                EncryptCode();
                MessageBox.Show("Error during encryption");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string text = new TextRange(encryptedRichTextBox.Document.ContentStart, encryptedRichTextBox.Document.ContentEnd).Text;

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Error during decryption");
            }
            else
            {
                CspParameters cspParam = new CspParameters();
                cspParam.Flags = CspProviderFlags.UseMachineKeyStore;
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(cspParam);
                RSA.FromXmlString(privateKeyTextBox.Text);
                byte[] decrypted = RSA.Decrypt(encrypted, false);
                decryptedRichTextBox.Document.Blocks.Clear();
                decryptedRichTextBox.Document.Blocks.Add(new Paragraph(new Run(System.Text.Encoding.Unicode.GetString(decrypted))));

            }
        }
    }
}
