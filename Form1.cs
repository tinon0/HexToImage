using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HextoJpeg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            string filepath = "C:\\image.jpeg";
            File.WriteAllBytes(filepath,ConvertHexToByteArray(txtHex.Text));
            pbImagen.ImageLocation = filepath;

        }


        public byte[] ConvertHexToByteArray(string hexCode)
        {
            // Remove whitespace and invalid characters from hexadecimal code
            hexCode = hexCode.Replace(" ", "").Replace("\r", "").Replace("\n", "");

            // Make sure the length of the string is an even number (each pair of characters represents one byte)
            if (hexCode.Length % 2 != 0)
            {
                throw new ArgumentException("The hexadecimal code must be of even length!");
            }

            // Create a byte array to store the binary data
            byte[] bytes = new byte[hexCode.Length / 2];

            // Loop through the hexadecimal string and convert it to bytes
            for (int i = 0; i < hexCode.Length; i += 2)
            {
                string hexFormatByte = hexCode.Substring(i, 2);
                bytes[i / 2] = Convert.ToByte(hexFormatByte, 16);
            }

            return bytes;
        }

    }
}
